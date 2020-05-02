using System;
using System.Collections.Generic;

namespace coreTest2Api.Models
{
    public partial class Administrateur
    {
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
    }
}
