using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace ExperimentalUI.BlazorWebApp.ViewModels
{
    public class ComponentBaseWithViewModel<TViewModel>
        : ComponentBase
        where TViewModel : IViewModel
    {
        [Inject]
        [NotNull]
        protected TViewModel ViewModel { get; set; } = default!;

        protected override void OnInitialized()
        {
            ViewModel.PropertyChanged += (_, _) => InvokeAsync(StateHasChanged);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            ViewModel.PropertyChanged += (_, _) => InvokeAsync(StateHasChanged);
            base.OnAfterRender(firstRender);
        }

        protected override void OnParametersSet()
        {
            ViewModel.PropertyChanged += (_, _) => InvokeAsync(StateHasChanged);
            base.OnParametersSet();
        }

        protected override Task OnInitializedAsync()
        {
            return ViewModel.OnInitializedAsync();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return ViewModel.OnAfterRenderAsync(firstRender);
        }

        protected override Task OnParametersSetAsync()
        {
            return ViewModel.OnParametersSetAsync();
        }
    }
}
