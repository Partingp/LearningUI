using CommunityToolkit.Mvvm.Messaging.Messages;
using ExperimentalUI.BlazorWebApp.Models;

namespace ExperimentalUI.BlazorWebApp.ViewModelMessages;

public class AnimalMessage(Animal animal) : ValueChangedMessage<Animal>(animal);