using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Service
    {
        public string name { get; set; }
        public int price { get; set; }
        public string img { get; set; }
        public string description { get; set; }

        public Service(string name, int price, string img, string description)
        {
            this.name = name;
            this.price = price;
            this.img = img;
            this.description = description;
        }

        public override string ToString()
        {
            return $"Service {name} costs {price}";
        }
    }
}
