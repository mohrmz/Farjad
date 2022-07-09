using Scorpion.Core.Contracts.Data.Commands;
using Scorpion.Samples.Core.Domain.Peaple.Entities;

namespace Scorpion.Samples.Core.Contracts.Peaple.Commands
{
    public interface IPersonCommandRepository : ICommandRepository<Person>
    {

    }
}
