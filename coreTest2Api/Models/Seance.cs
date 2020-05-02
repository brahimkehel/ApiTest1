using System;
using System.Collections.Generic;

namespace coreTest2Api.Models
{
    public partial class Seance
    {
        public Seance()
        {
            DetailSeance = new HashSet<DetailSeance>();
        }

        public string Id { get; set; }
        public DateTime? Date { get; set; }
        public string IdClasse { get; set; }
        public string IdHoraire { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Horaire IdHoraireNavigation { get; set; }
        public virtual ICollection<DetailSeance> DetailSeance { get; set; }
    }
}
