using Farjad.Infrastructures.Data.SqlServer.Commands;
using Farjad.Samples.Core.Contracts.Common;

namespace Farjad.Samples.Infrastructures.Data.Sql.Commands.Common
{
    public class SampleUnitOfWork : BaseEntityFrameworkUnitOfWork<SampleCommandDbContext>, ISampleUnitOfWork
    {
        public SampleUnitOfWork(SampleCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}