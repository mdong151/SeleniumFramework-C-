using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgencyApp.Ultils;
namespace TravelAgencyApp.Tests
{
    [TestClass]
    public class TestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            Browser.Maximize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Browser.Close();
        }
    }
}
