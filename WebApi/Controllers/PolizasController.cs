using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class PolizasController : ApiController
    {
        private dbModelCrud db = new dbModelCrud();

        // GET: api/Polizas
        public IQueryable<Polizas> GetPolizas()
        {
            return db.Polizas;
        }

        // GET: api/Polizas/5
        [ResponseType(typeof(Polizas))]
        public IHttpActionResult GetPolizas(int id)
        {
            Polizas polizas = db.Polizas.Find(id);
            if (polizas == null)
            {
                return NotFound();
            }

            return Ok(polizas);
        }

        // PUT: api/Polizas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPolizas(int id, Polizas polizas)
        {
            if (id != polizas.idPoliza)
            {
                return BadRequest();
            }

            db.Entry(polizas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolizasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Polizas
        [ResponseType(typeof(Polizas))]
        public IHttpActionResult PostPolizas(Polizas polizas)
        {
            db.Polizas.Add(polizas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = polizas.idPoliza }, polizas);
        }

        // DELETE: api/Polizas/5
        [ResponseType(typeof(Polizas))]
        public IHttpActionResult DeletePolizas(int id)
        {
            Polizas polizas = db.Polizas.Find(id);
            if (polizas == null)
            {
                return NotFound();
            }

            db.Polizas.Remove(polizas);
            db.SaveChanges();

            return Ok(polizas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PolizasExists(int id)
        {
            return db.Polizas.Count(e => e.idPoliza == id) > 0;
        }
    }
}