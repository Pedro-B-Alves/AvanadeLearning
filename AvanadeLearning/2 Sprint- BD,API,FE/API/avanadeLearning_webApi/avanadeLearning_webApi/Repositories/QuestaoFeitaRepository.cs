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
    public class QuestaoFeitaRepository : IBaseRepository<QuestaoFeitum>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, QuestaoFeitum entity)
        {
            QuestaoFeitum QuestaoFeitaBuscada = ctx.QuestaoFeita.Find(id);

            if (entity.Feito != QuestaoFeitaBuscada.Feito)
            {
                QuestaoFeitaBuscada.Feito = entity.Feito;
            }

            if (entity.Pontos != 0)
            {
                QuestaoFeitaBuscada.Pontos = entity.Pontos;
            }

            ctx.QuestaoFeita.Update(QuestaoFeitaBuscada);

            ctx.SaveChanges();
        }

        public QuestaoFeitum BuscarPorId(int id)
        {
            return ctx.QuestaoFeita
                .Include(q => q.IdAulaQuestoesNavigation)
                .Include(q => q.IdUsuarioNavigation)
                .Select(q => new QuestaoFeitum
                {
                    IdQuestaoFeita = q.IdQuestaoFeita,
                    IdAulaQuestoes = q.IdAulaQuestoes,
                    IdUsuario = q.IdUsuario,
                    Feito = q.Feito,
                    Pontos = q.Pontos,
                    IdAulaQuestoesNavigation = new AulaQuesto
                    {
                        IdAulaQuestoes = q.IdAulaQuestoesNavigation.IdAulaQuestoes,
                        IdUsuario = q.IdAulaQuestoesNavigation.IdUsuario,
                        IdAula = q.IdAulaQuestoesNavigation.IdAula,
                        Nota = q.IdAulaQuestoesNavigation.Nota
                    },
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = q.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = q.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = q.IdUsuarioNavigation.Nome,
                        Email = q.IdUsuarioNavigation.Email,
                        Imagem = q.IdUsuarioNavigation.Imagem,
                        Pontos = q.IdUsuarioNavigation.Pontos,
                        PontosSemanais = q.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = q.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = q.IdUsuarioNavigation.ImagemBackground,
                    }
                })
                .FirstOrDefault(tu => tu.IdUsuario == id);
        }

        public void Cadastrar(QuestaoFeitum entity)
        {
            ctx.QuestaoFeita.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            QuestaoFeitum QuestaoFeitaBuscada = ctx.QuestaoFeita.Find(id);

            ctx.QuestaoFeita.Remove(QuestaoFeitaBuscada);

            ctx.SaveChanges();
        }

        public List<QuestaoFeitum> Listar()
        {
            return ctx.QuestaoFeita
                .Include(q => q.IdAulaQuestoesNavigation)
                .Include(q => q.IdUsuarioNavigation)
                .Select(q => new QuestaoFeitum
                {
                    IdQuestaoFeita = q.IdQuestaoFeita,
                    IdAulaQuestoes = q.IdAulaQuestoes,
                    IdUsuario = q.IdUsuario,
                    Feito = q.Feito,
                    Pontos = q.Pontos,
                    IdAulaQuestoesNavigation = new AulaQuesto
                    {
                        IdAulaQuestoes = q.IdAulaQuestoesNavigation.IdAulaQuestoes,
                        IdUsuario = q.IdAulaQuestoesNavigation.IdUsuario,
                        IdAula = q.IdAulaQuestoesNavigation.IdAula,
                        Nota = q.IdAulaQuestoesNavigation.Nota
                    },
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = q.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = q.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = q.IdUsuarioNavigation.Nome,
                        Email = q.IdUsuarioNavigation.Email,
                        Imagem = q.IdUsuarioNavigation.Imagem,
                        Pontos = q.IdUsuarioNavigation.Pontos,
                        PontosSemanais = q.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = q.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = q.IdUsuarioNavigation.ImagemBackground,
                    }
                })
                .ToList();
        }
    }
       
}
