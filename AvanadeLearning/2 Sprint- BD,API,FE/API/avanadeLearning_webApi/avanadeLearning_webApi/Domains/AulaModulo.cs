using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class AulaModulo
    {
        [Key]
        public int IdAulaModulo { get; set; }
        [Required(ErrorMessage = "Inserir o id da aula é obrigatório", AllowEmptyStrings = false)]
        public int? IdAula { get; set; }
        [Required(ErrorMessage = "Inserir o id do modulo é obrigatório", AllowEmptyStrings = false)]
        public int? IdModulo { get; set; }

        public virtual Aula IdAulaNavigation { get; set; }
        public virtual Modulo IdModuloNavigation { get; set; }
    }
}
