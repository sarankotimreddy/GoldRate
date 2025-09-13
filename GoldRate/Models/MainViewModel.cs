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
        private string _time;

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
