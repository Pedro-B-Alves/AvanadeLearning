using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class Questao
    {
        public Questao()
        {
            AulaQuestos = new HashSet<AulaQuesto>();
            CategoriasQuestaos = new HashSet<CategoriasQuestao>();
            Resposta = new HashSet<Respostum>();
        }

        [Key]
        public int IdQuestao { get; set; }
        [Required(ErrorMessage = "A pergunta da questão é obrigatória", AllowEmptyStrings = false)]
        [StringLength(800, MinimumLength = 10)]
        public string Pergunta { get; set; }
        [Required(ErrorMessage = "Informe quantos pontos vale essa questão", AllowEmptyStrings = false)]
        public int PontosNota { get; set; }

        public virtual ICollection<AulaQuesto> AulaQuestos { get; set; }
        public virtual ICollection<CategoriasQuestao> CategoriasQuestaos { get; set; }
        public virtual ICollection<Respostum> Resposta { get; set; }
    }
}
