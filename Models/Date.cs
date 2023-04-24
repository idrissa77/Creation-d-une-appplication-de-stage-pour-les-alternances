using System;
using System.Collections.Generic;

namespace stages.Models
{
    public partial class Date
    {
        public Date()
        {
            Contacts = new HashSet<Contact>();
        }

        public DateOnly Datecontact { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
