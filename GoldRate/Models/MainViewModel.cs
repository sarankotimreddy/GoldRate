using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;


namespace GoldRate.Models
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _onzPrice;
        [ObservableProperty]
        private string _tnPrice;
        [ObservableProperty]
        private string _fnPrice;
        [ObservableProperty]
        private string _nfPrice;
        [ObservableProperty]
        private string _ttPrice;
        [ObservableProperty]
        private string _toPrice;
        [ObservableProperty]
        private string _ePrice;
        [ObservableProperty]
        private bool _isVisible = true;
        [ObservableProperty]
        private string _silverOnz;
        [ObservableProperty]
        private string _time;
        [ObservableProperty]
        private string _hPrice;
        [ObservableProperty]
        private string _fPrice;
        [ObservableProperty]
        private string _ozPrice;
        [ObservableProperty]
        private string _twPrice;
        [ObservableProperty]
        private string _tePrice;
        [ObservableProperty]
        private string _fiPrice;
        [ObservableProperty]
        private string _tfPrice;
        [ObservableProperty]
        private string _oPrice;
        [ObservableProperty]
        private string _maPrice;
        [ObservableProperty]
        private string _muPrice;
        [ObservableProperty]
        private string _nmPrice;
        [ObservableProperty]
        private string _gPrice;
        [ObservableProperty]
        private string _lPrice;
        [ObservableProperty]
        private string _hlPrice;
        [ObservableProperty]
        private string _rlPrice;
        [ObservableProperty]
        private string _blPrice;

        public double ResponsiveFontSize
        {
            get
            {
                Double.TryParse(Preferences.Get("FontSize", "20"), out double width);
                return width;
            }
        }
        [RelayCommand]
        private void HidePremiumBlock()
        {
            IsVisible = !IsVisible;
        }

        [RelayCommand]
        private async Task OpenBrowser(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                await Launcher.Default.OpenAsync(new Uri(url));
            }
        }
    }
}
