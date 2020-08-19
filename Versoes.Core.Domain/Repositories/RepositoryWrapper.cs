﻿using System.Threading.Tasks;
using Versoes.Entities;

namespace Versoes.Core.Domain.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext repositoryContext;
        private ISetorRepository setorRepository;
        private IUsuarioRepository usuarioRepository;
        private IProjetoRepository projetoRepository;
        private IRequisitoRepository requisitoRepository;
        private IBugRepository bugRepository;

        public ISetorRepository Setor => setorRepository ?? (setorRepository = new SetorRepository(repositoryContext));
        public IUsuarioRepository Usuario => usuarioRepository ?? (usuarioRepository = new UsuarioRepository(repositoryContext));
        public IProjetoRepository Projeto => projetoRepository ?? (projetoRepository = new ProjetoRepository(repositoryContext));
        public IRequisitoRepository Requisito => requisitoRepository ?? (requisitoRepository = new RequisitoRepository(repositoryContext));
        public IBugRepository Bug => bugRepository ?? (bugRepository = new BugRepository(repositoryContext));

        public RepositoryWrapper(RepositoryContext repositoryContext) => this.repositoryContext = repositoryContext;

        public async Task SaveAsync() => await repositoryContext.SaveChangesAsync();
    }
}
