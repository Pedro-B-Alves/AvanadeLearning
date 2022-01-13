using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class Curso
    {
        public Curso()
        {
            CategoriasCursos = new HashSet<CategoriasCurso>();
            Conquista = new HashSet<Conquistum>();
            Cursandos = new HashSet<Cursando>();
            Modulos = new HashSet<Modulo>();
            Postagems = new HashSet<Postagem>();
        }

        [Key]
        public int IdCurso { get; set; }
        [Required(ErrorMessage = "Inserir o id da instituição é obrigatório", AllowEmptyStrings = false)]
        public int? IdInstituicao { get; set; }
        [Required(ErrorMessage = "Inserir um nome para o curso é obrigatório", AllowEmptyStrings = false)]
        [StringLength(250, MinimumLength = 2)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Inserir uma descrição para o curso é obrigatório", AllowEmptyStrings = false)]
        [StringLength(800, MinimumLength = 2)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Inserir uma imagem para o curso é obrigatório", AllowEmptyStrings = false)]
        public string Imagem { get; set; }
        [Required(ErrorMessage = "Inserir o tanto de horas do curso é obrigatório", AllowEmptyStrings = false)]
        public int Horas { get; set; }

        public virtual Instituicao IdInstituicaoNavigation { get; set; }
        public virtual ICollection<CategoriasCurso> CategoriasCursos { get; set; }
        public virtual ICollection<Conquistum> Conquista { get; set; }
        public virtual ICollection<Cursando> Cursandos { get; set; }
        public virtual ICollection<Modulo> Modulos { get; set; }
        public virtual ICollection<Postagem> Postagems { get; set; }
    }
}
