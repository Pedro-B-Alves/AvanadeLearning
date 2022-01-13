using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class Pai
    {
        public Pai()
        {
            Estados = new HashSet<Estado>();
        }

        [Key]
        public int IdPais { get; set; }
        [Required(ErrorMessage = "Inserir um nome de pais é obrigatório", AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 3)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Inserir a imagem do pais é obrigatório", AllowEmptyStrings = false)]
        public string Imagem { get; set; }

        public virtual ICollection<Estado> Estados { get; set; }
    }
}
