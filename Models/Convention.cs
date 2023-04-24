using System;
using System.Collections.Generic;

namespace stages.Models
{
    public partial class Convention
    {
        public Convention()
        {
            EtudiantConNoconventionNavigations = new HashSet<Etudiant>();
            EtudiantNoconventionNavigations = new HashSet<Etudiant>();
            PropositionsstageConNoconventionNavigations = new HashSet<Propositionsstage>();
            PropositionsstageNoconventionNavigations = new HashSet<Propositionsstage>();
        }

        public int Noconvention { get; set; }
        public int Idfenseignant { get; set; }
        public int Idfetudiant { get; set; }
        public int EtuIdfetudiant { get; set; }
        public int Noproposition { get; set; }
        public int ProNoproposition { get; set; }
        public string? Sujetmemoire { get; set; }
        public DateOnly Datedebut { get; set; }
        public decimal? Salaire { get; set; }
        public DateOnly Datesignature { get; set; }

        public virtual Etudiant EtuIdfetudiantNavigation { get; set; } = null!;
        public virtual Enseignant IdfenseignantNavigation { get; set; } = null!;
        public virtual Etudiant IdfetudiantNavigation { get; set; } = null!;
        public virtual Propositionsstage NopropositionNavigation { get; set; } = null!;
        public virtual Propositionsstage ProNopropositionNavigation { get; set; } = null!;
        public virtual ICollection<Etudiant> EtudiantConNoconventionNavigations { get; set; }
        public virtual ICollection<Etudiant> EtudiantNoconventionNavigations { get; set; }
        public virtual ICollection<Propositionsstage> PropositionsstageConNoconventionNavigations { get; set; }
        public virtual ICollection<Propositionsstage> PropositionsstageNoconventionNavigations { get; set; }
    }
}
