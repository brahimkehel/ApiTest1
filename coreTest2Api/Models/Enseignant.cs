using System;
using System.Collections.Generic;

namespace coreTest2Api.Models
{
    public partial class Enseignant
    {
        public Enseignant()
        {
            DetailSeance = new HashSet<DetailSeance>();
            Matiere = new HashSet<Matiere>();
        }

        public string Id { get; set; }
        public string Cin { get; set; }
        public DateTime? DateNais { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public int? Telephnoe { get; set; }
        public DateTime? DateEmb { get; set; }
        public string Cnss { get; set; }
        public double? Salaire { get; set; }
        public string MotdePasse { get; set; }

        public virtual ICollection<DetailSeance> DetailSeance { get; set; }
        public virtual ICollection<Matiere> Matiere { get; set; }
    }
}
