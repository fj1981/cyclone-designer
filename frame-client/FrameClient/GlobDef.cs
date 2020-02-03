using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameClient
{
  class GlobDef
  {
    public static Size sz_image = new Size();
    public static double image_markrate = 0.25;
    public static string GetImgSizeStr()
    {
      return JsonConvert.SerializeObject(sz_image);
    }
  }
}
