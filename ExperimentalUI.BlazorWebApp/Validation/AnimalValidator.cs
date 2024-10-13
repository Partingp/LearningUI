namespace ExperimentalUI.BlazorWebApp.Validation;

using ExperimentalUI.BlazorWebApp.Models;
using FluentValidation;

public class AnimalValidator : AbstractValidator<Animal>
{
    //TODO - Implement validation
    public AnimalValidator()
    {
        RuleFor(x => x.Name).NotNull();
    }
}