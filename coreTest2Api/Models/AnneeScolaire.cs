using System;
using System.Collections.Generic;

namespace coreTest2Api.Models
{
    public partial class AnneeScolaire
    {
        public AnneeScolaire()
        {
            Classe = new HashSet<Classe>();
        }

        public string Id { get; set; }
        public string Annee { get; set; }

        public virtual ICollection<Classe> Classe { get; set; }
    }
}
