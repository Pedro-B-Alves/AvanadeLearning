using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class CategoriasCurso
    {
        [Key]
        public int IdCategoriasCurso { get; set; }
        [Required(ErrorMessage = "Inserir o id curso é obrigatório", AllowEmptyStrings = false)]
        public int? IdCurso { get; set; }
        [Required(ErrorMessage = "Inserir o id categoria curso é obrigatório", AllowEmptyStrings = false)]
        public int? IdCategoriaCurso { get; set; }

        public virtual CategoriaCurso IdCategoriaCursoNavigation { get; set; }
        public virtual Curso IdCursoNavigation { get; set; }
    }
}
