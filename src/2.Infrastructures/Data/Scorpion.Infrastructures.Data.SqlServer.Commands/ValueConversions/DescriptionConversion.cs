using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scoprion.Core.Domain.Toolkits.ValueObjects;

namespace Scorpion.Infrastructures.Data.SqlServer.Commands.ValueConversions
{
    public class DescriptionConversion : ValueConverter<Description, string>
    {
        public DescriptionConversion() : base(c => c.Value, c => Description.FromString(c))
        {
        }
    }
}