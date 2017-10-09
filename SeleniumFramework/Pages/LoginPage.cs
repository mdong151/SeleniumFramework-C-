using System;

namespace SeleniumFramework
{
    public class LoginPage
    {
        public void GoTo()
        {
            Browser.GoTo("https://www.qtptutorial.net/wp-login.php");
        }

        public void Login(string username, string password)
        {
            Browser.EnterText("ID", "user_login", username);
            Browser.EnterText("Id", "user_pass", password);
            Browser.Select("iD", "wp-submit");
        }

        public bool IsAt()
        {
            //return Browser.Title.Contains("");
            return Browser.IsAt(" ‹ Log In");
        }
    }
}