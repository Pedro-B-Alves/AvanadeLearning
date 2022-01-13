using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class CategoriaCurso
    {
        public CategoriaCurso()
        {
            CategoriasCursos = new HashSet<CategoriasCurso>();
        }

        [Key]
        public int IdCategoriaCurso { get; set; }
        [Required(ErrorMessage = "Inserir o categoria do curso é obrigatória", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 2)]
        public string Categoria { get; set; }

        public virtual ICollection<CategoriasCurso> CategoriasCursos { get; set; }
    }
}
