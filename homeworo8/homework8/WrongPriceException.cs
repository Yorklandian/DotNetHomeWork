using System;
using System.Collections.Generic;
using System.Text;

namespace homework8
{
    //Exceptions
    public class WrongPriceException:ApplicationException
    {
        public WrongPriceException(double price)
            : base($"Count {price} is invalid.") { }
    }
    public class WrongCountException : ApplicationException
    {
        public WrongCountException(int count)
            : base($"Count {count} is invalid.") { }
    }
    public class NullArgumentException : ApplicationException
    {
        public NullArgumentException(string argName)
            : base($"Argument \"{argName}\" is null.") { }
        public NullArgumentException() { }
    }
}
