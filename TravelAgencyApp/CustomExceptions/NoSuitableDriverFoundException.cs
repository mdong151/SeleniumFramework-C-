using System;


namespace TravelAgencyApp.CustomExceptions
{
    public class NoSuitableDriverFoundException : Exception
    {
        public NoSuitableDriverFoundException(string msg) : base(msg)
        {
            
        }
    }
}
