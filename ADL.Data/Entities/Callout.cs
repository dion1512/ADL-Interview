using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ADL.Data.Entities
{
    public class Callout:Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string ContactNumber { get; set; }
        public string Address { get; set; }

        public DateTime DateBookedStart { get; set; }

        public DateTime DateBookedEnd { get; set; }

        public string VehicleReg { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        [XmlIgnore]
        public virtual Category Category { get; set; }
        public string? Notes { get; set; }
    }
}
