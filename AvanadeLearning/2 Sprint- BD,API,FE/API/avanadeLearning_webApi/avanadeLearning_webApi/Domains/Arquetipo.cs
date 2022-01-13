using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class Arquetipo
    {
        public Arquetipo()
        {
            UsuarioArquetipos = new HashSet<UsuarioArquetipo>();
        }

        [Key]
        public int IdArquetipo { get; set; }
        [Required(ErrorMessage = "Inserir o nome do arquetipo é obrigatório", AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 2)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Inserir a imagem do arquetipo é obrigatório", AllowEmptyStrings = false)]
        public string Imagem { get; set; }
        [Required(ErrorMessage = "Inserir a descrição do arquetipo é obrigatório", AllowEmptyStrings = false)]
        [StringLength(800, MinimumLength = 2)]
        public string Descricao { get; set; }

        public virtual ICollection<UsuarioArquetipo> UsuarioArquetipos { get; set; }
    }
}
