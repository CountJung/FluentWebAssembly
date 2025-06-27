using FluentWebAssembly.ViewModels;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace FluentWebAssembly
{
    public abstract class MvvmComponentBase<TViewModel> : LayoutComponentBase
    where TViewModel : IViewModelBase
    {
        [Inject]
        [NotNull]
#pragma warning disable CS8618
        protected TViewModel ViewModel { get; set; }
#pragma warning restore CS8618

        protected override void OnInitialized()
        {
            // Cause changes to the ViewModel to make Blazor re-render
            ViewModel.PropertyChanged += PropertyChangedHandler;
            base.OnInitialized();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await ViewModel.OnAfterRenderAsync(firstRender);
            }
            await base.OnAfterRenderAsync(firstRender);
        }
        protected override Task OnInitializedAsync()
        {
            return ViewModel.OnInitializedAsync();
        }
        public async ValueTask DisposeAsync()
        {
            ViewModel.PropertyChanged -= PropertyChangedHandler;
            await ViewModel.DisposeAsync().ConfigureAwait(false);
        }
        private async void PropertyChangedHandler(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is TViewModel)
            {
                await Task.Yield();
                await InvokeAsync(() => { StateHasChanged(); });
            }
        }
    }
}
