using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Contexts;
using avanadeLearning_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Repositories
{
    public class QuestaoRepository : IBaseRepository<Questao>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, Questao entity)
        {
            Questao QuestaoBuscado = ctx.Questaos.Find(id);

            if (entity.Pergunta != null)
            {
                QuestaoBuscado.Pergunta = entity.Pergunta;
            }

            ctx.Questaos.Update(QuestaoBuscado);

            ctx.SaveChanges();
        }

        public Questao BuscarPorId(int id)
        {
            return ctx.Questaos
                .Select(q => new Questao
                {
                    IdQuestao = q.IdQuestao,
                    Pergunta = q.Pergunta,
                    PontosNota = q.PontosNota
                })
                .FirstOrDefault(tu => tu.IdQuestao == id);
        }

        public void Cadastrar(Questao entity)
        {
            ctx.Questaos.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Questao QuestaoBuscado = ctx.Questaos.Find(id);

            ctx.Questaos.Remove(QuestaoBuscado);

            ctx.SaveChanges();
        }

        public List<Questao> Listar()
        {
            return ctx.Questaos
                .Select(q => new Questao
                {
                    IdQuestao = q.IdQuestao,
                    Pergunta = q.Pergunta,
                    PontosNota = q.PontosNota
                })
                .ToList();
        }
    }
       
}
