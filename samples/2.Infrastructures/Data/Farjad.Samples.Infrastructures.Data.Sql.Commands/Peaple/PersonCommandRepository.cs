using Farjad.Infrastructures.Data.SqlServer.Commands;
using Farjad.Samples.Core.Contracts.Peaple.Commands;
using Farjad.Samples.Core.Domain.Peaple.Entities;
using Farjad.Samples.Infrastructures.Data.Sql.Commands.Common;

namespace Farjad.Samples.Infrastructures.Data.Sql.Commands.Peaple
{
    public class PersonCommandRepository : BaseCommandRepository<Person, SampleCommandDbContext>, IPersonCommandRepository
    {
        public PersonCommandRepository(SampleCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}