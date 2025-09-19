namespace GoldRate
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
                var url = Preferences.Get("GoldUrl", "");
                if (url == "")
                {
                    MainPage = new NavigationPage(new SettingsPage());
                }
            else
            {
                MainPage = new AppShell();

            }

            Current.UserAppTheme = AppTheme.Light;
            
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}
    }
}