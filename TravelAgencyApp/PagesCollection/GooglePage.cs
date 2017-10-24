
using OpenQA.Selenium;
using TravelAgencyApp.Ultils;

namespace TravelAgencyApp.PagesCollection
{
    public class GooglePage
    {
        public void GoTo()
        {
            Browser.GoToPage("https://google.com",false);
        }
        public void Search()
        {
            By q = Browser.GetElementBy("name", "q");
            Browser.EnterText(q,"ahihi");
            Browser.PressEnter(q);
        }
    }
}
