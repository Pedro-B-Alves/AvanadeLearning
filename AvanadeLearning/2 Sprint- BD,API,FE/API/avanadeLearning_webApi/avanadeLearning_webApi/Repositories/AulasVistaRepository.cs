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
    public class AulasVistaRepository : IAulasVistaRepository
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public void Atualizar(int id, AulasVistum entity)
        {
            AulasVistum AulasVistaBuscado = ctx.AulasVista.Find(id);

            if (entity.Visto != AulasVistaBuscado.Visto)
            {
                AulasVistaBuscado.Visto = entity.Visto;
            }

            if (entity.Pontos != 0)
            {
                AulasVistaBuscado.Pontos = entity.Pontos;
            }

            ctx.AulasVista.Update(AulasVistaBuscado);

            ctx.SaveChanges();
        }

        public AulasVistum BuscarPorId(int id)
        {
            return ctx.AulasVista
                .Include(a => a.IdAulaNavigation)
                .Include(a => a.IdUsuarioNavigation)
                .Select(a => new AulasVistum
                {
                    IdAulasVista = a.IdAulasVista,
                    IdAula = a.IdAula,
                    IdUsuario = a.IdUsuario,
                    Visto = a.Visto,
                    Pontos = a.Pontos,
                    IdAulaNavigation = new Aula
                    {
                        IdAula = Convert.ToInt32(a.IdAula),
                        Video = a.IdAulaNavigation.Video,
                        Descricao = a.IdAulaNavigation.Descricao,
                        LinkConteudoExtra = a.IdAulaNavigation.LinkConteudoExtra,
                        Titulo = a.IdAulaNavigation.Titulo
                    },
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = a.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = a.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = a.IdUsuarioNavigation.Nome,
                        Email = a.IdUsuarioNavigation.Email,
                        Imagem = a.IdUsuarioNavigation.Imagem,
                        Pontos = a.IdUsuarioNavigation.Pontos,
                        PontosSemanais = a.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = a.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = a.IdUsuarioNavigation.ImagemBackground
                    }
                })
                .FirstOrDefault(tu => tu.IdUsuario == id);
        }

        public AulasVistum BuscarPorIdAula(int id)
        {
            return ctx.AulasVista
                .Include(a => a.IdAulaNavigation)
                .Include(a => a.IdUsuarioNavigation)
                .Select(a => new AulasVistum
                {
                    IdAulasVista = a.IdAulasVista,
                    IdAula = a.IdAula,
                    IdUsuario = a.IdUsuario,
                    Visto = a.Visto,
                    Pontos = a.Pontos,
                    IdAulaNavigation = new Aula
                    {
                        IdAula = Convert.ToInt32(a.IdAula),
                        Video = a.IdAulaNavigation.Video,
                        Descricao = a.IdAulaNavigation.Descricao,
                        LinkConteudoExtra = a.IdAulaNavigation.LinkConteudoExtra,
                        Titulo = a.IdAulaNavigation.Titulo
                    },
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = a.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = a.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = a.IdUsuarioNavigation.Nome,
                        Email = a.IdUsuarioNavigation.Email,
                        Imagem = a.IdUsuarioNavigation.Imagem,
                        Pontos = a.IdUsuarioNavigation.Pontos,
                        PontosSemanais = a.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = a.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = a.IdUsuarioNavigation.ImagemBackground
                    }
                })
                .FirstOrDefault(tu => tu.IdAula == id);
        }

        public void Cadastrar(AulasVistum entity)
        {
            ctx.AulasVista.Add(entity);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            AulasVistum AulasVistaBuscado = ctx.AulasVista.Find(id);

            ctx.AulasVista.Remove(AulasVistaBuscado);

            ctx.SaveChanges();
        }

        public List<AulasVistum> Listar()
        {
            return ctx.AulasVista
                .Include(a => a.IdAulaNavigation)
                .Include(a => a.IdUsuarioNavigation)
                .Select(a => new AulasVistum
                {
                    IdAulasVista = a.IdAulasVista,
                    IdAula = a.IdAula,
                    IdUsuario = a.IdUsuario,
                    Visto = a.Visto,
                    Pontos = a.Pontos,
                    IdAulaNavigation = new Aula
                    {
                        IdAula = Convert.ToInt32(a.IdAula),
                        Video = a.IdAulaNavigation.Video,
                        Descricao = a.IdAulaNavigation.Descricao,
                        LinkConteudoExtra = a.IdAulaNavigation.LinkConteudoExtra,
                        Titulo = a.IdAulaNavigation.Titulo
                    },
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = a.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = a.IdUsuarioNavigation.IdTipoUsuario,
                        Nome = a.IdUsuarioNavigation.Nome,
                        Email = a.IdUsuarioNavigation.Email,
                        Imagem = a.IdUsuarioNavigation.Imagem,
                        Pontos = a.IdUsuarioNavigation.Pontos,
                        PontosSemanais = a.IdUsuarioNavigation.PontosSemanais,
                        SobreMim = a.IdUsuarioNavigation.SobreMim,
                        ImagemBackground = a.IdUsuarioNavigation.ImagemBackground
                    }
                })
                .ToList();
        }
    }
}
