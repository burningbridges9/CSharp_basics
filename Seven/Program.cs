using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seven
{
    class Program
    {
        public enum Account
        {
            Current = 1,
            Saving = 2
        };

        public class Bill
        {
            private static int count=0;
            public int Number { get; private set; }
            public double Balance { get; private set; }
            public Account AccountType { get; private set; }

            //public void ChangeNumber(int number)
            //{
            //    Number = number;
            //}
            public void Put(int balance)
            {
                Balance += balance;
            }
            public void Take(int balance)
            {
                if(Balance>=balance)
                    Balance -= balance;
            }
            public void ChangeAccountType(Account accountType)
            {
                AccountType = accountType;
            }

            //public Bill(int number, double balance, Account accountType)
            //{
            //    Number = number;
            //    Balance = balance;
            //    AccountType = accountType;
            //}
            public Bill(double balance, Account accountType)
            {
                Number = ++count;
                Balance = balance;
                AccountType = accountType;
            }
            public override string ToString()
            {
                string str = "Bill info:\n"+ Number.ToString() + '\n' + Balance.ToString() + '\n' + AccountType.ToString() + '\n';
                return str;
            }
        }

        public class Building
        {
            static int count = 0;
            private int number;
            public int Number
            {
                get
                {
                    return number;
                }
                set
                {
                    number = ++count;
                }
            }
            public double Height { get; set; }
            public int Floors { get; set; }
            public int FlatsNumber { get; set; }
            public int PorchNumber { get; set; }
            public Building(double Height , int Floors, int FlatsNumber, int PorchNumber)
            {
                Number = ++count;
                this.Height = Height;
                this.Floors = Floors;
                this.FlatsNumber = FlatsNumber;
                this.PorchNumber = PorchNumber;
            }

            public double GetFloorHeight()
            {
                return Height / Floors;
            }
            public int GetFlatsNumberInOnePorch()
            {
                return FlatsNumber / PorchNumber;
            }
            public int GetFlatsNumberInOneFloor()
            {
                return GetFlatsNumberInOnePorch() / Floors;
            }
            public override string ToString()
            {
                return "Building info:\n" 
                    + Number.ToString() + '\n' 
                    + Height.ToString() + '\n' 
                    + Floors.ToString() + '\n'
                    + FlatsNumber.ToString() + '\n'
                    + PorchNumber.ToString() + '\n';
            }
        }
        static void Main(string[] args)
        {
            //Bill bill1 = new Bill(100, Account.Current);
            //Console.WriteLine(bill1.ToString());
            //Bill bill2 = new Bill(100, Account.Current);
            //Console.WriteLine(bill2.ToString());
            //Bill bill3 = new Bill(100, Account.Current);
            //Console.WriteLine(bill3.ToString());
            Console.ReadKey();
        }
    }
}
