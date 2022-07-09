using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scoprion.Core.Domain.Toolkits.ValueObjects;

namespace Scorpion.Infrastructures.Data.SqlServer.Commands.ValueConversions
{
    public class TitleConversion : ValueConverter<Title, string>
    {
        public TitleConversion() : base(c => c.Value, c => Title.FromString(c))
        {
        }
    }
}