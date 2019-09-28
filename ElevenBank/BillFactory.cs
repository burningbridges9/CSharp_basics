using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenBank
{
    public class BillFactory
    {
        Hashtable hashtable = new Hashtable();
        public int CreateAccount()
        {
            Bill bill = new Bill();
            hashtable.Add(bill.Number, bill);
            return bill.Number;
        }
        public int CreateAccount(Account accountType)
        {
            Bill bill = new Bill(accountType);
            hashtable.Add(bill.Number, bill);
            return bill.Number;
        }
        public int CreateAccount(double balance)
        {
            Bill bill = new Bill(balance);
            hashtable.Add(bill.Number, bill);
            return bill.Number;
        }
        public int CreateAccount(double balance, Account accountType)
        {
            Bill bill = new Bill(balance, accountType);
            hashtable.Add(bill.Number, bill);
            return bill.Number;
        }
        public void DeleteAccount(int number)
        {
            hashtable.Remove(number);
        }
    }
}
