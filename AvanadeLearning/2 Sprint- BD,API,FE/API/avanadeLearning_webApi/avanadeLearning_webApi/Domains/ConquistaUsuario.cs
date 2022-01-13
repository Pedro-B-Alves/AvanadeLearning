using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class ConquistaUsuario
    {
        [Key]
        public int IdConquistaUsuario { get; set; }
        [Required(ErrorMessage = "Inserir o id conquista é obrigatório", AllowEmptyStrings = false)]
        public int? IdConquista { get; set; }
        [Required(ErrorMessage = "Inserir o id usuário é obrigatório", AllowEmptyStrings = false)]
        public int? IdUsuario { get; set; }

        public virtual Conquistum IdConquistaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
