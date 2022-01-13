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
    public class CategoriasCursoRepository : IBaseRepository<CategoriasCurso>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, CategoriasCurso entity)
        {
            CategoriasCurso CategoriasCursoBuscado = ctx.CategoriasCursos.Find(id);

            if (entity.IdCategoriaCurso != null)
            {
                CategoriasCursoBuscado.IdCategoriaCurso = entity.IdCategoriaCurso;
            }

            ctx.CategoriasCursos.Update(CategoriasCursoBuscado);

            ctx.SaveChanges();
        }

        public CategoriasCurso BuscarPorId(int id)
        {
            return ctx.CategoriasCursos
                .Include(c => c.IdCategoriaCursoNavigation)
                .Include(c => c.IdCursoNavigation)
                .Select(c => new CategoriasCurso
                {
                    IdCategoriasCurso = c.IdCategoriasCurso,
                    IdCurso = c.IdCurso,
                    IdCategoriaCurso = c.IdCategoriaCurso,
                    IdCursoNavigation = new Curso
                    {
                        IdCurso = c.IdCursoNavigation.IdCurso,
                        IdInstituicao = c.IdCursoNavigation.IdInstituicao,
                        Nome = c.IdCursoNavigation.Nome,
                        Descricao = c.IdCursoNavigation.Descricao,
                        Imagem = c.IdCursoNavigation.Imagem,
                        Horas = c.IdCursoNavigation.Horas
                    },
                    IdCategoriaCursoNavigation = new CategoriaCurso
                    {
                        IdCategoriaCurso = c.IdCategoriaCursoNavigation.IdCategoriaCurso,
                        Categoria = c.IdCategoriaCursoNavigation.Categoria
                    }
                })
                .FirstOrDefault(tu => tu.IdCurso == id);
        }

        public void Cadastrar(CategoriasCurso entity)
        {
            ctx.CategoriasCursos.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            CategoriasCurso CategoriasCursoBuscado = ctx.CategoriasCursos.Find(id);

            ctx.CategoriasCursos.Remove(CategoriasCursoBuscado);

            ctx.SaveChanges();
        }

        public List<CategoriasCurso> Listar()
        {
            return ctx.CategoriasCursos
                .Include(c => c.IdCategoriaCursoNavigation)
                .Include(c => c.IdCursoNavigation)
                .Select(c => new CategoriasCurso
                {
                    IdCategoriasCurso = c.IdCategoriasCurso,
                    IdCurso = c.IdCurso,
                    IdCategoriaCurso = c.IdCategoriaCurso,
                    IdCursoNavigation = new Curso
                    {
                        IdCurso = c.IdCursoNavigation.IdCurso,
                        IdInstituicao = c.IdCursoNavigation.IdInstituicao,
                        Nome = c.IdCursoNavigation.Nome,
                        Descricao = c.IdCursoNavigation.Descricao,
                        Imagem = c.IdCursoNavigation.Imagem,
                        Horas = c.IdCursoNavigation.Horas
                    },
                    IdCategoriaCursoNavigation = new CategoriaCurso
                    {
                        IdCategoriaCurso = c.IdCategoriaCursoNavigation.IdCategoriaCurso,
                        Categoria = c.IdCategoriaCursoNavigation.Categoria
                    }
                })
                .ToList();
        }

    }
}
