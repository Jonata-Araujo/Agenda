using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaApi.Data;
using AgendaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgenda.Controllers
{
    [Route("api/[controller]")]
    public class ContatoController : Controller
    {
        protected Contexto contexto;

        public ContatoController()
        {
            contexto = new Contexto();
        }

        /// <summary>
        /// List all contact details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Json(contexto.contatos.OrderBy(c => c.nome).ToList());
        }

        /// <summary>
        /// View Contact Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(contexto.contatos.SingleOrDefault(r => r.id == id));
        }

        /// <summary>
        /// Create new contact
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Contato value)
        {
            contexto.contatos.Add(value);
            contexto.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Update contact
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody] Contato value)
        {
            if (id == value.id)
            {
                Contato contato = contexto.contatos.SingleOrDefault(r => r.id == id);
                if (contato != null)
                {
                    contato.nome = value.nome;
                    contato.telefone = value.telefone;
                    contato.idagenda = value.idagenda;
                }
                else
                {
                    return NotFound();
                }
                contexto.contatos.Update(contato);
                contexto.SaveChanges();
            }
            return NoContent();
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Contato contato = contexto.contatos.Find(id);
            if (contato == null)
            {
                return NotFound();
            }
            contexto.contatos.Remove(contato);
            contexto.SaveChanges();
            return NoContent();
        }
    }
}
