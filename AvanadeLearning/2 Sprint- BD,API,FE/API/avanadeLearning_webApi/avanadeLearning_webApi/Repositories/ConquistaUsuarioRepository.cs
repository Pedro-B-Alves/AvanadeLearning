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
    public class ConquistaUsuarioRepository : IBaseRepository<ConquistaUsuario>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, ConquistaUsuario entity)
        {
            ConquistaUsuario ConquistaUsuarioBuscado = ctx.ConquistaUsuarios.Find(id);

            if (entity.IdConquista != null)
            {
                ConquistaUsuarioBuscado.IdConquista = entity.IdConquista;
            }

            if (entity.IdUsuario != null)
            {
                ConquistaUsuarioBuscado.IdUsuario = entity.IdUsuario;
            }

            ctx.ConquistaUsuarios.Update(ConquistaUsuarioBuscado);

            ctx.SaveChanges();
        }

        public ConquistaUsuario BuscarPorId(int id)
        {
            return ctx.ConquistaUsuarios
                .Include(c => c.IdConquistaNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .Select(c => new ConquistaUsuario
                {
                    IdConquistaUsuario = c.IdConquistaUsuario,
                    IdConquista = c.IdConquista,
                    IdUsuario = c.IdUsuario,
                    IdConquistaNavigation = new Conquistum
                    {
                        IdConquista = c.IdConquistaNavigation.IdConquista,
                        IdModulo = c.IdConquistaNavigation.IdModulo,
                        IdCurso = c.IdConquistaNavigation.IdCurso,
                        Nome = c.IdConquistaNavigation.Nome,
                        Descricao = c.IdConquistaNavigation.Descricao,
                        Imagem = c.IdConquistaNavigation.Imagem,
                        Pontos = c.IdConquistaNavigation.Pontos
                    },
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
                        ImagemBackground = c.IdUsuarioNavigation.ImagemBackground
                    }
                })
                .FirstOrDefault(tu => tu.IdUsuario == id);
        }

        public void Cadastrar(ConquistaUsuario entity)
        {
            ctx.ConquistaUsuarios.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ConquistaUsuario ConquistaUsuarioBuscado = ctx.ConquistaUsuarios.Find(id);

            ctx.ConquistaUsuarios.Remove(ConquistaUsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<ConquistaUsuario> Listar()
        {
            return ctx.ConquistaUsuarios
                .Include(c => c.IdConquistaNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .Select(c => new ConquistaUsuario
                {
                    IdConquistaUsuario = c.IdConquistaUsuario,
                    IdConquista = c.IdConquista,
                    IdUsuario = c.IdUsuario,
                    IdConquistaNavigation = new Conquistum
                    {
                        IdConquista = c.IdConquistaNavigation.IdConquista,
                        IdModulo = c.IdConquistaNavigation.IdModulo,
                        IdCurso = c.IdConquistaNavigation.IdCurso,
                        Nome = c.IdConquistaNavigation.Nome,
                        Descricao = c.IdConquistaNavigation.Descricao,
                        Imagem = c.IdConquistaNavigation.Imagem,
                        Pontos = c.IdConquistaNavigation.Pontos
                    },
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
                        ImagemBackground = c.IdUsuarioNavigation.ImagemBackground
                    }
                })
                .ToList();
        }
    }
}
