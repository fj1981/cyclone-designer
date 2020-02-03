using Saar.FFmpeg.CSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FrameClient
{
  class BuffDecode : QueueHelper<byte[]>
  {
    private MemoryStream stream = null;
    private MediaReader media = null;
    private VideoDecoder decoder = null;
    private VideoFrame frame = null;

    private static BuffDecode uniqueInstance;

    private BuffDecode()
    {
    }

    /// <summary>
    /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
    /// </summary>
    /// <returns></returns>
    public static BuffDecode GetInstance()
    {
      // 如果类的实例不存在则创建，否则直接返回
      if (uniqueInstance == null)
      {
        uniqueInstance = new BuffDecode();
      }
      return uniqueInstance;
    }

    public void DecodeData(byte[] bytes)
    {
      Add(bytes);
      Resume();
    }

    public override void Execute(byte[] bytes)
    {
      if (bytes.Length == 0)
      {
        return;
      }
      var aa = Thread.CurrentThread.ManagedThreadId.ToString();
      Console.WriteLine($"DecodeDataImpl {aa} ==> {bytes.Length}");
      if (null == stream)
      {
        stream = new MemoryStream();
      }
      else
      {
        try
        {
          stream.Seek(0, SeekOrigin.Begin);
        }
        catch (Exception ex)
        {
          stream = new MemoryStream();
          Console.WriteLine($"Execute   {ex.ToString()}");
        }
      }
      stream.Write(bytes, 0, bytes.Length);
      stream.Seek(0, SeekOrigin.Begin);

      if (null == media)
      {
        media = new MediaReader(stream);
        decoder = media.Decoders.OfType<VideoDecoder>().First();
        decoder.OutFormat = new VideoFormat(decoder.InFormat.Width, decoder.InFormat.Height, AVPixelFormat.Bgr24, 4);
      }

      if (null == frame)
      {
        frame = new VideoFrame();
      }
      if (media.NextFrame(frame, decoder.StreamIndex))
      {
        Bitmap image = new Bitmap(frame.Format.Width, frame.Format.Height, frame.Format.Strides[0], PixelFormat.Format24bppRgb, frame.Scan0);
        ImgMgr.Get().SetImg("live.png", image);
      }
    }
  }

}
