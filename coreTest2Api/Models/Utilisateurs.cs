using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreTest2Api.Models
{
    public class Utilisateurs
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotdePasse { get; set; }
        public string _Status { get; set; }
    }
}
