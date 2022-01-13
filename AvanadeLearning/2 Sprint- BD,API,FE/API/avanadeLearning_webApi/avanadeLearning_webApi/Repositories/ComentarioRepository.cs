using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Contexts;
using avanadeLearning_webApi.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Repositories
{
    public class ComentarioRepository : IBaseRepository<Comentario>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, Comentario entity)
        {
            Comentario ComentarioBuscado = ctx.Comentarios.Find(id);

            if (entity.Comentario1 != null)
            {
                ComentarioBuscado.Comentario1 = entity.Comentario1;
            }

            ctx.Comentarios.Update(ComentarioBuscado);

            ctx.SaveChanges();
        }

        public Comentario BuscarPorId(int id)
        {
            return ctx.Comentarios
                .Include(c => c.IdUsuarioNavigation)
                .Include(c => c.IdAulaNavigation)
                .Select(c => new Comentario
                {
                    IdComentario = c.IdComentario,
                    IdUsuario = c.IdUsuario,
                    IdAula = c.IdAula,
                    Comentario1 = c.Comentario1,
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = c.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = c.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = c.IdUsuarioNavigation.Nome,
                        Email = c.IdUsuarioNavigation.Email,
                        Imagem = c.IdUsuarioNavigation.Imagem,
                        Pontos = c.IdUsuarioNavigation.Pontos,
                        PontosSemanais = c.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = c.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = c.IdUsuarioNavigation.ImagemBackground,
                    },
                    IdAulaNavigation = new Aula
                    {
                        IdAula = c.IdAulaNavigation.IdAula,
                        Video = c.IdAulaNavigation.Video,
                        Descricao = c.IdAulaNavigation.Descricao,
                        LinkConteudoExtra = c.IdAulaNavigation.LinkConteudoExtra,
                        Titulo = c.IdAulaNavigation.Titulo
                    }
                })
                .FirstOrDefault(tu => tu.IdAula == id);
        }

        public void Cadastrar(Comentario entity)
        {
            ctx.Comentarios.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Comentario ComentarioBuscado = ctx.Comentarios.Find(id);

            ctx.Comentarios.Remove(ComentarioBuscado);

            ctx.SaveChanges();
        }

        public List<Comentario> Listar()
        {
            return ctx.Comentarios
                .Include(c => c.IdUsuarioNavigation)
                .Include(c => c.IdAulaNavigation)
                .Select(c => new Comentario
                {
                    IdComentario = c.IdComentario,
                    IdUsuario = c.IdUsuario,
                    IdAula = c.IdAula,
                    Comentario1 = c.Comentario1,
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = c.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = c.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = c.IdUsuarioNavigation.Nome,
                        Email = c.IdUsuarioNavigation.Email,
                        Imagem = c.IdUsuarioNavigation.Imagem,
                        Pontos = c.IdUsuarioNavigation.Pontos,
                        PontosSemanais = c.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = c.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = c.IdUsuarioNavigation.ImagemBackground,
                    },
                    IdAulaNavigation = new Aula
                    {
                        IdAula = c.IdAulaNavigation.IdAula,
                        Video = c.IdAulaNavigation.Video,
                        Descricao = c.IdAulaNavigation.Descricao,
                        LinkConteudoExtra = c.IdAulaNavigation.LinkConteudoExtra,
                        Titulo = c.IdAulaNavigation.Titulo
                    }
                })
                .ToList();
        }
    }
}
