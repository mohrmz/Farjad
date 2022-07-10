using Microsoft.EntityFrameworkCore;
using Scorpion.Infrastructures.Data.SqlServer.Commands;

namespace Scorpion.Samples.Infrastructures.Data.Sql.Commands.Common
{
    public class SampleCommandDbContext : BaseCommandDbContext
    {
        public SampleCommandDbContext(DbContextOptions<SampleCommandDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}