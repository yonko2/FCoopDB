using System;
using System.Collections.Generic;

#nullable disable

namespace Ф_КООП.Models
{
    public partial class Plot
    {
        public Plot()
        {
            Deals = new HashSet<Deal>();
        }

        public string PlotId { get; set; }
        public string Location { get; set; }
        public string Municipality { get; set; }
        public int? Type { get; set; }
        public decimal? Area { get; set; }

        public virtual Rent TypeNavigation { get; set; }
        public virtual ICollection<Deal> Deals { get; set; }
    }
}
