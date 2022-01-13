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
    public class CursoRepository : ICursoRepository
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, Curso entity)
        {
            Curso CursoBuscado = ctx.Cursos.Find(id);

            if (entity.Nome != null)
            {
                CursoBuscado.Nome = entity.Nome;
            }

            if (entity.Descricao != null)
            {
                CursoBuscado.Descricao = entity.Descricao;
            }

            if (entity.Imagem != null)
            {
                CursoBuscado.Imagem = entity.Imagem;
            }

            if (entity.Horas != 0)
            {
                CursoBuscado.Horas = entity.Horas;
            }

            ctx.Cursos.Update(CursoBuscado);

            ctx.SaveChanges();
        }

        public Curso BuscarPorId(int id)
        {
            return ctx.Cursos
                .Include(c => c.IdInstituicaoNavigation)
                .Select(c => new Curso
                {
                    IdCurso = c.IdCurso,
                    IdInstituicao = c.IdInstituicao,
                    Nome = c.Nome,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    Horas = c.Horas,
                    IdInstituicaoNavigation = new Instituicao
                    {
                        IdInstituicao = c.IdInstituicaoNavigation.IdInstituicao,
                        NomeFantasia = c.IdInstituicaoNavigation.NomeFantasia,
                        RazaoSocial = c.IdInstituicaoNavigation.RazaoSocial,
                        Endereco = c.IdInstituicaoNavigation.Endereco,
                        Cnpj = c.IdInstituicaoNavigation.Cnpj,
                        Telefone = c.IdInstituicaoNavigation.Telefone
                    }
                })
                .FirstOrDefault(tu => tu.IdCurso == id);
        }

        public Curso BuscarPorIdInstituicao(int id)
        {
            return ctx.Cursos
                .Include(c => c.IdInstituicaoNavigation)
                .Select(c => new Curso
                {
                    IdCurso = c.IdCurso,
                    IdInstituicao = c.IdInstituicao,
                    Nome = c.Nome,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    Horas = c.Horas,
                    IdInstituicaoNavigation = new Instituicao
                    {
                        IdInstituicao = c.IdInstituicaoNavigation.IdInstituicao,
                        NomeFantasia = c.IdInstituicaoNavigation.NomeFantasia,
                        RazaoSocial = c.IdInstituicaoNavigation.RazaoSocial,
                        Endereco = c.IdInstituicaoNavigation.Endereco,
                        Cnpj = c.IdInstituicaoNavigation.Cnpj,
                        Telefone = c.IdInstituicaoNavigation.Telefone
                    }
                })
                .FirstOrDefault(tu => tu.IdInstituicao == id);
        }

        public void Cadastrar(Curso entity)
        {
            ctx.Cursos.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Curso CursoBuscado = ctx.Cursos.Find(id);

            ctx.Cursos.Remove(CursoBuscado);

            ctx.SaveChanges();
        }

        public List<Curso> Listar()
        {
            return ctx.Cursos
                .Include(c => c.IdInstituicaoNavigation)
                .Select(c => new Curso
                {
                    IdCurso = c.IdCurso,
                    IdInstituicao = c.IdInstituicao,
                    Nome = c.Nome,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    Horas = c.Horas,
                    IdInstituicaoNavigation = new Instituicao
                    {
                        IdInstituicao = c.IdInstituicaoNavigation.IdInstituicao,
                        NomeFantasia = c.IdInstituicaoNavigation.NomeFantasia,
                        RazaoSocial = c.IdInstituicaoNavigation.RazaoSocial,
                        Endereco = c.IdInstituicaoNavigation.Endereco,
                        Cnpj = c.IdInstituicaoNavigation.Cnpj,
                        Telefone = c.IdInstituicaoNavigation.Telefone
                    }
                })
                .ToList();
        }

    }
}
