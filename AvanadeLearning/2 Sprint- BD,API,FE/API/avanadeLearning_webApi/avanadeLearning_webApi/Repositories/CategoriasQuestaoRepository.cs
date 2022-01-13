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
    public class CategoriasQuestaoRepository : IBaseRepository<CategoriasQuestao>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, CategoriasQuestao entity)
        {
            CategoriasQuestao CategoriasQuestaoBuscada = ctx.CategoriasQuestaos.Find(id);

            if (entity.IdCategoriaQuestao != null)
            {
                CategoriasQuestaoBuscada.IdCategoriaQuestao = entity.IdCategoriaQuestao;
            }

            if (entity.IdQuestao != null)
            {
                CategoriasQuestaoBuscada.IdQuestao = entity.IdQuestao;
            }

            ctx.CategoriasQuestaos.Update(CategoriasQuestaoBuscada);

            ctx.SaveChanges();
        }

        public CategoriasQuestao BuscarPorId(int id)
        {
            return ctx.CategoriasQuestaos
                .Include(c => c.IdCategoriaQuestaoNavigation)
                .Include(c => c.IdQuestaoNavigation)
                .Select(c => new CategoriasQuestao
                {
                    IdCategoriasQuestao = c.IdCategoriasQuestao,
                    IdCategoriaQuestao = c.IdCategoriaQuestao,
                    IdQuestao = c.IdQuestao,
                    IdCategoriaQuestaoNavigation = new CategoriaQuestao
                    {
                        IdCategoriaQuestao = c.IdCategoriaQuestaoNavigation.IdCategoriaQuestao,
                        Nome = c.IdCategoriaQuestaoNavigation.Nome
                    },
                    IdQuestaoNavigation = new Questao
                    {
                        IdQuestao = c.IdQuestaoNavigation.IdQuestao,
                        Pergunta = c.IdQuestaoNavigation.Pergunta,
                        PontosNota = c.IdQuestaoNavigation.PontosNota
                    }
                })
                .FirstOrDefault(tu => tu.IdQuestao == id);
        }

        public void Cadastrar(CategoriasQuestao entity)
        {
            ctx.CategoriasQuestaos.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            CategoriasQuestao CategoriasQuestaoBuscada = ctx.CategoriasQuestaos.Find(id);

            ctx.CategoriasQuestaos.Remove(CategoriasQuestaoBuscada);

            ctx.SaveChanges();
        }

        public List<CategoriasQuestao> Listar()
        {
            return ctx.CategoriasQuestaos
                .Include(c => c.IdCategoriaQuestaoNavigation)
                .Include(c => c.IdQuestaoNavigation)
                .Select(c => new CategoriasQuestao
                {
                    IdCategoriasQuestao = c.IdCategoriasQuestao,
                    IdCategoriaQuestao = c.IdCategoriaQuestao,
                    IdQuestao = c.IdQuestao,
                    IdCategoriaQuestaoNavigation = new CategoriaQuestao
                    {
                        IdCategoriaQuestao = c.IdCategoriaQuestaoNavigation.IdCategoriaQuestao,
                        Nome = c.IdCategoriaQuestaoNavigation.Nome
                    },
                    IdQuestaoNavigation = new Questao
                    {
                        IdQuestao = c.IdQuestaoNavigation.IdQuestao,
                        Pergunta = c.IdQuestaoNavigation.Pergunta,
                        PontosNota = c.IdQuestaoNavigation.PontosNota
                    }
                })
                .ToList();
        }
    }
       
}
