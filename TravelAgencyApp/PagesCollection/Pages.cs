using OpenQA.Selenium.Support.PageObjects;
using TravelAgencyApp.Ultils;

namespace TravelAgencyApp.PagesCollection
{
    public static class Pages 
    {
        public static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserBase.Driver, page);
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
        public static GooglePage GooglePage
        {
            get
            {
                return GetPage<GooglePage>();
            }
        }
        public static HomePage HomePage
        {
            get
            {
                return GetPage<HomePage>();
            }
        }
    }
}