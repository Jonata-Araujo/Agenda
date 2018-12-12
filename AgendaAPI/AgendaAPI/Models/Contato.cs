using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaApi.Models
{
    public class Contato
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string nome { get; set; }

        /// <summary>
        /// Contact
        /// </summary>
        public string telefone { get; set; }

        /// <summary>
        /// id schedule
        /// </summary>
        public int idagenda { get; set; }

        /// <summary>
        /// schedule
        /// </summary>
        public Agenda agenda { get; set; }
    }
}
