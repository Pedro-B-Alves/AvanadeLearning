using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class CategoriasQuestao
    {
        [Key]
        public int IdCategoriasQuestao { get; set; }
        [Required(ErrorMessage = "Inserir o id categoria questao é obrigatório", AllowEmptyStrings = false)]
        public int? IdCategoriaQuestao { get; set; }
        [Required(ErrorMessage = "Inserir o id questao é obrigatório", AllowEmptyStrings = false)]
        public int? IdQuestao { get; set; }

        public virtual CategoriaQuestao IdCategoriaQuestaoNavigation { get; set; }
        public virtual Questao IdQuestaoNavigation { get; set; }
    }
}
