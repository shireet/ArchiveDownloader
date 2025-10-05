using AwesomeFiles.Presentation.Models.Dtos;
using FluentValidation;

namespace AwesomeFiles.WebApi.Validators;

public class StartArchiveRequestValidator : AbstractValidator<StartArchiveRequest>
{
    public StartArchiveRequestValidator()
    {
        RuleFor(x => x.FileNames)
            .NotEmpty()
            .WithMessage("At least one file name must be provided.")
            .Must(files => files != null && files.All(f => !string.IsNullOrWhiteSpace(f)))
            .WithMessage("File names cannot be null or consist only of whitespace.")
            .Must(files => files != null && files.All(f => f.IndexOfAny(Path.GetInvalidFileNameChars()) < 0))
            .WithMessage("File names contain invalid characters.")
            .Must(files => files != null && files.Count == files.Distinct().Count())
            .WithMessage("Duplicate file names are not allowed.");
    }
}