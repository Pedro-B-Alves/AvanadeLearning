using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using avanadeLearning_webApi.Domains;

#nullable disable

namespace avanadeLearning_webApi.Contexts
{
    public partial class AvanadeLearningContext : DbContext
    {
        public AvanadeLearningContext()
        {
        }

        public AvanadeLearningContext(DbContextOptions<AvanadeLearningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arquetipo> Arquetipos { get; set; }
        public virtual DbSet<ArquivoModulo> ArquivoModulos { get; set; }
        public virtual DbSet<ArquivoPostagem> ArquivoPostagems { get; set; }
        public virtual DbSet<Aula> Aulas { get; set; }
        public virtual DbSet<AulaModulo> AulaModulos { get; set; }
        public virtual DbSet<AulaQuesto> AulaQuestoes { get; set; }
        public virtual DbSet<AulasVistum> AulasVista { get; set; }
        public virtual DbSet<CategoriaCurso> CategoriaCursos { get; set; }
        public virtual DbSet<CategoriaQuestao> CategoriaQuestaos { get; set; }
        public virtual DbSet<CategoriasCurso> CategoriasCursos { get; set; }
        public virtual DbSet<CategoriasQuestao> CategoriasQuestaos { get; set; }
        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<ConquistaUsuario> ConquistaUsuarios { get; set; }
        public virtual DbSet<Conquistum> Conquista { get; set; }
        public virtual DbSet<Cursando> Cursandos { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<EstadoUsuario> EstadoUsuarios { get; set; }
        public virtual DbSet<Instituicao> Instituicaos { get; set; }
        public virtual DbSet<LikeComentario> LikeComentarios { get; set; }
        public virtual DbSet<LikePostagem> LikePostagems { get; set; }
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Postagem> Postagems { get; set; }
        public virtual DbSet<Questao> Questaos { get; set; }
        public virtual DbSet<QuestaoFeitum> QuestaoFeita { get; set; }
        public virtual DbSet<RedeSocial> RedeSocials { get; set; }
        public virtual DbSet<RedesUsuario> RedesUsuarios { get; set; }
        public virtual DbSet<Respostum> Resposta { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioArquetipo> UsuarioArquetipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
<<<<<<< HEAD
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
              // optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=avanadeLearning; Integrated Security=True");
               //optionsBuilder.UseSqlServer("Data Source=.\\SSQLExpress; Initial Catalog=avanadeLearning; user id=admin; pwd=Lgni734ZOqktt7q9BZCI");
=======
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
>>>>>>> 2876515b3dfe8d86cb1d9f58292fcd0646ea1c03
                optionsBuilder.UseSqlServer("Data Source=database-1.cb12qr6tyrzv.us-east-1.rds.amazonaws.com; User Id=admin;Password=Lgni734ZOqktt7q9BZCI; Initial Catalog=avanadeLearning;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Arquetipo>(entity =>
            {
                entity.HasKey(e => e.IdArquetipo)
                    .HasName("PK__arquetip__669565E14532A001");

                entity.ToTable("arquetipo");

                entity.HasIndex(e => e.Nome, "UQ__arquetip__6F71C0DC6496073C")
                    .IsUnique();

                entity.Property(e => e.IdArquetipo).HasColumnName("idArquetipo");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.Imagem)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<ArquivoModulo>(entity =>
            {
                entity.HasKey(e => e.IdArquivoModulo)
                    .HasName("PK__arquivoM__3401AB9B8F36A303");

                entity.ToTable("arquivoModulo");

                entity.Property(e => e.IdArquivoModulo).HasColumnName("idArquivoModulo");

                entity.Property(e => e.Arquivo)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("arquivo");

                entity.Property(e => e.IdModulo).HasColumnName("idModulo");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.ArquivoModulos)
                    .HasForeignKey(d => d.IdModulo)
                    .HasConstraintName("FK__arquivoMo__idMod__5DCAEF64");
            });

            modelBuilder.Entity<ArquivoPostagem>(entity =>
            {
                entity.HasKey(e => e.IdArquivoPostagem)
                    .HasName("PK__arquivoP__6DEA034B132E3EA1");

                entity.ToTable("arquivoPostagem");

                entity.Property(e => e.IdArquivoPostagem).HasColumnName("idArquivoPostagem");

                entity.Property(e => e.Arquivo)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("arquivo");

                entity.Property(e => e.IdPostagem).HasColumnName("idPostagem");

                entity.HasOne(d => d.IdPostagemNavigation)
                    .WithMany(p => p.ArquivoPostagems)
                    .HasForeignKey(d => d.IdPostagem)
                    .HasConstraintName("FK__arquivoPo__idPos__5441852A");
            });

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.HasKey(e => e.IdAula)
                    .HasName("PK__aula__D861CCCB8BA39923");

                entity.ToTable("aula");

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.LinkConteudoExtra)
                    .IsUnicode(false)
                    .HasColumnName("linkConteudoExtra");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.Property(e => e.Video)
                    .IsUnicode(false)
                    .HasColumnName("video");
            });

