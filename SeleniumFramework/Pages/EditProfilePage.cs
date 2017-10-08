namespace SeleniumFramework
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