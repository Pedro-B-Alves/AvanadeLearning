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
    public class ModuloRepository : IBaseRepository<Modulo>, IModuloRepository
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, Modulo entity)
        {
            Modulo LikeBuscado = ctx.Modulos.Find(id);

            if (entity.Nome != null)
            {
                LikeBuscado.Nome = entity.Nome;
            }

            if (entity.Texto != null)
            {
                LikeBuscado.Texto = entity.Texto;
            }

            ctx.Modulos.Update(LikeBuscado);

            ctx.SaveChanges();
        }

        public Modulo BuscarPorId(int id)
        {
            return ctx.Modulos
                .Include(m => m.IdCursoNavigation)
                .Select(m => new Modulo
                {
                    IdModulo = m.IdModulo,
                    IdCurso = m.IdCurso,
                    Nome = m.Nome,
                    Texto = m.Texto,
                    IdCursoNavigation = new Curso
                    {
                        IdCurso = m.IdCursoNavigation.IdCurso,
                        IdInstituicao = m.IdCursoNavigation.IdInstituicao,
                        Nome = m.IdCursoNavigation.Nome,
                        Descricao = m.IdCursoNavigation.Descricao,
                        Imagem = m.IdCursoNavigation.Imagem,
                        Horas = m.IdCursoNavigation.Horas
                    }
                })
                .FirstOrDefault(tu => tu.IdCurso == id);
        }


        public Modulo BuscarPorIdCurso(int id)
        {
            return ctx.Modulos.FirstOrDefault(m => m.IdCurso == id);
        }

        public void Cadastrar(Modulo entity)
        {
            ctx.Modulos.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Modulo LikeBuscado = ctx.Modulos.Find(id);

            ctx.Modulos.Remove(LikeBuscado);

            ctx.SaveChanges();
        }

        public List<Modulo> Listar()
        {
            return ctx.Modulos
                .Include(m => m.IdCursoNavigation)
                .Select(m => new Modulo
                {
                    IdModulo = m.IdModulo,
                    IdCurso = m.IdCurso,
                    Nome = m.Nome,
                    Texto = m.Texto,
                    IdCursoNavigation = new Curso
                    {
                        IdCurso = m.IdCursoNavigation.IdCurso,
                        IdInstituicao = m.IdCursoNavigation.IdInstituicao,
                        Nome = m.IdCursoNavigation.Nome,
                        Descricao = m.IdCursoNavigation.Descricao,
                        Imagem = m.IdCursoNavigation.Imagem,
                        Horas = m.IdCursoNavigation.Horas
                    }
                })
                .ToList();
        }
    }
}
