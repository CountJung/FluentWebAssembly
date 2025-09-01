using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentWebAssembly.Models;
using Microsoft.FluentUI.AspNetCore.Components;

namespace FluentWebAssembly.ViewModels
{
    public partial class QuestionCardViewModel : ViewModelBase
    {
        public QuestionModels QuestionModels { get; private set; }
        public QuestionCardViewModel()
        {
            QuestionModels = new QuestionModels();
        }

        [ObservableProperty]
        private int currentCount = 0;
        [ObservableProperty]
        private string testText = "Test";
        [RelayCommand]
        private void IncrementCount()
        {
            CurrentCount++;
        }
        
        public FluentHorizontalScroll HorizontalScroll { get; set; } = default!;
    }
}
