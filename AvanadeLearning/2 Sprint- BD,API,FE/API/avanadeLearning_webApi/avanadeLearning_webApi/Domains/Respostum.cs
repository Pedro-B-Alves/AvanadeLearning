using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class Respostum
    {
        [Key]
        public int IdResposta { get; set; }
        [Required(ErrorMessage = "Inserir o id da questão é obrigatório", AllowEmptyStrings = false)]
        public int? IdQuestao { get; set; }
        [Required(ErrorMessage = "A resposta é obrigatória", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 1)]
        public string Resposta { get; set; }
        [Required(ErrorMessage = "Diga se a resposta é correta", AllowEmptyStrings = false)]
        public bool Correta { get; set; }

        public virtual Questao IdQuestaoNavigation { get; set; }
    }
}
