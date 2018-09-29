using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcPolizasModel
    {
        public int idPoliza { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string tipoCubrimiento { get; set; }
        public Nullable<int> Cobertura { get; set; }
        public Nullable<System.DateTime> inicioVigencia { get; set; }
        public Nullable<int> periodoCobertura { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public string tipoRiesgo { get; set; }
    }
}