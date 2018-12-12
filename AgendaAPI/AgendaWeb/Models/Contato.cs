using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendaWeb.Models
{
    public class Contato
    {
        public int id { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string nome { get; set; }
        public string telefone { get; set; }
        public int idagenda { get; set; }
        public Agenda agenda { get; set; }
    }
}