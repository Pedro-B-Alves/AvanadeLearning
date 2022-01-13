using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class RedeSocial
    {
        public RedeSocial()
        {
            RedesUsuarios = new HashSet<RedesUsuario>();
        }

        [Key]
        public int IdRedeSocial { get; set; }
        [Required(ErrorMessage = "O nome da rede social é obrigatório", AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 3)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O link da rede social é obrigatório", AllowEmptyStrings = false)]
        [StringLength(255, MinimumLength = 6)]
        public string LinkBase { get; set; }

        public virtual ICollection<RedesUsuario> RedesUsuarios { get; set; }
    }
}
