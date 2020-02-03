using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrameClient
{
  using Chromium;
  using Chromium.WebBrowser;
  using NetDimension.NanUI;

  internal static class Program
  {
    /// <summary>
    /// 应用程序的主入口点。
    /// </summary>
    /// 
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool SetProcessDPIAware();

    [STAThread]
    static void Main()
    {
      if (Environment.OSVersion.Version.Major >= 6)
        SetProcessDPIAware();
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      var result = Bootstrap.Load(settings =>
      {
        settings.AcceptLanguageList = "zh-CN; en-US";
        settings.LogSeverity = Chromium.CfxLogSeverity.Disable;
      }, commandline =>
      {
        commandline.AppendSwitch("disable-web-security");
      });
      if (result)
      {
        Bootstrap.RegisterAssemblyResources(System.Reflection.Assembly.GetExecutingAssembly(), "WebUI");
        Bootstrap.RegisterFolderResources(Application.StartupPath);
        var factory = new CfxSchemeHandlerFactory();
        factory.Create += (_, args) =>
        {
          if (args.SchemeName == "http" && args.Browser != null)
          {
            var wb = BrowserCore.GetBrowser(args.Browser.Identifier);
            var handler = new MemResourceHandler("", wb, "");
            args.SetReturnValue(handler);
          }
        };

        Bootstrap.RegisterCustomScheme("http", "memres.app.local", factory);

        var factoryZip = new CfxSchemeHandlerFactory();
        factoryZip.Create += (_, args) =>
        {
          if (args.SchemeName == "http" && args.Browser != null)
          {
            var wb = BrowserCore.GetBrowser(args.Browser.Identifier);
            var handler = new ZipResourceHandler(Application.StartupPath + "\\res.zip", wb, "zip.app.local");
            args.SetReturnValue(handler);
          }
        };
        Bootstrap.RegisterCustomScheme("http", "zip.app.local", factoryZip);
        Application.Run(new MainUI());
        Application.Exit();
      }
    }
  }
}
