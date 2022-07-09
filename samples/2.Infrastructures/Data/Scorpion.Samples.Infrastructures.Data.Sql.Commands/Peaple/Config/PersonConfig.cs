using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scorpion.Samples.Core.Domain.Peaple.Entities;
using Scorpion.Samples.Core.Domain.Peaple.ValueObjects;

namespace Scorpion.Samples.Infrastructures.Data.Sql.Commands.Peaple.Config
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(c => c.FirstName).HasConversion(c => c.Value, c => new FirstName(c));
            builder.Property(c => c.LastName).HasConversion(c => c.Value, c => new LastName(c));
        }
    }
}
