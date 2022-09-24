using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CustomExceptions
{
    [Serializable]
     public class InsufficientBallanceException : Exception
    {
        public InsufficientBallanceException() { }

        public InsufficientBallanceException(string name)
            : base(String.Format("The requested ammount is more than user's balance: {0}", name))
        {

        }
    }
}
