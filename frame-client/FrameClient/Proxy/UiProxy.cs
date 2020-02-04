using Chromium;
using Chromium.Remote;
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
      phoneProxy?.RunProject(nameProj);
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

    public void OnRemoveProcess(object func, CfrV8HandlerExecuteEventArgs args)
    {
      var obj = args.Arguments.FirstOrDefault(p => p.IsInt);
      if (obj != null)
      {
        PhoneProxy().RemoveProcess(obj.IntValue);
      }
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

    public void GetFlowPicSize(object func, CfrV8HandlerExecuteEventArgs args)
    {
      var jsObjectAccessor = new CfrV8Accessor();
      var jsObject = CfrV8Value.CreateObject(jsObjectAccessor);
      jsObject.SetValue("width", CfrV8Value.CreateInt(GlobDef.sz_image.width), CfxV8PropertyAttribute.ReadOnly);
      jsObject.SetValue("height", CfrV8Value.CreateInt(GlobDef.sz_image.height), CfxV8PropertyAttribute.ReadOnly);
      args.SetReturnValue(jsObject);
    }

    public void GetLiveMaxWidth(object func, CfrV8HandlerExecuteEventArgs args)
    {
      args.SetReturnValue(CfrV8Value.CreateInt(GlobDef.sz_image.width));
    }
  }
 
}
