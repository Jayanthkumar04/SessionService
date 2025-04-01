using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Session2Service;
using System.ServiceModel.Description;
namespace ConsoleHost2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:7000");
            Uri tcpBaseAddress = new Uri("net.tcp://localhost:6788");

            //ServiceHost sh = new ServiceHost(typeof(Service1),baseAddress);

            ServiceHost sh = new ServiceHost(typeof(Service1), new Uri[] { baseAddress, tcpBaseAddress });

            ServiceEndpoint se = sh.AddServiceEndpoint(typeof(IService1), new BasicHttpBinding(), baseAddress);

            ServiceEndpoint tcpSe = sh.AddServiceEndpoint(typeof(IService1), new NetTcpBinding(), tcpBaseAddress);

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();

            smb.HttpGetEnabled = true;

            //smb.HttpGetEnabled = false;
            sh.Description.Behaviors.Add(smb);

            ServiceEndpoint httpSeMex = sh.AddServiceEndpoint(typeof(IMetadataExchange),
                                                                MetadataExchangeBindings.CreateMexHttpBinding(),
                                                                "http://localhost:7000/MyHttpEndPoint/mex");

            ServiceEndpoint tcpSeMex = sh.AddServiceEndpoint(typeof(IMetadataExchange),
                                                                MetadataExchangeBindings.CreateMexTcpBinding(),
                                                                "net.tcp://localhost:6789/mex");

            sh.Open();
            Console.WriteLine("Service is ready");

            foreach (var ep in sh.Description.Endpoints)
            {
                Console.WriteLine("Address: {0}", ep.Address);
                Console.WriteLine("Binding: {0}", ep.Binding);
                Console.WriteLine("Contract: {0}", ep.Contract);
            }


            Console.ReadLine();

            sh.Close();

        }
    }
}
