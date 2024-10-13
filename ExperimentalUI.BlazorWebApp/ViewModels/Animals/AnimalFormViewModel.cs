using CommunityToolkit.Mvvm.ComponentModel;
using ExperimentalUI.BlazorWebApp.Interfaces;
using ExperimentalUI.BlazorWebApp.Models;
using ExperimentalUI.BlazorWebApp.Models.Options;

namespace ExperimentalUI.BlazorWebApp.ViewModels;

[ObservableRecipient]

public partial class AnimalFormViewModel : ViewModelBase
{
    private readonly IRestService<Animal, AnimalEndpointOptions> _animalRestService;

    [ObservableProperty]
    private Animal _animal;

    public AnimalFormViewModel(IRestService<Animal, AnimalEndpointOptions> animalRestService)
    {
        _animalRestService = animalRestService;
    }

    public async Task SaveAnimal()
    {
        //TODO - Implement create
        await _animalRestService.UpdateAsync(Animal.Id, Animal);
    }
}