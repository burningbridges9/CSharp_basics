using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ten
{
    class Program
    {
        interface ICipher
        {
            string Encode(string s);
            string Decode(string s);
        }

        class ACipher : ICipher
        {
            public string Decode(string s)
            {
                char[] chars = s.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    chars[i] = (char)(chars[i] - 1);
                }
                return new string(chars);
            }

            public string Encode(string s)
            {
                char[] chars = s.ToCharArray();
                for (int i =0; i< chars.Length;i++)
                {
                    chars[i] =(char)(chars[i]+ 1);
                }
                return new string(chars);
            }
        }
        class BCipher : ICipher
        {
            public string Decode(string s)
            {
                char z = 'a';
                int lastPos = (int)z;
                char[] chars = s.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    chars[i] = ((char)(lastPos + i)).ToString().ToLower().ToCharArray()[0];
                }
                return new string(chars);
            }

            public string Encode(string s)
            {
                char z = 'z';
                int lastPos = (int)z;
                char[] chars = s.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    chars[i] = ((char)(lastPos - i)).ToString().ToUpper().ToCharArray()[0];                    
                }
                return new string(chars);
            }
        }

        abstract class Figure
        {
            public string Color { get; set; }
            public bool Visibility { get; set; }
            public Figure()
            {
                Color = "black";
                Visibility = true;
            }
            public Figure(string c, bool v)
            {
                Color = c;
                Visibility = v;
            }
            public abstract void MoveHorizontal(int offset);
            public abstract void MoveVertical(int offset);
            public void Print()
            {
                Console.WriteLine("Figure:\nColor: " + Color + "\nVisibility: " + Visibility);
            }
        }
        class Point : Figure
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point():base()
            {
                X = 0;
                Y = 0;
            }
            public Point(int xVal, int yVal):base()
            {
                X = xVal;
                Y = yVal;
            }
            public Point(int xVal, int yVal, string s, bool v) : base(s, v)
            {
                X = xVal;
                Y = yVal;
            }
            public override void MoveHorizontal(int offset)
            {
                X += offset;
            }
            public override void MoveVertical(int offset)
            {
                Y += offset;
            }
            public new void Print()
            {
                base.Print();
                Console.WriteLine("Coordinates: ({0};{1})", X, Y);
            }
        }
        class Circle:Point
        {
            private double radius;
            public double Radius
            {
                get
                {
                    return radius;
                }
                set
                {
                    if (value > 0)
                    {
                        radius = value;
                    }
                }
            }
            public Circle():base()
            {
                Radius = Math.Pow(10,-10);
            }
            public Circle(double radVal) : base()
            {
                Radius = radVal;
            }
            public Circle(int xVal, int yVal, double radVal) : base(xVal, yVal)
            {
                Radius = radVal;
            }
            public Circle(int xVal, int yVal, double radVal, string s, bool v) : base(xVal, yVal, s, v)
            {
                Radius = radVal;
            }
            public double Area()
            {
                return Math.PI * Math.Pow(Radius, 2);
            }
            public new void Print()
            {
                base.Print();
                Console.WriteLine("Circle. Radius: {0}\n", Radius); 
            }
        }

        class Rectangle : Point
        {
            private double xLength;
            public double XLength
            {
                get
                {
                    return xLength;
                }
                set
                {
                    if (value > 0)
                    {
                        xLength = value;
                    }
                }
            }
            private double yLength;
            public double YLength
            {
                get
                {
                    return yLength;
                }
                set
                {
                    if (value > 0)
                    {
                        yLength = value;
                    }
                }
            }
            public Rectangle() : base()
            {
                XLength = Math.Pow(10, -10);
                YLength = Math.Pow(10, -10);
            }
            public Rectangle(double xLenVal, double yLenVal) : base()
            {
                XLength = xLenVal;
                YLength = yLenVal;
            }
            public Rectangle(int xVal, int yVal, double xLenVal, double yLenVal) : base(xVal, yVal)
            {
                XLength = xLenVal;
                YLength = yLenVal;
            }
            public Rectangle(int xVal, int yVal, double xLenVal, double yLenVal, string s, bool v) : base(xVal, yVal, s, v)
            {
                XLength = xLenVal;
                YLength = yLenVal;
            }
            public double Area()
            {
                return XLength*YLength;
            }
            public new void Print()
            {
                base.Print();
                Console.WriteLine("Rectangle. Lengths: {0};{1}\n", XLength, YLength);
            }
        }
        static void Main(string[] args)
        {
            //ACipher aCipher = new ACipher();
            //string s1 = aCipher.Encode("abcde");
            //string s2 = aCipher.Decode(s1);

            //BCipher bCipher = new BCipher();
            //string s3 = bCipher.Encode("abcde");
            //string s4 = bCipher.Decode(s3);

            Rectangle rectangle = new Rectangle(0, 0, 1, 1, "green", true);
            rectangle.Print();
            rectangle.MoveHorizontal(1);
            rectangle.MoveVertical(-1);
            rectangle.Print();
            Console.Read();
        }
    }
}
