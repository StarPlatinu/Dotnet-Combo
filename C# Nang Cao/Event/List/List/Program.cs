using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var numbers = new List<int>() { 1,2,3,4,5,6};
            var products = new List<Product>()
            {
                new Product(1,"Passed",100,"China"),
                 new Product(2,"Passedx2",100,"China"),
                  new Product(3,"Passedx3",100,"China")
            };

            Product? p1 = products.Find(
          (Product ob) =>
          {
              return ob.Name == "Passed";
          }
           );

        if(p1 != null )
                Console.WriteLine("(found) "+p1.ToString("0"));

            var ifound = products.FindIndex(x => x.Origin == "China");

            List<Product> p_100 = products.FindAll(p => p.Price > 100);

        }
    }
}
