using BibliotecaIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaIntegrador.Controllers
{
    public class EditorialController : Controller
    {
        private AccentureBibliotecaEntities db;
        public EditorialController()
        {
            this.db = new AccentureBibliotecaEntities();
        }

        public ActionResult Listar()
        {
            List<Editoriale> editoriales = this.db.Editoriales.ToList();
            return View(editoriales);
        }

        public ActionResult Editar(int id)
        {
            this.ViewBag.TituloPagina = "Editar editorial";
            Editoriale editorial = this.db.Editoriales.Find(id);
            return View(editorial);
        }

        [HttpPost]
        public ActionResult Editar(Editoriale editorial)
        {
            this.db.Editoriales.Attach(editorial);
            this.db.Entry(editorial).State = System.Data.Entity.EntityState.Modified;
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Agregar()
        {
            this.ViewBag.TituloPagina = "Agregar editorial";
            return View("Editar");
        }

        [HttpPost]
        public ActionResult Agregar(Editoriale editorial)
        {
            this.db.Editoriales.Add(editorial);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Eliminar(int id)
        {
            Editoriale editorial = this.db.Editoriales.Find(id);
            this.db.Editoriales.Remove(editorial);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }
    }
}