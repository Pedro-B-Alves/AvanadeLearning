using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class RedesUsuario
    {
        [Key]
        public int IdRedesUsuario { get; set; }
        [Required(ErrorMessage = "Inserir o id da rede social é obrigatório", AllowEmptyStrings = false)]
        public int? IdRedeSocial { get; set; }
        [Required(ErrorMessage = "Inserir o id do usuário é obrigatório", AllowEmptyStrings = false)]
        public int? IdUsuario { get; set; }
        [Required(ErrorMessage = "O link da rede social do usuário é obrigatório", AllowEmptyStrings = false)]
        [StringLength(800, MinimumLength = 6)]
        public string Link { get; set; }

        public virtual RedeSocial IdRedeSocialNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
