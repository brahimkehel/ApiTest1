using System;
using System.Collections.Generic;

namespace coreTest2Api.Models
{
    public partial class Matiere
    {
        public string Id { get; set; }
        public string NomMatiere { get; set; }
        public string IdEns { get; set; }
        public string IdFiliere { get; set; }

        public virtual Enseignant IdEnsNavigation { get; set; }
        public virtual Filiere IdFiliereNavigation { get; set; }
    }
}
