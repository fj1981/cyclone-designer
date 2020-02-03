using System;
using System.Collections.Generic;
using System.Text;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;

namespace TestFFmpeg.thriftImpl
{
  class ScreenClient
  {
    /**
     * 获取手机屏幕分辨率
     **/
    public static void getDisplay(Int32 port)
    {
      TSocket socket = new TSocket("127.0.0.1", port, 1000);
      TFramedTransport.Factory factory = new
         TFramedTransport.Factory();
      TTransport transport = factory.GetTransport(socket);
      TBinaryProtocol.Factory factory1 =
          new TBinaryProtocol.Factory();
      TProtocol protocol = factory1.GetProtocol(transport);

      TMultiplexedProtocol impl1
          = new TMultiplexedProtocol(protocol, "ScreenService");

      ScreenService.Client client =
              new ScreenService.Client(impl1);
      try
      {
        socket.Open();
        bool r
         = client.getDisplay();
      }
      catch (Exception x)
      {
        Console.WriteLine(x.StackTrace);
      }
      finally
      {
        transport.Close();
      }
    }
    /**
      * 获取手机屏幕分辨率
    **/
    public static String sendPoint(Int32 port, Int32 x, Int32 y)
    {
      TSocket socket = new TSocket("127.0.0.1", port, 1000);
      TFramedTransport.Factory factory = new
         TFramedTransport.Factory();
      TTransport transport = factory.GetTransport(socket);
      TBinaryProtocol.Factory factory1 =
          new TBinaryProtocol.Factory();
      TProtocol protocol = factory1.GetProtocol(transport);
      TMultiplexedProtocol impl1
          = new TMultiplexedProtocol(protocol, "ScreenService");

      ScreenService.Client client =
              new ScreenService.Client(impl1);
      try
      {
        socket.Open();
        return client.sendPoint(x, y);
      }
      catch (Exception e)
      {
        Console.WriteLine(e.StackTrace);
      }
      finally
      {
        transport.Close();
      }
      return "";
    }

    /**
     * 点击事件
     **/
    public static void InputEvent(Int32 port, MouseEventType type)
    {
      TSocket socket = new TSocket("127.0.0.1", port, 1000);
      TFramedTransport.Factory factory = new
         TFramedTransport.Factory();
      TTransport transport = factory.GetTransport(socket);
      TBinaryProtocol.Factory factory1 =
          new TBinaryProtocol.Factory();
      TProtocol protocol = factory1.GetProtocol(transport);
      TMultiplexedProtocol impl1
        = new TMultiplexedProtocol(protocol, "ScreenService");

      ScreenService.Client client =
              new ScreenService.Client(impl1);
      try
      {
        socket.Open();
        bool r
         = client.InputEvent(type);
      }
      catch (Exception x)
      {
        Console.WriteLine(x.StackTrace);
      }
      finally
      {
        transport.Close();
      }
    }


    public static Boolean Dump(Int32 port)
    {
      TSocket socket = new TSocket("127.0.0.1", port, 3000);
      TFramedTransport.Factory factory = new
         TFramedTransport.Factory();
      TTransport transport = factory.GetTransport(socket);
      TBinaryProtocol.Factory factory1 =
          new TBinaryProtocol.Factory();
      TProtocol protocol = factory1.GetProtocol(transport);
      TMultiplexedProtocol impl1
       = new TMultiplexedProtocol(protocol, "NodeService");

      NodeService.Client client =
              new NodeService.Client(impl1);
      try
      {
        socket.Open();
        return client.dump();

      }
      catch (Exception x)
      {
        Console.WriteLine(x.StackTrace);
      }
      finally
      {
        transport.Close();
      }
      return false;
    }
    public static String AddVar(Int32 port, String config)
    {
      TSocket socket = new TSocket("127.0.0.1", port, 3000);
      TFramedTransport.Factory factory = new
         TFramedTransport.Factory();
      TTransport transport = factory.GetTransport(socket);
      TBinaryProtocol.Factory factory1 =
          new TBinaryProtocol.Factory();
      TProtocol protocol = factory1.GetProtocol(transport);
      TMultiplexedProtocol impl1
       = new TMultiplexedProtocol(protocol, "NodeService");

      NodeService.Client client =
              new NodeService.Client(impl1);
      try
      {
         socket.Open();
        return client.addVar(config);

      }
      catch (Exception x)
      {
        Console.WriteLine(x.StackTrace);
      }
      finally
      {
        transport.Close();
      }
      return "";
    }
    public static String AddProcess(Int32 port, String config)
    {
      TSocket socket = new TSocket("127.0.0.1", port, 3000);
      TFramedTransport.Factory factory = new
         TFramedTransport.Factory();
      TTransport transport = factory.GetTransport(socket);
      TBinaryProtocol.Factory factory1 =
          new TBinaryProtocol.Factory();
      TProtocol protocol = factory1.GetProtocol(transport);
      TMultiplexedProtocol impl1
       = new TMultiplexedProtocol(protocol, "NodeService");

      NodeService.Client client =
              new NodeService.Client(impl1);
      try
      {
        socket.Open();
        return client.AddProcess(config);

      }
      catch (Exception x)
      {
        Console.WriteLine(x.StackTrace);
      }
      finally
      {
        transport.Close();
      }
      return "";
    }
    public static Boolean Start(Int32 port, String name)
    {
      TSocket socket = new TSocket("127.0.0.1", port, 3000);
      TFramedTransport.Factory factory = new
         TFramedTransport.Factory();
      TTransport transport = factory.GetTransport(socket);
      TBinaryProtocol.Factory factory1 =
          new TBinaryProtocol.Factory();
      TProtocol protocol = factory1.GetProtocol(transport);
      TMultiplexedProtocol impl1
       = new TMultiplexedProtocol(protocol, "NodeService");

      NodeService.Client client =
              new NodeService.Client(impl1);
      try
      {
        socket.Open();
        return client.start(name);

      }
      catch (Exception x)
      {
        Console.WriteLine(x.StackTrace);
      }
      finally
      {
        transport.Close();
      }
      return false;
    }

  }
}
