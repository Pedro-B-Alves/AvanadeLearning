using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class Modulo
    {
        public Modulo()
        {
            ArquivoModulos = new HashSet<ArquivoModulo>();
            AulaModulos = new HashSet<AulaModulo>();
            Conquista = new HashSet<Conquistum>();
        }

        [Key]
        public int IdModulo { get; set; }
        [Required(ErrorMessage = "Inserir o id do curso é obrigatório", AllowEmptyStrings = false)]
        public int? IdCurso { get; set; }
        [Required(ErrorMessage = "Inserir um nome do modulo é obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 3)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Inserir um texto par o modulo é obrigatório", AllowEmptyStrings = false)]
        [StringLength(500, MinimumLength = 3)]
        public string Texto { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual ICollection<ArquivoModulo> ArquivoModulos { get; set; }
        public virtual ICollection<AulaModulo> AulaModulos { get; set; }
        public virtual ICollection<Conquistum> Conquista { get; set; }
    }
}
