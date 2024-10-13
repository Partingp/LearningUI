using System.ComponentModel;

namespace ExperimentalUI.BlazorWebApp.ViewModels
{
    public interface IViewModel
        : INotifyPropertyChanged, INotifyPropertyChanging
    {
        Task OnInitializedAsync();
        Task OnAfterRenderAsync(bool firstRender);
        Task OnParametersSetAsync();
        Task Loaded();
        Task ParametersSet();
    }
}
