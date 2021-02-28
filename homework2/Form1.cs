using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework2
{
    public partial class Form1 : Form
    {
        string op1;
        double a1=0, b1=0, result=0;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
                a1 = Convert.ToDouble(textBox1.Text);
            if (textBox2.Text != null)
                b1 = Convert.ToDouble(textBox2.Text);
            calcu();
            string re = result.ToString();
            label1.Text = re;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            string op= cb.SelectedItem as string;
            op1 = op;
        }
        private void calcu()
        {
            switch (op1)
            {
                case "+":
                    result = a1 + b1;
                    break;
                case "-":
                    result = a1 - b1;
                    break;
                case "*":
                    result = a1 * b1;
                    break;
                case "/":
                    result = a1 / b1;
                    break;

            }
        }
    }
}
