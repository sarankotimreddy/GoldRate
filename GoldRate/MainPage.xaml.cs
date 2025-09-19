using GoldRate.Models;
using System.Globalization;

namespace GoldRate
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel ViewModel { get; set; }
        private System.Timers.Timer _timer;
        public MainPage()
        {
            InitializeComponent();
            var GoldUrl = Preferences.Get("GoldUrl", "");
            webview.Source = $"{GoldUrl}";
            ViewModel = new MainViewModel();
            BindingContext = ViewModel;
            StartTimer();
        }

        private void StartTimer()
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
        }

        private async void _timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                 await HandleMessageFromJS();
            });
        }

        private async Task HandleMessageFromJS()
        {
            var onz = await webview.EvaluateJavaScriptAsync(Preferences.Get("GoldElement", ""));
            var silverOnz = await webview.EvaluateJavaScriptAsync(Preferences.Get("SilverElement", ""));
            ViewModel.OnzPrice = onz;
            ViewModel.SilverOnz = silverOnz;
            if (
                double.TryParse(onz, NumberStyles.Number, CultureInfo.InvariantCulture, out double result) && 
                double.TryParse(premium.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double pre) && 
                double.TryParse(dollar.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double dollear) &&
                double.TryParse(McH.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcH) &&
                double.TryParse(McF.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcF) &&
                double.TryParse(McOz.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcOz) &&
                double.TryParse(McTw.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcTw) &&
                double.TryParse(McTe.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcTe) &&
                double.TryParse(McFi.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcFi) &&
                double.TryParse(McTf.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcTf) &&
                double.TryParse(McO.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcO) &&
                double.TryParse(McMa.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcMa) &&
                double.TryParse(McMu.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcMu) &&
                double.TryParse(McNm.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcNm) &&
                double.TryParse(McG.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcG) &&
                double.TryParse(McL.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcL) &&
                double.TryParse(McHl.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcHl) &&
                double.TryParse(McRl.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcRl) &&
                double.TryParse(McBl.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out double mcBl)
                )
            {
               var tnine = (((result+pre)*32.119)*dollear)/ 1000;
                ViewModel.TnPrice = tnine.ToString("F3");
                var fnPrice = ((tnine * 0.9999) / 0.999);
                ViewModel.FnPrice = fnPrice.ToString("F3");
                ViewModel.NfPrice = ((tnine * 0.995) / 0.999).ToString("F3");
                var ttPrice = (tnine * 0.917917);
                ViewModel.TtPrice = ttPrice.ToString("F3");
                ViewModel.ToPrice = (tnine * 0.875875).ToString("F3");
                ViewModel.EPrice = (tnine * 0.750750).ToString("F3");
                ViewModel.Time = Preferences.Get("Company", "VERSAY JEWELLERY") + " " + DateTime.Now.ToString();
                ViewModel.HPrice = ((fnPrice * 100) + mcH).ToString("F3");
                ViewModel.FPrice = ((fnPrice * 50) + mcF).ToString("F3");
                ViewModel.OzPrice = ((fnPrice * 31.10) + mcOz).ToString("F3");
                ViewModel.TwPrice = ((fnPrice * 20) + mcTw).ToString("F3");
                ViewModel.TePrice = ((fnPrice * 10) + mcTe).ToString("F3");
                ViewModel.FiPrice = ((fnPrice * 5) + mcFi).ToString("F3");
                ViewModel.TfPrice = ((fnPrice * 2.5) + mcTf).ToString("F3");
                ViewModel.OPrice = ((fnPrice * 1) + mcO).ToString("F3");
                ViewModel.MaPrice = ((ttPrice * 72) + mcMa).ToString("F3");
                ViewModel.MuPrice = ((ttPrice * 36) + mcMu).ToString("F3");
                ViewModel.NmPrice = ((ttPrice * 18) + mcNm).ToString("F3");
                ViewModel.GPrice = ((ttPrice * 8) + mcG).ToString("F3");
                ViewModel.LPrice = ((ttPrice * 7.2) + mcL).ToString("F3");
                ViewModel.HlPrice = ((ttPrice * 3.6) + mcHl).ToString("F3");
                ViewModel.RlPrice = ((ttPrice * 1.80) + mcRl).ToString("F3");
                ViewModel.BlPrice = ((ttPrice * 0.90) + mcBl).ToString("F3");
            }
            else
            {
                Console.WriteLine("Invalid number format.");
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _timer.Stop();
        }
        protected override void OnAppearing() 
        { 
            base.OnAppearing();
            _timer.Start();
        }
    }
}
