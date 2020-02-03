using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameClient
{
  class Util
  {
    public static string GetTimeStamp()
    {
      TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
      return Convert.ToInt64(ts.TotalMilliseconds).ToString();
    }
  }
}
