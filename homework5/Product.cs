using System;
using System.Collections.Generic;
using System.Text;

namespace homework5
{
    class Product
    {
        private string name;
        private double price;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Price
        {
            get { return price; }
            set {
                if (value > 0)
                    price = value;
                else
                    throw new WrongPriceException(value);
            }
        }
        public Product(string name,double price)
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
        public override int GetHashCode() => Name.GetHashCode() ^ Price.GetHashCode();
    
    }
}
