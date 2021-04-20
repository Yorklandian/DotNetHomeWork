using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;

namespace homework8
{
    public class OrderService
    {
        private static int count=1;
        public List<Order> Orders { get;set; } = new List<Order>();
        /*public Order CreateOrder(Product pd,Client cl,int num)
        {           
            OrderDetail od = new OrderDetail(pd, num);
            List<OrderDetail> odList = new List<OrderDetail>();
            odList.Add(od);
            Order order = new Order(count, cl, odList);
            count++;
            return order;
        }*/

        public int AddOrder(Order order)
        {
            if (order == null)
            {
                throw new NullArgumentException();
            }
            if (Exists(order.Id))
            {
                throw new OrderExistException();
            }
            Orders.Add(order);
            return order.Id;
        }


        public bool Exists(Order order)
        {
            return Orders.Contains(order);
        }
        public bool Exists(int id)
        {
            return Orders.Find(order => order.Id == id) != null;
        }


        public void RemoveOrder(int id)
        {
            int rmCounnt = Orders.RemoveAll(order => order.Id == id);
            if (rmCounnt == 0)
            {
                throw new OrderNotExistException();
            }
            count--;
        }
        public void RemoveOrder(Order order)
        {
            if (!Exists(order))
            {
                throw new OrderNotExistException();
            }
            Orders.Remove(order);
            count--;
        }
        
        public void ChangeOrder(Order order,Client c,OrderDetail odt,int rank)
        {
            order.Customer = c;
            order.Time = DateTime.Now;
            order.Details.RemoveAt(rank-1);
            order.Details.Add(odt);
            order.AllPrice = 0;
            foreach (OrderDetail od in order.Details)
            {
                order.AllPrice += od.TotalPrice;
            }
        }
        public Order GetByID(int id)
        {
            var query = from o in Orders
                        where o.Id == id
                        select o;
            return query.FirstOrDefault<Order>();

        }
        public List<Order> GetByCustomer(string cname)
        {
            var query = from o in Orders
                        where o.Customer.ClientName == cname
                        orderby o.AllPrice
                        select o;
            return query.ToList();
            
        }
        public List<Order> GetByPrice(double price)
        {
            var query = from o in Orders
                        where o.AllPrice == price
                        select o;
            return query.ToList();

        }
        public List<Order> GetByProduct(string pname)
        {
            var query = Orders.Where(o =>
            {
                bool b = false;
                foreach (OrderDetail od in o.Details)
                {
                    if (od.P.Name == pname)
                    {
                        b = true;
                        break;
                    }
                }
                return b;
            }).OrderBy(o => o.AllPrice);
            return query.ToList();
            
        }
        public void Export(String fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, Orders);
            }
        }
        public void Import(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach(order => {
                    if (!Orders.Contains(order))
                    {
                        Orders.Add(order);
                    }
                });
            }
        }

    }
    public class OrderExistException : ApplicationException
    { }
    public class OrderNotExistException : ApplicationException
    { }
}

