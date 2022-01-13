using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class LikePostagem
    {
        [Key]
        public int IdLikePostagem { get; set; }
        [Required(ErrorMessage = "Inserir o id da postagem é obrigatório", AllowEmptyStrings = false)]
        public int? IdPostagem { get; set; }
        [Required(ErrorMessage = "Inserir o id do usuário é obrigatório", AllowEmptyStrings = false)]
        public int? IdUsuario { get; set; }
        [Required(ErrorMessage = "Inserir se é um like ou dislike obrigatório", AllowEmptyStrings = false)]
        public bool Like { get; set; }

        public virtual Postagem IdPostagemNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
