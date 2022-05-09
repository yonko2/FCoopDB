using System;
using System.Collections.Generic;

#nullable disable

namespace Ф_КООП.Models
{
    public partial class Deal
    {
        public string ContractId { get; set; }
        public int? ClientId { get; set; }
        public string PlotId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual Plot Plot { get; set; }
    }
}
