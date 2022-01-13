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
    public class ArquivoPostagemRepository : IBaseRepository<ArquivoPostagem>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, ArquivoPostagem entity)
        {
            ArquivoPostagem ArquivoBuscado = ctx.ArquivoPostagems.Find(id);

            if (entity.Arquivo != null)
            {
                ArquivoBuscado.Arquivo = entity.Arquivo;
            }

            ctx.ArquivoPostagems.Update(ArquivoBuscado);

            ctx.SaveChanges();
        }

        public ArquivoPostagem BuscarPorId(int id)
        {
            return ctx.ArquivoPostagems
                .Include(a => a.IdPostagemNavigation)
                .Select(a => new ArquivoPostagem
                {
                    IdArquivoPostagem = a.IdArquivoPostagem,
                    Arquivo = a.Arquivo,
                    IdPostagem = a.IdPostagem,
                    IdPostagemNavigation = new Postagem
                    {
                        IdPostagem = a.IdPostagemNavigation.IdPostagem,
                        IdUsuario = a.IdPostagemNavigation.IdUsuario,
                        IdCurso = a.IdPostagemNavigation.IdCurso,
                        Texto = a.IdPostagemNavigation.Texto
                    }
                })
                .FirstOrDefault(tu => tu.IdPostagem == id);
        }

        public void Cadastrar(ArquivoPostagem entity)
        {
            ctx.ArquivoPostagems.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ArquivoPostagem ArquivoBuscado = ctx.ArquivoPostagems.Find(id);

            ctx.ArquivoPostagems.Remove(ArquivoBuscado);

            ctx.SaveChanges();
        }

        public List<ArquivoPostagem> Listar()
        {
            return ctx.ArquivoPostagems
                .Include(a => a.IdPostagemNavigation)
                .Select(a => new ArquivoPostagem
                {
                    IdArquivoPostagem = a.IdArquivoPostagem,
                    Arquivo = a.Arquivo,
                    IdPostagem = a.IdPostagem,
                    IdPostagemNavigation = new Postagem
                    {
                        IdPostagem = a.IdPostagemNavigation.IdPostagem,
                        IdUsuario = a.IdPostagemNavigation.IdUsuario,
                        IdCurso = a.IdPostagemNavigation.IdCurso,
                        Texto = a.IdPostagemNavigation.Texto
                    }
                })
                .ToList();
        }
    }
}
