using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Contexts;
using avanadeLearning_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Repositories
{
    public class InstituicaoRepository : IBaseRepository<Instituicao>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, Instituicao entity)
        {
            Instituicao InstituicaoBuscado = ctx.Instituicaos.Find(id);

            if (entity.NomeFantasia != null)
            {
                InstituicaoBuscado.NomeFantasia = entity.NomeFantasia;
            }

            if (entity.RazaoSocial != null)
            {
                InstituicaoBuscado.RazaoSocial = entity.RazaoSocial;
            }

            if (entity.Endereco != null)
            {
                InstituicaoBuscado.Endereco = entity.Endereco;
            }

            if (entity.Cnpj != null)
            {
                InstituicaoBuscado.Cnpj = entity.Cnpj;
            }

            if (entity.Telefone != null)
            {
                InstituicaoBuscado.Telefone = entity.Telefone;
            }

            ctx.Instituicaos.Update(InstituicaoBuscado);

            ctx.SaveChanges();
        }

        public Instituicao BuscarPorId(int id)
        {
            return ctx.Instituicaos
                .Select(i => new Instituicao
                {
                    IdInstituicao = i.IdInstituicao,
                    NomeFantasia = i.NomeFantasia,
                    RazaoSocial = i.RazaoSocial,
                    Endereco = i.Endereco,
                    Cnpj = i.Cnpj,
                    Telefone = i.Telefone
                })
                .FirstOrDefault(tu => tu.IdInstituicao == id);
        }

        public void Cadastrar(Instituicao entity)
        {
            ctx.Instituicaos.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Instituicao InstituicaoBuscado = ctx.Instituicaos.Find(id);

            ctx.Instituicaos.Remove(InstituicaoBuscado);

            ctx.SaveChanges();
        }

        public List<Instituicao> Listar()
        {
            return ctx.Instituicaos
                .Select(i => new Instituicao
                {
                    IdInstituicao = i.IdInstituicao,
                    NomeFantasia = i.NomeFantasia,
                    RazaoSocial = i.RazaoSocial,
                    Endereco = i.Endereco,
                    Cnpj = i.Cnpj,
                    Telefone = i.Telefone
                })
                .ToList();
        }
    }
}
