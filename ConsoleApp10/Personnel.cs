using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Personnel
    {
        public string master_name;
        public string service;
        public int master_age;
        public string image;

        public Personnel(string master_name, string service, int master_age, string image)
        {
            this.master_name = master_name;
            this.service = service;
            this.master_age = master_age;
            this.image = image;
        }

        public override string ToString()
        {
            return $"Master {master_name}";
        }
    }
}
