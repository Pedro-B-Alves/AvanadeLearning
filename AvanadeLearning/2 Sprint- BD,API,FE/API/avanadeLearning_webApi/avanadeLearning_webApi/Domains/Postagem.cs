using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class Postagem
    {
        public Postagem()
        {
            ArquivoPostagems = new HashSet<ArquivoPostagem>();
            LikePostagems = new HashSet<LikePostagem>();
        }

        [Key]
        public int IdPostagem { get; set; }
        [Required(ErrorMessage = "Inserir o id do usuário é obrigatório", AllowEmptyStrings = false)]
        public int? IdUsuario { get; set; }
        [Required(ErrorMessage = "Inserir o id do curso é obrigatório", AllowEmptyStrings = false)]
        public int? IdCurso { get; set; }
        [Required(ErrorMessage = "Inserir um texto é obrigatório", AllowEmptyStrings = false)]
        [StringLength(600, MinimumLength = 2)]
        public string Texto { get; set; }
        [Required(ErrorMessage = "Inserir uma data é obrigatório", AllowEmptyStrings = false)]
        public DateTime DataPostagem { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<ArquivoPostagem> ArquivoPostagems { get; set; }
        public virtual ICollection<LikePostagem> LikePostagems { get; set; }
    }
}
