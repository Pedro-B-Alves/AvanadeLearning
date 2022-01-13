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
    public class LikePostagemRepository : IBaseRepository<LikePostagem>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, LikePostagem entity)
        {
            LikePostagem LikeBuscado = ctx.LikePostagems.Find(id);

            if (entity.IdPostagem != null)
            {
                LikeBuscado.IdPostagem = entity.IdPostagem;
            }

            if (entity.IdUsuario != null)
            {
                LikeBuscado.IdUsuario = entity.IdUsuario;
            }

            if (entity.Like != LikeBuscado.Like)
            {
                LikeBuscado.Like = entity.Like;
            }

            ctx.LikePostagems.Update(LikeBuscado);

            ctx.SaveChanges();
        }

        public LikePostagem BuscarPorId(int id)
        {
            return ctx.LikePostagems
                .Include(l => l.IdPostagemNavigation)
                .Include(l => l.IdUsuarioNavigation)
                .Select(l => new LikePostagem
                {
                    IdLikePostagem = l.IdLikePostagem,
                    IdPostagem = l.IdPostagem,
                    IdUsuario = l.IdUsuario,
                    Like = l.Like,
                    IdPostagemNavigation = new Postagem
                    {
                        IdPostagem = l.IdPostagemNavigation.IdPostagem,
                        IdUsuario = l.IdPostagemNavigation.IdUsuario,
                        IdCurso = l.IdPostagemNavigation.IdCurso,
                        Texto = l.IdPostagemNavigation.Texto
                    },
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
                    }
                })
                .FirstOrDefault(tu => tu.IdPostagem == id);
        }

        public void Cadastrar(LikePostagem entity)
        {
            ctx.LikePostagems.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            LikePostagem LikeBuscado = ctx.LikePostagems.Find(id);

            ctx.LikePostagems.Remove(LikeBuscado);

            ctx.SaveChanges();
        }

        public List<LikePostagem> Listar()
        {
            return ctx.LikePostagems
                .Include(l => l.IdPostagemNavigation)
                .Include(l => l.IdUsuarioNavigation)
                .Select(l => new LikePostagem
                {
                    IdLikePostagem = l.IdLikePostagem,
                    IdPostagem = l.IdPostagem,
                    IdUsuario = l.IdUsuario,
                    Like = l.Like,
                    IdPostagemNavigation = new Postagem
                    {
                        IdPostagem = l.IdPostagemNavigation.IdPostagem,
                        IdUsuario = l.IdPostagemNavigation.IdUsuario,
                        IdCurso = l.IdPostagemNavigation.IdCurso,
                        Texto = l.IdPostagemNavigation.Texto
                    },
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
                    }
                })
                .ToList();
        }


    }
}
