using System;
using System.Collections.Generic;

#nullable disable

namespace Ф_КООП.Models
{
    public partial class Rent
    {
        public Rent()
        {
            Plots = new HashSet<Plot>();
        }

        public int Type { get; set; }
        public decimal? Rent1 { get; set; }

        public virtual ICollection<Plot> Plots { get; set; }
    }
}
