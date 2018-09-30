using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mvc.Controllers;
using Mvc.Models;
using System.Web.Mvc;

namespace polizaControllerTest
{
    [TestClass]
    public class PolizaControllerTest
    {
        [TestMethod]
        public void polizasTest()
        {
            //var controller = new ProductController();
            //var result = controller.Details(2) as ViewResult;
            //Assert.AreEqual("Details", result.ViewName);

            var poliza = new PolizasController();
            var mvcPoliza = new mvcPolizasModel() { tipoRiesgo = "alto",  Cobertura = 70 };
            var resultado = (ViewResult)poliza.Create(mvcPoliza) as ViewResult;
            Assert.AreEqual("Create", resultado.ViewName);
        }
    }
}
