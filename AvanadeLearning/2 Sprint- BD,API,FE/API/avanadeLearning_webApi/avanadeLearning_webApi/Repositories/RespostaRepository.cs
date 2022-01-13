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
    public class RespostaRepository : IBaseRepository<Respostum>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();

        public void Atualizar(int id, Respostum entity)
        {
            Respostum RespostaBuscado = ctx.Resposta.Find(id);

            if (entity.Resposta != null)
            {
                RespostaBuscado.Resposta = entity.Resposta;
            }

            if (entity.Correta != RespostaBuscado.Correta)
            {
                RespostaBuscado.Correta = entity.Correta;
            }

            ctx.Resposta.Update(RespostaBuscado);

            ctx.SaveChanges();
        }

        public Respostum BuscarPorId(int id)
        {
            return ctx.Resposta
                .Include(r => r.IdQuestaoNavigation)
                .Select(r => new Respostum
                {
                    IdResposta = r.IdResposta,
                    IdQuestao = r.IdQuestao,
                    Resposta = r.Resposta,
                    Correta = r.Correta,
                    IdQuestaoNavigation = new Questao
                    {
                        IdQuestao = r.IdQuestaoNavigation.IdQuestao,
                        Pergunta = r.IdQuestaoNavigation.Pergunta,
                        PontosNota = r.IdQuestaoNavigation.PontosNota
                    }
                })
                .FirstOrDefault(tu => tu.IdResposta == id);
        }

        public void Cadastrar(Respostum entity)
        {
            ctx.Resposta.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Respostum RespostumBuscado = ctx.Resposta.Find(id);

            ctx.Resposta.Remove(RespostumBuscado);

            ctx.SaveChanges();
        }

        public List<Respostum> Listar()
        {
            return ctx.Resposta
                .Include(r => r.IdQuestaoNavigation)
                .Select(r => new Respostum
                {
                    IdResposta = r.IdResposta,
                    IdQuestao = r.IdQuestao,
                    Resposta = r.Resposta,
                    Correta = r.Correta,
                    IdQuestaoNavigation = new Questao
                    {
                        IdQuestao = r.IdQuestaoNavigation.IdQuestao,
                        Pergunta = r.IdQuestaoNavigation.Pergunta,
                        PontosNota = r.IdQuestaoNavigation.PontosNota
                    }
                })
                .ToList();
        }
    }
}
