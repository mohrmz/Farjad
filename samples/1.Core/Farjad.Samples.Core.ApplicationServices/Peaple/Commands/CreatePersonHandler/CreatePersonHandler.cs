using Farjad.Core.ApplicationServices.Commands;
using Farjad.Core.Contracts.ApplicationServices.Commands;
using Farjad.Samples.Core.Contracts.Peaple.Commands;
using Farjad.Samples.Core.Domain.Peaple.Entities;
using Farjad.Utilities;

namespace Farjad.Samples.Core.ApplicationServices.Peaple.Commands.CreatePersonHandler
{
    public class CreatePersonHandler : CommandHandler<CreatePerson, long>
    {
        private readonly IPersonCommandRepository _repository;

        public CreatePersonHandler(FarjadServices FarjadServices, IPersonCommandRepository repository) : base(FarjadServices)
        {
            _repository = repository;
        }

        public override async Task<CommandResult<long>> Handle(CreatePerson request)
        {
            Person person = new(new(request.FirstName), new(request.LastName));
            await _repository.InsertAsync(person);
            await _repository.CommitAsync();
            return Ok(person.Id);
        }
    }
}