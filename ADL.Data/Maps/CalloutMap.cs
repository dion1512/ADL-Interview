using ADL.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADL.Data.Maps
{
    public class CalloutMap
    {
        public CalloutMap(EntityTypeBuilder<Callout> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.EmailAddress).IsRequired();
            entityBuilder.Property(t => t.ContactNumber).IsRequired();
            entityBuilder.Property(t => t.Address).IsRequired();
            entityBuilder.Property(t => t.DateBookedStart).IsRequired();
            entityBuilder.Property(t => t.DateBookedEnd).IsRequired();
            entityBuilder.Property(t => t.VehicleReg).IsRequired().HasMaxLength(7);
            entityBuilder.Property(t => t.Notes).HasMaxLength(500);
            entityBuilder.HasOne(t => t.Category);
        }
    }
}
