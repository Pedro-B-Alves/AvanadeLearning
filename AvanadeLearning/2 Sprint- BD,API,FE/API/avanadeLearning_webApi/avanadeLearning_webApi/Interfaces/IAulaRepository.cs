using avanadeLearning_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Interfaces
{
    public interface IAulaRepository
    {
        List<Aula> Listar();

        Aula BuscarPorId(int id);

        bool Cadastrar(Aula entity);

        bool Atualizar(int id, Aula entity);

        void Deletar(int id);
    }
}
