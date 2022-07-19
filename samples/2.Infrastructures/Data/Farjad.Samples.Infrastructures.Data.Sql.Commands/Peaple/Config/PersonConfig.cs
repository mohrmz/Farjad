using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Farjad.Samples.Core.Domain.Peaple.Entities;
using Farjad.Samples.Core.Domain.Peaple.ValueObjects;

namespace Farjad.Samples.Infrastructures.Data.Sql.Commands.Peaple.Config
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