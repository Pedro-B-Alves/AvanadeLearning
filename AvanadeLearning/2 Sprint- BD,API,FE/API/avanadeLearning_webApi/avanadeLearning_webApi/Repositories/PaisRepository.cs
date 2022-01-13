using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Contexts;
using avanadeLearning_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Repositories
{
    public class PaisRepository : IBaseRepository<Pai>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();

        public void Atualizar(int id, Pai entity)
        {
            Pai PaisBuscado = ctx.Pais.Find(id);

            if (entity.Nome != null)
            {
                PaisBuscado.Nome = entity.Nome;
            }

            if (entity.Imagem != null)
            {
                PaisBuscado.Imagem = entity.Imagem;
            }

            ctx.Pais.Update(PaisBuscado);

            ctx.SaveChanges();
        }

        public Pai BuscarPorId(int id)
        {
            return ctx.Pais
                .Select(p => new Pai
                {
                    IdPais = p.IdPais,
                    Nome = p.Nome,
                    Imagem = p.Imagem
                })
                .FirstOrDefault(tu => tu.IdPais == id);
        }

        public void Cadastrar(Pai entity)
        {
            ctx.Pais.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pai PaisBuscado = ctx.Pais.Find(id);

            ctx.Pais.Remove(PaisBuscado);

            ctx.SaveChanges();
        }

        public List<Pai> Listar()
        {
            return ctx.Pais
                .Select(p => new Pai
                {
                    IdPais = p.IdPais,
                    Nome = p.Nome,
                    Imagem = p.Imagem
                })
                .ToList();
        }
    }
}
