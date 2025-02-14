using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FluentWebAssembly.ViewModels
{
    public partial class CounterViewModel : ViewModelBase
    {
        [ObservableProperty]
        private int currentCount = 0;
        [ObservableProperty]
        private string testText = "Test";
        [RelayCommand]
        private void IncrementCount()
        {
            CurrentCount++;
        }
    }
}
