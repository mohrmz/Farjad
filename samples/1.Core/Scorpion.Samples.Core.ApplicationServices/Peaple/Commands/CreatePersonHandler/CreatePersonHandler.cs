using Scorpion.Core.ApplicationServices.Commands;
using Scorpion.Core.Contracts.ApplicationServices.Commands;
using Scorpion.Samples.Core.Contracts.Peaple.Commands;
using Scorpion.Samples.Core.Domain.Peaple.Entities;
using Scorpion.Utilities;

namespace Scorpion.Samples.Core.ApplicationServices.Peaple.Commands.CreatePersonHandler
{
    
    public class CreatePersonHandler : CommandHandler<CreatePerson, long>
    {
        private readonly IPersonCommandRepository _repository;
        public CreatePersonHandler(ScorpionServices scorpionServices, IPersonCommandRepository repository) : base(scorpionServices)
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
