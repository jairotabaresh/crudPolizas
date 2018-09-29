using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc.Models.Repositorio
{
    public class polizasRepositorio : IPolizasRepositorio
    {
        private polizasContext contextIni; 

        public polizasRepositorio(polizasContext context)
        {
            this.contextIni = context;
        }
        public void DeletePoliza(int idPoliza)
        {
            mvcPolizasModel poliza = contextIni.Poliza.Find(idPoliza);
            contextIni.Poliza.Remove(poliza);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<mvcPolizasModel> GetPolizas()
        {
            return contextIni.Poliza.ToList();
        }

        public void InsertPoliza(mvcPolizasModel poliza)
        {
            contextIni.Poliza.Add(poliza);
        }

        public void Save()
        {
            contextIni.SaveChanges();
        }

        public void UpdatePoliza(mvcPolizasModel poliza)
        {
            contextIni.Entry(poliza).State = System.Data.Entity.EntityState.Modified;
        }
    }
}