using System;
using System.Collections.Generic;

#nullable disable

namespace Ф_КООП.Models
{
    public partial class Contract
    {
        public string ContractId { get; set; }
        public DateTime? Date { get; set; }
        public int? Term { get; set; }
        public string Plant { get; set; }
        public int? AverageYield { get; set; }

        public virtual Deal Deal { get; set; }
    }
}
