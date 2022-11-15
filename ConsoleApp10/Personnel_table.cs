using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Personnel_table
    {
        private List<Personnel> personnels = new List<Personnel>();

        public Personnel_table Add(Personnel personnel)
        {
            personnels.Add(personnel);
            return this;
        }

        public List<Personnel> Services()
        {
            return personnels;
        }

        public void Show()
        {
            foreach (Personnel personnel in personnels)
            {
                Console.WriteLine(personnel);
            }
            Console.WriteLine();
        }
    }
}
