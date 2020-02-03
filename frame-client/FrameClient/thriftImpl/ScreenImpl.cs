using FrameClient.Adb;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestFFmpeg.thriftImpl
{
    class ScreenImpl : ScreenService.Iface
    {
            private static IFace face;

            public static void setIFace(IFace iFace)
            {
                face = iFace;
            }

        public void translate(byte[] bytes)
        {
            if (face != null)
            {
                face.translate(bytes);
            }
        }

        public bool ping(int interval)
        {
            if (face != null)
            {
                return face.ping(interval);
            }
            return false;
        }


        public bool getDisplay()
        {
            throw new NotImplementedException();
        }

        public bool sendPoint2(int width, int height)
        {
            throw new NotImplementedException();
        }

        public bool InputEvent(MouseEventType type)
        {
            throw new NotImplementedException();
        }

        public string sendPoint(int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool sendDisplay(int width, int height, int barHeight, int scale)
        {
            if (face != null)
            {
                return face.display(width, height, barHeight,scale);
            }
            return false;
        }
    }
}
