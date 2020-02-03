﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Internal;

using FF = Saar.FFmpeg.Internal.FFmpeg;
using System.Runtime.InteropServices;

namespace Saar.FFmpeg.CSharp {
	unsafe public abstract class Codec : DisposableObject {
		internal AVStream* stream;
		internal AVCodecContext* codecContext;
		internal AVCodec* codec;

		public AVMediaType CodecType => codec->Type;
		public AVCodecID ID => codecContext->CodecId;
		public int StreamIndex => stream != null ? stream->Index : -1;
		public string Name { get; }
		public string FullName { get; }

		public Codec(AVCodecID codecID, bool encode = true) {
			if (encode) {
				codec = GetEncoder(codecID);
			} else {
				codec = GetDecoder(codecID);
			}
			Name = Marshal.PtrToStringAnsi((IntPtr) codec->Name);
			FullName = Marshal.PtrToStringAnsi((IntPtr) codec->LongName) ?? Name;
		}

		public Codec(AVStream* stream) {
			this.stream = stream;
			codecContext = stream->Codec;
			if (stream->Codec->Codec == null) {
				stream->Codec->Codec = GetDecoder(stream->Codec->CodecId);
			}
			codec = stream->Codec->Codec;
			Name = Marshal.PtrToStringAnsi((IntPtr) codec->Name);
			FullName = Marshal.PtrToStringAnsi((IntPtr) codec->LongName) ?? Name;
		}

		internal static AVCodec* GetDecoder(AVCodecID codecID) {
			AVCodec* codec = FF.avcodec_find_decoder(codecID);
			if (codec == null) throw new ArgumentException($"未能找到解码器:{codecID}", nameof(codecID));
			return codec;
		}

		internal static AVCodec* GetEncoder(AVCodecID codecID) {
			AVCodec* codec = FF.avcodec_find_encoder(codecID);
			if (codec == null) throw new ArgumentException($"未能找到编码器:{codecID}", nameof(codecID));
			return codec;
		}

		protected override void Dispose(bool disposing) {
			if (codecContext == null) return;
			FF.avcodec_close(codecContext);
			codecContext = null;
		}

		public override string ToString() => FullName;

		public static IReadOnlyList<CodecDescription> GetAllCodecs() {
			var list = new List<CodecDescription>();
			AVCodec* codec = FF.av_codec_next(null);
			while (codec != null) {
				list.Add(new CodecDescription(codec));
				codec = FF.av_codec_next(codec);
			}
			return list;
		}
	}
}
