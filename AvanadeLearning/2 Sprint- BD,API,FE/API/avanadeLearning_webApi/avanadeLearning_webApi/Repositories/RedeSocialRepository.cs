using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Contexts;
using avanadeLearning_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Repositories
{
    public class RedeSocialRepository : IBaseRepository<RedeSocial>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, RedeSocial entity)
        {
            RedeSocial RedeSocialBuscado = ctx.RedeSocials.Find(id);

            if (entity.Nome != null)
            {
                RedeSocialBuscado.Nome = entity.Nome;
            }

            if (entity.LinkBase != null)
            {
                RedeSocialBuscado.LinkBase = entity.LinkBase;
            }

            ctx.RedeSocials.Update(RedeSocialBuscado);

            ctx.SaveChanges();
        }

        public RedeSocial BuscarPorId(int id)
        {
            return ctx.RedeSocials
                .Select(r => new RedeSocial
                {
                    IdRedeSocial = r.IdRedeSocial,
                    Nome = r.Nome,
                    LinkBase = r.LinkBase
                })
                .FirstOrDefault(tu => tu.IdRedeSocial == id);
        }

        public void Cadastrar(RedeSocial entity)
        {
            ctx.RedeSocials.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            RedeSocial RedeSocialBuscado = ctx.RedeSocials.Find(id);

            ctx.RedeSocials.Remove(RedeSocialBuscado);

            ctx.SaveChanges();
        }

        public List<RedeSocial> Listar()
        {
            return ctx.RedeSocials
                .Select(r => new RedeSocial
                {
                    IdRedeSocial = r.IdRedeSocial,
                    Nome = r.Nome,
                    LinkBase = r.LinkBase
                })
                .ToList();
        }
    }
}
