using FrameClient.Adb;
using NetDimension.NanUI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FrameClient
{
  public partial class MainUI : Formium
  {
    private UiProxy uiProxy;
    private AdbWrapper adbWrapper;
    public MainUI()
      : base("http://zip.app.local/index.html")
    {
      InitializeComponent();
      int SH = Screen.PrimaryScreen.Bounds.Height;
      int SW = Screen.PrimaryScreen.Bounds.Width;
      using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
      {
        SW = (int)(SW * 96 / graphics.DpiX);
        SH = (int)(SH * 96 / graphics.DpiY);
      }
      if(SW < 1400)
      {
        GlobDef.globle_scale = 2.0;
      }
      this.WindowState = FormWindowState.Maximized;
      LoadHandler.OnLoadEnd += LoadHandler_OnLoadEnd;

      RegisterJSFunc();
      if (adbWrapper == null)
      {
        adbWrapper = new AdbWrapper();
        adbWrapper.Init();
        adbWrapper.prjDataCallBack += UpdateFlow;
        adbWrapper.notifyUpdateProcessStateHandler += UpdateProcessState;
      }
      ImgMgr.Get().dataChangedHandler += UpdateVideo;
      CellPhoneProxy.Instance.notifyUpdateHoverRect += UpdateHoverRect;
      CellPhoneProxy.Instance.notifyEnanleAddFlowItem += EnableAddFlowItem;
    }

    private void RegisterJSFunc()
    {
      if (uiProxy == null)
      {
        uiProxy = new UiProxy();
        GlobalObject.AddFunction("OnNewFile").Execute += uiProxy.OnNewFile;
        GlobalObject.AddFunction("OnOpenFile").Execute += uiProxy.OnOpenFile;
        GlobalObject.AddFunction("OnSaveFile").Execute += uiProxy.OnSaveFile;
        GlobalObject.AddFunction("OnRun").Execute += uiProxy.OnRun;
        GlobalObject.AddFunction("OnPause").Execute += uiProxy.OnPause;
        GlobalObject.AddFunction("OnStop").Execute += uiProxy.OnStop;
        GlobalObject.AddFunction("OnMouseHover").Execute += uiProxy.OnMouseMove;
        GlobalObject.AddFunction("BeginAddFlowItem").Execute += uiProxy.OnBeginAddFlowItem;
        GlobalObject.AddFunction("EndAddFlowItem").Execute += uiProxy.OnEndAddFlowItem;
        GlobalObject.AddFunction("GetFlowPicSize").Execute += uiProxy.GetFlowPicSize;
        GlobalObject.AddFunction("GetLiveMaxWidth").Execute += uiProxy.GetLiveMaxWidth;
        GlobalObject.AddFunction("OnRemoveProcess").Execute += uiProxy.OnRemoveProcess;
      }
    }

    void UpdateVideo(string resName,int width,int height)
    {
      ExecuteJavascript($"UpdateRes('{resName}',{width},{height})");
    }

    void UpdateHoverRect(string rcStr)
    {
      ExecuteJavascript($"UpdateHoverRect({rcStr},{GlobDef.globle_scale})");
    }

    void EnableAddFlowItem()
    {
      ExecuteJavascript($"EnableCreateFlowItem()");
    }

    void UpdateFlow(string rcStr)
    {
      var cmd = $"UpdateFlow(`{rcStr}`,{GlobDef.GetImgSizeStr()},{GlobDef.image_markrate})";
      ExecuteJavascript(cmd);
    }

    void UpdateProcessState(string rcStr)
    {
      var cmd = $"UpdateProcessState(`{rcStr}`)";
      ExecuteJavascript(cmd);
    }

    private void LoadHandler_OnLoadEnd(object sender, Chromium.Event.CfxOnLoadEndEventArgs e)
    {
      // Check if it is the main frame when page has loaded.
      if (e.Frame.IsMain)
      {
        Chromium.ShowDevTools();
      }
    }
  }
}
