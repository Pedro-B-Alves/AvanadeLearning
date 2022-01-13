using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace avanadeLearning_webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            AulaQuestos = new HashSet<AulaQuesto>();
            AulasVista = new HashSet<AulasVistum>();
            Comentarios = new HashSet<Comentario>();
            ConquistaUsuarios = new HashSet<ConquistaUsuario>();
            Cursandos = new HashSet<Cursando>();
            EstadoUsuarios = new HashSet<EstadoUsuario>();
            LikeComentarios = new HashSet<LikeComentario>();
            LikePostagems = new HashSet<LikePostagem>();
            Postagems = new HashSet<Postagem>();
            QuestaoFeita = new HashSet<QuestaoFeitum>();
            RedesUsuarios = new HashSet<RedesUsuario>();
            UsuarioArquetipos = new HashSet<UsuarioArquetipo>();
        }

        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "O tipo de usuário é obrigatório", AllowEmptyStrings = false)]
        public int? IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }
        [StringLength(150, MinimumLength = 3)]
        [Required(ErrorMessage = "O email do usuário é obrigatório", AllowEmptyStrings = false)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha do usuário é obrigatória", AllowEmptyStrings = false)]
        [StringLength(8, MinimumLength = 6)]
        public string Senha { get; set; }
        public string Imagem { get; set; }
        [StringLength(9, MinimumLength = 9)]
        public string Rg { get; set; }
        [StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataNascimento { get; set; }
        [StringLength(11, MinimumLength = 10)]
        public string Telefone { get; set; }
        public int? Pontos { get; set; }
        public int? PontosSemanais { get; set; }
        public string SobreMim { get; set; }
        public string ImagemBackground { get; set; }
        [StringLength(150, MinimumLength = 3)]
        public string Empresa { get; set; }
        [StringLength(150, MinimumLength = 3)]
        public string Cargo { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<AulaQuesto> AulaQuestos { get; set; }
        public virtual ICollection<AulasVistum> AulasVista { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<ConquistaUsuario> ConquistaUsuarios { get; set; }
        public virtual ICollection<Cursando> Cursandos { get; set; }
        public virtual ICollection<EstadoUsuario> EstadoUsuarios { get; set; }
        public virtual ICollection<LikeComentario> LikeComentarios { get; set; }
        public virtual ICollection<LikePostagem> LikePostagems { get; set; }
        public virtual ICollection<Postagem> Postagems { get; set; }
        public virtual ICollection<QuestaoFeitum> QuestaoFeita { get; set; }
        public virtual ICollection<RedesUsuario> RedesUsuarios { get; set; }
        public virtual ICollection<UsuarioArquetipo> UsuarioArquetipos { get; set; }
    }
}
