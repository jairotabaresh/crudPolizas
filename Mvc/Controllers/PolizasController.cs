using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class PolizasController : Controller
    {
        // GET: Polizas
        public ActionResult Index()
        {
            IEnumerable<mvcPolizasModel> poliList;
            HttpResponseMessage response = Globals.webApiClient.GetAsync("Polizas").Result;
            poliList = response.Content.ReadAsAsync<IEnumerable<mvcPolizasModel>>().Result;
            return View(poliList);
        }

        public ActionResult Create(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcPolizasModel());
            }
            else
            {
                HttpResponseMessage response = Globals.webApiClient.GetAsync("Polizas/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcPolizasModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult Create(mvcPolizasModel poli)
        {
            HttpResponseMessage response = Globals.webApiClient.PostAsJsonAsync("Polizas", poli).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = Globals.webApiClient.DeleteAsync("Polizas/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}