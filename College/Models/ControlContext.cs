using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace College.Models
{
    public class ControlContext : DbContext
    {
        public ControlContext() : base("DefaultConnection")
        {

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        //public DbSet<RelacaoAlunoCurso> RelacaoAlunoCurso{ get; set; }


    }
}