using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using ExperimentalUI.BlazorWebApp.Interfaces;
using ExperimentalUI.BlazorWebApp.Models;
using ExperimentalUI.BlazorWebApp.Models.Options;
using ExperimentalUI.BlazorWebApp.ViewModelMessages;

namespace ExperimentalUI.BlazorWebApp.ViewModels;

[ObservableRecipient]
public partial class AnimalsOverviewViewModel : ViewModelBase
{
    private readonly IRestService<Animal, AnimalEndpointOptions> _animalRestService;

    [ObservableProperty]
    private List<Animal> _animals;

    [ObservableProperty]
    private bool _showCardView = true;

    public AnimalsOverviewViewModel(IRestService<Animal, AnimalEndpointOptions> animalRestService)
    {
        _animalRestService = animalRestService;
    }

    public override async Task Loaded()
    {
        Animals = (await _animalRestService.GetAllAsync()).ToList();

    }

    public override async Task Rendered(bool firstRender)
    {
        if (!ShowCardView)
        {
            StrongReferenceMessenger.Default.Send(new AnimalsMessage(Animals));
        }
    }
}