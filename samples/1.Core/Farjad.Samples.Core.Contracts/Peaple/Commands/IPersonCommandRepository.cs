using Farjad.Core.Contracts.Data.Commands;
using Farjad.Samples.Core.Domain.Peaple.Entities;

namespace Farjad.Samples.Core.Contracts.Peaple.Commands
{
    public interface IPersonCommandRepository : ICommandRepository<Person>
    {
    }
}