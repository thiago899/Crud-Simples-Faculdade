using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace College.Models
{
    public class Aluno

    {
        [Key]
        public int AlunoId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]

        public string Nome { get; set; }



        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 7)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Por favor, informe um e-mail válido")]
        public string Email { get; set; }

        [Display(Name = "Idade")]
        [Range(18, 100, ErrorMessage = "A idade deve ser maior que 18 anos.")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        //[StringLength(2, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]
        public int Idade { get; set; }



        public int CursoId { get; set; }

        //[ForeignKey("RefCursoId")]
        public virtual ICollection<Curso> Curso { get; set; }






    }


}

