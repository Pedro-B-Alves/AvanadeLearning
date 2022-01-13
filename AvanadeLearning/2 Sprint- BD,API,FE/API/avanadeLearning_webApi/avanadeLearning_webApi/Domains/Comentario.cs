using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class Comentario
    {
        public Comentario()
        {
            LikeComentarios = new HashSet<LikeComentario>();
        }

        [Key]
        public int IdComentario { get; set; }
        [Required(ErrorMessage = "Inserir o id usuário é obrigatório", AllowEmptyStrings = false)]
        public int? IdUsuario { get; set; }
        [Required(ErrorMessage = "Inserir um id aula é obrigatório", AllowEmptyStrings = false)]
        public int? IdAula { get; set; }
        [Required(ErrorMessage = "Inserir um comentario é obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 5)]
        public string Comentario1 { get; set; }

        public virtual Aula IdAulaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<LikeComentario> LikeComentarios { get; set; }
    }
}
