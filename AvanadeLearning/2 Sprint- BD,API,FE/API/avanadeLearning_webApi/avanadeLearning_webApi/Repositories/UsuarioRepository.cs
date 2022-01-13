using avanadeLearning_webApi.Contexts;
using avanadeLearning_webApi.Domains;
using avanadeLearning_webApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, Usuario entity)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            if (entity.IdTipoUsuario != null)
            {
                UsuarioBuscado.IdTipoUsuario = entity.IdTipoUsuario;
            }

            if (entity.Nome != null)
            {
                UsuarioBuscado.Nome = entity.Nome;
            }

            if (entity.Email != null)
            {
                UsuarioBuscado.Email = entity.Email;
            }

            if (entity.Senha != null)
            {
                UsuarioBuscado.Senha = entity.Senha;
            }

            if (entity.Imagem != null)
            {
                UsuarioBuscado.Imagem = entity.Imagem;
            }

            if (entity.Rg != null)
            {
                UsuarioBuscado.Rg = entity.Rg;
            }

            if (entity.Cpf != null)
            {
                UsuarioBuscado.Cpf = entity.Cpf;
            }

            if (entity.DataNascimento != null)
            {
                UsuarioBuscado.DataNascimento = entity.DataNascimento;
            }

            if (entity.Telefone != null)
            {
                UsuarioBuscado.Telefone = entity.Telefone;
            }

            if (entity.SobreMim != null)
            {
                UsuarioBuscado.SobreMim = entity.SobreMim;
            }

            if (entity.ImagemBackground != null)
            {
                UsuarioBuscado.ImagemBackground = entity.ImagemBackground;
            }

            if (entity.Empresa != null)
            {
                UsuarioBuscado.Empresa = entity.Empresa;
            }

            if (entity.Cargo != null)
            {
                UsuarioBuscado.Cargo = entity.Cargo;
            }

            ctx.Usuarios.Update(UsuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorEmail(string email)
        {
            return ctx.Usuarios
                .Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    IdTipoUsuario = u.IdTipoUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    Imagem = u.Imagem
                })
                .FirstOrDefault(tu => tu.Email.ToLower() == email.ToLower());
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios
                .Include(u => u.IdTipoUsuarioNavigation)
                .Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    IdTipoUsuario = u.IdTipoUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Imagem = u.Imagem,
                    Rg = u.Rg,
                    Cpf = u.Cpf,
                    DataNascimento = u.DataNascimento,
                    Telefone = u.Telefone,
                    Pontos = u.Pontos,
                    PontosSemanais = u.PontosSemanais,
                    SobreMim = u.SobreMim,
                    ImagemBackground = u.ImagemBackground,
                    Empresa = u.Empresa,
                    Cargo = u.Cargo,
                    IdTipoUsuarioNavigation = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        Tipo = u.IdTipoUsuarioNavigation.Tipo
                    }
                })
                .FirstOrDefault(tu => tu.IdUsuario == id);
        }

        public void Cadastrar(Usuario entity)
        {
            ctx.Usuarios.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(UsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios
                .Include(u => u.IdTipoUsuarioNavigation)
                .Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    IdTipoUsuario = u.IdTipoUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Imagem = u.Imagem,
                    Pontos = u.Pontos,
                    PontosSemanais = u.PontosSemanais,
                    SobreMim = u.SobreMim,
                    ImagemBackground = u.ImagemBackground,
                    IdTipoUsuarioNavigation = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        Tipo = u.IdTipoUsuarioNavigation.Tipo
                    }
                })
                .ToList();
        }

    }
}
