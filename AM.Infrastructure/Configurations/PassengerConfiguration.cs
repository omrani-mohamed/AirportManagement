using AM.Application.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    internal class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable("Passengers");

            builder.OwnsOne(p => p.FullName, fullName =>
            {
                fullName.Property(f => f.FirstName)
                        .HasMaxLength(30)
                        .HasColumnName("PassFirstName");

                fullName.Property(f => f.LastName)
                        .IsRequired()
                        .HasColumnName("PassLastName");
            });

            //builder.HasDiscriminator<string>("IsTraveller")
            //    .HasValue<Traveller>("1")
            //    .HasValue<Staff>("2")
            //    .HasValue<Passenger>("0");
        }
    }
}
