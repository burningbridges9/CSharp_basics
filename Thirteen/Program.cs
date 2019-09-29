using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twelve;

namespace Thirteen
{
    class Program
    {
        public enum Account
        {
            Current = 1,
            Saving = 2
        };

        public class BankTransaction
        {
            double Sum { get; }
            DateTime Dt { get; }
            public BankTransaction(double sum)
            {
                Sum = sum;
                Dt = DateTime.Now;
            }
            public override string ToString()
            {
                return "Transaction:\n" + Dt.ToString() + '\n' + Sum + '\n';
            }
        }

        public class Bill : IDisposable
        {
            private static int count = 0;
            public int Number { get; private set; }
            public double Balance { get; private set; }
            public Account AccountType { get; private set; }
            public string Holder { get; private set; }
            List<BankTransaction> transactions = new List<BankTransaction>();
            public BankTransaction this[int index]
            {
                get
                {
                    return transactions[index];
                }
            }
            public void Put(int balance)
            {
                Balance += balance;
                BankTransaction bt = new BankTransaction(balance);
                transactions.Add(bt);
            }
            public void Take(int balance)
            {
                if (Balance >= balance)
                {
                    Balance -= balance;
                    BankTransaction bt = new BankTransaction(-balance);
                    transactions.Add(bt);
                }
            }
            public void ChangeAccountType(Account accountType)
            {
                AccountType = accountType;
            }
            void Increment()
            {
                count++;
            }
            internal Bill()
            {
                Increment();
                Number = count;
            }
            internal Bill(Account accountType) : this()
            {
                AccountType = accountType;
            }
            internal Bill(double balance) : this()
            {
                Balance = balance;
            }
            internal Bill(double balance, Account accountType) : this()
            {
                Balance = balance;
                AccountType = accountType;
            }

            public override string ToString()
            {
                string str = "Bill info:\n" + Number.ToString() + '\n' + Balance.ToString() + '\n' + AccountType.ToString() + '\n';
                return str;
            }
            public static bool operator !=(Bill b1, Bill b2)
            {
                if (b1.Number != b2.Number || b1.Balance != b2.Balance || b1.AccountType != b2.AccountType)
                    return true;
                else
                    return false;
            }
            public static bool operator ==(Bill b1, Bill b2)
            {
                if (b1 != b2)
                    return false;
                else
                    return true;
            }
            public override bool Equals(object obj)
            {
                return this == (Bill)obj;
            }
            public void Dispose()
            {
                string fiOut = Directory.GetCurrentDirectory() + "\\outPut.txt";
                string text = "";
                foreach (BankTransaction bt in transactions)
                {
                    text += bt.ToString();

                }
                File.WriteAllText(fiOut, text);
                GC.SuppressFinalize(this);
            }
        }


        [DeveloperInfo("Rostam", "KSU")]
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
            internal Building(double Height, int Floors, int FlatsNumber, int PorchNumber)
            {
                Number = ++count;
                this.Height = Height;
                this.Floors = Floors;
                this.FlatsNumber = FlatsNumber;
                this.PorchNumber = PorchNumber;
            }
            internal Building()
            {
                Number = ++count;
            }
            internal Building(int Floors, int FlatsNumber, int PorchNumber)
            {
                Number = ++count;
                this.Floors = Floors;
                this.FlatsNumber = FlatsNumber;
                this.PorchNumber = PorchNumber;
            }
            internal Building(int FlatsNumber, int PorchNumber)
            {
                Number = ++count;
                this.Floors = Floors;
                this.FlatsNumber = FlatsNumber;
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

        public class BuildingRepository
        {
            Building[] buildings = new Building[10];
            public Building this[int index]
            {
                get
                {
                    if (index<10)
                    {
                        return buildings[index];
                    }
                    else
                    {
                        throw new Exception("wrong index");
                    }
                }
                set
                {
                    if (index < 10)
                    {
                        buildings[index] = value;
                    }
                    else
                    {
                        throw new Exception("wrong index");
                    }
                }
            }
            public BuildingRepository()
            {
                for (int i = 0; i < 10; i++)
                    buildings[i] = new Building(i + 2, i + 30, i + 1);
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
