using System;
using System.Collections.Generic;

namespace coreTest2Api.Models
{
    public partial class DetailSeance
    {
        public string Id { get; set; }
        public string Sujet { get; set; }
        public string IdEns { get; set; }
        public string IdSeance { get; set; }

        public virtual Enseignant IdEnsNavigation { get; set; }
        public virtual Seance IdSeanceNavigation { get; set; }
    }
}
