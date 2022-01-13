using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class Instituicao
    {
        public Instituicao()
        {
            Cursos = new HashSet<Curso>();
        }

        [Key]
        public int IdInstituicao { get; set; }
        [Required(ErrorMessage = "Inserir um nome fantasia para a instituição é obrigatório", AllowEmptyStrings = false)]
        [StringLength(250, MinimumLength = 3)]
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        [Required(ErrorMessage = "Inserir um endereço para a instituição é obrigatório", AllowEmptyStrings = false)]
        [StringLength(500, MinimumLength = 5)]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Inserir um CNPJ para a instituição é obrigatório", AllowEmptyStrings = false)]
        [StringLength(14, MinimumLength = 14)]
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "Inserir um telefone para a instituição é obrigatório", AllowEmptyStrings = false)]
        [StringLength(11, MinimumLength = 10)]
        public string Telefone { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
