namespace GoldRate;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
		UrlEntry.Text = Preferences.Get("URL", "");
		JsEntry.Text = Preferences.Get("Element", "");
		AppFontSize.Text = Preferences.Get("FontSize", "20");
	}

	private void OnSaveClicked(object sender, EventArgs e)
	{
		Preferences.Set("URL", UrlEntry.Text);
		Preferences.Set("Element", JsEntry.Text);
		Preferences.Set("FontSize", AppFontSize.Text);
		DisplayAlert("SUCCESS","Setting Saved Restart Application to take Effect","OK");
	}

    private async void OnLinkTapped(object sender, EventArgs e)
    {
        var uri = new Uri("https://github.com/sarankotimreddy");
        await Launcher.Default.OpenAsync(uri);
    }
}