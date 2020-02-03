using Chromium;
using Chromium.WebBrowser;
using System.Runtime.InteropServices;

namespace FrameClient
{
  internal class MemResourceHandler: Chromium.CfxResourceHandler
  {
    private BrowserCore wb;
    private object domainName;
    private GCHandle gcHandle;
    private WebResource webResource;
    private int readResponseStreamOffset;

    public MemResourceHandler(object path, BrowserCore wb, object domainName)
    {
      gcHandle = GCHandle.Alloc(this);
      this.wb = wb;
      this.domainName = domainName;
      this.CanGetCookie += (_, e) => e.SetReturnValue(false);
      this.CanSetCookie += (_, e) => e.SetReturnValue(false);
      this.GetResponseHeaders += OnGetResponseHeaders;
      this.ProcessRequest += OnProcessRequest;
      this.ReadResponse += OnReadResponse;
    }

    private void OnGetResponseHeaders(object sender, Chromium.Event.CfxGetResponseHeadersEventArgs e)
    {
      if (webResource == null)
      {
        e.Response.Status = 404;
      }
      else
      {
        var length = webResource.data.Length;
        e.ResponseLength = webResource.data.Length;
        e.Response.MimeType = webResource.mimeType;
        e.Response.Status = 200;
        var headers = e.Response.GetHeaderMap();
        e.Response.SetHeaderMap(headers);
      }
    }

    private void OnProcessRequest(object sender, Chromium.Event.CfxProcessRequestEventArgs e)
    {
      /*
      System.Reflection.Assembly Asmb = System.Reflection.Assembly.GetExecutingAssembly();
      string strName = Asmb.GetName().Name + ".WebUI.logo512.png";
      System.IO.Stream ManifestStream = Asmb.GetManifestResourceStream(strName);

      byte[] StreamData = new byte[ManifestStream.Length];
      ManifestStream.Read(StreamData, 0, (int)ManifestStream.Length);
      */

      var uri = new System.Uri(e.Request.Url);
      webResource = new WebResource(ImgMgr.Get().GetImg(uri.AbsolutePath.TrimStart('/')));

      e.Callback.Continue();
      e.SetReturnValue(true);

    }
    private void OnReadResponse(object sender, Chromium.Event.CfxReadResponseEventArgs e)
    {
      int bytesToCopy = webResource.data.Length - readResponseStreamOffset;

      if (bytesToCopy > e.BytesToRead)
        bytesToCopy = e.BytesToRead;

      Marshal.Copy(webResource.data, readResponseStreamOffset, e.DataOut, bytesToCopy);

      e.BytesRead = bytesToCopy;

      readResponseStreamOffset += bytesToCopy;

      e.SetReturnValue(true);


      if (readResponseStreamOffset == webResource.data.Length)
      {
        gcHandle.Free();
      }
    }
  }
}