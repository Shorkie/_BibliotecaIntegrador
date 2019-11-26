using BibliotecaIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaIntegrador.Controllers
{
    public class AutorController : Controller
    {
        private AccentureBibliotecaEntities db;
        public AutorController()
        {
            this.db = new AccentureBibliotecaEntities();
        }

        public ActionResult Listar()
        {
            List<Autore> autores = this.db.Autores.ToList();
            return View(autores);
        }

        public ActionResult Editar(int id)
        {
            this.ViewBag.TituloPagina = "Editar Autor";
            Autore autor = this.db.Autores.Find(id);
            return View(autor);
        }

        [HttpPost]
        public ActionResult Editar(Autore autor)
        {
            this.db.Autores.Attach(autor);
            this.db.Entry(autor).State = System.Data.Entity.EntityState.Modified;
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Agregar()
        {
            this.ViewBag.TituloPagina = "Agregar autor";
            return View("Editar");
        }

        [HttpPost]
        public ActionResult Agregar(Autore autor)
        {
            this.db.Autores.Add(autor);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Eliminar(int id)
        {
            Autore autor = this.db.Autores.Find(id);
            this.db.Autores.Remove(autor);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }
    }
}