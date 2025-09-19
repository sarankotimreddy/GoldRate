namespace GoldRate;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
		UrlEntry.Text = Preferences.Get("GoldUrl", "");
		GoldEntry.Text = Preferences.Get("GoldElement", "");
        SilverEntry.Text = Preferences.Get("SilverElement", "");
        AppFontSize.Text = Preferences.Get("FontSize", "20");
		UserEntry.Text = Preferences.Get("Company", "VERSAY JEWELLERY");
	}

	private void OnSaveClicked(object sender, EventArgs e)
	{
		Preferences.Set("GoldUrl", UrlEntry.Text);
		Preferences.Set("GoldElement", GoldEntry.Text);
        Preferences.Set("SilverElement", SilverEntry.Text);
        Preferences.Set("FontSize", AppFontSize.Text);
		Preferences.Set("Company", UserEntry.Text);
		Application.Current.MainPage = new AppShell();
	}

    private async void OnLinkTapped(object sender, EventArgs e)
    {
        var uri = new Uri("https://github.com/sarankotimreddy");
        await Launcher.Default.OpenAsync(uri);
    }
}