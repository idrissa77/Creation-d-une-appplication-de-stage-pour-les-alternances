using System;
using System.Collections.Generic;

namespace stages.Models
{
    public partial class Entreprise
    {
        public Entreprise()
        {
            Propositionsstages = new HashSet<Propositionsstage>();
        }

        public int Noentreprise { get; set; }
        public int? Idfenseignant { get; set; }
        public string? Nomentreprise { get; set; }
        public string? Addresse { get; set; }

        public virtual Enseignant? IdfenseignantNavigation { get; set; }
        public virtual ICollection<Propositionsstage> Propositionsstages { get; set; }
    }
}
