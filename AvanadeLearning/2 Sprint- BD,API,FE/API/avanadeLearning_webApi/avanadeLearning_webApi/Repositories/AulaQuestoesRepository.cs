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
    public class AulaQuestoesRepository : IBaseRepository<AulaQuesto>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, AulaQuesto entity)
        {
            AulaQuesto AulaQuestaoBuscado = ctx.AulaQuestoes.Find(id);

            if (entity.Nota != null)
            {
                AulaQuestaoBuscado.Nota = entity.Nota;
            }

            ctx.AulaQuestoes.Update(AulaQuestaoBuscado);

            ctx.SaveChanges();
        }

        public AulaQuesto BuscarPorId(int id)
        {
            return ctx.AulaQuestoes
                .Include(a => a.IdQuestaoNavigation)
                .Include(a => a.IdUsuarioNavigation)
                .Include(a => a.IdAulaNavigation)
                .Select(a => new AulaQuesto
                {
                    IdAulaQuestoes = a.IdAulaQuestoes,
                    IdQuestao = a.IdQuestao,
                    IdUsuario = a.IdUsuario,
                    IdAula = a.IdAula,
                    Nota = a.Nota,
                    IdQuestaoNavigation = new Questao
                    {
                        IdQuestao = a.IdQuestaoNavigation.IdQuestao,
                        Pergunta = a.IdQuestaoNavigation.Pergunta,
                        PontosNota = a.IdQuestaoNavigation.PontosNota
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
                        ImagemBackground = a.IdUsuarioNavigation.ImagemBackground,
                    },
                    IdAulaNavigation = new Aula
                    {
                        IdAula = a.IdAulaNavigation.IdAula,
                        Video = a.IdAulaNavigation.Video,
                        Descricao = a.IdAulaNavigation.Descricao,
                        LinkConteudoExtra = a.IdAulaNavigation.LinkConteudoExtra,
                        Titulo = a.IdAulaNavigation.Titulo
                    }
                })
                .FirstOrDefault(tu => tu.IdAulaQuestoes == id);
        }

        public void Cadastrar(AulaQuesto entity)
        {
            ctx.AulaQuestoes.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            AulaQuesto AulaQuestionarioBuscado = ctx.AulaQuestoes.Find(id);

            ctx.AulaQuestoes.Remove(AulaQuestionarioBuscado);

            ctx.SaveChanges();
        }

        public List<AulaQuesto> Listar()
        {
            return ctx.AulaQuestoes
                .Include(a => a.IdQuestaoNavigation)
                .Include(a => a.IdUsuarioNavigation)
                .Include(a => a.IdAulaNavigation)
                .Select(a => new AulaQuesto
                {
                    IdAulaQuestoes = a.IdAulaQuestoes,
                    IdQuestao = a.IdQuestao,
                    IdUsuario = a.IdUsuario,
                    IdAula = a.IdAula,
                    Nota = a.Nota,
                    IdQuestaoNavigation = new Questao
                    {
                        IdQuestao = a.IdQuestaoNavigation.IdQuestao,
                        Pergunta = a.IdQuestaoNavigation.Pergunta,
                        PontosNota = a.IdQuestaoNavigation.PontosNota
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
                        ImagemBackground = a.IdUsuarioNavigation.ImagemBackground,
                    },
                    IdAulaNavigation = new Aula
                    {
                        IdAula = a.IdAulaNavigation.IdAula,
                        Video = a.IdAulaNavigation.Video,
                        Descricao = a.IdAulaNavigation.Descricao,
                        LinkConteudoExtra = a.IdAulaNavigation.LinkConteudoExtra,
                        Titulo = a.IdAulaNavigation.Titulo
                    }
                })
                .ToList();
        }
    }
}
