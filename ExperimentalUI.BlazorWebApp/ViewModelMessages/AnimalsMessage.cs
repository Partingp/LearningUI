using CommunityToolkit.Mvvm.Messaging.Messages;
using ExperimentalUI.BlazorWebApp.Models;

namespace ExperimentalUI.BlazorWebApp.ViewModelMessages;

public class AnimalsMessage(List<Animal> animal) : ValueChangedMessage<List<Animal>>(animal);