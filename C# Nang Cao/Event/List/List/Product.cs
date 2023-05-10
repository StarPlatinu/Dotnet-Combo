using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    internal class Product : IComparable<Product>,IFormattable
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public double Price { get; set; }
        public string Origin { get; set; }

        public Product(int id, string name, double price, string origin)
        {
            Id = id;
            Name = name;
            Price = price;
            Origin = origin;
        }

        public int CompareTo(Product other)
        {
            double delta = this.Price - other.Price;
            if(delta > 0)
            {
                return -1; //price > first
            }
            else if(delta < 0)
            {
                return 1;
            }
            return 0;
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (format == null) format = "O";
            switch (format.ToUpper())
            {
                case "O":
                    return $"Xuat xu: {Origin} - Price: {Price} - ID: {Id}";
                case "N":
                    return $"Name: {Name} - Xuat xu: {Origin} - Price: {Price} - ID: {Id}";
                default:
                    throw new FormatException("No support this format");
            }
        }

        public override string ToString()
      => $"{Name} - {Price}";

        public string  ToString(string format) => this.ToString(format, null);
    }
}
 