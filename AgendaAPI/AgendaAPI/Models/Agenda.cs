using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaApi.Models
{
    public class Agenda
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Schedule name
        /// </summary>
        public string nome { get; set; }

        /// <summary>
        /// Contacts
        /// </summary>
        public virtual ICollection<Contato> contatos { get; set; }
    }
}
