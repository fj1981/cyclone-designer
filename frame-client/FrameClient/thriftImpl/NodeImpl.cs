using FrameClient.Adb;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestFFmpeg.thriftImpl
{
  public delegate void PrjDataCallBack(string prj);
  class NodeImpl : NodeService.Iface
  {
    public NodeImpl()
    {

    }
    public PrjDataCallBack prjDataCallBack = null;
    private static IFace face;

    public static void setIFace(IFace iFace)
    {
      face = iFace;
    }

    public string AddProcess(string config)
    {
      throw new NotImplementedException();
    }

    public string addVar(string value)
    {
      throw new NotImplementedException();
    }

    public bool DataCallBack(string data)
    {
      prjDataCallBack?.Invoke(data);
      return true;

    }

    public bool dump()
    {
      throw new NotImplementedException();
    }

    public bool ExcuteProcess(string processName)
    {
      throw new NotImplementedException();
    }

    public bool ProcessCallback(string processStatus)
    {
      throw new NotImplementedException();
    }

    public string queryVar(string key)
    {
      throw new NotImplementedException();
    }

    public bool RectCallback(string rects)
    {
      throw new NotImplementedException();
    }

    public string RemoveProcess(int lineNumber)
    {
      throw new NotImplementedException();
    }

    public string RemoveProcess(string lineNumber)
    {
      throw new NotImplementedException();
    }

    public bool removeVar(string name)
    {
      throw new NotImplementedException();
    }

    public bool save(string processName)
    {
      throw new NotImplementedException();
    }

    public bool saveVar(string key, string value)
    {
      throw new NotImplementedException();
    }

    public byte[] ScreenShot()
    {
      throw new NotImplementedException();
    }

    public bool start(string processName)
    {
      throw new NotImplementedException();
    }

    public string UpdateProcess(string config)
    {
      throw new NotImplementedException();
    }


    string NodeService.ISync.updateVar(string json)
    {
      throw new NotImplementedException();
    }
  }
}
