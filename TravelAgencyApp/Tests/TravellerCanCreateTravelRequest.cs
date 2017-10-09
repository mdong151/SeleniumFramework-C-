
using NUnit.Framework;
using SeleniumFramework;
using System;

namespace TravelAgencyApp 
{    
    public class TravellerCanCreateTravelRequest : TestBase
    {
       [Test]
       public void CreateTravelRequest()
        {
            TravelAgencyPages.CreatePage.GoTo();
            TravelAgencyPages.CreatePage.FakeAuthenTo("bach phuong chi");
            TravelAgencyPages.CreatePage.FillPlanTrip(); 
        }
    }
}
