using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class ArquivoModulo
    {
        [Key]
        public int IdArquivoModulo { get; set; }
        [Required(ErrorMessage = "Inserir o id do modulo é obrigatório", AllowEmptyStrings = false)]
        public int? IdModulo { get; set; }
        [Required(ErrorMessage = "Inserir um arquivo é obrigatório", AllowEmptyStrings = false)]
        public string Arquivo { get; set; }

        public virtual Modulo IdModuloNavigation { get; set; }
    }
}
