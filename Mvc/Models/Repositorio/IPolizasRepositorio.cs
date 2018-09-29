using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Models.Repositorio
{
    interface IPolizasRepositorio : IDisposable
    {
        IEnumerable<mvcPolizasModel> GetPolizas();

        void InsertPoliza(mvcPolizasModel poliza);

        void DeletePoliza(int idPoliza);

        void UpdatePoliza(mvcPolizasModel poliza);

        void Save();

    }
}
