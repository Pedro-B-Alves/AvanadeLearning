using AvanadeLearning.Interfaces;
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
    public class EstadoRepository : IEstadoRepository
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();

        public void Atualizar(int id, Estado entity)
        {
            Estado EstadoBuscado = ctx.Estados.Find(id);

            if (entity.Nome != null)
            {
                EstadoBuscado.Nome = entity.Nome;
            }

            if (entity.Imagem != null)
            {
                EstadoBuscado.Imagem = entity.Imagem;
            }

            ctx.Estados.Update(EstadoBuscado);

            ctx.SaveChanges();
        }

        public Estado BuscarPorId(int id)
        {
            return ctx.Estados
                .Include(e => e.IdPaisNavigation)
                .Select(e => new Estado
                {
                    IdEstado = e.IdEstado,
                    IdPais = e.IdPais,
                    Nome = e.Nome,
                    Imagem = e.Imagem,
                    IdPaisNavigation = new Pai
                    {
                        IdPais = e.IdPaisNavigation.IdPais,
                        Nome = e.IdPaisNavigation.Nome,
                        Imagem = e.IdPaisNavigation.Imagem
                    }
                })
                .FirstOrDefault(tu => tu.IdEstado == id);
        }

        public Estado BuscarPorIdPais(int id)
        {
            return ctx.Estados
                .Include(e => e.IdPaisNavigation)
                .Select(e => new Estado
                {
                    IdEstado = e.IdEstado,
                    IdPais = e.IdPais,
                    Nome = e.Nome,
                    Imagem = e.Imagem,
                    IdPaisNavigation = new Pai
                    {
                        IdPais = e.IdPaisNavigation.IdPais,
                        Nome = e.IdPaisNavigation.Nome,
                        Imagem = e.IdPaisNavigation.Imagem
                    }
                })
                .FirstOrDefault(tu => tu.IdPais == id);
        }

        public void Cadastrar(Estado entity)
        {
            ctx.Estados.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Estado estadoBuscado = ctx.Estados.Find(id);

            ctx.Estados.Remove(estadoBuscado);

            ctx.SaveChanges();
        }

        public List<Estado> Listar()
        {
            return ctx.Estados
                .Include(e => e.IdPaisNavigation)
                .Select(e => new Estado
                {
                    IdEstado = e.IdEstado,
                    IdPais = e.IdPais,
                    Nome = e.Nome,
                    Imagem = e.Imagem,
                    IdPaisNavigation = new Pai
                    {
                        IdPais = e.IdPaisNavigation.IdPais,
                        Nome = e.IdPaisNavigation.Nome,
                        Imagem = e.IdPaisNavigation.Imagem
                    }
                })
                .ToList();
        }
    }
}
