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
    public class agendaController : Controller
    {
        private salaoEntities db = new salaoEntities();

        // GET: agenda
        public ActionResult Index()
        {
            var agenda = db.agenda.Include(a => a.funcionario);
            return View(agenda.ToList());
        }

        // GET: agenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agenda agenda = db.agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // GET: agenda/Create
        public ActionResult Create()
        {

            int idSessao = int.Parse(Session["IdCliente"].ToString());

            var filtro = from f in db.funcionario where f.IdCliente == idSessao select f;

            ViewBag.IdFuncionario = new SelectList(filtro, "IdFuncionario", "Nome");
            return View();
        }

        // POST: agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAgenda,NomeCliente,DataAgenda,IdFuncionario")] agenda agenda)
        {
            if (ModelState.IsValid)
            {
                db.agenda.Add(agenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFuncionario = new SelectList(db.funcionario, "IdFuncionario", "Nome", agenda.IdFuncionario);
            return View(agenda);
        }

        // GET: agenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agenda agenda = db.agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFuncionario = new SelectList(db.funcionario, "IdFuncionario", "Nome", agenda.IdFuncionario);
            return View(agenda);
        }

        // POST: agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAgenda,NomeCliente,DataAgenda,IdFuncionario")] agenda agenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFuncionario = new SelectList(db.funcionario, "IdFuncionario", "Nome", agenda.IdFuncionario);
            return View(agenda);
        }

        // GET: agenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agenda agenda = db.agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // POST: agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            agenda agenda = db.agenda.Find(id);
            db.agenda.Remove(agenda);
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
