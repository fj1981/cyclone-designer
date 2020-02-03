using Chromium.Remote.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameClient
{

  class UiProxy
  {
    private CellPhoneProxy phoneProxy;
    private string nameProj;



    private CellPhoneProxy PhoneProxy()
    {
      if (phoneProxy == null)
      {
        if(nameProj == null)
        {
          nameProj ="cy_" + Util.GetTimeStamp();
        }
        phoneProxy = CellPhoneProxy.Instance;
        phoneProxy.NewProject(nameProj);
      }
      return phoneProxy;
    }
    public void OnNewFile(object func, CfrV8HandlerExecuteEventArgs args)
    {

    }

    public void OnOpenFile(object func, CfrV8HandlerExecuteEventArgs args)
    {

    }

    public void OnSaveFile(object func, CfrV8HandlerExecuteEventArgs args)
    {

    }

    public void OnRun(object func, CfrV8HandlerExecuteEventArgs args)
    {

    }

    public void OnPause(object func, CfrV8HandlerExecuteEventArgs args)
    {

    }

    public void OnStop(object func, CfrV8HandlerExecuteEventArgs args)
    {

    }

    public void GetVideoImage(object func, CfrV8HandlerExecuteEventArgs args)
    {

    }

    public void OnMouseMove(object func, CfrV8HandlerExecuteEventArgs args)
    {
      var obj = args.Arguments.FirstOrDefault(p => p.IsString);
      if (obj != null)
      {
        PhoneProxy().MouseMove(obj.StringValue);
      }
    }

    public void OnBeginAddFlowItem(object func, CfrV8HandlerExecuteEventArgs args)
    {
      PhoneProxy().BeginAddFlowItem();
    }

    public void OnEndAddFlowItem(object func, CfrV8HandlerExecuteEventArgs args)
    {
      var obj = args.Arguments.FirstOrDefault(p => p.IsString);
      if (obj != null)
      {
        PhoneProxy().EndAddFlowItem(obj.StringValue);
      }
    }
  }
 
}
