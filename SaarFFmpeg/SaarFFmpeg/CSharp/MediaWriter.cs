﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.CSharp;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public class MediaWriter : MediaStream {
		//private class FixedAudioFrame {
		//	public AudioFrame Frame { get; }
		//	public int Offset { get; private set; } = 0;

		//	public FixedAudioFrame(AudioFormat format, int fixedCount) {
		//		Frame = new AudioFrame(format);
		//		Frame.Resize(fixedCount);
		//	}

		//	public void AppendForEach(AudioFrame input, Action<AudioFrame> callback) {
		//		int fixedCount = Frame.sampleCount;
		//		int length = Offset + input.sampleCount;
		//		int i;
		//		if (fixedCount <= length) {
		//			for (i = 0; i + fixedCount <= length; i += fixedCount) {
		//				if (i == 0) {
		//					input.CopyToNoResize(0, fixedCount - Offset, Frame, Offset);
		//				} else {
		//					input.CopyToNoResize(i - Offset, fixedCount, Frame, 0);
		//				}
		//				callback(Frame);
		//			}
		//			input.CopyToNoResize(i - Offset, length - i, Frame, 0);
		//			Offset = length - i;
		//		} else {
		//			input.CopyToNoResize(0, input.sampleCount, Frame, Offset);
		//			Offset += input.sampleCount;
		//		}
		//	}
		//}

		public delegate Frame RequestFrameHandle(Encoder encoder);

		//private bool remuxing = false;
		private Packet packet = new Packet();
		private AVOutputFormat* outputFormat;
		private List<Encoder> encoders = new List<Encoder>();
		private List<Encoder> readyEncoders;
		//private AVFormatContext* inputFmtCtx;
		private FixedAudioFrameQueue[] fixedQueues;
		public IReadOnlyList<Encoder> Encoders => encoders;

		//public AVCodecID AudioCodecID => remuxing ? inputFmtCtx->AudioCodecId : outputFormat->AudioCodec;
		//public AVCodecID VideoCodecID => remuxing ? inputFmtCtx->VideoCodecId : outputFormat->VideoCodec;

		/// <summary>
		/// 创建一个编码模式的媒体写入器
		/// </summary>
		/// <param name="file">输出的文件路径</param>
		/// <param name="ignoreExtension">如果为true，则不会根据文件扩展名自动推断编码器</param>
		public MediaWriter(string file, bool ignoreExtension = false)
			: base(File.Open(file, FileMode.Create, FileAccess.Write), true, FF.av_guess_format(null, ignoreExtension ? null : file, null)) {
			outputFormat = formatContext->Oformat;
		}

		/// <summary>
		/// 创建一个编码模式的媒体写入器
		/// </summary>
		/// <param name="outputStream">输出的流</param>
		/// <param name="mediaName">根据"mp3","flac","h264"等多媒体的短名称自动推断编码器</param>
		public MediaWriter(Stream outputStream, string mediaName = null)
			: base(outputStream, true, FF.av_guess_format(mediaName, null, null)) {
			outputFormat = formatContext->Oformat;
		}

		///// <summary>
		///// 创建一个封装模式的媒体写入器
		///// </summary>
		///// <param name="file"></param>
		///// <param name="mediaReader"></param>
		//public MediaWriter(string file, MediaReader mediaReader)
		//	: base(File.Open(file, FileMode.Create, FileAccess.Write), true, FF.av_guess_format(null, file, null)) {
		//	outputFormat = formatContext->Oformat;
		//	remuxing = true;

		//	SetEncoders(mediaReader);
		//}

		///// <summary>
		///// 创建一个封装模式的媒体写入器
		///// </summary>
		///// <param name="outputStream"></param>
		///// <param name="mediaName"></param>
		///// <param name="mediaReader"></param>
		//public MediaWriter(Stream outputStream, string mediaName, MediaReader mediaReader)
		//	: base(outputStream, true, FF.av_guess_format(mediaName, null, null)) {
		//	outputFormat = formatContext->Oformat;
		//	remuxing = true;

		//	SetEncoders(mediaReader);
		//}

		//private void SetEncoders(MediaReader mediaReader) {
		//	try {
		//		foreach (var decoder in mediaReader.Decoders) {
		//			if (decoder != null) {
		//				var stream = FF.avformat_new_stream(formatContext, decoder.codec);
		//				if (stream == null) throw new InvalidOperationException("无法创建流");
		//				int result = FF.avcodec_copy_context(stream->Codec, decoder.codecContext);
		//				if (result < 0) throw new FFmpegException(result);
		//				stream->Codec->CodecTag = 0;
		//				if (outputFormat->Flags.HasFlag(AVFmt.GlobalHeader)) {
		//					stream->Codec->Flags |= AVCodecFlag.GlobalHeader;
		//				}
		//				stream->TimeBase = mediaReader.formatContext->Streams[decoder.StreamIndex]->TimeBase;
		//				//stream->TimeBase = decoder.codecContext->TimeBase;
		//				result = FF.avcodec_parameters_from_context(stream->Codecpar, stream->Codec);
		//				if (result < 0) throw new FFmpegException(result);
		//			}
		//		}
		//		inputFmtCtx = mediaReader.formatContext;
		//	} catch {
		//		Dispose();
		//		throw;
		//	}
		//}

		public MediaWriter AddAudio(AudioFormat format, BitRate bitRate) {
			if (readyEncoders != null) throw new InvalidOperationException($"该{nameof(MediaWriter)}对象已经初始化");
			if (outputFormat == null) throw new InvalidOperationException("无法确定媒体的输出格式");

			if (outputFormat->AudioCodec == AVCodecID.None)
				throw new InvalidOperationException($"该{nameof(MediaWriter)}对象并不支持音频");

			var stream = FF.avformat_new_stream(formatContext, Codec.GetEncoder(outputFormat->AudioCodec));
			if (stream == null) throw new InvalidOperationException("无法创建流");
			var codecContext = stream->Codec;
			var audioEncoder = new AudioEncoder(stream, format, bitRate);
			stream->TimeBase = codecContext->TimeBase;
			int result = FF.avcodec_parameters_from_context(stream->Codecpar, codecContext);
			if (result < 0) throw new FFmpegException(result);
			encoders.Add(audioEncoder);
			return this;
		}

		public MediaWriter AddAudio(AudioFormat format) {
			return AddAudio(format, BitRate.Zero);
		}

		public MediaWriter AddVideo(VideoFormat format, VideoEncoderParameters encoderParams = null) {
			if (readyEncoders != null) throw new InvalidOperationException($"该{nameof(MediaWriter)}对象已经初始化");
			if (outputFormat == null) throw new InvalidOperationException("无法确定媒体的输出格式");

			if (outputFormat->VideoCodec == AVCodecID.None)
				throw new InvalidOperationException($"该{nameof(MediaWriter)}对象并不支持视频");

			var stream = FF.avformat_new_stream(formatContext, Codec.GetEncoder(outputFormat->VideoCodec));
			if (stream == null) throw new InvalidOperationException("无法创建流");
			var codecContext = stream->Codec;
			var videoEncoder = new VideoEncoder(stream, format, encoderParams);
			stream->TimeBase = codecContext->TimeBase;
			stream->AvgFrameRate = codecContext->Framerate;
			int result = FF.avcodec_parameters_from_context(stream->Codecpar, codecContext);
			if (result < 0) throw new FFmpegException(result);
			encoders.Add(videoEncoder);
			return this;
		}

		public MediaWriter AddEncoder(Encoder encoder) {
			if (readyEncoders != null) throw new InvalidOperationException($"该{nameof(MediaWriter)}对象已经初始化");

			if (outputFormat == null) {
				var desc = FF.avcodec_descriptor_get(encoder.ID);
				if (desc == null) throw new InvalidOperationException("无法获得编码器的短名称描述");
				outputFormat = FF.av_guess_format(desc->Name, null, null);
				if (outputFormat == null) throw new InvalidOperationException("无法确定媒体的输出格式");
				formatContext->Oformat = outputFormat;
			}

			var stream = FF.avformat_new_stream(formatContext, encoder.codec);
			if (stream == null) throw new InvalidOperationException("无法创建流");
			// stream->TimeBase = encoder.codecContext->TimeBase;
			int result = FF.avcodec_parameters_from_context(stream->Codecpar, encoder.codecContext);
			if (result < 0) throw new FFmpegException(result);
			encoder.stream = stream;
			encoders.Add(encoder);
			return this;
		}

		public MediaWriter Initialize() {
			if (readyEncoders != null) throw new InvalidOperationException($"该{nameof(MediaWriter)}对象已经初始化");
			if (outputFormat == null) throw new InvalidOperationException("无法确定媒体的输出格式");

			int result = FF.avformat_write_header(formatContext, null);
			if (result < 0) throw new FFmpegException(result, "写入头部错误");

			readyEncoders = new List<Encoder>(encoders);
			fixedQueues = new FixedAudioFrameQueue[encoders.Count];
			for (int i = 0; i < encoders.Count; i++) {
				if (encoders[i] is AudioEncoder audioEncoder)
					fixedQueues[i] = new FixedAudioFrameQueue(audioEncoder.RequestSamples);
			}
			return this;
		}

		///// <summary>
		///// 封装模式专用
		///// </summary>
		///// <param name="packet"></param>
		//public void Write(Packet packet) {
		//	if (packet.StreamIndex >= 0 && packet.StreamIndex < formatContext->NbStreams) {
		//		if (inputFmtCtx != null) {
		//			var inTimebase = inputFmtCtx->Streams[packet.StreamIndex]->TimeBase;
		//			var outTimebase = formatContext->Streams[packet.StreamIndex]->TimeBase;
		//			if (packet.packet->Pts != long.MinValue) {
		//				packet.packet->Pts = FF.av_rescale_q(packet.packet->Pts, inTimebase, outTimebase);
		//			}
		//			if (packet.packet->Dts != long.MinValue) {
		//				packet.packet->Dts = FF.av_rescale_q(packet.packet->Dts, inTimebase, outTimebase);
		//			}
		//			packet.packet->Duration = FF.av_rescale_q(packet.packet->Duration, inTimebase, outTimebase);
		//		}
		//		packet.packet->Pos = -1;
		//		InternalWrite(packet);
		//	}
		//}

		private void Encode(Encoder encoder, Frame frame) {
			if (encoder.Encode(frame, packet)) {
				InternalWrite(packet);
			}
		}

		/// <summary>
		/// 编码并写入流。不要调用<see cref="Encoder.Encode(Frame, Packet)"/>，<see cref="MediaWriter"/>会自动调用。
		/// </summary>
		/// <param name="handler">当<paramref name="handler"/>返回null表示编码结束。</param>
		/// <returns>当全部编码结束时返回false</returns>
		public bool Write(RequestFrameHandle handler) {
			if (readyEncoders == null) throw new InvalidOperationException($"该{nameof(MediaWriter)}对象未初始化或已释放");

			var encoder = readyEncoders.Minimal(e => e.InputFrames * e.codecContext->TimeBase.Value);
			if (encoder == null) return false;

			Frame frame;
			if (encoder is AudioEncoder) {
				var queue = fixedQueues[encoder.StreamIndex];
				while (true) {
					frame = queue.Dequeue();
					if (frame != null) break;
					frame = handler(encoder);
					if (frame == null) {
						frame = queue.Dequeue(false);
						readyEncoders.Remove(encoder);
						break;
					} else {
						queue.Enqueue(frame as AudioFrame ?? throw new InvalidOperationException("返回必须是音频帧"));
					}
				}
			} else {
				frame = handler(encoder);
			}

			if (frame == null) {
				readyEncoders.Remove(encoder);
			} else {
				Encode(encoder, frame);
			}

			return true;
		}

		public void Write(Frame frame) {
			if (readyEncoders == null || encoders.Count == 0) throw new InvalidOperationException($"该{nameof(MediaWriter)}对象未初始化或已释放");
			if (encoders.Count != 1) throw new InvalidOperationException($"该{nameof(MediaWriter)}对象包含一个以上的编码流，因此不能调用此方法");

			var encoder = encoders[0];
			Encode(encoder, frame);
		}

		public void Flush() {
			if (readyEncoders == null) return;

			readyEncoders = new List<Encoder>(encoders);
			while (true) {
				var encoder = readyEncoders.Minimal(e => e.InputFrames * e.codecContext->TimeBase.Value);
				if (encoder == null) break;

				var queue = fixedQueues[encoder.StreamIndex];
				if (queue != null) {
					var frame = queue.Dequeue(false);
					if (frame != null) {
						Encode(encoder, frame);
						continue;
					}
				}
				while (encoder.Encode(null, packet)) InternalWrite(packet);
				readyEncoders.Remove(encoder);
				formatContext->Streams[encoder.StreamIndex]->Duration = encoder.InputTimestamp.Ticks / 10;
			}

			int result = FF.av_write_trailer(formatContext);
			if (result < 0) throw new FFmpegException(result);
			readyEncoders = null;
		}

		protected override void Dispose(bool disposing) {
			Flush();

			if (disposing) {
				packet.Dispose();
				foreach (var enc in encoders)
					enc.Dispose();

				for (int i = 0; i < fixedQueues.Length; i++) {
					fixedQueues[i]?.Dispose();
					fixedQueues[i] = null;
				}
			}

			base.Dispose(disposing);
		}
	}
}
