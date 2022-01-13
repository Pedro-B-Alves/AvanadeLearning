using avanadeLearning_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvanadeLearning.Interfaces
{

    public interface IBaseRepository<T> where T : class
    {
        List<T> Listar();

        T BuscarPorId(int id);

        void Cadastrar(T entity);

        void Atualizar(int id, T entity);

        void Deletar(int id);

        //Modulo BuscarPorIdCurso(int id);
    }
}
