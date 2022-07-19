using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Farjad.Core.Domain.Toolkits.ValueObjects;

namespace Farjad.Infrastructures.Data.SqlServer.Commands.ValueConversions
{
    public class NationalCodeConversion : ValueConverter<NationalCode, string>
    {
        public NationalCodeConversion() : base(c => c.Value, c => NationalCode.FromString(c))
        {
        }
    }
}