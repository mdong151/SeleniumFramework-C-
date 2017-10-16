using OpenQA.Selenium.Support.PageObjects;
using TravelAgencyApp.Ultils;

namespace TravelAgencyApp.PagesCollection
{
    public static class Pages 
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

        public static RequestToHandlePage RequestToHandlePage
        {
            get
            {
                return GetPage<RequestToHandlePage>();
            }
        }
    }
}