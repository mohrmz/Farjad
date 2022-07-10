using Scorpion.Infrastructures.Data.SqlServer.Commands;
using Scorpion.Samples.Core.Contracts.Common;

namespace Scorpion.Samples.Infrastructures.Data.Sql.Commands.Common
{
    public class SampleUnitOfWork : BaseEntityFrameworkUnitOfWork<SampleCommandDbContext>, ISampleUnitOfWork
    {
        public SampleUnitOfWork(SampleCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}