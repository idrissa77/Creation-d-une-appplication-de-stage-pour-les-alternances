using System;
using System.Collections.Generic;

namespace stages.Models
{
    public partial class Enseignant
    {
        public Enseignant()
        {
            Conventions = new HashSet<Convention>();
            Entreprises = new HashSet<Entreprise>();
        }

        public int Idfenseignant { get; set; }
        public string? Nomenseignant { get; set; }
        public string? Prenomenseignant { get; set; }
        public DateOnly Datevisite { get; set; }

        public virtual ICollection<Convention> Conventions { get; set; }
        public virtual ICollection<Entreprise> Entreprises { get; set; }
    }
}
