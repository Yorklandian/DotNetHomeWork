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
    public partial class ChangeOrderWindow : Form
    {
        public MainWindow mainWindow;
        public Order order;
        public ChangeOrderWindow()
        {
            InitializeComponent();
        }

        private void ChangeOrderWindow_Load(object sender, EventArgs e)
        {
            MainWindow parent = (MainWindow)this.Owner;
            mainWindow = parent;
            order = mainWindow.service.GetByID(Int32.Parse(mainWindow.textBox5.Text));
            this.textBox1.Text = order.Customer.ClientName;
            this.textBox2.Text = order.Customer.Address;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client c = new Client(textBox1.Text, textBox2.Text);
            Product p = new Product(textBox3.Text, Double.Parse(textBox5.Text));
            OrderDetail odt = new OrderDetail(p,Int32.Parse(textBox4.Text));
            mainWindow.service.ChangeOrder(order, c,odt,Int32.Parse(textBox6.Text));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
