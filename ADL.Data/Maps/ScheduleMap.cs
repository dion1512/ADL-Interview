using ADL.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADL.Data.Maps
{
    public class ScheduleMap
    {
        public ScheduleMap(EntityTypeBuilder<Schedule> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.DayName).IsRequired();
        }
    }
}
