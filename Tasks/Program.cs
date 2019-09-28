using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void FirstTask()
        {
            Console.WriteLine("Enter your name:");
            string str = Console.ReadLine();
            Console.WriteLine("Hello, {0}", str);
        }
        static void SecondTask()
        {
            Console.WriteLine("Enter 2 numbers:");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int res;
            try
            {
                res = a / b;
                Console.WriteLine("Res = " + res);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static void ThirdTask()
        {
            Console.WriteLine("Char:");
            int code = Console.Read();
            char c = Convert.ToChar(++code);
            Console.Write(c);
        }
        static void FourthTask()
        {
            Console.WriteLine("a , b , c coefs:");
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            double c = Convert.ToDouble(Console.ReadLine());
            double droot, x, y;

            try
            {
                droot = Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);
                if (double.IsNaN(droot))
                    throw new Exception("can't get roots");
                x = (-b + droot) / (2 * a);
                y = (-b - droot) / (2 * a);
                Console.WriteLine("x = {0}\n y = {1}",x ,y);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            //FirstTask();
            //SecondTask();
            //ThirdTask();
            FourthTask();
            Console.ReadKey();
        }
    }
}
