using System;
using System.Collections.Generic;

#nullable disable

namespace Ф_КООП.Models
{
    public partial class Client
    {
        public Client()
        {
            Deals = new HashSet<Deal>();
        }

        public int ClientId { get; set; }
        public string IdcardNum { get; set; }
        public string Name { get; set; }
        public string Residence { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Deal> Deals { get; set; }
    }
}
