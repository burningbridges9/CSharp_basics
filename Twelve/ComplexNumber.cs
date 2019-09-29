using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twelve
{
    class ComplexNumber
    {
        int Real { get; set; }
        int Imag { get; set; }
        public ComplexNumber(int r, int i)
        {
            Real = r;
            Imag = i;
        }
        public override string ToString()
        {
            if (Imag>=0)
                return string.Format("{0}+{1}*i", Real, Imag);
            else
                return string.Format("{0}{1}*i", Real, Imag);
        }

        public static bool operator !=(ComplexNumber cn1, ComplexNumber cn2)
        {
            if (cn1.Real != cn2.Real || cn1.Imag != cn2.Imag)
                return true;
            else
                return false;
        }
        public static bool operator ==(ComplexNumber cn1, ComplexNumber cn2)
        {
            if (cn1 != cn2)
                return false;
            else
                return true;
        }     
        public static ComplexNumber operator +(ComplexNumber cn1, ComplexNumber cn2)
        {
            return new ComplexNumber(cn1.Real + cn2.Real, cn1.Imag + cn2.Imag);
        }
        public static ComplexNumber operator -(ComplexNumber cn1, ComplexNumber cn2)
        {
            return new ComplexNumber(cn1.Real - cn2.Real, cn1.Imag - cn2.Imag);
        }
        public static ComplexNumber operator *(ComplexNumber cn1, ComplexNumber cn2)
        {
            return new ComplexNumber(cn1.Real * cn2.Real - cn1.Imag * cn2.Imag, cn1.Real * cn2.Imag+ cn1.Imag * cn2.Real);
        }
        public override bool Equals(object obj)
        {
            return this == (ComplexNumber)obj;
        }
    }
}
