using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


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
                var width = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
                return width switch
                {
                    < 360 => 14,
                    < 420 => 16,
                    < 600 => 18,
                    < 800 => 40,
                    _ => 80
                };
            }
        }
        [RelayCommand]
        private void HidePremiumBlock()
        {
            IsVisible = !IsVisible;
        }
    }
}
