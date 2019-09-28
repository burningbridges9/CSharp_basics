using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four
{
    class Program
    {
        enum Month
        {
            Jan = 1,
            Feb = 2,
            Mar = 3,
            Apr = 4,
            May = 5,
            Jun = 6,
            Jul = 7,
            Aug = 8,
            Sep = 9,
            Oct = 10,
            Nov = 11,
            Dec = 12
        }

        static void FirstTask(Dictionary<int, int> dic)
        {
            int day;
            string dayStr = Console.ReadLine();
            Console.WriteLine("Enter day:");
            try
            {
                bool isParsed = Int32.TryParse(dayStr, out day);
                if (!isParsed)
                    throw new Exception("Cannot parse str to int");
                if (day < 1 || day > 365)
                    throw new Exception("Wrong value");
                int daySum = 0;
                int prevDaySum = 0;
                Month m;
                foreach (KeyValuePair<int, int> monthDays in dic)
                {
                    daySum += monthDays.Value;
                    if (daySum < day)
                    {
                        prevDaySum = daySum;
                        continue;
                    }
                    else
                    {
                        int dayNumber = day - prevDaySum;
                        m = (Month)monthDays.Key;
                        Console.WriteLine("Day: {0}, Month: {1}", dayNumber, m);
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void CheckV(out bool isV)
        {
            int year;
            string yearStr = Console.ReadLine();
            isV = false;
            Console.WriteLine("Enter year:");
            try
            {
                bool isParsed = Int32.TryParse(yearStr, out year);
                if (!isParsed)
                    throw new Exception("Cannot parse str to int");
                if (year < 1)
                    throw new Exception("Wrong value");
                if (year%4==0)
                {
                    if (year % 100 == 0)
                        isV = false;
                    if (year % 400 == 0)
                        isV = true;
                }
                else
                {
                    isV = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            Dictionary<int, int> monthDaysV = new Dictionary<int, int> { { 1, 31 }, { 2, 28 }, { 3, 31 },
                                                                       { 4, 30 }, { 5, 31 }, { 6, 30 },
                                                                       { 7,31 },{8,31 }, {9,30 },
                                                                       { 10,31 },{11,30 }, {12,30 }};
            Dictionary<int, int> monthDaysN = new Dictionary<int, int> { { 1, 31 }, { 2, 29 }, { 3, 31 },
                                                                       { 4, 30 }, { 5, 31 }, { 6, 30 },
                                                                       { 7,31 },{8,31 }, {9,30 },
                                                                       { 10,31 },{11,30 }, {12,30 }};
            bool isV;
            CheckV(out isV);
            if (isV)
                FirstTask(monthDaysV);
            else
                FirstTask(monthDaysN);
            Console.ReadKey();
        }
    }
}
