﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.FFTW;

namespace Saar.FFmpeg.CSharp.DSP {
	unsafe public abstract class FloatFFTBase : FFTBase {
		public override Type SampleType => typeof(float);

		protected FloatFFTBase(int fftSize) : base(fftSize) { }

		protected override void DestroyPlan(IntPtr plan)
			=> fftwf.destroy_plan(plan);

		public override void Free(IntPtr buffer)
			=> fftwf.free(buffer);

		protected override void SaveConfig()
			=> fftwf.export_wisdom_to_filename(FFTWF_ConfigName);
	}
}
