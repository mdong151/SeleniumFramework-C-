using System;

namespace TravelAgencyApp.CustomExceptions
{
    public class NoKeywordFoundException : Exception
    {
        public NoKeywordFoundException(string message) : base(message)
        {
        }
    }
}
