using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenBank
{
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
}
