using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card.Validation.Web.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TableAttribute : Attribute
    {
        public string Name { get; set; }

        public TableAttribute(string name)
        {
            Name = name;
        }

        public string Schema { get; set; }
    }
}
