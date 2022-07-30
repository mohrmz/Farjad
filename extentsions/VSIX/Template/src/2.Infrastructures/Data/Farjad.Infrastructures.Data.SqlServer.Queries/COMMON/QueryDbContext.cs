using Microsoft.EntityFrameworkCore;
using Farjad.Infrastructures.Data.SqlServer.Queries;

namespace $projectname$.Common
{
    public class QueryDbContext : BaseQueryDbContext
    {
        public QueryDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}