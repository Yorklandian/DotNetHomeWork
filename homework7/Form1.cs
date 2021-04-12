using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                getReferances();
        }
            catch (Exception ex)
            {
                message.Text = ex.Message;
            }
            if (graphics == null)
                graphics = panel2.CreateGraphics();
            graphics.Clear(panel2.BackColor);
            drawCayleyTree(n, panel2.Width/2, (panel2.Height/20)*19, length, -Math.PI / 2);
        }

        private Graphics graphics;
        int n= 10;
        int length=100;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        Color color = Color.Blue;
        void getReferances()
        {           
                n = Convert.ToInt32(Depth.Text);           
                length = Convert.ToInt32(Length.Text);           
                per1 = Convert.ToDouble(Per1.Text);
                per2 = Convert.ToDouble(Per2.Text);
                th1 = Convert.ToDouble(Th1.Text);
                th2 = Convert.ToDouble(Th2.Text);
        }
        

        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);

        }
        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(new Pen(color), (int)x0, (int)y0, (int)x1, (int)y1);
        
        }

        private void ColorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ColorBox.SelectedIndex)
            {
                case 0:color = Color.Red;break;
                case 1:color = Color.Blue;break;
                case 2:color = Color.Green; break;
                case 3:color = Color.Yellow;break;
                case 4:color = Color.Black;break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
