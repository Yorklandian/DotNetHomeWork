using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework8;
namespace OrderWindow
{
    public partial class AddOrderWindow : Form
    {
        public int count = 1;
        public MainWindow mainWindow;
        public List<OrderDetail> orderDetails = new List<OrderDetail>();
        public AddOrderWindow()
        {
            InitializeComponent();
        }

        private void AddOrderWindow_Load(object sender, EventArgs e)
        {
            this.orderDetails.Clear();
            MainWindow parent =(MainWindow)this.Owner;
            mainWindow = parent;
            DetailDataSource.DataSource = this.orderDetails;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product product = new Product(textBox3.Text, Double.Parse(textBox4.Text));
            OrderDetail orderDetail = new OrderDetail(product, Int32.Parse(textBox5.Text));
            orderDetails.Add(orderDetail);
            DetailDataSource.ResetBindings(true);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client(textBox1.Text, textBox2.Text);
            Order order = new Order(count, client, orderDetails);
            ;count++;
            try
            {
                
                mainWindow.service.AddOrder(order);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(OrderExistException)
            {
                count--;
                textBox6.Text = "Order Already Exists";
            }
            
        }
    }
}
