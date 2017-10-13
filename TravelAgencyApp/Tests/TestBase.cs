using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TravelAgencyApp.Ultilities;
using TravelAgencyApp.PagesCollection;
namespace TravelAgencyApp.Tests
{
    [TestClass]
    public class TestBase
    {
        [TestInitialize]
        public void Initialize()
        {

            Browser.Initialize();
            Browser.Maximize();
            Console.WriteLine("Initialize sucessfully!");
            
        }

        [TestCleanup]
        public void Cleanup()
        {
            Browser.Close();
            
        }
    }
}
