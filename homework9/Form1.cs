using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework9
{
    public partial class Form1 : Form
    {
        SimpleCrawler crawler = new SimpleCrawler();
        public Form1()
        {
            InitializeComponent();           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            try
            {
                textBox2.Text = null;
                textBox3.Text = null;
                button.Enabled = false;
                button.Text = "正在爬";
                foreach (string res in crawler.Crawl(textBox1.Text))
                {
                    textBox2.Text += res;
                    textBox2.ScrollToCaret();
                }
            }
            catch(Exception ex)
            {
                textBox3.Text = ex.Message;
            }
            finally
            {
                button.Enabled = true;
                button.Text = "爬行";
            }
        }
    }
}
