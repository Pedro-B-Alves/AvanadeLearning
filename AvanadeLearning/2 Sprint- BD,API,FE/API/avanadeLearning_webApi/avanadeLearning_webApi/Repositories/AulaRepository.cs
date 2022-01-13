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
    public class AulaRepository : IAulaRepository
    {
        AvanadeLearningContext ctx = new AvanadeLearningContext();
        public bool Atualizar(int id, Aula entity)
        {
            Aula aulaBuscada = ctx.Aulas.Find(id);

            if (entity.Video != null || aulaBuscada.Video.Length > 5)
            {
                if (entity.Video.Contains("youtube") || entity.Video.Contains("youtu.be"))
                {
                    aulaBuscada.Video = entity.Video;

                    if (entity.Descricao != null)
                    {
                        aulaBuscada.Descricao = entity.Descricao;
                    }

                    if (entity.LinkConteudoExtra != null)
                    {
                        aulaBuscada.LinkConteudoExtra = entity.LinkConteudoExtra;
                    }

                    if (entity.Titulo != null)
                    {
                        aulaBuscada.Titulo = entity.Titulo;
                    }

                    ctx.Aulas.Update(aulaBuscada);

                    ctx.SaveChanges();

                    return true;
                }

                else
                {
                    return false;
                }

            }

            if (entity.Descricao != null)
            {
                aulaBuscada.Descricao = entity.Descricao;
            }

            if (entity.LinkConteudoExtra != null)
            {
                aulaBuscada.LinkConteudoExtra = entity.LinkConteudoExtra;
            }

            if (entity.Titulo != null)
            {
                aulaBuscada.Titulo = entity.Titulo;
            }

            ctx.Aulas.Update(aulaBuscada);

            ctx.SaveChanges();

            return true;
        }

        public Aula BuscarPorId(int id)
        {
            Aula aula = ctx.Aulas
                .Select(a => new Aula
                {
                    IdAula = a.IdAula,
                    Video = a.Video,
                    Descricao = a.Descricao,
                    LinkConteudoExtra = a.LinkConteudoExtra,
                    Titulo = a.Titulo
                })
                .FirstOrDefault(tu => tu.IdAula == id);

            if (aula.Video != null || aula.Video.Length > 5)
            {
                if (aula.Video.Contains("youtube"))
                {
                    string quebraDeLink = aula.Video;

                    string[] parteDoLink = quebraDeLink.Split("v=");

                    aula.Video = parteDoLink[1];
                }

                else if (aula.Video.Contains("youtu.be"))
                {
                    string quebraDeLink = aula.Video;

                    string[] parteDoLink = quebraDeLink.Split("youtu.be/");

                    aula.Video = parteDoLink[1];
                }
            }
            
            return aula;
        }

        public bool Cadastrar(Aula entity)
        {
            if (entity.Video != null || entity.Video.Length > 5)
            {
                if (entity.Video.Contains("youtube") || entity.Video.Contains("youtu.be"))
                {
                    ctx.Aulas.Add(entity);

                    ctx.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            
            ctx.Aulas.Add(entity);

            ctx.SaveChanges();

            return true;
        }

        public void Deletar(int id)
        {
            Aula AulaBuscado = ctx.Aulas.Find(id);

            ctx.Aulas.Remove(AulaBuscado);

            ctx.SaveChanges();
        }

        public List<Aula> Listar()
        {
            List<Aula> aula = ctx.Aulas
                .Select(a => new Aula
                {
                    IdAula = a.IdAula,
                    Video = a.Video,
                    Descricao = a.Descricao,
                    LinkConteudoExtra = a.LinkConteudoExtra,
                    Titulo = a.Titulo
                })
                .ToList();

            for (int i = 0; i < aula.Count; i++)
            {
                if (aula[i].Video != null || aula[i].Video.Length > 5)
                {
                    if (aula[i].Video.Contains("youtube"))
                    {
                        string quebraDeLink = aula[i].Video;

                        string[] parteDoLink = quebraDeLink.Split("v=");

                        aula[i].Video = parteDoLink[1];
                    }

                    else if (aula[i].Video.Contains("youtu.be"))
                    {
                        string quebraDeLink = aula[i].Video;

                        string[] parteDoLink = quebraDeLink.Split("youtu.be/");

                        aula[i].Video = parteDoLink[1];
                    }
                }
            }

            return aula;
        }
    }
}
