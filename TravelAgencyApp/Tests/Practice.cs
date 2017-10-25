
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgencyApp.PagesCollection;

namespace TravelAgencyApp.Tests
{
    [TestClass]
    public class Practice : TestBase
    {
        [TestMethod, TestCategory("Practice")]
        public void PracticeTest()
        {
            Pages.GooglePage.GoTo();
            Pages.GooglePage.Search("ahihi");
        }
        [TestMethod, TestCategory("Practice")]
        public void PracticeTest2()
        {
            Pages.GooglePage.GoTo();
            Pages.GooglePage.Search("abc");
        }
        [TestMethod, TestCategory("Practice")]
        public void PracticeTest3()
        {
            Pages.GooglePage.GoTo();
            Pages.GooglePage.Search("thu ngay thang nam");
        }
    }
}
