using Microsoft.EntityFrameworkCore;
using Farjad.Infrastructures.Data.SqlServer.Commands;

namespace Farjad.Samples.Infrastructures.Data.Sql.Commands.Common
{
    public class SampleCommandDbContext : BaseCommandDbContext
    {
        public SampleCommandDbContext(DbContextOptions<SampleCommandDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(builder); 
        }
    }
}