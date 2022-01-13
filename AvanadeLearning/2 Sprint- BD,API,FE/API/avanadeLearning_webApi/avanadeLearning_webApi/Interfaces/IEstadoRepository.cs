﻿using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Interfaces
{
    public interface IAulaModuloRepository : IBaseRepository<AulaModulo>
    {
        AulaModulo BuscarPorIdModulo(int id);
    }
}
