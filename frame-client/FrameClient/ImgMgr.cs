using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FrameClient
{

  public delegate void NotifyDataChangedHandler(string res,int width,int height);
  class ImgMgr
  {
    private static readonly object Lock = new object();
    private ConcurrentDictionary<string, Image> resImage = new ConcurrentDictionary<string, Image>();
    private static ImgMgr instance = null;
    public NotifyDataChangedHandler dataChangedHandler;
    private Image imgForSave;
    private ImgMgr()
    {

    }
    static public ImgMgr Get()
    {
      if (null == instance)
      {
        instance = new ImgMgr();
      }
      return instance;
    }

    public void SetImg(string resName, Image img)
    {
      if(img.Width !=0)
      {
        if(GlobDef.globle_scale != 1)
        {
          img = GetThumbnailImage(img,
            (int)(img.Width / GlobDef.globle_scale),
            (int)(img.Height / GlobDef.globle_scale));
        }
        lock (Lock)
        {
          imgForSave = img;
          resImage[resName] = img;
        }
        dataChangedHandler(resName,img.Width,img.Height);
      }
    }

    public Image GetImg(string resName)
    {
      Image img;
      if (resImage.TryGetValue(resName, out img))
      {
        return img;
      }
      return resImage[resName];
    }

    private static Image GetThumbnailImage(Image image, int width, int height)
    {
      if (image == null || width < 1 || height < 1)
        return null;

      Image bitmap = new Bitmap(width, height);

      using (var g = Graphics.FromImage(bitmap))
      {
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.CompositingQuality = CompositingQuality.HighQuality;
        g.Clear(Color.Transparent);
        g.DrawImage(image, new Rectangle(0, 0, width, height),
            new Rectangle(0, 0, image.Width, image.Height),
            GraphicsUnit.Pixel);
        return bitmap;
      }
    }

      public string NewSaveImage()
    {
      if(imgForSave != null)
      {
        var imgName = "img" + Util.GetTimeStamp();
        lock (Lock)
        {
          var img = GetThumbnailImage(imgForSave, imgForSave.Width / 2, imgForSave.Height / 2);
          GlobDef.sz_image.width = img.Width;
          GlobDef.sz_image.height = img.Height;
          resImage[imgName] = img;
        }
        return imgName;
      }
      return null;
    }

  }
}
