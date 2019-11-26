using BibliotecaIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaIntegrador.Controllers
{
    public class GeneroController : Controller
    {

        private AccentureBibliotecaEntities db;
        public GeneroController()
        {
            this.db = new AccentureBibliotecaEntities();
        }

        public ActionResult Listar()
        {
            List<Genero> generos = this.db.Generos.ToList();
            return View(generos);
        }

        public ActionResult Editar(int id)
        {
            this.ViewBag.TituloPagina = "Editar Genero";
            Genero genero = this.db.Generos.Find(id);
            return View(genero);
        }

        [HttpPost]
        public ActionResult Editar(Genero genero)
        {
            this.db.Generos.Attach(genero);
            this.db.Entry(genero).State = System.Data.Entity.EntityState.Modified;
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Agregar()
        {
            this.ViewBag.TituloPagina = "Agregar genero";
            return View("Editar");
        }

        [HttpPost]
        public ActionResult Agregar(Genero genero)
        {
            this.db.Generos.Add(genero);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Eliminar(int id)
        {
            Genero genero = this.db.Generos.Find(id);
            this.db.Generos.Remove(genero);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

    }
}