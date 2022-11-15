using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Site site = new Site();
            site.ShowService();
            site.ShowPersonnel();
            site.FindService("Nails");
            site.ShowAddress();
        }
    }
}
