using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ExperimentalUI.BlazorWebApp.Models;
using ExperimentalUI.BlazorWebApp.ViewModelMessages;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace ExperimentalUI.BlazorWebApp.ViewModels;

[ObservableRecipient]
public partial class AnimalTableViewModel : ViewModelBase, IRecipient<AnimalsMessage>
{
    private readonly NavigationManager _navigationManager;

    [ObservableProperty]
    private IQueryable<Animal> _animals;

    [ObservableProperty]
    private PaginationState _pagination = new() { ItemsPerPage = 5 };

    public AnimalTableViewModel(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;

        StrongReferenceMessenger.Default.Register<AnimalsMessage>(this, (_, message) => Receive(message));
    }

    [RelayCommand]
    public void NavigateToAnimalDetails(Guid? id)
    {
        //TODO - See if header can be excluded from OnRowClick event
        if (id != Guid.Empty)
        {
            _navigationManager.NavigateTo($"/animals/{id}");
        }

    }

    public void Receive(AnimalsMessage message)
    {
        Animals = message.Value.AsQueryable();
    }
}