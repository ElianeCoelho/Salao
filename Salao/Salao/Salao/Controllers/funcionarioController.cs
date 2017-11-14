using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Salao;

namespace Salao.Controllers
{
    public class funcionarioController : Controller
    {
        private salaoEntities db = new salaoEntities();

        // GET: funcionario
        public ActionResult Index()
        {
            var funcionario = db.funcionario.Include(f => f.cargo).Include(f => f.cliente);
            return View(funcionario.ToList());
        }

        // GET: funcionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcionario funcionario = db.funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: funcionario/Create
        public ActionResult Create()
        {
            ViewBag.IdCargo = new SelectList(db.cargo, "IdCargo", "nomeCargo");
            ViewBag.IdCliente = new SelectList(db.cliente, "IdCliente", "Nome");
            return View();
        }

        // POST: funcionario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFuncionario,Nome,IdCargo,IdCliente")] funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.funcionario.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCargo = new SelectList(db.cargo, "IdCargo", "nomeCargo", funcionario.IdCargo);
            ViewBag.IdCliente = new SelectList(db.cliente, "IdCliente", "Nome", funcionario.IdCliente);
            return View(funcionario);
        }

        // GET: funcionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcionario funcionario = db.funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCargo = new SelectList(db.cargo, "IdCargo", "nomeCargo", funcionario.IdCargo);
            ViewBag.IdCliente = new SelectList(db.cliente, "IdCliente", "Nome", funcionario.IdCliente);
            return View(funcionario);
        }

        // POST: funcionario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFuncionario,Nome,IdCargo,IdCliente")] funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCargo = new SelectList(db.cargo, "IdCargo", "nomeCargo", funcionario.IdCargo);
            ViewBag.IdCliente = new SelectList(db.cliente, "IdCliente", "Nome", funcionario.IdCliente);
            return View(funcionario);
        }

        // GET: funcionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcionario funcionario = db.funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            funcionario funcionario = db.funcionario.Find(id);
            db.funcionario.Remove(funcionario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
