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
    public class CursandoRepository : ICursandoRepository
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, Cursando entity)
        {
            Cursando CursandoBuscado = ctx.Cursandos.Find(id);

            if (entity.IdUsuario != null)
            {
                CursandoBuscado.IdUsuario = entity.IdUsuario;
            }

            if (entity.IdCurso != null)
            {
                CursandoBuscado.IdCurso = entity.IdCurso;
            }

            ctx.Cursandos.Update(CursandoBuscado);

            ctx.SaveChanges();
        }

        public Cursando BuscarPorId(int id)
        {
            return ctx.Cursandos
                .Include(c => c.IdUsuarioNavigation)
                .Include(c => c.IdCursoNavigation)
                .Select(c => new Cursando
                {
                    IdCursando = c.IdCursando,
                    IdUsuario = c.IdUsuario,
                    IdCurso = c.IdCurso,
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = Convert.ToInt32(c.IdUsuario),
                        IdTipoUsuario = c.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = c.IdUsuarioNavigation.Nome,
                        Imagem = c.IdUsuarioNavigation.Imagem,
                        Pontos = c.IdUsuarioNavigation.Pontos,
                        PontosSemanais = c.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = c.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = c.IdUsuarioNavigation.ImagemBackground,
                        
                    },
                    IdCursoNavigation = new Curso
                    {
                        IdCurso = Convert.ToInt32(c.IdCurso),
                        IdInstituicao = c.IdCursoNavigation.IdInstituicao,
                        Nome = c.IdCursoNavigation.Nome,
                        Descricao = c.IdCursoNavigation.Descricao,
                        Imagem = c.IdCursoNavigation.Imagem,
                        Horas = c.IdCursoNavigation.Horas
                    }
                })
                .FirstOrDefault(tu => tu.IdCurso == id);
        }

        public Cursando BuscarPorIdUsuario(int id)
        {
            return ctx.Cursandos
                .Include(c => c.IdUsuarioNavigation)
                .Include(c => c.IdCursoNavigation)
                .Select(c => new Cursando
                {
                    IdCursando = c.IdCursando,
                    IdUsuario = c.IdUsuario,
                    IdCurso = c.IdCurso,
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = Convert.ToInt32(c.IdUsuario),
                        IdTipoUsuario = c.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = c.IdUsuarioNavigation.Nome,
                        Imagem = c.IdUsuarioNavigation.Imagem,
                        Pontos = c.IdUsuarioNavigation.Pontos,
                        PontosSemanais = c.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = c.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = c.IdUsuarioNavigation.ImagemBackground,

                    },
                    IdCursoNavigation = new Curso
                    {
                        IdCurso = Convert.ToInt32(c.IdCurso),
                        IdInstituicao = c.IdCursoNavigation.IdInstituicao,
                        Nome = c.IdCursoNavigation.Nome,
                        Descricao = c.IdCursoNavigation.Descricao,
                        Imagem = c.IdCursoNavigation.Imagem,
                        Horas = c.IdCursoNavigation.Horas
                    }
                })
                .FirstOrDefault(tu => tu.IdUsuario == id);
        }

        public void Cadastrar(Cursando entity)
        {
            ctx.Cursandos.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Cursando CursandoBuscado = ctx.Cursandos.Find(id);

            ctx.Cursandos.Remove(CursandoBuscado);

            ctx.SaveChanges();
        }

        public List<Cursando> Listar()
        {
            return ctx.Cursandos
                .Include(c => c.IdUsuarioNavigation)
                .Include(c => c.IdCursoNavigation)
                .Select(c => new Cursando
                {
                    IdCursando = c.IdCursando,
                    IdUsuario = c.IdUsuario,
                    IdCurso = c.IdCurso,
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = Convert.ToInt32(c.IdUsuario),
                        IdTipoUsuario = c.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = c.IdUsuarioNavigation.Nome,
                        Imagem = c.IdUsuarioNavigation.Imagem,
                        Pontos = c.IdUsuarioNavigation.Pontos,
                        PontosSemanais = c.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = c.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = c.IdUsuarioNavigation.ImagemBackground,

                    },
                    IdCursoNavigation = new Curso
                    {
                        IdCurso = Convert.ToInt32(c.IdCurso),
                        IdInstituicao = c.IdCursoNavigation.IdInstituicao,
                        Nome = c.IdCursoNavigation.Nome,
                        Descricao = c.IdCursoNavigation.Descricao,
                        Imagem = c.IdCursoNavigation.Imagem,
                        Horas = c.IdCursoNavigation.Horas
                    }
                })
                .ToList();
        }
    }
}
