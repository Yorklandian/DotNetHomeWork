using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace homework5
{
    class Order
    {
        public Client Customer { get; set; }
        public List<OrderDetail> Details { get; set; }
        public int Id { get; set; }
        public double AllPrice { get; set; }
        public DateTime Time { get; set; }

        public Order(int id,Client c, List<OrderDetail> details)
        {
            Id = id;
            Customer = c;
            Details = details;
            Time =DateTime.Now;
            foreach(OrderDetail od in details)
            {
                AllPrice += od.TotalPrice;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"id: {Id}\n\n")
              .Append($"client:\n{Customer}\n\n")
              .Append($"All Price: {AllPrice}\n\n")
              .Append("details:\n");
            Details.ForEach(detail => sb.Append($"{detail}\n"));
            sb.Append($"Order time:{Time}\n");
            sb.Append("\n");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Order other = (Order)obj;
            return Customer.Equals(other.Customer)
                && Details.Equals(other.Details);
        }

        public override int GetHashCode() => Customer.GetHashCode()
                                           ^ Details.GetHashCode();

    }
}
