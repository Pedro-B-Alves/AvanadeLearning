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
    public class AulaModuloRepository : IAulaModuloRepository
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();

        public void Atualizar(int id, AulaModulo entity)
        {
            AulaModulo AulaBuscada = ctx.AulaModulos.Find(id);

            if (entity.IdAula != null)
            {
                AulaBuscada.IdAula = entity.IdAula;
            }

            if (entity.IdModulo != null)
            {
                AulaBuscada.IdModulo = entity.IdModulo;
            }

            ctx.AulaModulos.Update(AulaBuscada);

            ctx.SaveChanges();
        }

        public AulaModulo BuscarPorId(int id)
        {
            return ctx.AulaModulos
                .Include(a => a.IdAulaNavigation)
                .Include(a => a.IdModuloNavigation)
                .Select(a => new AulaModulo
                {
                    IdAulaModulo = a.IdAulaModulo,
                    IdAula = a.IdAula,
                    IdModulo = a.IdModulo,
                    IdAulaNavigation = new Aula
                    {
                        IdAula = a.IdAulaNavigation.IdAula,
                        Video = a.IdAulaNavigation.Video,
                        Descricao = a.IdAulaNavigation.Descricao,
                        LinkConteudoExtra = a.IdAulaNavigation.LinkConteudoExtra,
                        Titulo = a.IdAulaNavigation.Titulo
                    },
                    IdModuloNavigation = new Modulo
                    {
                        IdModulo = a.IdModuloNavigation.IdModulo,
                        IdCurso = a.IdModuloNavigation.IdCurso,
                        Nome = a.IdModuloNavigation.Nome,
                        Texto = a.IdModuloNavigation.Texto
                    }
                })
                .FirstOrDefault(tu => tu.IdAulaModulo == id);
        }

        public AulaModulo BuscarPorIdModulo(int id)
        {
            return ctx.AulaModulos
                .Include(a => a.IdAulaNavigation)
                .Include(a => a.IdModuloNavigation)
                .Select(a => new AulaModulo
                {
                    IdAulaModulo = a.IdAulaModulo,
                    IdAula = a.IdAula,
                    IdModulo = a.IdModulo,
                    IdAulaNavigation = new Aula
                    {
                        IdAula = a.IdAulaNavigation.IdAula,
                        Video = a.IdAulaNavigation.Video,
                        Descricao = a.IdAulaNavigation.Descricao,
                        LinkConteudoExtra = a.IdAulaNavigation.LinkConteudoExtra,
                        Titulo = a.IdAulaNavigation.Titulo
                    },
                    IdModuloNavigation = new Modulo
                    {
                        IdModulo = a.IdModuloNavigation.IdModulo,
                        IdCurso = a.IdModuloNavigation.IdCurso,
                        Nome = a.IdModuloNavigation.Nome,
                        Texto = a.IdModuloNavigation.Texto
                    }
                })
                .FirstOrDefault(tu => tu.IdModulo == id);
        }

        public void Cadastrar(AulaModulo entity)
        {
            ctx.AulaModulos.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            AulaModulo AulaBuscada = ctx.AulaModulos.Find(id);

            ctx.AulaModulos.Remove(AulaBuscada);

            ctx.SaveChanges();
        }

        public List<AulaModulo> Listar()
        {
            return ctx.AulaModulos
                .Include(a => a.IdAulaNavigation)
                .Include(a => a.IdModuloNavigation)
                .Select(a => new AulaModulo
                {
                    IdAulaModulo = a.IdAulaModulo,
                    IdAula = a.IdAula,
                    IdModulo = a.IdModulo,
                    IdAulaNavigation = new Aula
                    {
                        IdAula = a.IdAulaNavigation.IdAula,
                        Video = a.IdAulaNavigation.Video,
                        Descricao = a.IdAulaNavigation.Descricao,
                        LinkConteudoExtra = a.IdAulaNavigation.LinkConteudoExtra,
                        Titulo = a.IdAulaNavigation.Titulo
                    },
                    IdModuloNavigation = new Modulo
                    {
                        IdModulo = a.IdModuloNavigation.IdModulo,
                        IdCurso = a.IdModuloNavigation.IdCurso,
                        Nome = a.IdModuloNavigation.Nome,
                        Texto = a.IdModuloNavigation.Texto
                    }
                })
                .ToList();
        }
    }
}
