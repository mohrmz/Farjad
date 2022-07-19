using Microsoft.EntityFrameworkCore;
using Farjad.Infrastructures.Data.SqlServer.Queries;

namespace Farjad.Samples.Infrastructures.Data.Sql.Queries.Common
{
    public class SampleQueryDbContext : BaseQueryDbContext
    {
        public SampleQueryDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}