using SeleniumFramework;

namespace Practice
{
    public class EditProfilePage
    {
        public bool IsAt()
        {
            Browser.SwitchToTab(1);
            return Browser.IsAt("Edit Profile |");
        }

    }
}