using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card.Validation.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class IocDomainAttribute : Attribute
    { 
        public string Name { get; }

        public IocDomainAttribute(string name = null)
        {
            Name  = name;
        }
    }
}
