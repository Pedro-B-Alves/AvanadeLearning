using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class AulaQuesto
    {
        public AulaQuesto()
        {
            QuestaoFeita = new HashSet<QuestaoFeitum>();
        }

        [Key]
        public int IdAulaQuestoes { get; set; }
        [Required(ErrorMessage = "Inserir o id da questão é obrigatório", AllowEmptyStrings = false)]
        public int? IdQuestao { get; set; }
        [Required(ErrorMessage = "Inserir o id do usuário é obrigatório", AllowEmptyStrings = false)]
        public int? IdUsuario { get; set; }
        [Required(ErrorMessage = "Inserir o id da aula é obrigatório", AllowEmptyStrings = false)]
        public int? IdAula { get; set; }
        [StringLength(2, MinimumLength = 1)]
        public int? Nota { get; set; }

        public virtual Aula IdAulaNavigation { get; set; }
        public virtual Questao IdQuestaoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<QuestaoFeitum> QuestaoFeita { get; set; }
    }
}
