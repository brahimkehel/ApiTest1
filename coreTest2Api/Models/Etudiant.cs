using System;
using System.Collections.Generic;

namespace coreTest2Api.Models
{
    public partial class Etudiant
    {
        public Etudiant()
        {
            Classe = new HashSet<Classe>();
        }

        public string Id { get; set; }
        public string Cin { get; set; }
        public DateTime? DateNais { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public int? Telephnoe { get; set; }
        public string Cne { get; set; }
        public string IdFiliere { get; set; }
        public string MotdePasse { get; set; }

        public virtual Filiere IdFiliereNavigation { get; set; }
        public virtual ICollection<Classe> Classe { get; set; }
    }
}
