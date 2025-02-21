using CommunityToolkit.Mvvm.Input;
using Microsoft.FluentUI.AspNetCore.Components;

namespace FluentWebAssembly.ViewModels
{
    public partial class MainViewModel :ViewModelBase
    {
        public DesignThemeModes Mode { get; set; }
        public OfficeColor? OfficeColor { get; set; }

        public MainViewModel()
        {
        }

        [RelayCommand]
        public void ToggleTheme()
        {
            Mode = Mode == DesignThemeModes.Light ? DesignThemeModes.Dark : DesignThemeModes.Light;
        }
    }
}
