﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Versoes.Entities;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Repositories
{
    public class ProjetoRepository : RepositoryBase<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Projeto>> GetAllProjetosAsync() =>
            await FindAll()
                .OrderBy(p => p.Nome)
                .ToListAsync();

        public async Task<Projeto> GetProjetoByIdAsync(long id) =>
            await FindByCondition(p => p.Id.Equals(id))
                .FirstOrDefaultAsync();
    }
}
