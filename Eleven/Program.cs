using ElevenBank;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleven
{
    class Program
    {
        static void Main(string[] args)
        {
            BillFactory billFactory = new BillFactory();
            int n = billFactory.CreateAccount(10, Account.Current);
        }
    }
}
