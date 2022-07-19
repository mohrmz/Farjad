using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Farjad.Core.Domain.ValueObjects;

namespace Farjad.Infrastructures.Data.SqlServer.Commands.ValueConversions
{
    public class BusinessIdConversion : ValueConverter<BusinessId, Guid>
    {
        public BusinessIdConversion() : base(c => c.Value, c => BusinessId.FromGuid(c))
        {
        }
    }
}