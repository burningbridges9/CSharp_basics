using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twelve
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DeveloperInfoAttribute : System.Attribute
    {
        public string Developer { get; set; }
        public DeveloperInfoAttribute(string developer, string date)
        {
            Developer = developer;
            Date = date;
        }
        public string Date{ get; set ;}
    }
}
