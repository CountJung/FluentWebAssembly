using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace FluentWebAssembly.ViewModels
{
    public static class Dependencies
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddScoped<CounterViewModel>();
            return services;
        }
    }

    public interface IViewModelBase : INotifyPropertyChanged
    {
        Task OnInitializedAsync();
        Task Loaded();
    }

    public abstract partial class ViewModelBase : ObservableObject, IViewModelBase
    {
        public virtual async Task OnInitializedAsync()
        {
            await Loaded().ConfigureAwait(true);
        }

        protected virtual void NotifyStateChanged() => OnPropertyChanged((string?)null);

        [RelayCommand]
        public virtual async Task Loaded()
        {
            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}
