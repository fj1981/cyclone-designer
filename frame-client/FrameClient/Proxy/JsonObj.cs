using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameClient
{
  public class Point
  {
    /// <summary>
    /// 
    /// </summary>
    public int x { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int y { get; set; }
  }

  public class Size
  {
    /// <summary>
    /// 
    /// </summary>
    public int width { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int height { get; set; }
  }


  public class NewFlowDataOrg
  {
    /// <summary>
    /// 
    /// </summary>
    public int type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Point pt { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string param { get; set; }

    public int preLineNumber { get; set; }
  }

  public class NewValData
  {
    /// <summary>
    /// 
    /// </summary>
    public int lineNumber { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string value { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }
  }

  public class NewFlowData
  {
    /// <summary>
    /// 
    /// </summary>
    public List<string> @params { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Point point { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int preLineNumber { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string serial { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string extraJson { get; set; }
  }


  public class Config
  {
    /// <summary>
    /// 
    /// </summary>
    public int lineNumber { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string value { get; set; }
  }

  public class Result
  {
    /// <summary>
    /// 
    /// </summary>
    public int code { get; set; }
  }

  public class NewValRet
  {
    /// <summary>
    /// 
    /// </summary>
    public Config config { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Result result { get; set; }
  }
}
