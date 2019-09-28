using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenBank
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
}
