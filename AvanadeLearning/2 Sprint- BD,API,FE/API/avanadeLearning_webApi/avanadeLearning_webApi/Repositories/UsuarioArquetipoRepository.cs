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
    public class UsuarioArquetipoRepository : IBaseRepository<UsuarioArquetipo>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, UsuarioArquetipo entity)
        {
            UsuarioArquetipo UsuarioArquetipoBuscado = ctx.UsuarioArquetipos.Find(id);

            if (entity.Porcentagem != 0)
            {
                UsuarioArquetipoBuscado.Porcentagem = entity.Porcentagem;
            }

            if (entity.Ativo != UsuarioArquetipoBuscado.Ativo)
            {
                UsuarioArquetipoBuscado.Ativo = entity.Ativo;
            }

            ctx.UsuarioArquetipos.Update(UsuarioArquetipoBuscado);

            ctx.SaveChanges();
        }

        public UsuarioArquetipo BuscarPorId(int id)
        {
            return ctx.UsuarioArquetipos
                .Include(a => a.IdArquetipoNavigation)
                .Include(a => a.IdUsuarioNavigation)
                .Select(a => new UsuarioArquetipo 
                {
                    IdUsuarioArquetipo = a.IdUsuarioArquetipo,
                    IdArquetipo = a.IdArquetipo,
                    IdUsuario = a.IdUsuario,
                    Porcentagem = a.Porcentagem,
                    Ativo = a.Ativo,
                    IdArquetipoNavigation = new Arquetipo
                    {
                        IdArquetipo = a.IdArquetipoNavigation.IdArquetipo,
                        Nome = a.IdArquetipoNavigation.Nome,
                        Imagem = a.IdArquetipoNavigation.Imagem,
                        Descricao = a.IdArquetipoNavigation.Descricao
                    },
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = a.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = a.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = a.IdUsuarioNavigation.Nome,
                        Email = a.IdUsuarioNavigation.Email,
                        Imagem = a.IdUsuarioNavigation.Imagem,
                        Pontos = a.IdUsuarioNavigation.Pontos,
                        PontosSemanais = a.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = a.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = a.IdUsuarioNavigation.ImagemBackground
                    }
                })
                .FirstOrDefault(tu => tu.IdUsuario == id);
        }

        public void Cadastrar(UsuarioArquetipo entity)
        {
            ctx.UsuarioArquetipos.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            UsuarioArquetipo UsuarioArquetipoBuscado = ctx.UsuarioArquetipos.Find(id);

            ctx.UsuarioArquetipos.Remove(UsuarioArquetipoBuscado);

            ctx.SaveChanges();
        }

        public List<UsuarioArquetipo> Listar()
        {
            return ctx.UsuarioArquetipos
                .Include(a => a.IdArquetipoNavigation)
                .Include(a => a.IdUsuarioNavigation)
                .Select(a => new UsuarioArquetipo
                {
                    IdUsuarioArquetipo = a.IdUsuarioArquetipo,
                    IdArquetipo = a.IdArquetipo,
                    IdUsuario = a.IdUsuario,
                    Porcentagem = a.Porcentagem,
                    Ativo = a.Ativo,
                    IdArquetipoNavigation = new Arquetipo
                    {
                        IdArquetipo = a.IdArquetipoNavigation.IdArquetipo,
                        Nome = a.IdArquetipoNavigation.Nome,
                        Imagem = a.IdArquetipoNavigation.Imagem,
                        Descricao = a.IdArquetipoNavigation.Descricao
                    },
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = a.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = a.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = a.IdUsuarioNavigation.Nome,
                        Email = a.IdUsuarioNavigation.Email,
                        Imagem = a.IdUsuarioNavigation.Imagem,
                        Pontos = a.IdUsuarioNavigation.Pontos,
                        PontosSemanais = a.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = a.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = a.IdUsuarioNavigation.ImagemBackground
                    }
                })
                .ToList();
        }
    }
}
