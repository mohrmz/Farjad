using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Farjad.Core.Domain.Toolkits.ValueObjects;

namespace Farjad.Infrastructures.Data.SqlServer.Commands.ValueConversions
{
    public class DescriptionConversion : ValueConverter<Description, string>
    {
        public DescriptionConversion() : base(c => c.Value, c => Description.FromString(c))
        {
        }
    }
}