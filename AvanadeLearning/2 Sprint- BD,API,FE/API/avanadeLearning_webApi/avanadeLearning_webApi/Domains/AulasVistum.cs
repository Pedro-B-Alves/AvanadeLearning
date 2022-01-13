using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class AulasVistum
    {
        [Key]
        public int IdAulasVista { get; set; }
        [Required(ErrorMessage = "Inserir o id da aula é obrigatório", AllowEmptyStrings = false)]
        public int? IdAula { get; set; }
        public int? IdUsuario { get; set; }
        [Required(ErrorMessage = "Inserir se a aula foi vista é obrigatório", AllowEmptyStrings = false)]
        public bool Visto { get; set; }
        [Required(ErrorMessage = "Inserir os pontos é obrigatório", AllowEmptyStrings = false)]
        public int Pontos { get; set; }

        public virtual Aula IdAulaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
