using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Contexts;
using avanadeLearning_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Repositories
{
    public class ArquetipoRepository : IBaseRepository<Arquetipo>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, Arquetipo entity)
        {
            Arquetipo ArquetipoBuscado = ctx.Arquetipos.Find(id);

            if (entity.Nome != null)
            {
                ArquetipoBuscado.Nome = entity.Nome;
            }

            if (entity.Imagem != null)
            {
                ArquetipoBuscado.Imagem = entity.Imagem;
            }

            if (entity.Descricao != null)
            {
                ArquetipoBuscado.Descricao = entity.Descricao;
            }

            ctx.Arquetipos.Update(ArquetipoBuscado);

            ctx.SaveChanges();
        }

        public Arquetipo BuscarPorId(int id)
        {
            return ctx.Arquetipos
                .Select(a => new Arquetipo
                {
                    IdArquetipo = a.IdArquetipo,
                    Nome = a.Nome,
                    Imagem = a.Imagem,
                    Descricao = a.Descricao
                })
                .FirstOrDefault(tu => tu.IdArquetipo == id);
        }

        public void Cadastrar(Arquetipo entity)
        {
            ctx.Arquetipos.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Arquetipo ArquetipoBuscado = ctx.Arquetipos.Find(id);

            ctx.Arquetipos.Remove(ArquetipoBuscado);

            ctx.SaveChanges();
        }

        public List<Arquetipo> Listar()
        {
            return ctx.Arquetipos
                .Select(a => new Arquetipo
                {
                    IdArquetipo = a.IdArquetipo,
                    Nome = a.Nome,
                    Imagem = a.Imagem,
                    Descricao = a.Descricao
                })
                .ToList();
        }
    }
}
