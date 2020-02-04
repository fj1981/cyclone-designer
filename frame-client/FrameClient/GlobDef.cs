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
    public static Size sz_live = new Size();
    public static double image_markrate = 0.25;
    public static double point_convert_scale = 2;
    public static double globle_scale = 1;
    public static string GetImgSizeStr()
    {
      return JsonConvert.SerializeObject(sz_image);
    }
    public static Point GetDevPoint(Point pt)
    {
      Point ret = new Point();
      ret.x = (int)(pt.x * point_convert_scale * globle_scale);
      ret.y = (int)(pt.y * point_convert_scale * globle_scale);
      return ret;
    }
  }
}
