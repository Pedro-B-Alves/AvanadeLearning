using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class CategoriaQuestao
    {
        public CategoriaQuestao()
        {
            CategoriasQuestaos = new HashSet<CategoriasQuestao>();
        }

        [Key]
        public int IdCategoriaQuestao { get; set; }
        [StringLength(150, MinimumLength = 2)]
        public string Nome { get; set; }

        public virtual ICollection<CategoriasQuestao> CategoriasQuestaos { get; set; }
    }
}
