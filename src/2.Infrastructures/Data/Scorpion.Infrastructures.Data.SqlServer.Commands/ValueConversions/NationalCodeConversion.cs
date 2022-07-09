using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scoprion.Core.Domain.Toolkits.ValueObjects;

namespace Scorpion.Infrastructures.Data.SqlServer.Commands.ValueConversions
{
    public class NationalCodeConversion : ValueConverter<NationalCode, string>
    {
        public NationalCodeConversion() : base(c => c.Value, c => NationalCode.FromString(c))
        {
        }
    }
}