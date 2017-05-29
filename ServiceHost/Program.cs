using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri pipesUrl = new Uri("net.pipe://localhost/ProductsInfoService/ProductsInfo");
            Uri httpsUrl = new Uri("https://localhost/ProductsInfoService/ProductsInfo");
            Uri httpUrl = new Uri("http://localhost/ProductsInfoService/ProductsInfo");

            using (ServiceHost host = new ServiceHost(typeof(ProductsInfoService.ProductsInfo), pipesUrl, httpsUrl, httpUrl))
            {
                host.AddServiceEndpoint(typeof(ProductsInfoService.IProductsInfoService), new NetNamedPipeBinding(), "");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpsGetEnabled = true;

                host.Open();

                Console.WriteLine("Host is running... Press <Enter> to exit");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
