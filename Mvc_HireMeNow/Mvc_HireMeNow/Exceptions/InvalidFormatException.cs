using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Mvc_HireMeNow.Exceptions
{
    [Serializable]
    public class InvalidFormatException:Exception
    {
        public InvalidFormatException() { }
        public InvalidFormatException (string message)
        : base(message)
        {
        }
    }
}
