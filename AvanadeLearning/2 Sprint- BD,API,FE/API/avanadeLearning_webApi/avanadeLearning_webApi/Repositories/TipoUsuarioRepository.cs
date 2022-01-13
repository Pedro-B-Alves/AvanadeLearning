using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Contexts;
using avanadeLearning_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Repositories
{
    public class TipoUsuarioRepository : IBaseRepository<TipoUsuario>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, TipoUsuario entity)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            if (entity.Tipo != null)
            {
                TipoUsuarioBuscado.Tipo = entity.Tipo;

            }

            ctx.TipoUsuarios.Update(TipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios
                .Select(t => new TipoUsuario
                {
                    IdTipoUsuario = t.IdTipoUsuario,
                    Tipo = t.Tipo
                })
                .FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario entity)
        {
            ctx.TipoUsuarios.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            ctx.TipoUsuarios.Remove(TipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios
                .Select(t => new TipoUsuario
                {
                    IdTipoUsuario = t.IdTipoUsuario,
                    Tipo = t.Tipo
                })
                .ToList();
        }
    }
}
