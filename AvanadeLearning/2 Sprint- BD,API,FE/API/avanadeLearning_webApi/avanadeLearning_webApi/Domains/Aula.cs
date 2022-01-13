using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class Aula
    {
        public Aula()
        {
            AulaModulos = new HashSet<AulaModulo>();
            AulaQuestos = new HashSet<AulaQuesto>();
            AulasVista = new HashSet<AulasVistum>();
            Comentarios = new HashSet<Comentario>();
        }

        [Key]
        public int IdAula { get; set; }
        public string Video { get; set; }
        [StringLength(200, MinimumLength = 5)]
        public string Descricao { get; set; }
        [StringLength(800, MinimumLength = 5)]
        public string LinkConteudoExtra { get; set; }
        [StringLength(150, MinimumLength = 2)]
        public string Titulo { get; set; }

        public virtual ICollection<AulaModulo> AulaModulos { get; set; }
        public virtual ICollection<AulaQuesto> AulaQuestos { get; set; }
        public virtual ICollection<AulasVistum> AulasVista { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
