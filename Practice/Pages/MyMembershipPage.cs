using SeleniumFramework;
using System;

namespace Practice
{
    public class MyMembershipPage
    {
        #region constants
        private int PAGE_LOAD_TIMEOUT = 10;
        #endregion

        public bool IsAt()
        {
            Browser.WaitUntilElementIsDisplayed("xpath", "//title", PAGE_LOAD_TIMEOUT);
            return Browser.IsAt("My Membership");
        }
        public void ClickEditProfileButton()
        {
            Browser.Select("xpath", "//span[contains(text(),'Edit Profile')]");
        }
    }
}