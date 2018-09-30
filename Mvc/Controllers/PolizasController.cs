using Mvc.Models;
using Mvc.Models.Repositorio;
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

        //Se intenta llamar la lógica creada en el patrón repositorio pero no funciona correctamente con EF usando base de datos existente 
        //private IPolizasRepositorio interfacePolizas;

        //public PolizasController()
        //{
        //    this.interfacePolizas = new polizasRepositorio(new polizasContext());
        //}


        //public ActionResult Index()
        //{
        //    var data = from a in interfacePolizas.GetPolizas() select a;
        //    return View(data);
        //}


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
            if (poli.tipoRiesgo == "alto" && poli.Cobertura > 50)
            {
                TempData["msg"] = "<script>alert('El % de cubrimiento no puede ser superior al 50% para un riesgo alto');</script>";
                return View("Create");
            }
            else
            {
                if (poli.idPoliza == 0)
                {
                    HttpResponseMessage response = Globals.webApiClient.PostAsJsonAsync("Polizas", poli).Result;                  
                }
                else
                {
                    HttpResponseMessage response = Globals.webApiClient.PutAsJsonAsync("Polizas/"+poli.idPoliza, poli).Result;
                }
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = Globals.webApiClient.DeleteAsync("Polizas/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}