using System;
using System.Collections.Generic;

namespace coreTest2Api.Models
{
    public partial class Filiere
    {
        public Filiere()
        {
            Classe = new HashSet<Classe>();
            Etudiant = new HashSet<Etudiant>();
            Matiere = new HashSet<Matiere>();
        }

        public string Id { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Classe> Classe { get; set; }
        public virtual ICollection<Etudiant> Etudiant { get; set; }
        public virtual ICollection<Matiere> Matiere { get; set; }
    }
}
