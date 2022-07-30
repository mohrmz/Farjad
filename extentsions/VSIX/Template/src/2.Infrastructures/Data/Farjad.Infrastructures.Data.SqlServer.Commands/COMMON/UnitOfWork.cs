using Farjad.Infrastructures.Data.SqlServer.Commands;
using $ext_projectname$.Core.Contracts.Common;

namespace $projectname$.Common
{
    public class UnitOfWork : BaseEntityFrameworkUnitOfWork<CommandDbContext>, I$ext_projectname$UnitOfWork
    {
        public UnitOfWork(CommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}