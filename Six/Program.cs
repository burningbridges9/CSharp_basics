using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six
{
    class Program
    {
        static bool IsGlas(char c)
        {
            switch (c.ToString().ToLower())
            {
                case "а":
                case "о":
                case "и":
                case "е":
                case "ё":
                case "э":
                case "ы":
                case "у":
                case "ю":
                case "я":
                    return true;
                default:
                    return false;
            }
        }

        static void First(string arg)
        {
            string[] dirArr = Directory.GetCurrentDirectory().Split('\\');
            string file = String.Join("\\", dirArr.TakeWhile(x => String.Compare("bin", x) != 0).ToArray()) + "\\" + arg;
            int sog, glas;
            using (StreamReader reader = new StreamReader(file, Encoding.Default))
            {
                char[] symbols = reader.ReadToEnd().ToCharArray();
                Check(symbols, out sog, out glas);
            }
            Console.WriteLine("Согласных {0}, Гласных {1}", sog, glas);
        }

        static void Check(char [] symbols, out int sog, out int glas)
        {
            sog = glas = 0;
            foreach (char c in symbols)
            {
                if (IsGlas(c))
                    glas++;
                else
                    sog++;
            }
        }


        static void Second()
        {
            try
            {
                System.Random random = new System.Random();
                Console.WriteLine("input n1, m1, n2, m2");
                int n1 = Convert.ToInt32(Console.ReadLine());
                int m1 = Convert.ToInt32(Console.ReadLine());
                int n2 = Convert.ToInt32(Console.ReadLine());
                int m2 = Convert.ToInt32(Console.ReadLine());
                if (m1 != n2)
                    throw new Exception("Wrong sizes");
                double[,] x = new double[n1, m1];
                double[,] y = new double[n2, m2];
                double[,] z = new double[n1, m2];
                for (int i = 0; i < n1; ++i)
                    for (int j = 0; j < m1; ++j)
                        x[i, j] = random.NextDouble();
                Console.WriteLine("Generated X:");
                PrintMatrix(x);
                for (int i = 0; i < n2; ++i)
                    for (int j = 0; j < m2; ++j)
                        y[i, j] = random.NextDouble();
                Console.WriteLine("Generated Y:");
                PrintMatrix(y);
                z = Multiplication(x, y);
                Console.WriteLine("Result Z:");
                PrintMatrix(z);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static double[,] Multiplication(double[,] a, double[,] b)
        {
            double[,] z = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        z[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return z;
        }
        static void PrintMatrix(double[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j].ToString("0.0", CultureInfo.InvariantCulture));
                }
                Console.WriteLine();
            }
        }
        static void PrintVector(double[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine("{0} ", a[i].ToString("0.0", CultureInfo.InvariantCulture));
            }
            Console.WriteLine();
        }


        static void Third()
        {
            System.Random random = new System.Random();
            double[,] x = new double[12, 30];
            for (int i = 0; i < x.GetLength(0); ++i)
                for (int j = 0; j < x.GetLength(1); ++j)
                    x[i, j] = random.NextDouble()*10;
            Console.WriteLine("Generated X:");
            double[] y = new double[12];
            PrintMatrix(x);
            y = GetAverage(x);
            Console.WriteLine("Average X:");
            PrintVector(y);
        }

        static double[] GetAverage(double [,] x)
        {
            double[] y = new double[12];
            for (int i=0; i<x.GetLength(0);i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                    y[i] += x[i, j];
                y[i] /= x.GetLength(1);
            }
            return y;
        }


        static void Fourth(string arg)
        {
            string[] dirArr = Directory.GetCurrentDirectory().Split('\\');
            string file = String.Join("\\", dirArr.TakeWhile(x => String.Compare("bin", x) != 0).ToArray()) + "\\" + arg;
            int sog, glas;
            using (StreamReader reader = new StreamReader(file, Encoding.Default))
            {
                List<char> symbols = reader.ReadToEnd().ToList<char>();
                Check(symbols, out sog, out glas);
            }
            Console.WriteLine("Согласных {0}, Гласных {1}", sog, glas);
        }
        static void Check(List<char> symbols, out int sog, out int glas)
        {
            sog = glas = 0;
            foreach (char c in symbols)
            {
                if (IsGlas(c))
                    glas++;
                else
                    sog++;
            }
        }



        static void Fifth()
        {
            try
            {
                System.Random random = new System.Random();
                Console.WriteLine("input n1, m1, n2, m2");
                int n1 = Convert.ToInt32(Console.ReadLine());
                int m1 = Convert.ToInt32(Console.ReadLine());
                int n2 = Convert.ToInt32(Console.ReadLine());
                int m2 = Convert.ToInt32(Console.ReadLine());
                if (m1 != n2)
                    throw new Exception("Wrong sizes");
                LinkedList<double> row = new LinkedList<double>();
                LinkedList<LinkedList<double>> x = new LinkedList<LinkedList<double>>();                
                LinkedList<LinkedList<double>> y = new LinkedList<LinkedList<double>>();
                LinkedList<LinkedList<double>> z = new LinkedList<LinkedList<double>>();
                for (int i = 0; i < n1; ++i)
                {
                    row.Clear();
                    for (int j = 0; j < m1; ++j)
                    {
                        row.AddLast(random.NextDouble());
                    }
                    x.AddLast(row);
                }
                Console.WriteLine("Generated X:");
                PrintMatrix(x);
                for (int i = 0; i < n2; ++i)
                {
                    row.Clear();
                    for (int j = 0; j < m2; ++j)
                    {
                        row.AddLast(random.NextDouble());
                    }
                    y.AddLast(row);
                }
                Console.WriteLine("Generated Y:");
                PrintMatrix(y);
                //z = Multiplication(x, y);
                //Console.WriteLine("Result Z:");
                //PrintMatrix(z);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static LinkedList<LinkedList<double>> Multiplication(LinkedList<LinkedList<double>> a, LinkedList<LinkedList<double>> b)
        {
            LinkedList<LinkedList<double>> z = new LinkedList<LinkedList<double>>();
            LinkedList<double> row = new LinkedList<double>();
            for (int i = 0; i < a.Count; i++)
            {
                row.Clear();
                for (int j = 0; j < b.First.List.Count; j++)
                {
                    for (int k = 0; k < b.Count; k++)
                    {
                       // z[i, j] += a[i, k] * b[k, j];
                       
                    }
                }
            }
            return z;
        }
        static void PrintMatrix(LinkedList<LinkedList<double>> a)
        {
            foreach(var linkedList in a)
            {
                foreach(var doubleValue in linkedList)
                    Console.Write("{0} ", doubleValue);
                Console.WriteLine();
            }
        }



        enum Month
        {
            Jan = 1,
            Feb = 2,
            Mar = 3,
            Apr = 4,
            May = 5,
            Jun = 6,
            Jul = 7,
            Aug = 8,
            Sep = 9,
            Oct = 10,
            Nov = 11,
            Dec = 12
        }
        static void Sixth()
        {
            System.Random random = new System.Random();
            Dictionary<string, double[]> dictionary = new Dictionary<string, double[]>();
            for (int i = 1; i <= 12; i++)
            {          
                String month = ((Month)i).ToString();
                double[] tempers = new double[30];
                for(int j=0;j<30;j++)
                    tempers[j] = random.NextDouble() * 10;
                dictionary.Add(month, tempers);
            }
            List<double> y = new List<double>(12);
            y = GetAverage(dictionary);
            foreach (double d in y)
                Console.WriteLine("{0}", d);
        }

        static List<double> GetAverage(Dictionary<string, double[]> dictionary)
        {
            List<double> y = new List<double>();
            int i = 0;
            foreach(KeyValuePair<string, double[]> kvp in dictionary)
            {
                double sum = 0;
                foreach (double d in kvp.Value)
                    sum += d;
                sum /= kvp.Value.Length;
                y.Add(sum);
            }
            return y;
        }
        static void Main(string[] args)
        {
            //First(args[0]);
            //Second();
            //Third();
            //Fourth(args[0]);
            //Fifth();
            //Sixth();

            Console.Read();
        }
    }
}
