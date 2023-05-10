//LINQ (Language Integrated Query) 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings;

namespace linq_app
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string[] Colors { get; set; }
        public int Brand { set; get; }

        public Product(int id, string name, int price, string[] colors, int brand)
        {
            Id = id;
            Name = name;
            Price = price;
            Colors = colors;
            Brand = brand;
        }

        public override string? ToString()
      => $"{Id,3} {Name,2} {Price,5} {Brand, 2} {string.Join(",",Colors)}";
    }

    public class Brand {
      public string Name { get; set; }
      public int ID { set; get; }
    }




    class Program
    {
        public static void ProductPrice400(List<Product> products)
        {
            var kq = from product in products where product.Price == 400 select product;

            foreach (var product in kq) Console.WriteLine(product.ToString());

        }

        public static void ProductPrice300(List<Product> products)
        {
            var kq = from product in products where product.Price == 300 select product;

            foreach(var product in kq) Console.WriteLine(product.ToString() );
        }

        public static void getAllName(List<Product> products)
        {
            var kq = from product in products select product.Name;

            foreach(var name in kq) Console.WriteLine(name);
        }

        public static void orderDecending(List<Product> products)
        {
            var kq = from product in products
                     where product.Price <= 300
                     orderby product.Id descending
                     select product;    
            foreach(var product in kq) Console.WriteLine(product.ToString() );    
        }

        public static void groupBy(List<Product> products)
        {
            var kq = from product in products
                     where product.Price >= 400 && product.Price <= 500
                     group product by product.Price;
            foreach (var group in kq)
            {
                Console.WriteLine(group.Key);
                foreach (var product in group) Console.WriteLine($"{product.Name} {product.Price}");
            }
        }

        public static void groupByUseInto(List<Product> products)
        {
            var kq = from product in products
                     where product.Price >= 400 && product.Price <=500
                     group product by product.Price into gr
                     orderby gr.Key descending
                     select gr;

            foreach (var product in kq) Console.WriteLine( product.ToString() );
        }

        public static void joinX(List<Product> products,List<Brand> brands)
        {
            var kq = from product in products
                     join brand in brands
                     on product.Brand equals brand.ID
                     select new
                     {
                         name = product.Name,
                         brand = brand.Name,
                         price = product.Price
                     };
            foreach(var item in kq)
            {
                Console.WriteLine($"{item.name} {item.brand} {item.price}");
            }
        }
        public static void Main(string[] args)
        {
            var brands = new List<Brand>()
            {
                new Brand{ID = 1, Name = "Company AAA"},
                new Brand{ID = 2, Name = "Company BBB"},
                new Brand{ID = 4, Name = "Company CCC"}
            };

            var products = new List<Product>()
            {
               new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
               new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
               new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
               new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
               new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
               new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
               new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };

            ProductPrice400(products);
            ProductPrice300(products);
            Console.WriteLine("-----------------------------");
            getAllName(products);
            //anonimous

            var kq = from product in products
                     select new
                     {
                         ten = product.Name.ToUpper(),
                         mausac = string.Join(",", product.Colors)

                     };
            foreach(var k in kq) Console.WriteLine(k.ten +" - "+k.mausac);

            Console.WriteLine("-----------------------------");
            orderDecending(products);
            Console.WriteLine("-----------------------------");
            groupBy(products);
            Console.WriteLine("-----------------------------");
            groupByUseInto(products);
            Console.WriteLine("-----------------------------");
            joinX(products,brands); 
        }

    }

}
