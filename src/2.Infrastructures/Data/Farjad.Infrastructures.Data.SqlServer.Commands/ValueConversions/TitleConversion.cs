using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Farjad.Core.Domain.Toolkits.ValueObjects;

namespace Farjad.Infrastructures.Data.SqlServer.Commands.ValueConversions
{
    public class TitleConversion : ValueConverter<Title, string>
    {
        public TitleConversion() : base(c => c.Value, c => Title.FromString(c))
        {
        }
    }
}