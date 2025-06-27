using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace FluentWebAssembly.ViewModels
{
    public static class Dependencies
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddScoped<MainViewModel>();
            services.AddScoped<QuestionCardViewModel>();
            return services;
        }
    }

    public interface IViewModelBase : INotifyPropertyChanged
    {
        Task OnInitializedAsync();
        Task OnAfterRenderAsync(bool firstRender);
        Task Loaded();
        ValueTask DisposeAsync();
    }

    public abstract partial class ViewModelBase : ObservableObject, IViewModelBase
    {
        public virtual async Task OnInitializedAsync()
        {
            await Loaded().ConfigureAwait(true);
        }

        protected virtual void NotifyStateChanged() => OnPropertyChanged((string?)null);
        public virtual async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // Perform any initialization logic here
                // await Loaded().ConfigureAwait(false);
            }
            await Task.CompletedTask.ConfigureAwait(false);
        }
        [RelayCommand]
        public virtual async Task Loaded()
        {
            await Task.CompletedTask.ConfigureAwait(false);
        }

        public virtual async ValueTask DisposeAsync()
        {
            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}
