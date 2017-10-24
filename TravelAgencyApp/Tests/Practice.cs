
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgencyApp.PagesCollection;

namespace TravelAgencyApp.Tests
{
    [TestClass]
    public class Practice : TestBase
    {
        [TestMethod]
        public void PracticeTest()
        {
            Pages.GooglePage.GoTo();
            Pages.GooglePage.Search();
        }
    }
}
