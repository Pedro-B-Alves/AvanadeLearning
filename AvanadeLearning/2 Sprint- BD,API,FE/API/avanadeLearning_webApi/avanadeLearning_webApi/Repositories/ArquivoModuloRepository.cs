using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Contexts;
using avanadeLearning_webApi.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Controllers
{
    public class ArquivoModuloRepository : IBaseRepository<ArquivoModulo>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, ArquivoModulo entity)
        {
            ArquivoModulo ArquivoBuscado = ctx.ArquivoModulos.Find(id);

            if (entity.Arquivo != null)
            {
                ArquivoBuscado.Arquivo = entity.Arquivo;
            }

            ctx.ArquivoModulos.Update(ArquivoBuscado);

            ctx.SaveChanges();
        }

        public ArquivoModulo BuscarPorId(int id)
        {
            return ctx.ArquivoModulos
                .Include(a => a.IdModuloNavigation)
                .Select(a => new ArquivoModulo
                {
                    IdArquivoModulo = a.IdArquivoModulo,
                    Arquivo = a.Arquivo,
                    IdModulo = a.IdModulo,
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

        public void Cadastrar(ArquivoModulo entity)
        {
            ctx.ArquivoModulos.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ArquivoModulo ArquivoBuscado = ctx.ArquivoModulos.Find(id);

            ctx.ArquivoModulos.Remove(ArquivoBuscado);

            ctx.SaveChanges();
        }

        public List<ArquivoModulo> Listar()
        {
            return ctx.ArquivoModulos
                .Include(a => a.IdModuloNavigation)
                .Select(a => new ArquivoModulo
                {
                    IdArquivoModulo = a.IdArquivoModulo,
                    Arquivo = a.Arquivo,
                    IdModulo = a.IdModulo,
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
