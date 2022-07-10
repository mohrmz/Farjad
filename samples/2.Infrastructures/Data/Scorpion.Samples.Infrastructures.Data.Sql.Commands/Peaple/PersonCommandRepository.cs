using Scorpion.Infrastructures.Data.SqlServer.Commands;
using Scorpion.Samples.Core.Contracts.Peaple.Commands;
using Scorpion.Samples.Core.Domain.Peaple.Entities;
using Scorpion.Samples.Infrastructures.Data.Sql.Commands.Common;

namespace Scorpion.Samples.Infrastructures.Data.Sql.Commands.Peaple
{
    public class PersonCommandRepository : BaseCommandRepository<Person, SampleCommandDbContext>, IPersonCommandRepository
    {
        public PersonCommandRepository(SampleCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}