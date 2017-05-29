using System;
using System.ServiceModel;

namespace WcfServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri pipesUrl = new Uri("net.pipe://localhost/Service/ProductService");
           

            using (ServiceHost host = new ServiceHost(typeof(Service.ProductService), pipesUrl))
            {              
                host.Open();

                Console.WriteLine("Host is running... \nPlease start the WpfSampleApp client. \n\nPress <Enter> to exit the host....");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
