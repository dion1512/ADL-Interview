using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADL.Data.Entities
{
    public class Schedule:Base
    {
        public string DayName { get; set; }
        public string AppointmentTimeStart { get; set; }
        public string AppointmentTimeEnd { get; set; }

    }
}
