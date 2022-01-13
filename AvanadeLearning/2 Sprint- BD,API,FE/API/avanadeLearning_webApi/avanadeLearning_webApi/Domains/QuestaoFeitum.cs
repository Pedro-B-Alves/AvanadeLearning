using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class QuestaoFeitum
    {
        [Key]
        public int IdQuestaoFeita { get; set; }
        [Required(ErrorMessage = "Inserir o id da aulaQuestoes é obrigatório", AllowEmptyStrings = false)]
        public int? IdAulaQuestoes { get; set; }
        [Required(ErrorMessage = "Inserir o id do usuário é obrigatório", AllowEmptyStrings = false)]
        public int? IdUsuario { get; set; }
        [Required(ErrorMessage = "Informe se a questão foi feita", AllowEmptyStrings = false)]
        public bool Feito { get; set; }
        [Required(ErrorMessage = "Informar os pontos é obrigatório", AllowEmptyStrings = false)]
        public int? Pontos { get; set; }

        public virtual AulaQuesto IdAulaQuestoesNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
