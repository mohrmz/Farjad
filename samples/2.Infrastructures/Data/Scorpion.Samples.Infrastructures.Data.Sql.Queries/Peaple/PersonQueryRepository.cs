using Scorpion.Infrastructures.Data.SqlServer.Queries;
using Scorpion.Samples.Core.Contracts.Peaple.Queries;
using Scorpion.Samples.Infrastructures.Data.Sql.Queries.Common;

namespace Scorpion.Samples.Infrastructures.Data.Sql.Queries.Peaple
{
    public class PersonQueryRepository : BaseQueryRepository<SampleQueryDbContext>, IPersonQueryRepository
    {
        public PersonQueryRepository(SampleQueryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
