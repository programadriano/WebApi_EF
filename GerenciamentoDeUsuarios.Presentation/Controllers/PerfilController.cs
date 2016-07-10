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
using GerenciamentoDeUsuarios.Domain.Entidades;
using GerenciamentoDeUsuarios.Infra.Contextos;

namespace GerenciamentoDeUsuarios.Presentation.Controllers
{
    public class PerfilController : ApiController
    {
        private GerenciamentoDeUsuariosContext db = new GerenciamentoDeUsuariosContext();

        // GET api/Perfil
        public IQueryable<Perfil> GetPerfis()
        {
            return db.Perfis;
        }

        // GET api/Perfil/5
        [ResponseType(typeof(Perfil))]
        public IHttpActionResult GetPerfil(int id)
        {
            Perfil perfil = db.Perfis.Find(id);
            if (perfil == null)
            {
                return NotFound();
            }

            return Ok(perfil);
        }

        // PUT api/Perfil/5
        public IHttpActionResult PutPerfil(int id, Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfil.Id)
            {
                return BadRequest();
            }

            db.Entry(perfil).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
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

        // POST api/Perfil
        [ResponseType(typeof(Perfil))]
        public IHttpActionResult PostPerfil(Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Perfis.Add(perfil);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = perfil.Id }, perfil);
        }

        // DELETE api/Perfil/5
        [ResponseType(typeof(Perfil))]
        public IHttpActionResult DeletePerfil(int id)
        {
            Perfil perfil = db.Perfis.Find(id);
            if (perfil == null)
            {
                return NotFound();
            }

            db.Perfis.Remove(perfil);
            db.SaveChanges();

            return Ok(perfil);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerfilExists(int id)
        {
            return db.Perfis.Count(e => e.Id == id) > 0;
        }
    }
}