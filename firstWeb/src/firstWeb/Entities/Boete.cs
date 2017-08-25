using System;
using System.Collections.Generic;

namespace firstWeb.Entities
{
    public partial class Boete
    {
        public int Studnr { get; set; }
        public int? Boet { get; set; }

        public virtual Studenten StudnrNavigation { get; set; }
    }
}
