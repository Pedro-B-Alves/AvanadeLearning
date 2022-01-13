using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class UsuarioArquetipo
    {
        [Key]
        public int IdUsuarioArquetipo { get; set; }
        [Required(ErrorMessage = "Inserir o id do arquetipo é obrigatório", AllowEmptyStrings = false)]
        public int? IdArquetipo { get; set; }
        [Required(ErrorMessage = "Inserir o id do usuário é obrigatório", AllowEmptyStrings = false)]
        public int? IdUsuario { get; set; }
        [Required(ErrorMessage = "A porcentagem do arquetipo é obrigatória", AllowEmptyStrings = false)]
        public int Porcentagem { get; set; }
        [Required(ErrorMessage = "Diga se esse arquetipo está ativo", AllowEmptyStrings = false)]
        public bool Ativo { get; set; }

        public virtual Arquetipo IdArquetipoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
