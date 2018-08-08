using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace College.Models
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }


        [Display(Name = "Nome do Curso")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [StringLength(100, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]
        [Index("NomeCursoIndex", IsUnique = true)]
        public string NomeCurso { get; set; }


        [Display(Name = "Descrição do Curso")]
        //[Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(500, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 7)]
        //[DataType(DataType.EmailAddress)]
        public string DescricaoCurso { get; set; }

        [Display(Name = "Data de início")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(500, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 7)]
        [DataType(DataType.Date)]
        public string DataICurso { get; set; }

        [Display(Name = "Data de fim")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(500, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 7)]
        [DataType(DataType.Date)]
        public string DataFCurso { get; set; }



    }



}