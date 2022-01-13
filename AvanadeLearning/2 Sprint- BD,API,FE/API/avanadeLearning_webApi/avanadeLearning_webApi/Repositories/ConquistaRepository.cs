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
    public class ConquistaRepository : IBaseRepository<Conquistum>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, Conquistum entity)
        {
            Conquistum CursandoBuscado = ctx.Conquista.Find(id);

            if (entity.Nome != null)
            {
                CursandoBuscado.Nome = entity.Nome;
            }

            if (entity.Descricao != null)
            {
                CursandoBuscado.Descricao = entity.Descricao;
            }

            if (entity.Imagem != null)
            {
                CursandoBuscado.Imagem = entity.Imagem;
            }

            if (entity.Pontos != 0)
            {
                CursandoBuscado.Pontos = entity.Pontos;
            }

            ctx.Conquista.Update(CursandoBuscado);

            ctx.SaveChanges();
        }

        public Conquistum BuscarPorId(int id)
        {
            return ctx.Conquista
                .Include(c => c.IdModuloNavigation)
                .Include(c => c.IdCursoNavigation)
                .Select(c => new Conquistum
                {
                    IdConquista = c.IdConquista,
                    IdModulo = c.IdModulo,
                    IdCurso = c.IdCurso,
                    Nome = c.Nome,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    Pontos = c.Pontos,
                    IdModuloNavigation = new Modulo
                    {
                        IdModulo = c.IdModuloNavigation.IdModulo,
                        IdCurso = c.IdModuloNavigation.IdCurso,
                        Nome = c.IdModuloNavigation.Nome,
                        Texto = c.IdModuloNavigation.Texto
                    },
                    IdCursoNavigation = new Curso
                    {
                        IdCurso = c.IdCursoNavigation.IdCurso,
                        IdInstituicao = c.IdCursoNavigation.IdInstituicao,
                        Nome = c.IdCursoNavigation.Nome,
                        Descricao = c.IdCursoNavigation.Descricao,
                        Imagem = c.IdCursoNavigation.Imagem,
                        Horas = c.IdCursoNavigation.Horas
                    }
                })
                .FirstOrDefault(tu => tu.IdConquista == id);
        }

        public void Cadastrar(Conquistum entity)
        {
            ctx.Conquista.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Conquistum ConquistaBuscado = ctx.Conquista.Find(id);

            ctx.Conquista.Remove(ConquistaBuscado);

            ctx.SaveChanges();
        }

        public List<Conquistum> Listar()
        {
            return ctx.Conquista
                .Include(c => c.IdModuloNavigation)
                .Include(c => c.IdCursoNavigation)
                .Select(c => new Conquistum
                {
                    IdConquista = c.IdConquista,
                    IdModulo = c.IdModulo,
                    IdCurso = c.IdCurso,
                    Nome = c.Nome,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    Pontos = c.Pontos,
                    IdModuloNavigation = new Modulo
                    {
                        IdModulo = c.IdModuloNavigation.IdModulo,
                        IdCurso = c.IdModuloNavigation.IdCurso,
                        Nome = c.IdModuloNavigation.Nome,
                        Texto = c.IdModuloNavigation.Texto
                    },
                    IdCursoNavigation = new Curso
                    {
                        IdCurso = c.IdCursoNavigation.IdCurso,
                        IdInstituicao = c.IdCursoNavigation.IdInstituicao,
                        Nome = c.IdCursoNavigation.Nome,
                        Descricao = c.IdCursoNavigation.Descricao,
                        Imagem = c.IdCursoNavigation.Imagem,
                        Horas = c.IdCursoNavigation.Horas
                    }
                })
                .ToList();
        }
    }
}
