using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class Estado
    {
        public Estado()
        {
            EstadoUsuarios = new HashSet<EstadoUsuario>();
        }

        [Key]
        public int IdEstado { get; set; }
        [Required(ErrorMessage = "Inserir um id pais para o estado é obrigatório", AllowEmptyStrings = false)]
        public int? IdPais { get; set; }
        [Required(ErrorMessage = "Inserir um nome para o estado é obrigatório", AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 2)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Inserir uma imagem para o estado é obrigatório", AllowEmptyStrings = false)]
        public string Imagem { get; set; }

        public virtual Pai IdPaisNavigation { get; set; }
        public virtual ICollection<EstadoUsuario> EstadoUsuarios { get; set; }
    }
}
