using System;
using System.Collections.Generic;

namespace stages.Models
{
    public partial class Contact
    {
        public int Noproposition { get; set; }
        public int Idfetudiant { get; set; }
        public DateOnly Datecontact { get; set; }

        public virtual Date DatecontactNavigation { get; set; } = null!;
        public virtual Etudiant IdfetudiantNavigation { get; set; } = null!;
        public virtual Propositionsstage NopropositionNavigation { get; set; } = null!;
    }
}
