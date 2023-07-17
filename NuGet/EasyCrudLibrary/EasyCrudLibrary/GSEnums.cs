using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCrudLibrary
{
    public class GSEnums
    {
        public enum WithInQuery
        {
            None,
            NoLock,
            ReadPast
        }

        public enum ExecuteType
        {
            ExecuteReader,
            ExecuteNonQuery
        }

        public enum ConditionENUM
        {
            Like = 0,
            Equal = 1,
            GreaterThan = 2,
            LessThan = 3,
        }
    }
}
