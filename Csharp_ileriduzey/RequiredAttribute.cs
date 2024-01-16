using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_ileriduzey
{
    //ozel attrıbute tanımlama
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : Attribute //class adının yanında Attribute girilmesi zorunlu ve Attribute sınıfından miras almalı
    {
    }
}
