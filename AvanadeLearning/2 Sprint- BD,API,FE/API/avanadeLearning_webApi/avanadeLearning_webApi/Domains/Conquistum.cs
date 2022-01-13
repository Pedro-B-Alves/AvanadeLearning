using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class Conquistum
    {
        public Conquistum()
        {
            ConquistaUsuarios = new HashSet<ConquistaUsuario>();
        }

        [Key]
        public int IdConquista { get; set; }
        [Required(ErrorMessage = "Inserir um id modulo é obrigatório", AllowEmptyStrings = false)]
        public int? IdModulo { get; set; }
        [Required(ErrorMessage = "Inserir um id curso é obrigatório", AllowEmptyStrings = false)]
        public int? IdCurso { get; set; }
        [Required(ErrorMessage = "Inserir um nome da conquista é obrigatória", AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 2)]
        public string Nome { get; set; }
        [StringLength(300, MinimumLength = 5)]
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        [Required(ErrorMessage = "Inserir os pontos da conquista é obrigatório", AllowEmptyStrings = false)]
        public int Pontos { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Modulo IdModuloNavigation { get; set; }
        public virtual ICollection<ConquistaUsuario> ConquistaUsuarios { get; set; }
    }
}
