using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twelve
{
    public class Program
    {

        public enum Account
        {
            Current = 1,
            Saving = 2
        };

        public class BankTransaction
        {
            readonly double Sum;
            DateTime Dt;
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

            Queue<BankTransaction> transactions = new Queue<BankTransaction>();

            public void Put(int balance)
            {
                Balance += balance;
                BankTransaction bt = new BankTransaction(balance);
                transactions.Enqueue(bt);
            }
            public void Take(int balance)
            {
                if (Balance >= balance)
                {
                    Balance -= balance;
                    BankTransaction bt = new BankTransaction(-balance);
                    transactions.Enqueue(bt);
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
            public static bool operator == (Bill b1, Bill b2)
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

        
        static void Main(string[] args)
        {
            BookRepository bookRepository = new BookRepository();
            Console.WriteLine(bookRepository.ToString());
            bookRepository.RegisterHandler("Name");
            bookRepository.sortHandler.Invoke();
            Console.WriteLine(bookRepository.ToString());
            bookRepository.RegisterHandler("Author");
            bookRepository.sortHandler.Invoke();
            Console.WriteLine(bookRepository.ToString());
            bookRepository.RegisterHandler("Publisher");
            bookRepository.sortHandler.Invoke();
            Console.WriteLine(bookRepository.ToString());
            Console.Read();
        }
    }
}
