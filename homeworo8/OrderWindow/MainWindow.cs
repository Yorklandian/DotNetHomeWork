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
    public partial class MainWindow : Form
    {
        public OrderService service = new OrderService();
        AddOrderWindow orderWindow = new AddOrderWindow();
        ChangeOrderWindow changeWindow = new ChangeOrderWindow();

        public MainWindow()
        {
            InitializeComponent();
            /*OrderBindingSource.DataSource = service.Orders;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = orderWindow.ShowDialog();

            OrderBindingSource.ResetBindings(result == DialogResult.OK);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
            orderWindow.Owner = this;
            changeWindow.Owner = this;
            OrderBindingSource.DataSource = service.Orders;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "")
            {
                try { service.RemoveOrder(Int32.Parse(textBox1.Text));
                    OrderBindingSource.ResetBindings(true);
                }
                catch (OrderNotExistException)
                {
                    textBox2.Text = "Order does not exit!";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != null && textBox3.Text != "")
            {
                Order order=service.GetByID(Int32.Parse(textBox3.Text));
                OrderBindingSource.DataSource = order;
                OrderBindingSource.ResetBindings(true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != null && textBox4.Text != "")
            {
                List<Order> orderlist = service.GetByProduct(textBox4.Text);
                OrderBindingSource.DataSource = orderlist;
                OrderBindingSource.ResetBindings(true);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != null && textBox5.Text != "")
            {
                
                var result = changeWindow.ShowDialog();
                OrderBindingSource.ResetBindings(result == DialogResult.OK);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != null && textBox6.Text != "")
            {
                service.Export(textBox6.Text);
                textBox2.Text = "Export succeed!";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != null && textBox7.Text != "")
            {
                service.Import(textBox7.Text);
                textBox2.Text = "Import succeed!";
            }
        }

        private void OrderData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Order o = (Order)OrderData.CurrentRow.DataBoundItem;
            DetailBindingSource.DataSource = o.Details;
            DetailBindingSource.ResetBindings(true);
        }
    }
}
