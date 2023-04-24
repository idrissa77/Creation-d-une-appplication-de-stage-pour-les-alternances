using System;
using System.Collections.Generic;

namespace stages.Models
{
    public partial class Propositionsstage
    {
        public Propositionsstage()
        {
            Contacts = new HashSet<Contact>();
            ConventionNopropositionNavigations = new HashSet<Convention>();
            ConventionProNopropositionNavigations = new HashSet<Convention>();
        }

        public int Noproposition { get; set; }
        public int Noentreprise { get; set; }
        public int Noconvention { get; set; }
        public int ConNoconvention { get; set; }
        public string? Sujetpropose { get; set; }
        public DateOnly Dateproposition { get; set; }
        public DateOnly Duree { get; set; }
        public decimal? Remuneration { get; set; }

        public virtual Convention ConNoconventionNavigation { get; set; } = null!;
        public virtual Convention NoconventionNavigation { get; set; } = null!;
        public virtual Entreprise NoentrepriseNavigation { get; set; } = null!;
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Convention> ConventionNopropositionNavigations { get; set; }
        public virtual ICollection<Convention> ConventionProNopropositionNavigations { get; set; }
    }
}
