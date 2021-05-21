using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework12.Models
{
    public class Product
    {
        private string name;
        private double price;
        [Key]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
                else
                    throw new WrongPriceException(value);
            }
        }
        public Product() { }
        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        public override string ToString() => $"name: {Name}, price: {Price}";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Product other = (Product)obj;
            return Name == other.Name && Price == other.Price;
        }

        public override int GetHashCode()
        {
            int hashCode = -44027456;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }
    }
}
