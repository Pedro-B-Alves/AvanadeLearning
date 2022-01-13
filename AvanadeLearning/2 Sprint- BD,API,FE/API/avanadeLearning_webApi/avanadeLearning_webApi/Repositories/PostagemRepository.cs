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
    public class PostagemRepository : IBaseRepository<Postagem>
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, Postagem entity)
        {
            Postagem PostagemBuscado = ctx.Postagems.Find(id);

            if (entity.Texto != null)
            {
                PostagemBuscado.Texto = entity.Texto;
            }


            ctx.Postagems.Update(PostagemBuscado);

            ctx.SaveChanges();
        }

        public Postagem BuscarPorId(int id)
        {
            return ctx.Postagems
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.IdCursoNavigation)
                .Select(p => new Postagem
                {
                    IdPostagem = p.IdPostagem,
                    IdUsuario = p.IdUsuario,
                    IdCurso = p.IdCurso,
                    Texto = p.Texto,
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = p.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = p.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = p.IdUsuarioNavigation.Nome,
                        Email = p.IdUsuarioNavigation.Email,
                        Imagem = p.IdUsuarioNavigation.Imagem,
                        Pontos = p.IdUsuarioNavigation.Pontos,
                        PontosSemanais = p.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = p.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = p.IdUsuarioNavigation.ImagemBackground
                    },
                    IdCursoNavigation = new Curso
                    {
                        IdCurso = p.IdCursoNavigation.IdCurso,
                        IdInstituicao = p.IdCursoNavigation.IdInstituicao,
                        Nome = p.IdCursoNavigation.Nome,
                        Descricao = p.IdCursoNavigation.Descricao,
                        Imagem = p.IdCursoNavigation.Imagem,
                        Horas = p.IdCursoNavigation.Horas
                    }
                })
                .FirstOrDefault(tu => tu.IdCurso == id);
        }

        public void Cadastrar(Postagem entity)
        {
            ctx.Postagems.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Postagem PostagemBuscado = ctx.Postagems.Find(id);

            ctx.Postagems.Remove(PostagemBuscado);

            ctx.SaveChanges();
        }

        public List<Postagem> Listar()
        {
            return ctx.Postagems
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.IdCursoNavigation)
                .Select(p => new Postagem
                {
                    IdPostagem = p.IdPostagem,
                    IdUsuario = p.IdUsuario,
                    IdCurso = p.IdCurso,
                    Texto = p.Texto,
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = p.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = p.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = p.IdUsuarioNavigation.Nome,
                        Email = p.IdUsuarioNavigation.Email,
                        Imagem = p.IdUsuarioNavigation.Imagem,
                        Pontos = p.IdUsuarioNavigation.Pontos,
                        PontosSemanais = p.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = p.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = p.IdUsuarioNavigation.ImagemBackground
                    },
                    IdCursoNavigation = new Curso
                    {
                        IdCurso = p.IdCursoNavigation.IdCurso,
                        IdInstituicao = p.IdCursoNavigation.IdInstituicao,
                        Nome = p.IdCursoNavigation.Nome,
                        Descricao = p.IdCursoNavigation.Descricao,
                        Imagem = p.IdCursoNavigation.Imagem,
                        Horas = p.IdCursoNavigation.Horas
                    }
                })
                .ToList();
        }
    }
}
