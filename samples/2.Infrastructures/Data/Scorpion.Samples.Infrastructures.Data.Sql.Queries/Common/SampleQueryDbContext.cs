using Microsoft.EntityFrameworkCore;
using Scorpion.Infrastructures.Data.SqlServer.Queries;

namespace Scorpion.Samples.Infrastructures.Data.Sql.Queries.Common
{
    public class SampleQueryDbContext : BaseQueryDbContext
    {
        public SampleQueryDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
