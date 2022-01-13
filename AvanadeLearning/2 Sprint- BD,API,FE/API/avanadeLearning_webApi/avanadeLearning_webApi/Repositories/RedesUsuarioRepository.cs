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
    public class RedesUsuarioRepository : IBaseRepository<RedesUsuario>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, RedesUsuario entity)
        {
            RedesUsuario RedesUsuarioBuscado = ctx.RedesUsuarios.Find(id);

            if (entity.Link != null)
            {
                RedesUsuarioBuscado.Link = entity.Link;
            }

            ctx.RedesUsuarios.Update(RedesUsuarioBuscado);

            ctx.SaveChanges();
        }

        public RedesUsuario BuscarPorId(int id)
        {
            return ctx.RedesUsuarios
                .Include(r => r.IdRedeSocialNavigation)
                .Include(r => r.IdUsuarioNavigation)
                .Select(r => new RedesUsuario
                {
                    IdRedesUsuario = r.IdRedesUsuario,
                    IdRedeSocial = r.IdRedeSocial,
                    IdUsuario = r.IdUsuario,
                    Link = r.Link,
                    IdRedeSocialNavigation = new RedeSocial
                    {
                        IdRedeSocial = r.IdRedeSocialNavigation.IdRedeSocial,
                        Nome = r.IdRedeSocialNavigation.Nome,
                        LinkBase = r.IdRedeSocialNavigation.LinkBase
                    },
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = r.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = r.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = r.IdUsuarioNavigation.Nome,
                        Email = r.IdUsuarioNavigation.Email,
                        Imagem = r.IdUsuarioNavigation.Imagem,
                        Pontos = r.IdUsuarioNavigation.Pontos,
                        PontosSemanais = r.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = r.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = r.IdUsuarioNavigation.ImagemBackground,
                    }
                })
                .FirstOrDefault(tu => tu.IdUsuario == id);
        }

        public void Cadastrar(RedesUsuario entity)
        {
            ctx.RedesUsuarios.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            RedesUsuario RedesUsuarioBuscado = ctx.RedesUsuarios.Find(id);

            ctx.RedesUsuarios.Remove(RedesUsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<RedesUsuario> Listar()
        {
            return ctx.RedesUsuarios
                .Include(r => r.IdRedeSocialNavigation)
                .Include(r => r.IdUsuarioNavigation)
                .Select(r => new RedesUsuario 
                {
                    IdRedesUsuario = r.IdRedesUsuario,
                    IdRedeSocial = r.IdRedeSocial,
                    IdUsuario = r.IdUsuario,
                    Link = r.Link,
                    IdRedeSocialNavigation = new RedeSocial
                    {
                        IdRedeSocial = r.IdRedeSocialNavigation.IdRedeSocial,
                        Nome = r.IdRedeSocialNavigation.Nome,
                        LinkBase = r.IdRedeSocialNavigation.LinkBase
                    },
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = r.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = r.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = r.IdUsuarioNavigation.Nome,
                        Email = r.IdUsuarioNavigation.Email,
                        Imagem = r.IdUsuarioNavigation.Imagem,
                        Pontos = r.IdUsuarioNavigation.Pontos,
                        PontosSemanais = r.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = r.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = r.IdUsuarioNavigation.ImagemBackground,
                    }
                })
                .ToList();
        }
    }
}
