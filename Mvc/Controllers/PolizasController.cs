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
    }
}