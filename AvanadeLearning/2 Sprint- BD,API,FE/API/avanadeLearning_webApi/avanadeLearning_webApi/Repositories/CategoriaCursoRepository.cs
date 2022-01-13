using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Contexts;
using avanadeLearning_webApi.Domains;
using avanadeLearning_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Repositories
{
    public class CategoriaCursoRepository : IBaseRepository<CategoriaCurso>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, CategoriaCurso entity)
        {
            CategoriaCurso CategoriaCursoBuscado = ctx.CategoriaCursos.Find(id);

            if (entity.Categoria != null)
            {
                CategoriaCursoBuscado.Categoria = entity.Categoria;
            }

            ctx.CategoriaCursos.Update(CategoriaCursoBuscado);

            ctx.SaveChanges();
        }

        public CategoriaCurso BuscarPorId(int id)
        {
            return ctx.CategoriaCursos
                .Select(c => new CategoriaCurso
                {
                    IdCategoriaCurso = c.IdCategoriaCurso,
                    Categoria = c.Categoria
                })
                .FirstOrDefault(tu => tu.IdCategoriaCurso == id);
        }

        public void Cadastrar(CategoriaCurso entity)
        {
            ctx.CategoriaCursos.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            CategoriaCurso CategoriaCursoBuscado = ctx.CategoriaCursos.Find(id);

            ctx.CategoriaCursos.Remove(CategoriaCursoBuscado);

            ctx.SaveChanges();
        }

        public List<CategoriaCurso> Listar()
        {
            return ctx.CategoriaCursos
                .Select(c => new CategoriaCurso
                {
                    IdCategoriaCurso = c.IdCategoriaCurso,
                    Categoria = c.Categoria
                })
                .ToList();
        }

    }
}
