using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.FullName, fullName =>
            {
                fullName.Property(fn => fn.FirstName)
                    .HasMaxLength(30) 
                    .HasColumnName("PassFirstName"); 

                fullName.Property(fn => fn.LastName)
                    .IsRequired() 
                    .HasColumnName("PassLastName"); 
            });
            /*builder.HasDiscriminator<string>("IsTravller")
                .HasValue<Traveller>("1")
                .HasValue<Staff>("2")
                .HasValue<Passenger>("0");*/

        }
           

    }
}
