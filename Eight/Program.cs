using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eight
{
    class Program
    {
        public enum Account
        {
            Current = 1,
            Saving = 2
        };

        public class Bill
        {
            private static int count = 0;
            public int Number { get; private set; }
            public double Balance { get; private set; }
            public Account AccountType { get; private set; }

            //public void ChangeNumber(int number)
            //{
            //    Number = number;
            //}
            public void Put(int balance)
            {
                Balance += balance;
            }
            public void Take(int balance)
            {
                if (Balance >= balance)
                    Balance -= balance;
            }
            public void ChangeAccountType(Account accountType)
            {
                AccountType = accountType;
            }

            //public Bill(int number, double balance, Account accountType)
            //{
            //    Number = number;
            //    Balance = balance;
            //    AccountType = accountType;
            //}
            public Bill(double balance, Account accountType)
            {
                Number = ++count;
                Balance = balance;
                AccountType = accountType;
            }

            public void SendMoney(Bill b, double money)
            {
                if(Balance >= money)
                {
                    b.Balance += money;
                    this.Balance -= money;
                }
            }
            public override string ToString()
            {
                string str = "Bill info:\n" + Number.ToString() + '\n' + Balance.ToString() + '\n' + AccountType.ToString() + '\n';
                return str;
            }
        }


        static string Reverse(string str)
        {
            string newStr = str.Reverse().ToString();
            return newStr;
        }
        static void Third()
        {
            Console.WriteLine("enter file name:");
            string file = Console.ReadLine();
            FileInfo fi = new FileInfo(file);
            if(fi.Exists)
            {
                string fiOut = file.Substring(0, file.LastIndexOf("\\"))+"\\output.txt";
                
                using (StreamReader sr = new StreamReader(file, Encoding.Default))
                {
                    string text = sr.ReadToEnd().ToUpper();
                    File.WriteAllText(fiOut, text);
                }       
            }
            else
            {
                Environment.Exit(0);
            }
        }

        static void CheckFromattable(object obj)
        {
            if (obj is IFormattable)
            {
                Console.WriteLine("obj is formattable");
                object res = obj as IFormattable;
                Type[] types = obj.GetType().GetInterfaces();
                Console.WriteLine("Containing types: ");
                foreach (Type t in types)
                {
                    Console.WriteLine(t);
                }
                Console.WriteLine("Cast result: " + res.ToString());
            }
            else
            {
                Console.WriteLine("obj is not formattable");
                object res = obj as IFormattable;
                Type[] types = obj.GetType().GetInterfaces();
                Console.WriteLine("Containing types: ");
                foreach (Type t in types)
                {
                    Console.WriteLine(t);
                }
                var v = res?.ToString();
                Console.WriteLine("Cast result: " + v);
            }
        }

        static void Fifth()
        {
            string file = @"C:\Users\Rustam\Documents\Visual Studio 2017\Projects\Tasks\Eight\mails.txt";
            FileInfo fi = new FileInfo(file);
            string fiOut = file.Substring(0, file.LastIndexOf("\\")) + "\\mailsOutput.txt";
            
            using (StreamReader sr = new StreamReader(file, Encoding.Default))
            {
                string[] nameMails = sr.ReadToEnd().Split('\n');
                string str = string.Empty;
                foreach(string s in nameMails)
                {
                    var temp = s;
                    GetMail(ref temp);
                    str+=temp.TrimStart()+"\n";
                }
                File.WriteAllText(fiOut, str);
            }
        }

        static void GetMail(ref string str)
        {
            str = (str.Split('#'))[1];
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
            //   Third();
            //object o1 = new DateTime() as Object;
            //object o2 = (object)(new Bill(1,Account.Saving));
            //CheckFromattable(o1);
            //CheckFromattable(o2);

            //Fifth();


            List<Song> listSongs = new List<Song>();
            for (int i=0; i< 4;i++)
            {
                Song s = new Song();
                s.SetName(i.ToString());
                s.SetAuthor(i.ToString());
                if (i!=0)
                    s.SetPrevSong(listSongs.Last());
                listSongs.Add(s);
            }
            bool b = listSongs.First().Equals(listSongs[1]);
            if (b)
                Console.WriteLine("Eq");
            else
                Console.WriteLine("Not Eq");
            Console.ReadKey();
        }
    }
}
