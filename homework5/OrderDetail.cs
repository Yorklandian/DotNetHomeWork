using System;
using System.Collections.Generic;
using System.Text;

namespace homework5
{
    class OrderDetail
    {
        public Product P { get; set; }
        private double totalPrice;
        private int count;
        public double TotalPrice
        {
            get => totalPrice;
            set => totalPrice = value;
        }
        public int Count
        {
            get => count;
            set
            {
                if (count >= 0)
                    count = value;
                else
                    throw new WrongCountException(value);
            }
        }
        public OrderDetail(Product p,int count)
        {
            P = p;
            this.count = count;
            totalPrice = count * p.Price;
        }
        public override string ToString()
        {
            return $"Prodect: {P.Name}\n" +
                   $"TotalPrice: {TotalPrice}\n" +
                   $"count: {Count}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            OrderDetail other = (OrderDetail)obj;
            return P == other.P
                   && TotalPrice== other.TotalPrice
                   && Count == other.Count;
        }
        public override int GetHashCode() => TotalPrice.GetHashCode()
                                             ^ P.GetHashCode()
                                             ^ Count;

    }
}
