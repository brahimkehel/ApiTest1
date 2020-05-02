using System;
using System.Collections.Generic;

namespace coreTest2Api.Models
{
    public partial class Absence
    {
        public string Id { get; set; }
        public string IdEtu { get; set; }
        public string IdSeance { get; set; }

        public virtual Etudiant IdEtuNavigation { get; set; }
        public virtual Seance IdSeanceNavigation { get; set; }
    }
}
