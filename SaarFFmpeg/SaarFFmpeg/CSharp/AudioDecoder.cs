﻿using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public class AudioDecoder : Decoder {
		private AudioResampler resampler;

		public AudioFormat InFormat { get; }

		/// <summary>
		/// 获取或设置输出格式。如果设置为null或和<see cref="InFormat"/>的值一致 ，则不使用重采样。
		/// </summary>
		public AudioFormat OutFormat {
			get { return resampler?.Destination ?? InFormat; }
			set {
				if (value == null || InFormat.Equals(value)) {
					resampler?.Dispose();
					resampler = null;
				} else {
					if (resampler == null || !OutFormat.Equals(value)) {
						resampler?.Dispose();
						resampler = new AudioResampler(InFormat, value);
					}
				}
			}
		}

		public AudioResampler Resampler => resampler;

		internal AudioDecoder(AVStream* stream) : base(stream) {
			var sampleRate = codecContext->SampleRate;
			var channelLayout = codecContext->ChannelLayout;
			var sampleFormat = codecContext->SampleFmt;
			if (channelLayout == 0) channelLayout = FF.av_get_default_channel_layout(codecContext->Channels);
			InFormat = new AudioFormat(sampleRate, channelLayout, sampleFormat);
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				resampler?.Dispose();
				resampler = null;
			}
			base.Dispose(disposing);
		}

		public override bool Decode(Packet packet, Frame outFrame) {
			if (!(outFrame is AudioFrame audioFrame)) {
				throw new ArgumentException($"{nameof(outFrame)}必须是{nameof(AudioFrame)}类型且不为null。");
			}

			if (packet != null) {
				int gotPicture = 0;
				FF.avcodec_decode_audio4(codecContext, outFrame.frame, &gotPicture, packet.packet).CheckFFmpegCode("音频解码发生错误");
				if (gotPicture == 0) return false;

				if (stream != null) outFrame.presentTimestamp = new Timestamp(outFrame.frame->Pts, stream->TimeBase);
				audioFrame.format = InFormat;
				if (resampler != null) {
					resampler.InternalResample(audioFrame); // resample and update
				} else {
					outFrame.UpdateFromNative();
				}
			} else if (resampler != null) {
				resampler.ResampleFinal(audioFrame);
				if (audioFrame.LineDataBytes == 0) return false;
			} else {
				return false;
			}

			return true;
		}

		public override string ToString()
			=> $"{FullName}, 输入:{InFormat}, 输出:{OutFormat}";
	}
}
