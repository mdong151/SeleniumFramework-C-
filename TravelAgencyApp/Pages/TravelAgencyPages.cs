using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework;
namespace TravelAgencyApp.Pages
{
    public static class TravelAgencyPages
    {
        public static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browser.Driver, page);
            return page;
        }

        public static CreatePage CreatePage
        {
            get
            {
                return GetPage<CreatePage>();
            }
        }

       


    }
}