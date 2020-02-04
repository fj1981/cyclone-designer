using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TestFFmpeg.thriftImpl;

namespace FrameClient.Adb
{
  /// <summary>
  /// Defines the properties and methods necessary for implementing a
  /// custom media input stream.
  /// </summary>
  public unsafe interface IFace
  {
    /// <summary>
    /// Gets the stream URI. This is just a pseudo URI to identify the stream.
    /// </summary>
    void translate(byte[] bytes);

    bool display(Int32 width, Int32 height, Int32 barHeight,Int32 scale);

    bool ping(Int32 interval);

  }

  public delegate void PrjDataCallBack(string prj);

  class AdbWrapper : IFace , NodeService.Iface
  {
    public PrjDataCallBack prjDataCallBack = null;
    // PC端向手机端发送数据对应端口
    public const Int32 CLIENT_PORT = 11111;
    // PC端接收手机端数据对应端口
    public const Int32 LISTEN_PORT = 22222;
    // 启动移动端App命令
    //public readonly static string START_APP = "adb shell am start -n com.example.qiandu.h264demo/.MainActivity";
    public const string START_APP = "adb shell am start -n com.cyclone.rpadroid.executoy/com.cyclone.rpadroid.runtime.MainActivity";
    // adb forward命令
    public readonly static string START_ADB_FORWARD = "adb forward tcp:" + CLIENT_PORT + " tcp:" + LISTEN_PORT;
    // adb reverse命令
    public readonly static string START_ADB_REVERSE = "adb reverse tcp:" + CLIENT_PORT + " tcp:" + LISTEN_PORT;
    // 检查adb端口命令
    public const string FIND_PORT_5037 = "netstat -ano | findstr \"5037\"";
    // kill某个进程
    public const string KILL_PID = "taskkill -PID pid -F";
    // 启动adb服务
    public const string START_ADB = "adb start-server";
    // 启动accessibilityService
    public const string START_ACCESSIBILITY_SERVICE = "adb shell settings put secure enabled_accessibility_services com.cyclone.rpadroid.executoy/com.cyclone.rpadroid.WxAccessibilityService";
    // 设置accessibilityService可用
    public const string SET_ACCESSIBILITY_ENABLE = "settings put secure accessibility_enabled 1";
    // 本地定时任务间隔时间
    public const Int32 TIMER_INTERVAL = 1000;
    // 连续接收不到移动端心跳最大次数（超过此次数的话则认为移动端app异常关闭或者端口打开失败，则重设端口和启动app）
    public const Int32 PING_FAIL_MAX_COUNT = 5;

    //public ByteInputStream stream = null;
    public static FileStream fileStream = null;
    private readonly object ReadSyncRoot = new object();

    public void Init()
    {
      ThreadStart threadStart = new ThreadStart(InitServer);
      Thread thread = new Thread(threadStart);
      thread.Start();
    }

    private void InitServer()
    {
      CheckAdbPort();
      StartServer();
    }

    private void CheckAdbPort()
    {
      List<String> list = AdbUtils.exeCommandForList(FIND_PORT_5037);
      List<String> pids = new List<String>();
      foreach (String line in list)
      {
        String[] array = Regex.Split(line.Trim(), "\\s+", RegexOptions.IgnoreCase);
        if (array.Length == 5 && array[1] == "127.0.0.1:5037")
        {
          String pid = array[4];
          if (!pids.Contains(pid))
          {
            pids.Add(pid);
          }
        }
      }
      foreach (String pid in pids)
      {
        if (pid != "0")
        {
          AdbUtils.exeCommandForList(KILL_PID.Replace("pid", pid));
        }
      }
      AdbUtils.exeCommand(START_ADB);
    }

    public void StartServer()
    {
      StartAdbPort();
      StartApp();
      ScreenImpl.setIFace(this);
      NodeImpl.setIFace(this);
            ScreenServer.Run(LISTEN_PORT,this);
      
    }

    private void StartAdbPort()
    {
      AdbUtils.exeCommand(START_ADB_FORWARD);
      AdbUtils.exeCommand(START_ADB_REVERSE);
    }

    private void StartApp()
    {
      AdbUtils.exeCommand(START_APP);
      AdbUtils.exeCommand(START_ACCESSIBILITY_SERVICE);
    }

    void IFace.translate(byte[] bytes)
    {
      BuffDecode.GetInstance().DecodeData(bytes);
    }

    bool IFace.display(int width, int height, int barHeight,int scale)
    {
      GlobDef.sz_live.width = width;
      GlobDef.sz_live.height = height;
      GlobDef.point_convert_scale = scale;
      return true;
      //throw new NotImplementedException();
    }

    bool IFace.ping(int interval)
    {
      return true;
      //throw new NotImplementedException();
    }

    public byte[] ScreenShot()
    {
      throw new NotImplementedException();
    }

    public bool RectCallback(string rects)
    {
      throw new NotImplementedException();
    }

    public bool start(string processName)
    {
      throw new NotImplementedException();
    }

    public bool save(string processName)
    {
      throw new NotImplementedException();
    }

    public string addVar(string value)
    {
      throw new NotImplementedException();
    }

    public string updateVar(string json)
    {
      throw new NotImplementedException();
    }

    public bool removeVar(string name)
    {
      throw new NotImplementedException();
    }

    public bool dump()
    {
      throw new NotImplementedException();
    }

    public string AddProcess(string config)
    {
      throw new NotImplementedException();
    }

    public string RemoveProcess(string lineNumber)
    {
      throw new NotImplementedException();
    }

    public string UpdateProcess(string config)
    {
      throw new NotImplementedException();
    }

    public bool ExcuteProcess(string processName)
    {
      throw new NotImplementedException();
    }

    public bool saveVar(string key, string value)
    {
      throw new NotImplementedException();
    }

    public string queryVar(string key)
    {
      throw new NotImplementedException();
    }

    public bool ProcessCallback(string processStatus)
    {
      throw new NotImplementedException();
    }

    public bool DataCallBack(string data)
    {
      prjDataCallBack?.Invoke(data);
      return true;
    }
  }
}

