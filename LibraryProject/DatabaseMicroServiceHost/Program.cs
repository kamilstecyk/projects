using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace DatabaseMicroServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {


            using (ServiceHost host = new ServiceHost(typeof(Dboperations)))
            {
                
                host.Open();
                Console.WriteLine("Server is up and running on port 32578");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                host.Close();
            }

        }
    }
}
