using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class Cursando
    {
        [Key]
        public int IdCursando { get; set; }
        [Required(ErrorMessage = "Inserir um id usuário é obrigatório", AllowEmptyStrings = false)]
        public int? IdUsuario { get; set; }
        [Required(ErrorMessage = "Inserir um id curso é obrigatório", AllowEmptyStrings = false)]
        public int? IdCurso { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
