﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Repositories
{
    public interface IProjetoRepository : IRepositoryBase<Projeto>
    {
        Task<IEnumerable<Projeto>> GetAllProjetosAsync();
        Task<Projeto> GetProjetoByIdAsync(long id);
    }
}