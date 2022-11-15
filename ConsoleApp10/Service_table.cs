using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Service_table
    {
        private List<Service> services = new List<Service> ();

        public Service_table Add(Service service)
        {
            services.Add(service);
            return this;
        }

        public List<Service> Services()
        {
            return services;
        }

        public void Show()
        {
            foreach (Service service in services)
            {
                Console.WriteLine(service);
            }
            Console.WriteLine();
        }
    }
}
