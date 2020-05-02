using System;
using System.Collections.Generic;

namespace coreTest2Api.Models
{
    public partial class Horaire
    {
        public Horaire()
        {
            Seance = new HashSet<Seance>();
        }

        public string Id { get; set; }
        public DateTime? Date { get; set; }

        public virtual ICollection<Seance> Seance { get; set; }
    }
}
