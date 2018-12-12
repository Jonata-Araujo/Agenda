using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaApi.Data;
using AgendaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers
{
    [Route("api/[controller]")]
    public class AgendaController : Controller
    {
        protected Contexto contexto;

        public AgendaController()
        {
            contexto = new Contexto();
        }

        /// <summary>
        /// View Schedule Details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Json(contexto.agendas.ToList());
        }

        /// <summary>
        /// View Schedule Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(contexto.agendas.SingleOrDefault(r => r.id == id));
        }

        /// <summary>
        /// Create new Schedule
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Agenda value)
        {
            contexto.agendas.Add(value);
            contexto.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Update Schedule
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody] Agenda value)
        {
            if (id == value.id)
            {
                Agenda agenda = contexto.agendas.SingleOrDefault(r => r.id == id);
                if (agenda != null)
                {
                    agenda.nome = value.nome;
                }
                else
                {
                    return NotFound();
                }
                contexto.agendas.Update(agenda);
                contexto.SaveChanges();
            }
            return NoContent();
        }

        /// <summary>
        /// Delete Schedule
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Agenda restaurante = contexto.agendas.Find(id);
            if (restaurante == null)
            {
                return NotFound();
            }
            contexto.agendas.Remove(restaurante);
            contexto.SaveChanges();
            return NoContent();
        }
    }
}
