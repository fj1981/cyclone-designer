using System;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;

namespace TestFFmpeg.thriftImpl
{
    class ScreenServer
    {
        public static void Run(int port, NodeService.Iface iface)
        {
            ScreenImpl client = new ScreenImpl();
            ScreenService.Processor processor = new global::ScreenService.Processor(client);
            NodeService.Processor nodeProcessor = new global::NodeService.Processor(iface);

            TMultiplexedProcessor pro =  new TMultiplexedProcessor();
            pro.RegisterProcessor("ScreenService",processor);
            pro.RegisterProcessor("NodeService",nodeProcessor);
            TServerTransport transport = new TServerSocket(port);
            TServer server = new TThreadPoolServer(pro, transport);
            try
            {
                server.Serve();
            }
            catch (Exception e)
            {
            }
        }
    }
}
