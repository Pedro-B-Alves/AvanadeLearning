using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Contexts;
using avanadeLearning_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Repositories
{
    public class CategoriaQuestaoRepository : IBaseRepository<CategoriaQuestao>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, CategoriaQuestao entity)
        {
            CategoriaQuestao CategoriaQuestaoBuscada = ctx.CategoriaQuestaos.Find(id);

            if (entity.Nome != null)
            {
                CategoriaQuestaoBuscada.Nome = entity.Nome;
            }

            ctx.CategoriaQuestaos.Update(CategoriaQuestaoBuscada);

            ctx.SaveChanges();
        }

        public CategoriaQuestao BuscarPorId(int id)
        {
            return ctx.CategoriaQuestaos
                .Select(c => new CategoriaQuestao
                {
                    IdCategoriaQuestao = c.IdCategoriaQuestao,
                    Nome = c.Nome
                })
                .FirstOrDefault(tu => tu.IdCategoriaQuestao == id);
        }

        public void Cadastrar(CategoriaQuestao entity)
        {
            ctx.CategoriaQuestaos.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            CategoriaQuestao CategoriaQuestaoBuscada = ctx.CategoriaQuestaos.Find(id);

            ctx.CategoriaQuestaos.Remove(CategoriaQuestaoBuscada);

            ctx.SaveChanges();
        }

        public List<CategoriaQuestao> Listar()
        {
            return ctx.CategoriaQuestaos
                .Select(c => new CategoriaQuestao
                {
                    IdCategoriaQuestao = c.IdCategoriaQuestao,
                    Nome = c.Nome
                })
                .ToList();
        }
    }
       
}
