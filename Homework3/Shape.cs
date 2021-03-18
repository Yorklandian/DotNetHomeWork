using System;

namespace Homework3
{
    abstract class Shape
    {
        protected double area;
        public double Area
        {
            get=>area;
            set => area = value;
        }
        public abstract bool IsLegal();
    }
    
    //Square
    class Square : Shape
    {
        private double side = 0;
        public double Side
        {
            get => side;
            set => side = value;
        }
        public Square(double side)
        {
            this.side = side;
            base.Area = side * side;
        }
/*        new public double Area
        {
            get => side * side;
            set => area = value;
        }*/
        public override bool IsLegal()
        {
            if (side <=0)
                return false;
            else
                return true;
        }
    }
    //Rectangle
    class Rectangle : Shape
    {
        private double length = 0;
        private double width = 0;

        public double Length
        {
            get => length;
            set => length = value;
        }
        public double Width
        {
            get => width;
            set => width = value;
        }
        public Rectangle(double length,double width)
        {
            this.length = length;
            this.width = width;
            base.Area = length * width;
        }
        /*new public double Area
        {
            get => length*width;
            set => area = value;
        }*/
        public override bool IsLegal()
        {
            if (width <= 0||length<=0)
                return false;
            else
                return true;
        }
    }
    //Triangle
    class Triangle : Shape
    {
        private double line1 = 0;
        private double line2 = 0;
        private double line3 = 0;

        public double Line1
        {
            get => line1;
            set => line1 = value;
        }
        public double Line2
        {
            get => line2;
            set => line2 = value;
        }
        public double Line3
        {
            get => line3;
            set => line3 = value;
        }
        public Triangle(double line1, double line2,double line3)
        {
            this.line1 = line1;
            this.line2 = line2;
            this.line3 = line3;
            double p = (line1 + line2 + line3) / 2;
            base.Area=Math.Sqrt(p * (p - line1) * (p - line2) * (p - line3));
        }
        ~Triangle(){ }
        /*new public double Area
        {
            get
            {
                double p = (line1 + line2 + line3) / 2;
                return Math.Sqrt(p*(p-line1)*(p - line2) * (p - line3));
            }
            set => area = value;
        }*/
        public override bool IsLegal()
        {
            if (line1 <= 0 || line2 <= 0||line3<=0)
                return false;
            else
            {
                if (line1 + line2 < line3 || line1 + line3 < line2 || line2 + line3 < line1)
                    return false;
                else
                    return true;
            }
        }
    }
    class Calculate
    {
        //利用随机数决定生成Shape的类型以及各边长
        public static Shape Factory(double a)
        {
            if (a >= 0 && a < 3.333)
            {
                Random r = new Random();
                double x = r.NextDouble() * 10;
                Square square = new Square(x);
                return square;
            }
            else
            {

                if (a <= 6.666)
                {
                    Random r = new Random();
                    double x = r.NextDouble() * 10;
                    double y = r.NextDouble() * 10;
                    Rectangle rec = new Rectangle(x, y);
                    return rec;
                }
                else
                {
                    Random r1 = new Random();
                    double x = r1.NextDouble();
                    double y = r1.NextDouble();
                    double z = r1.NextDouble();
                    Triangle tr = new Triangle(x, y, z);
                    while (!tr.IsLegal())
                    {
                        double x1 = r1.NextDouble();
                        double y1 = r1.NextDouble();
                        double z1 = r1.NextDouble();
                        tr = new Triangle(x1, y1, z1);
                    }
                    return tr;
                }
            }
        }
            public static void Main()
            {
                double totalArea = 0;
                for (int i = 0; i < 10; i++)
                {
                    Random rand = new Random();
                    double d = rand.NextDouble() * 10;
                    Shape s = Factory(d);
                    Console.WriteLine(s.Area);
                    totalArea += s.Area;
                }
                Console.WriteLine("The total area is: " + (int)totalArea);
            }
        }
    }
