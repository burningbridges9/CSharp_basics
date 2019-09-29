using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twelve
{

    [DeveloperInfo("Rostam", "08 - 28 - 2019")]
    public class RationalNumber
    {
        int Num { get; set; }
        int Denom { get; set; }
        public RationalNumber(int n, int d)
        {
            Num = n;
            Denom = d;
        }
        public override string ToString()
        {
            return string.Format("{0}/{1}", Num, Denom);
        }

        public static bool operator !=(RationalNumber rn1, RationalNumber rn2)
        {
            if (rn1.Num != rn2.Num || rn1.Denom != rn2.Denom)
                return true;
            else
                return false;
        }
        public static bool operator ==(RationalNumber rn1, RationalNumber rn2)
        {
            if (rn1 != rn2)
                return false;
            else
                return true;
        }
        public static bool operator <(RationalNumber rn1, RationalNumber rn2)
        {
            if (rn1.Num * rn2.Denom < rn2.Num * rn1.Denom)
                return true;
            else
                return false;
        }
        public static bool operator >(RationalNumber rn1, RationalNumber rn2)
        {
            return !(rn1 < rn2);
        }
        public static bool operator <=(RationalNumber rn1, RationalNumber rn2)
        {
            if (rn1.Num * rn2.Denom <= rn2.Num * rn1.Denom)
                return true;
            else
                return false;
        }
        public static bool operator >=(RationalNumber rn1, RationalNumber rn2)
        {
            return !(rn1 <= rn2);
        }
        public static RationalNumber operator +(RationalNumber rn1, RationalNumber rn2)
        {
            return new RationalNumber (rn1.Num * rn2.Denom + rn2.Num * rn1.Denom, rn1.Denom * rn2.Denom);
        }
        public static RationalNumber operator -(RationalNumber rn1, RationalNumber rn2)
        {
            return new RationalNumber(rn1.Num * rn2.Denom + rn2.Num * rn1.Denom, rn1.Denom * rn2.Denom);
        }
        public static RationalNumber operator ++(RationalNumber rn)
        {
            rn.Num += rn.Denom;
            rn.Denom += rn.Denom;
            return rn;
        }
        public static RationalNumber operator --(RationalNumber rn)
        {
            rn.Num -= rn.Denom;
            rn.Denom -= rn.Denom;
            return rn;
        }
        public static RationalNumber operator *(RationalNumber rn1, RationalNumber rn2)
        {
            return new RationalNumber(rn1.Num * rn2.Num, rn1.Denom * rn2.Denom);
        }
        public static int operator /(RationalNumber rn1, RationalNumber rn2)
        {
            return (rn1.Num * rn2.Denom / rn1.Num * rn2.Denom);
        }
        public static int operator %(RationalNumber rn1, RationalNumber rn2)
        {
            return (rn1.Num * rn2.Denom) % (rn1.Num * rn2.Denom);
        }
        public static explicit operator int(RationalNumber rn)
        {
            return rn.Num/rn.Denom;
        }
        public static explicit operator double(RationalNumber rn)
        {
            return ((double)rn.Num / (double)rn.Denom);
        }
        public override bool Equals(object obj)
        {
            return this == (RationalNumber)obj;
        }
    }
}
