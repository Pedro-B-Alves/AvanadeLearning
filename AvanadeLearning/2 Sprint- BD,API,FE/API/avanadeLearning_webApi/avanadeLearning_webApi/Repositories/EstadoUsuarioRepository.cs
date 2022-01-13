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
    public class EstadoUsuarioRepository : IBaseRepository<EstadoUsuario>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();

        public void Atualizar(int id, EstadoUsuario entity)
        {
            EstadoUsuario EstadoUsuarioBuscado = ctx.EstadoUsuarios.Find(id);

            if (entity.IdEstado != null)
            {
                EstadoUsuarioBuscado.IdEstado = entity.IdEstado;
            }

            if (entity.IdUsuario != null)
            {
                EstadoUsuarioBuscado.IdUsuario = entity.IdUsuario;
            }

            ctx.EstadoUsuarios.Update(EstadoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public EstadoUsuario BuscarPorId(int id)
        {
            return ctx.EstadoUsuarios
                .Include(e => e.IdEstadoNavigation)
                .Include(e => e.IdUsuarioNavigation)
                .Select(e => new EstadoUsuario
                {
                    IdEstadoUsuario = e.IdEstadoUsuario,
                    IdEstado = e.IdEstado,
                    IdUsuario = e.IdUsuario,
                    IdEstadoNavigation = new Estado
                    {
                        IdEstado = e.IdEstadoNavigation.IdEstado,
                        IdPais = e.IdEstadoNavigation.IdPais,
                        Nome = e.IdEstadoNavigation.Nome,
                        Imagem = e.IdEstadoNavigation.Imagem
                    },
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = e.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = e.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = e.IdUsuarioNavigation.Nome,
                        Email = e.IdUsuarioNavigation.Email,
                        Imagem = e.IdUsuarioNavigation.Imagem,
                        Pontos = e.IdUsuarioNavigation.Pontos,
                        PontosSemanais = e.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = e.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = e.IdUsuarioNavigation.ImagemBackground
                    }
                })
                .FirstOrDefault(tu => tu.IdUsuario == id);
        }

        public void Cadastrar(EstadoUsuario entity)
        {
            ctx.EstadoUsuarios.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            EstadoUsuario EstadoUsuarioBuscado = ctx.EstadoUsuarios.Find(id);

            ctx.EstadoUsuarios.Remove(EstadoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<EstadoUsuario> Listar()
        {
            return ctx.EstadoUsuarios
                .Include(e => e.IdEstadoNavigation)
                .Include(e => e.IdUsuarioNavigation)
                .Select(e => new EstadoUsuario 
                {
                    IdEstadoUsuario = e.IdEstadoUsuario,
                    IdEstado = e.IdEstado,
                    IdUsuario = e.IdUsuario,
                    IdEstadoNavigation = new Estado
                    {
                        IdEstado = e.IdEstadoNavigation.IdEstado,
                        IdPais = e.IdEstadoNavigation.IdPais,
                        Nome = e.IdEstadoNavigation.Nome,
                        Imagem = e.IdEstadoNavigation.Imagem
                    },
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = e.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = e.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = e.IdUsuarioNavigation.Nome,
                        Email = e.IdUsuarioNavigation.Email,
                        Imagem = e.IdUsuarioNavigation.Imagem,
                        Pontos = e.IdUsuarioNavigation.Pontos,
                        PontosSemanais = e.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = e.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = e.IdUsuarioNavigation.ImagemBackground
                    }
                })
                .ToList();
        }
    }
}
