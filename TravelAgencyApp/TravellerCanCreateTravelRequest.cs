//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using SeleniumFramework;
using System;
using TravelAgencyApp.Pages;

namespace TravelAgencyApp 
{
    
    public class TravellerCanCreateTravelRequest : TestBase
    {
       [Test]
       public void CreateTravelRequest()
        {
            //Pages.CreatePage.GoTo();
            //Pages.CreatePage.FakeAuthenTo("bach phuong chi");
            //Pages.CreatePage.FillPlanTrip();
            TravelAgencyPages.CreatePage.GoTo();
            
            TravelAgencyPages.CreatePage.FakeAuthenTo("bach phuong chi");
            TravelAgencyPages.CreatePage.FillPlanTrip();
            //random comments
            
            
        }
    }
}
