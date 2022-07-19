using FluentValidation;
using Farjad.Extensions.Translations.Abstractions;
using Farjad.Samples.Core.Domain;
using Farjad.Samples.Core.Domain.Peaple.Entities;
using Farjad.Samples.Core.Domain.Peaple.ValueObjects;


namespace Farjad.Samples.Core.ApplicationServices.Peaple.Commands.CreatePersonHandler
{
    public class CreatePersonValidator : AbstractValidator<Person>
    {
        public CreatePersonValidator(ITranslator translator)
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage(translator[Messages.InvalidNullValue, nameof(FirstName)]);
            RuleFor(c => c.LastName).NotEmpty().WithMessage(translator[Messages.InvalidNullValue, nameof(LastName)]);
        }
    }
}