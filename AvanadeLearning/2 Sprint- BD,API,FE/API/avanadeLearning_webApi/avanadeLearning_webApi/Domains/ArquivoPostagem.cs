using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class ArquivoPostagem
    {
        [Key]
        public int IdArquivoPostagem { get; set; }
        [Required(ErrorMessage = "Inserir o id da postagem é obrigatório", AllowEmptyStrings = false)]
        public int? IdPostagem { get; set; }
        [Required(ErrorMessage = "Inserir um arquivo é obrigatório", AllowEmptyStrings = false)]
        public string Arquivo { get; set; }

        public virtual Postagem IdPostagemNavigation { get; set; }
    }
}
