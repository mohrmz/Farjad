using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scoprion.Core.Domain.Toolkits.ValueObjects;

namespace Scorpion.Infrastructures.Data.SqlServer.Commands.ValueConversions
{
    public class LegalNationalIdConversion : ValueConverter<LegalNationalId, string>
    {
        public LegalNationalIdConversion() : base(c => c.Value, c => LegalNationalId.FromString(c))
        {
        }
    }
}