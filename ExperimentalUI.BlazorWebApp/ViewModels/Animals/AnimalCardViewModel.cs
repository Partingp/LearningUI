using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ExperimentalUI.BlazorWebApp.ViewModels;

[ObservableRecipient]

public partial class AnimalCardViewModel : ViewModelBase
{
    [RelayCommand]
    public void ViewEnlargedCard()
    {
        //TODO - Show an enlarged image
    }
}