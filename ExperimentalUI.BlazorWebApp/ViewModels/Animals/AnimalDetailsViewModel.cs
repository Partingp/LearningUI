using CommunityToolkit.Mvvm.ComponentModel;
using ExperimentalUI.BlazorWebApp.Interfaces;
using ExperimentalUI.BlazorWebApp.Models;
using ExperimentalUI.BlazorWebApp.Models.Options;

namespace ExperimentalUI.BlazorWebApp.ViewModels;

[ObservableRecipient]

public partial class AnimalDetailsViewModel : ViewModelBase
{
    private readonly IRestService<Animal, AnimalEndpointOptions> _animalRestService;

    [ObservableProperty]
    private Animal _animal;

    public AnimalDetailsViewModel(IRestService<Animal, AnimalEndpointOptions> animalRestService)
    {
        _animalRestService = animalRestService;
    }

    public async Task IntialiseViewModel(Guid id)
    {
        Animal = await _animalRestService.GetByIdAsync(id);
        Console.WriteLine("Test");
    }
}