using BibliotecaIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaIntegrador.Controllers
{
    public class LibroController : Controller
    {
        private AccentureBibliotecaEntities db;
        public LibroController()
        {
            this.db = new AccentureBibliotecaEntities();
        }

        public ActionResult Listar()
        {
            List<Libro> libros = this.db.Libros.ToList();
            return View(libros);
        }

        public ActionResult Editar(int id)
        {
            this.ViewBag.TituloPagina = "Editar libro";
            //this.ViewBag.ListaEditoriales = this.db.Editoriales.ToList();
            Libro libro = this.db.Libros.Find(id);
            return View(libro);
        }

        [HttpPost]
        public ActionResult Editar(Libro libro)
        {
            this.db.Libros.Attach(libro);
            this.db.Entry(libro).State = System.Data.Entity.EntityState.Modified;
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Agregar()
        {
            this.ViewBag.TituloPagina = "Agregar libro";
            return View("Editar");
        }

        [HttpPost]
        public ActionResult Agregar(Libro libro)
        {
            this.db.Libros.Add(libro);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Eliminar(int id)
        {
            Libro libro = this.db.Libros.Find(id);
            this.db.Libros.Remove(libro);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }
    }
}