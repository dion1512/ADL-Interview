using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADL.Data.Entities
{
    public class Category:Base
    {
        public string CategoryName { get; set; }
        public virtual ICollection<Callout>? Callouts { get; set; }
    }
}
