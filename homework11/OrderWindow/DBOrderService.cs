using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using homework8;

namespace OrderWindow
{
    public class DBOrderService
    {              
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
            using (var db = new OrderContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return order.Id;
            }
            
        }


        public bool Exists(Order order)
        {
            using (var db = new OrderContext())
            {
                return db.Orders.Contains(order);
            }
        }
        public bool Exists(int id)
        {
            using (var db = new OrderContext())
            {
                Order order1 = db.Orders.Find(id);
                return order1!= null;
            }
        }


        public void RemoveOrder(int id)
        {
            using (var db = new OrderContext())
            {
                var order = db.Orders.Include("Details").FirstOrDefault(o => o.Id == id);
                if (order != null)
                {
                    db.Orders.Remove(order);
                    db.SaveChanges();
                }
            }
            
        }       

        public void ChangeOrder(Order order, Client c, OrderDetail odt, int rank)
        {
            DateTime dt = DateTime.Now;
            using(var context=new OrderContext())
            {
                var order1 = context.Orders.FirstOrDefault(o => o.Id == order.Id);
                if (order1 != null)
                {
                    order1.Customer = c;
                    order1.Time = dt;
                    order1.Details.RemoveAt(rank - 1);
                    order1.Details.Add(odt);
                    order1.AllPrice = 0;
                    foreach (OrderDetail od in order1.Details)
                    {
                        order1.AllPrice += od.TotalPrice;
                    }
                    context.SaveChanges();
                }
                
            }
        }
        public Order GetByID(int id)
        {
            using(var context=new OrderContext())
            {
                var Order1 = context.Orders.SingleOrDefault(o => o.Id == id);
                if (Order1 != null)
                    return Order1;
                else
                    return null;
            }

        }
        /*public List<Order> GetByCustomer(string cname)
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

        }*/
        public bool GetProd(Order o,string pname)
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
        }
        public List<Order> GetByProduct(string pname)
        {
            using (var context = new OrderContext())
            {
                var query = context.Orders.Where(o =>GetProd(o,pname)
                ).OrderBy(o => o.AllPrice);
                return query.ToList();
            }

        }
        public void Export(String fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using (var db = new OrderContext())
                {
                    xs.Serialize(fs, db.Orders);
                }
            }
        }
        public void Import(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (var db = new OrderContext())
                {
                    List<Order> temp = (List<Order>)xs.Deserialize(fs);
                    temp.ForEach(order =>
                    {
                        if (!db.Orders.Contains(order))
                        {
                            db.Orders.Add(order);
                        }
                    });
                }
            }
        }

    }
    public class OrderExistException : ApplicationException
    { }
    public class OrderNotExistException : ApplicationException
    { }
}



