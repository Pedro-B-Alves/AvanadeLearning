using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Interfaces
{
    public interface ICursandoRepository : IBaseRepository<Cursando>
    {
        Cursando BuscarPorIdUsuario(int id);
    }
}
