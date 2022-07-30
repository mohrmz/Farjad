using Microsoft.EntityFrameworkCore;
using Farjad.Infrastructures.Data.SqlServer.Commands;

namespace $projectname$.Common
{
    public class CommandDbContext : BaseCommandDbContext
    {
        public CommandDbContext(DbContextOptions<CommandDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(builder); 
        }
    }
}