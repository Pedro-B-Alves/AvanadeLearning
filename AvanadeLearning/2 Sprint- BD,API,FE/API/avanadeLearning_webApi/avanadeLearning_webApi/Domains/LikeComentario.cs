using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class LikeComentario
    {
        [Key]
        public int IdLikeComentario { get; set; }
        [Required(ErrorMessage = "Inserir o id do usuário é obrigatório", AllowEmptyStrings = false)]
        public int? IdUsuario { get; set; }
        [Required(ErrorMessage = "Inserir o id do comentario é obrigatório", AllowEmptyStrings = false)]
        public int? IdComentario { get; set; }
        [Required(ErrorMessage = "Inserir se é um like ou dislike obrigatório", AllowEmptyStrings = false)]
        public bool Like { get; set; }

        public virtual Comentario IdComentarioNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