            modelBuilder.Entity<AulaModulo>(entity =>
            {
                entity.HasKey(e => e.IdAulaModulo)
                    .HasName("PK__aulaModu__3B864C4EDE9F66B2");

                entity.ToTable("aulaModulo");

                entity.Property(e => e.IdAulaModulo).HasColumnName("idAulaModulo");

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.IdModulo).HasColumnName("idModulo");

                entity.HasOne(d => d.IdAulaNavigation)
                    .WithMany(p => p.AulaModulos)
                    .HasForeignKey(d => d.IdAula)
                    .HasConstraintName("FK__aulaModul__idAul__628FA481");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.AulaModulos)
                    .HasForeignKey(d => d.IdModulo)
                    .HasConstraintName("FK__aulaModul__idMod__6383C8BA");
            });

            modelBuilder.Entity<AulaQuesto>(entity =>
            {
                entity.HasKey(e => e.IdAulaQuestoes)
                    .HasName("PK__aulaQues__DCB4D771E7267790");

                entity.ToTable("aulaQuestoes");

                entity.Property(e => e.IdAulaQuestoes).HasColumnName("idAulaQuestoes");

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.IdQuestao).HasColumnName("idQuestao");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Nota).HasColumnName("nota");

                entity.HasOne(d => d.IdAulaNavigation)
                    .WithMany(p => p.AulaQuestos)
                    .HasForeignKey(d => d.IdAula)
                    .HasConstraintName("FK__aulaQuest__idAul__6E01572D");

                entity.HasOne(d => d.IdQuestaoNavigation)
                    .WithMany(p => p.AulaQuestos)
                    .HasForeignKey(d => d.IdQuestao)
                    .HasConstraintName("FK__aulaQuest__idQue__6C190EBB");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AulaQuestos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__aulaQuest__idUsu__6D0D32F4");
            });

            modelBuilder.Entity<AulasVistum>(entity =>
            {
                entity.HasKey(e => e.IdAulasVista)
                    .HasName("PK__aulasVis__CA9D44F596A87FBC");

                entity.ToTable("aulasVista");

                entity.Property(e => e.IdAulasVista).HasColumnName("idAulasVista");

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Pontos).HasColumnName("pontos");

                entity.Property(e => e.Visto).HasColumnName("visto");

                entity.HasOne(d => d.IdAulaNavigation)
                    .WithMany(p => p.AulasVista)
                    .HasForeignKey(d => d.IdAula)
                    .HasConstraintName("FK__aulasVist__idAul__66603565");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AulasVista)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__aulasVist__idUsu__6754599E");
            });

            modelBuilder.Entity<CategoriaCurso>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaCurso)
                    .HasName("PK__categori__A696C38BD0FE99D9");

                entity.ToTable("categoriaCurso");

                entity.HasIndex(e => e.Categoria, "UQ__categori__1179412FB624B096")
                    .IsUnique();

                entity.Property(e => e.IdCategoriaCurso).HasColumnName("idCategoriaCurso");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("categoria");
            });

            modelBuilder.Entity<CategoriaQuestao>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaQuestao)
                    .HasName("PK__categori__E6CD759A8DB0BFEC");

                entity.ToTable("categoriaQuestao");

                entity.Property(e => e.IdCategoriaQuestao).HasColumnName("idCategoriaQuestao");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<CategoriasCurso>(entity =>
            {
                entity.HasKey(e => e.IdCategoriasCurso)
                    .HasName("PK__categori__108477B8D58CE950");

                entity.ToTable("categoriasCurso");

                entity.Property(e => e.IdCategoriasCurso).HasColumnName("idCategoriasCurso");

                entity.Property(e => e.IdCategoriaCurso).HasColumnName("idCategoriaCurso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.HasOne(d => d.IdCategoriaCursoNavigation)
                    .WithMany(p => p.CategoriasCursos)
                    .HasForeignKey(d => d.IdCategoriaCurso)
                    .HasConstraintName("FK__categoria__idCat__49C3F6B7");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.CategoriasCursos)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__categoria__idCur__48CFD27E");
            });

            modelBuilder.Entity<CategoriasQuestao>(entity =>
            {
                entity.HasKey(e => e.IdCategoriasQuestao)
                    .HasName("PK__categori__3182ECE183220EC9");

                entity.ToTable("categoriasQuestao");

                entity.Property(e => e.IdCategoriasQuestao).HasColumnName("idCategoriasQuestao");

                entity.Property(e => e.IdCategoriaQuestao).HasColumnName("idCategoriaQuestao");

                entity.Property(e => e.IdQuestao).HasColumnName("idQuestao");

                entity.HasOne(d => d.IdCategoriaQuestaoNavigation)
                    .WithMany(p => p.CategoriasQuestaos)
                    .HasForeignKey(d => d.IdCategoriaQuestao)
                    .HasConstraintName("FK__categoria__idCat__72C60C4A");

                entity.HasOne(d => d.IdQuestaoNavigation)
                    .WithMany(p => p.CategoriasQuestaos)
                    .HasForeignKey(d => d.IdQuestao)
                    .HasConstraintName("FK__categoria__idQue__73BA3083");
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => e.IdComentario)
                    .HasName("PK__comentar__C74515DA6F320A04");

                entity.ToTable("comentario");

                entity.Property(e => e.IdComentario).HasColumnName("idComentario");

                entity.Property(e => e.Comentario1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("comentario");

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdAulaNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.IdAula)
                    .HasConstraintName("FK__comentari__idAul__778AC167");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__comentari__idUsu__76969D2E");
            });

            modelBuilder.Entity<ConquistaUsuario>(entity =>
            {
                entity.HasKey(e => e.IdConquistaUsuario)
                    .HasName("PK__conquist__A16BA0CBCEF850D7");

                entity.ToTable("conquistaUsuario");

                entity.Property(e => e.IdConquistaUsuario).HasColumnName("idConquistaUsuario");

                entity.Property(e => e.IdConquista).HasColumnName("idConquista");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdConquistaNavigation)
                    .WithMany(p => p.ConquistaUsuarios)
                    .HasForeignKey(d => d.IdConquista)
                    .HasConstraintName("FK__conquista__idCon__08B54D69");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ConquistaUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__conquista__idUsu__09A971A2");
            });

            modelBuilder.Entity<Conquistum>(entity =>
            {
                entity.HasKey(e => e.IdConquista)
                    .HasName("PK__conquist__6830F5783C58167B");

                entity.ToTable("conquista");

                entity.Property(e => e.IdConquista).HasColumnName("idConquista");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdModulo).HasColumnName("idModulo");

                entity.Property(e => e.Imagem)
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Pontos).HasColumnName("pontos");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Conquista)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__conquista__idCur__05D8E0BE");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Conquista)
                    .HasForeignKey(d => d.IdModulo)
                    .HasConstraintName("FK__conquista__idMod__04E4BC85");
            });

            modelBuilder.Entity<Cursando>(entity =>
            {
                entity.HasKey(e => e.IdCursando)
                    .HasName("PK__cursando__9FA02B1945C3BE9B");

                entity.ToTable("cursando");

                entity.Property(e => e.IdCursando).HasColumnName("idCursando");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Cursandos)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__cursando__idCurs__4D94879B");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cursandos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__cursando__idUsua__4CA06362");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__curso__8551ED05DB61DCDD");

                entity.ToTable("curso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.Horas).HasColumnName("horas");

                entity.Property(e => e.IdInstituicao).HasColumnName("idInstituicao");

                entity.Property(e => e.Imagem)
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__curso__idInstitu__45F365D3");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__estado__62EA894AFC057923");

                entity.ToTable("estado");

                entity.HasIndex(e => e.Nome, "UQ__estado__6F71C0DC170D137B")
                    .IsUnique();

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdPais).HasColumnName("idPais");

                entity.Property(e => e.Imagem)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Estados)
                    .HasForeignKey(d => d.IdPais)
                    .HasConstraintName("FK__estado__idPais__2F10007B");
            });

            modelBuilder.Entity<EstadoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdEstadoUsuario)
                    .HasName("PK__estadoUs__5708857307F69D96");

                entity.ToTable("estadoUsuario");

                entity.Property(e => e.IdEstadoUsuario).HasColumnName("idEstadoUsuario");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.EstadoUsuarios)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__estadoUsu__idEst__3C69FB99");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.EstadoUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__estadoUsu__idUsu__3D5E1FD2");
            });

            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao)
                    .HasName("PK__institui__8EA7AB00062C6024");

                entity.ToTable("instituicao");

                entity.HasIndex(e => e.Cnpj, "UQ__institui__35BD3E489A9673EE")
                    .IsUnique();

                entity.Property(e => e.IdInstituicao).HasColumnName("idInstituicao");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nomeFantasia");

                entity.Property(e => e.RazaoSocial)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telefone");
            });

            modelBuilder.Entity<LikeComentario>(entity =>
            {
                entity.HasKey(e => e.IdLikeComentario)
                    .HasName("PK__likeCome__1472B467AFE1BC11");

                entity.ToTable("likeComentario");

                entity.Property(e => e.IdLikeComentario).HasColumnName("idLikeComentario");

                entity.Property(e => e.IdComentario).HasColumnName("idComentario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Like).HasColumnName("like");

                entity.HasOne(d => d.IdComentarioNavigation)
                    .WithMany(p => p.LikeComentarios)
                    .HasForeignKey(d => d.IdComentario)
                    .HasConstraintName("FK__likeComen__idCom__7B5B524B");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.LikeComentarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__likeComen__idUsu__7A672E12");
            });

            modelBuilder.Entity<LikePostagem>(entity =>
            {
                entity.HasKey(e => e.IdLikePostagem)
                    .HasName("PK__likePost__A2D00926A8254200");

                entity.ToTable("likePostagem");

                entity.Property(e => e.IdLikePostagem).HasColumnName("idLikePostagem");

                entity.Property(e => e.IdPostagem).HasColumnName("idPostagem");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Like).HasColumnName("like");

                entity.HasOne(d => d.IdPostagemNavigation)
                    .WithMany(p => p.LikePostagems)
                    .HasForeignKey(d => d.IdPostagem)
                    .HasConstraintName("FK__likePosta__idPos__571DF1D5");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.LikePostagems)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__likePosta__idUsu__5812160E");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo)
                    .HasName("PK__modulo__3CE613FAE4D6825A");

                entity.ToTable("modulo");

                entity.Property(e => e.IdModulo).HasColumnName("idModulo");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Texto)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("texto");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Modulos)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__modulo__idCurso__5AEE82B9");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.HasKey(e => e.IdPais)
                    .HasName("PK__pais__BD2285E339ABB886");

                entity.ToTable("pais");

                entity.HasIndex(e => e.Nome, "UQ__pais__6F71C0DCD15F09F4")
                    .IsUnique();

                entity.Property(e => e.IdPais).HasColumnName("idPais");

                entity.Property(e => e.Imagem)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Postagem>(entity =>
            {
                entity.HasKey(e => e.IdPostagem)
                    .HasName("PK__postagem__C4F315C66E65C418");

                entity.ToTable("postagem");

                entity.Property(e => e.IdPostagem).HasColumnName("idPostagem");

                entity.Property(e => e.DataPostagem)
                    .HasColumnType("date")
                    .HasColumnName("dataPostagem");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Texto)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("texto");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Postagems)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__postagem__idCurs__5165187F");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Postagems)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__postagem__idUsua__5070F446");
            });

            modelBuilder.Entity<Questao>(entity =>
            {
                entity.HasKey(e => e.IdQuestao)
                    .HasName("PK__questao__BB81A065B85CB5BB");

                entity.ToTable("questao");

                entity.Property(e => e.IdQuestao).HasColumnName("idQuestao");

                entity.Property(e => e.Pergunta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("pergunta");

                entity.Property(e => e.PontosNota).HasColumnName("pontosNota");
            });

            modelBuilder.Entity<QuestaoFeitum>(entity =>
            {
                entity.HasKey(e => e.IdQuestaoFeita)
                    .HasName("PK__questaoF__85C3F4776AFE6961");

                entity.ToTable("questaoFeita");

                entity.Property(e => e.IdQuestaoFeita).HasColumnName("idQuestaoFeita");

                entity.Property(e => e.Feito).HasColumnName("feito");

                entity.Property(e => e.IdAulaQuestoes).HasColumnName("idAulaQuestoes");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Pontos).HasColumnName("pontos");

                entity.HasOne(d => d.IdAulaQuestoesNavigation)
                    .WithMany(p => p.QuestaoFeita)
                    .HasForeignKey(d => d.IdAulaQuestoes)
                    .HasConstraintName("FK__questaoFe__idAul__7E37BEF6");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.QuestaoFeita)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__questaoFe__idUsu__7F2BE32F");
            });

            modelBuilder.Entity<RedeSocial>(entity =>
            {
                entity.HasKey(e => e.IdRedeSocial)
                    .HasName("PK__redeSoci__D3532549FF52A400");

                entity.ToTable("redeSocial");

                entity.HasIndex(e => e.Nome, "UQ__redeSoci__6F71C0DCA0CA93FC")
                    .IsUnique();

                entity.HasIndex(e => e.LinkBase, "UQ__redeSoci__859BF4BD609BBE43")
                    .IsUnique();

                entity.Property(e => e.IdRedeSocial).HasColumnName("idRedeSocial");

                entity.Property(e => e.LinkBase)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("linkBase");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<RedesUsuario>(entity =>
            {
                entity.HasKey(e => e.IdRedesUsuario)
                    .HasName("PK__redesUsu__5ADA484443DBEA99");

                entity.ToTable("redesUsuario");

                entity.Property(e => e.IdRedesUsuario).HasColumnName("idRedesUsuario");

                entity.Property(e => e.IdRedeSocial).HasColumnName("idRedeSocial");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("link");

                entity.HasOne(d => d.IdRedeSocialNavigation)
                    .WithMany(p => p.RedesUsuarios)
                    .HasForeignKey(d => d.IdRedeSocial)
                    .HasConstraintName("FK__redesUsua__idRed__38996AB5");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.RedesUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__redesUsua__idUsu__398D8EEE");
            });

            modelBuilder.Entity<Respostum>(entity =>
            {
                entity.HasKey(e => e.IdResposta)
                    .HasName("PK__resposta__E83D107BC89E2509");

                entity.ToTable("resposta");

                entity.Property(e => e.IdResposta).HasColumnName("idResposta");

                entity.Property(e => e.Correta).HasColumnName("correta");

                entity.Property(e => e.IdQuestao).HasColumnName("idQuestao");

                entity.Property(e => e.Resposta)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("resposta");

                entity.HasOne(d => d.IdQuestaoNavigation)
                    .WithMany(p => p.Resposta)
                    .HasForeignKey(d => d.IdQuestao)
                    .HasConstraintName("FK__resposta__idQues__02084FDA");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF395C6DD8");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.Tipo, "UQ__tipoUsua__E7F95649F83203C8")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A6AF57DC1C");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E6164B9249C78")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cargo");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Empresa)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("empresa");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Imagem)
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.ImagemBackground)
                    .IsUnicode(false)
                    .HasColumnName("imagemBackground");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Pontos).HasColumnName("pontos");

                entity.Property(e => e.PontosSemanais).HasColumnName("pontosSemanais");

                entity.Property(e => e.Rg)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("rg");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.Property(e => e.SobreMim)
                    .IsUnicode(false)
                    .HasColumnName("sobreMim");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("telefone");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__35BCFE0A");
            });

            modelBuilder.Entity<UsuarioArquetipo>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioArquetipo)
                    .HasName("PK__usuarioA__E7AE58E2A59CB489");

                entity.ToTable("usuarioArquetipo");

                entity.Property(e => e.IdUsuarioArquetipo).HasColumnName("idUsuarioArquetipo");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.IdArquetipo).HasColumnName("idArquetipo");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Porcentagem).HasColumnName("porcentagem");

                entity.HasOne(d => d.IdArquetipoNavigation)
                    .WithMany(p => p.UsuarioArquetipos)
                    .HasForeignKey(d => d.IdArquetipo)
                    .HasConstraintName("FK__usuarioAr__idArq__0C85DE4D");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioArquetipos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__usuarioAr__idUsu__0D7A0286");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
