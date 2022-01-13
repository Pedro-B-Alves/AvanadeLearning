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
    public class LikeComentarioRepository : IBaseRepository<LikeComentario>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, LikeComentario entity)
        {
            LikeComentario LikeComentarioBuscado = ctx.LikeComentarios.Find(id);

            if (entity.IdUsuario != null)
            {
                LikeComentarioBuscado.IdUsuario = entity.IdUsuario;
            }

            if (entity.IdComentario != null)
            {
                LikeComentarioBuscado.IdComentario = entity.IdComentario;
            }

            if (entity.Like != LikeComentarioBuscado.Like)
            {
                LikeComentarioBuscado.Like = entity.Like;
            }

            ctx.LikeComentarios.Update(LikeComentarioBuscado);

            ctx.SaveChanges();
        }

        public LikeComentario BuscarPorId(int id)
        {
            return ctx.LikeComentarios
                .Include(l => l.IdUsuarioNavigation)
                .Include(l => l.IdComentarioNavigation)
                .Select(l => new LikeComentario
                {
                    IdLikeComentario = l.IdLikeComentario,
                    IdUsuario = l.IdUsuario,
                    IdComentario = l.IdComentario,
                    Like = l.Like,
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = l.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = l.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = l.IdUsuarioNavigation.Nome,
                        Email = l.IdUsuarioNavigation.Email,
                        Imagem = l.IdUsuarioNavigation.Imagem,
                        Pontos = l.IdUsuarioNavigation.Pontos,
                        PontosSemanais = l.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = l.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = l.IdUsuarioNavigation.ImagemBackground
                    },
                    IdComentarioNavigation = new Comentario
                    {
                        IdComentario = l.IdComentarioNavigation.IdComentario,
                        IdUsuario = l.IdComentarioNavigation.IdUsuario,
                        IdAula = l.IdComentarioNavigation.IdAula,
                        Comentario1 = l.IdComentarioNavigation.Comentario1
                    }
                })
                .FirstOrDefault(tu => tu.IdComentario == id);
        }

        public void Cadastrar(LikeComentario entity)
        {
            ctx.LikeComentarios.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            LikeComentario LikeComentarioBuscado = ctx.LikeComentarios.Find(id);

            ctx.LikeComentarios.Remove(LikeComentarioBuscado);

            ctx.SaveChanges();
        }

        public List<LikeComentario> Listar()
        {
            return ctx.LikeComentarios
                .Include(l => l.IdUsuarioNavigation)
                .Include(l => l.IdComentarioNavigation)
                .Select(l => new LikeComentario
                {
                    IdLikeComentario = l.IdLikeComentario,
                    IdUsuario = l.IdUsuario,
                    IdComentario = l.IdComentario,
                    Like = l.Like,
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = l.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = l.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = l.IdUsuarioNavigation.Nome,
                        Email = l.IdUsuarioNavigation.Email,
                        Imagem = l.IdUsuarioNavigation.Imagem,
                        Pontos = l.IdUsuarioNavigation.Pontos,
                        PontosSemanais = l.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = l.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = l.IdUsuarioNavigation.ImagemBackground
                    },
                    IdComentarioNavigation = new Comentario
                    {
                        IdComentario = l.IdComentarioNavigation.IdComentario,
                        IdUsuario = l.IdComentarioNavigation.IdUsuario,
                        IdAula = l.IdComentarioNavigation.IdAula,
                        Comentario1 = l.IdComentarioNavigation.Comentario1
                    }
                })
                .ToList();
        }
    }
}
