using System;
using System.Collections.Generic;

namespace coreTest2Api.Models
{
    public partial class Classe
    {
        public Classe()
        {
            Seance = new HashSet<Seance>();
        }

        public string Id { get; set; }
        public string Libelle { get; set; }
        public string IdEtu { get; set; }
        public string IdFiliere { get; set; }
        public string IdAnnee { get; set; }

        public virtual AnneeScolaire IdAnneeNavigation { get; set; }
        public virtual Etudiant IdEtuNavigation { get; set; }
        public virtual Filiere IdFiliereNavigation { get; set; }
        public virtual ICollection<Seance> Seance { get; set; }
    }
}
