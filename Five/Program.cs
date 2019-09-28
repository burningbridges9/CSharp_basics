using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Five
{
    class Program
    {
        static double Greater(double x, double y)
        {
            return x > y ? x : y;
        }

        static void ChangeNumber(ref double x, ref double y)
        {
            double temp = x;
            x = y;
            y = temp;
        }

        static bool Factorial(int i, out int n)
        {
            checked
            {
                bool res;
                try
                {
                    if (i == 0 || i == 1)
                    {
                        n = 1;
                        return res = true;
                    }
                    else
                    {
                        res = Factorial(i - 1, out n);
                        n = i * n;
                        return res;
                    }
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                    n = 0;
                    return res = false;
                }
            }
        }

        static double Euclid(double a, double b)
        {
            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }
            else
            {
                if (a >= b)
                {
                    return Euclid(a % b, b);
                }
                else
                {
                    return Euclid(a, b % a);
                }
            }
        }

        static double Euclid(double a, double b, double c)
        {
            double abNod = Euclid(a, b);
            double result = Euclid(abNod, c);
            return result;
        }

        static double Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return (Fibonacci(n - 1) + Fibonacci(n - 2));
            }
        }

        static void Main(string[] args)
        {
            //1
            //Console.WriteLine("Enter x, y:");
            //double x, y;
            //x = Convert.ToDouble(Console.ReadLine());
            //y = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("Largest : {0}", Greater(x, y));

            //2
            //ChangeNumber(ref x, ref y);
            //Console.WriteLine("X now : {0}\nY now : {1}", x,y);

            //3
            //do
            //{
            //    int i = Convert.ToInt32(Console.ReadLine());
            //    int n = 0;
            //    bool b = Factorial(i, out n);
            //    Console.WriteLine("Result\nboolean : {0}\nValue : {1}", b, n);
            //}
            //while (true);

            //4
            //Console.WriteLine("Enter x, y, z:");
            //double x, y, z;
            //x = Convert.ToDouble(Console.ReadLine());
            //y = Convert.ToDouble(Console.ReadLine());
            //z = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("Result = "+Euclid(x, y, z));

            //5
            //do
            //{
            //    Console.WriteLine("Enter x:");
            //    int x = Convert.ToInt32(Console.ReadLine());
            //    double res = Fibonacci(x);
            //    Console.WriteLine("Result = " + res);
            //} while (true);


            Console.ReadKey();
        }
    }
}
