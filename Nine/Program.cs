using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nine
{
    class Program
    {
        public enum Account
        {
            Current = 1,
            Saving = 2
        };

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
            public Bill()
            {
                Increment();
                Number = count;
            }
            public Bill(Account accountType) : this()
            {
                AccountType = accountType;
            }
            public Bill(double balance) : this()
            {
                Balance = balance;
            }
            public Bill(double balance, Account accountType):this()
            {
                Balance = balance;
                AccountType = accountType;
            }

            public override string ToString()
            {
                string str = "Bill info:\n" + Number.ToString() + '\n' + Balance.ToString() + '\n' + AccountType.ToString() + '\n';
                return str;
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
        public class BankTransaction
        {
           //Operation OperationType;
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

        class Song
        {
            string name; //название песни
            string author; //автор песни
            Song prev; //связь с предыдущей песней в списке
            public void SetName(string n)
            {
                name = n;
            }
            public void SetAuthor(string a)
            {
                author = a;
            }
            public Song(string n, string a)
            {
                name =n;
                author = a;
                prev = null;
            }
            public Song(string n, string a, Song s)
            {
                name = n;
                author = a;
                prev = s;
            }
            public Song()
            { }
            public void SetPrevSong(Song s)
            {
                prev = new Song();
                prev.name = s?.name;
                prev.author = s?.author;
                prev.prev = s?.prev;
            }
            public string Title()
            {
                return "author:" + author + "\nname" + name + '\n';
            }
            public override bool Equals(object d)
            {
                Song s = d as Song;
                if (s != null)
                {
                    if (this.name.Equals(s.name) && this.author.Equals(s.author))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        static void Main(string[] args)
        {
            Song mySong = new Song();
        }
    }
}
