using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three
{
    class Program
    {
        enum Account
        {
            Current = 1,
            Saving = 2
        };
        static void First()
        {
            Account first = Account.Current;
            Account second = Account.Saving;
            Console.WriteLine("First acc is {0} \nSecond acc is {1}", first, second);
        }

        struct AccountInfo
        {
            public int Num { get; set; }
            public Account Type { get; set; }
            public double Balance { get; set; }

            public void Print()
            {
                Console.WriteLine($"Number = {Num} \nType = {Type} \nBalance = {Balance}");
            }
        }

        static void Second()
        {
            AccountInfo acc = new AccountInfo
            {
                Num = 111,
                Type = Account.Current,
                Balance = 2000.0
            };
            acc.Print();
        }

        enum Univer
        {
            KSU,
            KAI,
            KNITU
        }

        struct Worker
        {
            public string Name { get; set; }
            public Univer Type { get; set; }
            public void Print()
            {
                Console.WriteLine($"Name: {Name} \nUniver: {Type}");
            }
        }

        static void Third()
        {
            Worker worker = new Worker
            {
                Name = "Some worker",
                Type = Univer.KSU
            };
            worker.Print();
        }

        static void Main(string[] args)
        {
            //First();
            //Second();
            Third();
            Console.ReadKey();
        }
    }
}
