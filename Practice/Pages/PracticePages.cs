using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework;

namespace Practice
{
    public static class PracticePages
    {
        public static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browser.Driver, page);
            return page;
        }
        public static LoginPage LoginPage
        {
            get
            {
                return GetPage<LoginPage>();
            }
        }

        public static MyMembershipPage MyMembershipPage
        {
            get
            {
                return GetPage<MyMembershipPage>();
            }
        }

        public static EditProfilePage EditProfilePage
        {
            get
            {
                return GetPage<EditProfilePage>();
            }
        }

        //public static CreatePage CreatePage
        //{
        //   get
        //    {
        //        return GetPage<CreatePage>();
        //    }
        //}

       


    }
}