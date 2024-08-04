using ExperimentalRestAPI.API.DTOs;
using FluentValidation;
using System.Text.RegularExpressions;

namespace ExperimentalRestAPI.API.Validators
{
    public class UpdateAnimalDTOValidator : AbstractValidator<UpdateAnimalDTO>
    {
        public UpdateAnimalDTOValidator()
        {
            RuleFor(x => x.Name)
                .Length(1, 16);

            RuleFor(x => x.Description)
                .Length(1, 64);

            RuleFor(x => x.Thumbnail)
                .Must(BeAValidBase64DataUri)
                .WithMessage("The provided string is not a valid Base64 Data URI.");

        }

        private bool BeAValidBase64DataUri(string base64DataUri)
        {
            if (string.IsNullOrEmpty(base64DataUri))
                return false;

            // Regular expression to match Data URI with base64
            var dataUriPattern = @"^data:(?<mimeType>[a-zA-Z0-9]+\/[a-zA-Z0-9\-\+\.]+)?;base64,(?<data>[a-zA-Z0-9+/]+={0,2})$";

            var match = Regex.Match(base64DataUri, dataUriPattern);

            if (!match.Success)
                return false;

            // Extract the base64 data part
            var base64Data = match.Groups["data"].Value;

            try
            {
                // Try to convert the base64 string to bytes
                Convert.FromBase64String(base64Data);
                return true;
            }
            catch (FormatException)
            {
                // If conversion fails, it's not a valid base64 string
                return false;
            }
        }

    }
}
