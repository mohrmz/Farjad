using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scorpion.Core.Domain.ValueObjects;

namespace Scorpion.Infrastructures.Data.SqlServer.Commands.ValueConversions
{
    public class BusinessIdConversion : ValueConverter<BusinessId, Guid>
    {
        public BusinessIdConversion() : base(c => c.Value, c => BusinessId.FromGuid(c))
        {
        }
    }
}