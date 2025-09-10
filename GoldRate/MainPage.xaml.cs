using GoldRate.Models;
using System.Globalization;

namespace GoldRate
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel ViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            BindingContext = ViewModel;
#if ANDROID
            webview.Navigated += (s, e) =>
            {
                webview.Eval("window.external = { notify: function(msg) { window.location.href = 'invoke://' + encodeURIComponent(msg); } }");
            };
#elif IOS
        webview.Navigated += (s, e) =>
        {
            webview.Eval("window.external = { notify: function(msg) { window.location.href = 'invoke://' + encodeURIComponent(msg); } }");
        };
#endif
            
            webview.Navigating += OnWebViewNavigating;
            webview.Navigated += OnWebViewNavigated;
        }

        private void OnWebViewNavigated(object? sender, WebNavigatedEventArgs e)
        {
            webview.Eval(@"
    setInterval(() => {
        const priceElements = '';
        if (priceElements.length > 1) {
            var price = encodeURIComponent(priceElements[1].innerText);
            window.location.href = 'invoke://' + price;
        }
    }, 2000);
");
        }

        private void OnWebViewNavigating(object? sender, WebNavigatingEventArgs e)
        {
            if (e.Url.StartsWith("invoke://"))
            {
                e.Cancel = true;

                var message = Uri.UnescapeDataString(e.Url.Replace("invoke://", "").Replace("/",""));
                HandleMessageFromJS(message);
            }
        }

        private void HandleMessageFromJS(string message)
        {
            ViewModel.OnzPrice = message;
            if (double.TryParse(message, NumberStyles.Number, CultureInfo.InvariantCulture, out double result) && double.TryParse(premium.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double pre) && double.TryParse(dollar.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double dollear))
            {
               var tnine = (((result+pre)*32.119)*dollear)/ 1000;
                ViewModel.TnPrice = tnine.ToString("F3");
                ViewModel.FnPrice = ((tnine * 0.9999) / 0.999).ToString("F3");
                ViewModel.NfPrice = ((tnine * 0.995) / 0.999).ToString("F3");
                ViewModel.TtPrice = (tnine * 0.917917).ToString("F3");
                ViewModel.ToPrice = (tnine * 0.875875).ToString("F3");
                ViewModel.EPrice = (tnine * 0.750750).ToString("F3");
                ViewModel.Time = "VERSAY JEWELLERY " + DateTime.Now.ToString();
            }
            else
            {
                Console.WriteLine("Invalid number format.");
            }
        }
    }
}
