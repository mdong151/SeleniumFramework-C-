using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgencyApp.PagesCollection;
using TravelAgencyApp.Ultils;

namespace TravelAgencyApp.Tests
{
    [TestClass]
    public class CreateTravelRequest : TestBase
    {
       [TestMethod,TestCategory("RegressionTest")]
       public void TravelAgentCanQuicklyCreateTravelRequestForTraveller()
        {
            Pages.CreatePage.GoTo();
            Pages.CreatePage.FakeAuthenTo("roxana");
            Pages.CreatePage.FillPlanTrip("ATP", "tran hai linh", "train", "20/10/2017", "25/10/2017", "Ho Chi Minh", "new zealand");
            Pages.CreatePage.SubmitPlanATripForm();
            Assert.IsTrue(Pages.CreatePage.GetPopupMessageText().Contains("successfully"));
        }
    }
}
