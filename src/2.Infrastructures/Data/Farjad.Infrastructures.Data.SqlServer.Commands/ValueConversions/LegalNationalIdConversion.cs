using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Farjad.Core.Domain.Toolkits.ValueObjects;

namespace Farjad.Infrastructures.Data.SqlServer.Commands.ValueConversions
{
    public class LegalNationalIdConversion : ValueConverter<LegalNationalId, string>
    {
        public LegalNationalIdConversion() : base(c => c.Value, c => LegalNationalId.FromString(c))
        {
        }
    }
}