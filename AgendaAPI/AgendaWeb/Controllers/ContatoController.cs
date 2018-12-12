using AgendaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AgendaWeb.Controllers
{
    public class ContatoController : Controller
    {
        // GET: Contato
        //public ActionResult Index()
        //{
        //    IEnumerable<Contato> listContato;
        //    HttpResponseMessage response = GlobalVariaveis.WebAPI.GetAsync("Contato").Result;
        //    listContato = response.Content.ReadAsAsync<IEnumerable<Contato>>().Result;
        //    return View(listContato);
        //}

        // GET: /Contato/
        public ActionResult Index(string searchString)
        {
            IEnumerable<Contato> listContato;
            HttpResponseMessage response = GlobalVariaveis.WebAPI.GetAsync("Contato").Result;
            listContato = response.Content.ReadAsAsync<IEnumerable<Contato>>().Result;

            if (!String.IsNullOrEmpty(searchString))
            {
                listContato = listContato.Where(s => s.nome.ToUpper().Contains(searchString.ToUpper())
                                       || s.nome.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(listContato);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Contato());
            }
            else
            {
                HttpResponseMessage response = GlobalVariaveis.WebAPI.GetAsync("Contato/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Contato>().Result);
            }

        }

        [HttpPost]
        public ActionResult AddorEdit(Contato contato)
        {
            if (contato.id == 0)
            {
                HttpResponseMessage response = GlobalVariaveis.WebAPI.PostAsJsonAsync("Contato", contato).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariaveis.WebAPI.PutAsJsonAsync("Contato/" + contato.id, contato).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariaveis.WebAPI.DeleteAsync("Contato/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}