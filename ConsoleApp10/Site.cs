using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Site
    {
        private Service_table service = new Service_table()
            .Add(new Service("Nails", 199, "a.png", ""))
            .Add(new Service("Hair", 250, "b.png", ""))
            .Add(new Service("Eyebrws", 150, "c.png", ""));
        private Personnel_table personnel = new Personnel_table()
            .Add(new Personnel("Anna", "Nails", 199, "a.png"))
            .Add(new Personnel("Maria", "Hair", 250, "b.png"))
            .Add(new Personnel("Emily", "Eyebrws", 150, "c.png"));

        public List<String> address = new List<String>() { "Uzhhorod", "Lviv", "Kyiv"};

        public void ShowService()
        {
            service.Show();
        }

        public void ShowPersonnel()
        {
            personnel.Show();
        }

        public void FindService(string ServiceName)
        {
            foreach (Service service in service.Services().Where(item => item.name == ServiceName))
            {
                Console.WriteLine(service);
            }
            Console.WriteLine();
        }

        public void ShowAddress()
        {
            foreach (string item in address)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
