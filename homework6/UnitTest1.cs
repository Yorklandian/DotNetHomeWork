using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework5;
using System.Collections.Generic;
using System.IO;

namespace homework5Test
{
    [TestClass]
    public class UnitTest1
    {
        public static Order MakeOrder()
        {
            OrderService Server = new OrderService();
            Client client = new Client("York", "WHU");
            Product product = new Product("Book", 100);
            OrderDetail od = new OrderDetail(product, 2);
            List<OrderDetail> odList = new List<OrderDetail>();
            odList.Add(od);
            Order order = new Order(1, client, odList);
            return order;
        }
        
        [TestMethod]
        public void TestCreateOrder()
        {
            OrderService Server = new OrderService();
            Client client = new Client("York", "WHU");
            Product product = new Product("Book", 100);
            Order order=Server.CreateOrder(product,client,3);
            Assert.IsNotNull(order);
        }
        [TestMethod]
        public void TestAddOrder()
        {
            OrderService Server = new OrderService();
            Order order = MakeOrder();
            Server.AddOrder(order);
            Assert.IsNotNull(Server.Orders);
        }
        [TestMethod()]
        public void ExistsTest()
        {
            OrderService Server = new OrderService();
            Order order = MakeOrder();
            Server.AddOrder(order);
            Assert.IsTrue(Server.Exists(order));
        }
        [TestMethod]
        public void RemoveOrderTest()
        {
            OrderService Server = new OrderService();
            Order order = MakeOrder();
            Server.AddOrder(order);
            Server.RemoveOrder(order);
            Assert.IsTrue(Server.Orders.Count == 0);
        }
        [TestMethod]
        public void ChangeOrderTest()
        {
            OrderService Server = new OrderService();
            Order order = MakeOrder();
            Server.AddOrder(order);

            Client client = new Client("Joey", "WHU");
            Product product = new Product("Book2", 100);
            OrderDetail od = new OrderDetail(product, 2);

            Server.ChangeOrder(order, client, od, 1);
            Assert.AreEqual(order.Customer, client);
        }
        [TestMethod]
        public void GetByidTest()
        {
            OrderService Server = new OrderService();
            Order order = MakeOrder();
            Server.AddOrder(order);
            Server.GetByID(1);
        }
        [TestMethod]
        public void ExportTest()
        {
            OrderService Server = new OrderService();
            Order order = MakeOrder();
            Server.AddOrder(order);
            Server.Export("Server.xml");
            
            
        }
        [TestMethod]
        public void ImportTest()
        {
            OrderService Server = new OrderService();
            Order order = MakeOrder();
            Server.AddOrder(order);
            Server.Export("Server.xml");
            OrderService service = new OrderService(); 
            service.Orders=OrderService.Import("Server.xml");
            Assert.IsTrue(service.Orders== Server.Orders);
        }
    }
}
