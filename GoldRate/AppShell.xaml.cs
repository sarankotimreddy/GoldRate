namespace GoldRate
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("HomePage", typeof(MainPage));
            Routing.RegisterRoute("SettingsPage", typeof(SettingsPage));
        }
    }
}
