using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EasyCrudLibrary.GSEnums;

namespace EasyCrudLibrary.Model
{
    public class AdvanceFilterByModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public ConditionENUM Condition { get; set; }
    }
}
