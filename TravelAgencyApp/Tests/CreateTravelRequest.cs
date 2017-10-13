using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgencyApp.PagesCollection;

namespace TravelAgencyApp.Tests
{
    [TestClass]
    public class CreateTravelRequest : TestBase
    {
       [TestMethod]
       public void TravelAgentCanQuicklyCreateTravelRequestForTraveller()
        {
            Pages.CreatePage.GoTo();
            //Pages.CreatePage.FakeAuthenTo("roxana");
            Pages.CreatePage.FillPlanTrip("plane", "tran hai linh", "train", "20/10/2017", "25/10/2017", "Ho Chi Minh", "new zealand");
            Pages.CreatePage.SubmitPlanATripForm();
            Assert.IsTrue(Pages.CreatePage.GetPopupMessage().Contains("successfully"));
            Assert.IsTrue(Pages.RequestToHandlePage.IsAt());
        }
    }
}
