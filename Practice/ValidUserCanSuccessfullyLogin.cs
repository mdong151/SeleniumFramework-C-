using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumFramework;

namespace Practice
{

    [TestClass]
    public class ValidUserCanSuccessfullyLogin : TestBase
    {

        
        public void ValidUserCanSuccessfullyLoginTest()
        {
            PracticePages.LoginPage.GoTo();
            PracticePages.LoginPage.Login("mdong151", "Abcd1234");
            Assert.IsTrue(PracticePages.MyMembershipPage.IsAt(),"A valid user not able to login");
            PracticePages.MyMembershipPage.ClickEditProfileButton();
            Assert.IsTrue(PracticePages.EditProfilePage.IsAt());
        }
    }
}
