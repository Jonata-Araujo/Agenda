using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaWeb.Models
{
    public class Agenda
    {
        public int id { get; set; }
        public string nome { get; set; }

        public virtual ICollection<Contato> contatos { get; set; }
    }
}