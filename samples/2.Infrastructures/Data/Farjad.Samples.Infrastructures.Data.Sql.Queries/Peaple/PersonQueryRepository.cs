using Farjad.Infrastructures.Data.SqlServer.Queries;
using Farjad.Samples.Core.Contracts.Peaple.Queries;
using Farjad.Samples.Infrastructures.Data.Sql.Queries.Common;

namespace Farjad.Samples.Infrastructures.Data.Sql.Queries.Peaple
{
    public class PersonQueryRepository : BaseQueryRepository<SampleQueryDbContext>, IPersonQueryRepository
    {
        public PersonQueryRepository(SampleQueryDbContext dbContext) : base(dbContext)
        {
        }
    }
}