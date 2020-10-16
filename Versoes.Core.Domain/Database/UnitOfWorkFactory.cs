using Versoes.Entities;

namespace Versoes.Core.Domain.Database
{
    public class UnitOfWorkFactory : IUnitOfWork
    {
        public static readonly UnitOfWorkFactory Default = new UnitOfWorkFactory();

        //public IUnitOfWork GetUnitOfWork(string context = "")
        //{

        //}

        //
        //protected virtual IUnitOfWork GetDatabaseUnitOfWork()
        //{
        //    //var connection = GetConnection();

        //    IUnitOfWork unitOfWork = new RepositoryContext();

        //    return unitOfWork;
        //}

        public void Commit()
        {
            throw new System.NotImplementedException();
        }
    }
}
