
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
        public void Search(string textToSearch)
        {
            By q = Browser.GetElementBy("name", "q");
            Browser.EnterText(q, textToSearch);
            Browser.PressEnter("name","q");
        }
    }
}
