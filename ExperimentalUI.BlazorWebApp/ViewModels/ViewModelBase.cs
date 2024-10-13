using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ExperimentalUI.BlazorWebApp.ViewModels;

public abstract partial class ViewModelBase : ObservableObject, IViewModel
{
    public virtual async Task OnInitializedAsync()
    {
        await Loaded().ConfigureAwait(true);
    }

    public virtual async Task OnAfterRenderAsync(bool firstRender)
    {
        await Rendered(firstRender).ConfigureAwait(true);
    }

    public virtual async Task OnParametersSetAsync()
    {
        await ParametersSet().ConfigureAwait(true);
    }

    protected virtual void NotifyStateChanged() => OnPropertyChanged((string?)null);

    [RelayCommand]
    public virtual async Task Loaded()
    {
        await Task.CompletedTask.ConfigureAwait(false);
    }

    [RelayCommand]
    public virtual async Task Rendered(bool firstRender)
    {
        await Task.CompletedTask.ConfigureAwait(false);
    }

    [RelayCommand]
    public virtual async Task ParametersSet()
    {
        await Task.CompletedTask.ConfigureAwait(false);
    }
}
