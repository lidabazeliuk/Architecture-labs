using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        interface IImplementation
        {
            string Buy();
        }

        class SellSystem
        {
            protected IImplementation _implementation = null;

            public SellSystem(IImplementation implementation)
            {
                _implementation = implementation;
            }
            public virtual string Operation()
            {
                return "";
            }
        }

        class Product : SellSystem
        {
            public string name;
            public float price;
            
            public Product(IImplementation implementation, string name, float price): base(implementation)
            {
                this.name = name;
                this.price = price;
            }
            public Product(string name, float price): base(null)
            {
                this.name = name;
                this.price = price;
            }

            public override string Operation()
            {
                return $"One product for: {price}$ " +
                _implementation.Buy();
            }
        }
        class Order : SellSystem
        {
            protected Dictionary<Product, int> products;
            public Order(IImplementation implementation, Dictionary<Product, int> products) : base(implementation)
            {
                this.products = products;
            }
            public override string Operation()
            {
                string res = "Whole order: \n";
                foreach(var product in products)
                {
                    res += $"{product.Key.name} for {product.Value * product.Key.price},\n";
                }
                return res +
                _implementation.Buy();
            }
        }

        class BuyWithDebit : IImplementation
        {
            public string Buy()
            {
                return "with debit.";
            }
        }
        class BuyWithLoan : IImplementation
        {
            public string Buy()
            {
                return "with loan.";
            }
        }

        static void Main(string[] args)
        {
            SellSystem p1 = new Product(new BuyWithDebit(), "TV1", 123);
            SellSystem p2 = new Product(new BuyWithLoan(), "TV2", 234);
            SellSystem o1 = new Order(new BuyWithDebit(), new Dictionary<Product, int>()
            {
                { new Product("TV3", 123), 1 },
                { new Product("TV4", 123), 2 }
            });
            SellSystem o2 = new Order(new BuyWithLoan(), new Dictionary<Product, int>()
            {
                { new Product("TV5", 123), 3 },
                { new Product("TV6", 123), 4 }
            });

            Console.WriteLine(p1.Operation());
            Console.WriteLine(p2.Operation());
            Console.WriteLine(o1.Operation());
            Console.WriteLine(o2.Operation());
        }
    }
}
