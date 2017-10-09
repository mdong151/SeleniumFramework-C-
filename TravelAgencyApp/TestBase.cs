using NUnit.Framework;
using SeleniumFramework;
using System;

namespace TravelAgencyApp
{

    public class TestBase
    {
        [SetUp]
        public void Initialize()
        {
            Browser.Initialize();
            Browser.Maximize();
            Console.WriteLine("Initialize sucessfully!");
            
        }

        [TearDown]
        public void Cleanup()
        {
            //Browser.Close();
        }
    }
}
