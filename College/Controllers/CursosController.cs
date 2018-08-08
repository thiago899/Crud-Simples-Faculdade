using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using College.Models;

namespace College.Controllers
{
    public class CursosController : Controller
    {
        private ControlContext db = new ControlContext();

        //Adicionar Alunos
        public ActionResult AddAluno(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(id.ToString(),db.Alunos.ToList());



            //var view = new Curso
            //{
            //    CursoId = id.Value,
            //};

            //ViewBag.AlunoId = new SelectList(db.Alunos.Where(u => u.AlunoId).OrderBy(u => u.Nome), "AlunoId", "nome", curso.CursoId);
        }

        // GET: Cursos
        public ActionResult Index()
        {
            return View(db.Cursos.ToList());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Alunos
        public ActionResult AddAlunos()
        {
            return View(db.Alunos.ToList());
             
        }

  

        // GET: Cursos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CursoId,NomeCurso,DescricaoCurso,DataICurso,DataFCurso")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                var VerificarCurso = CursoSemRepeticao(curso.NomeCurso.ToString());
                if (VerificarCurso)
                {
                    db.Cursos.Add(curso);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Exist = curso.NomeCurso.ToString() + " Já existe em nosso banco de dados.";
                    return View();
                }
              
            }

            return View(curso);
        }


        //Método que não permite cadastrar nome de curso duplicado
        public Boolean CursoSemRepeticao(string nomeCurso)
        {
            var CursoSemRepeticao = db.Cursos.Where(u => u.NomeCurso == nomeCurso).Count() == 0;

            return CursoSemRepeticao;

        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CursoId,NomeCurso,DescricaoCurso,DataICurso,DataFCurso")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Cursos.Find(id);
            db.Cursos.Remove(curso);
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
