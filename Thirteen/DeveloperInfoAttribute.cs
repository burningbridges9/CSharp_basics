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
        public DeveloperInfoAttribute(string developer, string organization)
        {
            Developer = developer;
            Organization = organization;
        }
        public string Organization{ get; set ;}
    }
}
