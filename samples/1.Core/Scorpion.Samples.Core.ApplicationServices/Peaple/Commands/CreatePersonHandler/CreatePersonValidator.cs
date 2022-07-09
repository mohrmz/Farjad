using FluentValidation;
using Scorpion.Samples.Core.Domain;
using Scorpion.Samples.Core.Domain.Peaple.Entities;
using Scorpion.Samples.Core.Domain.Peaple.ValueObjects;
using Zamin.Extentions.Translations.Abstractions;

namespace Scorpion.Samples.Core.ApplicationServices.Peaple.Commands.CreatePersonHandler
{
    public class CreatePersonValidator : AbstractValidator<Person>
    {
        public CreatePersonValidator(ITranslator translator)
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage(translator[Messages.InvalidNullValue,nameof(FirstName)]);
            RuleFor(c => c.LastName).NotEmpty().WithMessage(translator[Messages.InvalidNullValue, nameof(LastName)]);
        }
    }
}
