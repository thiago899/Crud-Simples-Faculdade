using College.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System;
using static System.Net.WebRequestMethods;

namespace College.Controllers
{
    public class AlunosController : Controller
    {
        private ControlContext db = new ControlContext();

        // GET: Alunos
        public ActionResult Index()
        {

            return View(db.Alunos.ToList());
        }

        // GET: Alunos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Alunos/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlunoId,Nome,Email,Idade")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var VerificarEmail = EmailSemRepeticao(aluno.Email.ToString());
                if (VerificarEmail)
                {
                    db.Alunos.Add(aluno);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Exist = aluno.Email.ToString() + " Já existe em nosso banco de dados.";
                    return View();
                }

            }

            return View(aluno);
        }

        //Método que não permite cadastrar e-mail duplicado
        public Boolean EmailSemRepeticao(string Email)
        {
            var EmailSemRepeticao = db.Alunos.Where(u => u.Email == Email).Count() == 0;

            return EmailSemRepeticao;

        }


        // GET: Alunos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlunoId,Nome,Email,Idade")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            db.Alunos.Remove(aluno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult Pesquisa(AlunoVM _alunovm)
        //{
        //    using (var db = new ControlContext())
        //    {
        //        var AlunoPesquisa = from alunoes in db.Alunos
        //                            where ((_alunovm.Nome == null) || (alunoes.Nome == _alunovm.Nome.Trim()))
        //                            && ((_alunovm.Email == null) || (alunoes.Email == _alunovm.Email.Trim()))
        //                            && ((_alunovm.Idade == null))
        //                            select new
        //                            {
        //                                alunoes.AlunoId,
        //                                alunoes.Nome,
        //                                alunoes.Email,
        //                                alunoes.Idade
        //                            };

        //        List<Aluno> listaAlunos = new List<Aluno>();

        //        foreach (var reg in AlunoPesquisa)
        //        {
        //            Aluno aluno = new Aluno();
        //            aluno.AlunoId = reg.AlunoId;
        //            aluno.Nome = reg.Nome;
        //            aluno.Email = reg.Email;
        //            aluno.Idade = reg.Idade;
        //            listaAlunos.Add(aluno);
        //        }

        //        _alunovm.Alunos = listaAlunos;

        //        return View(_alunovm);
        //    }
        //}



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
