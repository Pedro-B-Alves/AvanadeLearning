using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class EstadoUsuario
    {
        [Key]
        public int IdEstadoUsuario { get; set; }
        [Required(ErrorMessage = "Inserir um id estado é obrigatório", AllowEmptyStrings = false)]
        public int? IdEstado { get; set; }
        [Required(ErrorMessage = "Inserir um id usuário é obrigatório", AllowEmptyStrings = false)]
        public int? IdUsuario { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
