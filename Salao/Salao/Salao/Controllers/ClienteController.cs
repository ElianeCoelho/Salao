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
    public class ClienteController : Controller
    {
        private salaoEntities db = new salaoEntities();

        // GET: cliente
        public ActionResult PerfilCliente()
        {

            int idSessao = int.Parse(Session["IdCliente"].ToString());

            var filtro = from f in db.cliente where f.IdCliente == idSessao select f;


            return View(filtro);

        }

        // GET: cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCliente,Nome,Cpf,Telefone,NomeSalao,Cep,Rua,Numero,Complemento,Bairro,Cidade,Estado,Email,Senha,ConfirmaSenha")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCliente,Nome,Cpf,Telefone,NomeSalao,Cep,Rua,Numero,Complemento,Bairro,Cidade,Estado,Email,Senha,ConfirmaSenha")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cliente cliente = db.cliente.Find(id);
            db.cliente.Remove(cliente);
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


        public ActionResult Index()
        {
            return View();
        }


        //Login

        public ActionResult Login()
        {
            return View();
        }


        //ValidaLogin
        [HttpPost]
        public ActionResult Login(cliente client)
        {
            using (salaoEntities db = new salaoEntities())
            {
                var cli = db.cliente.Single(c => c.Email == client.Email && c.Senha == client.Senha);
                if (cli != null)
                {
                    Session["IdCliente"] = cli.IdCliente.ToString();
                    Session["Email"] = cli.Nome.ToString();

                    return RedirectToAction("Index");

                }
                else
                {


                    ModelState.AddModelError("", "Email ou Senha Incorreto.");
                }
            }
            return View();
        }






    }
}
