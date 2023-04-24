using System;
using System.Collections.Generic;

namespace stages.Models
{
    public partial class Etudiant
    {
        public Etudiant()
        {
            Contacts = new HashSet<Contact>();
            ConventionEtuIdfetudiantNavigations = new HashSet<Convention>();
            ConventionIdfetudiantNavigations = new HashSet<Convention>();
        }

        public int Idfetudiant { get; set; }
        public int Noconvention { get; set; }
        public int ConNoconvention { get; set; }
        public string? Nometudiant { get; set; }
        public string? Prenometudiant { get; set; }

        public virtual Convention ConNoconventionNavigation { get; set; } = null!;
        public virtual Convention NoconventionNavigation { get; set; } = null!;
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Convention> ConventionEtuIdfetudiantNavigations { get; set; }
        public virtual ICollection<Convention> ConventionIdfetudiantNavigations { get; set; }
    }
}
