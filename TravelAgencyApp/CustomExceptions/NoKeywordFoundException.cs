using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyApp.CustomExceptions
{
    public class NoKeywordFoundException : Exception
    {
        public NoKeywordFoundException(string message) : base(message)
        {
        }
    }
}
