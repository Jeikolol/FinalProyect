using BankingProject.Data;
using System.Collections.Generic;

namespace BankingProject.data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public T Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public List<T> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public T GetDetail(int id)
        {
            return this._dbContext.Set<T>().Find(id);
        }

        public T Insert(T entity)
        {
            this._dbContext.Set<T>().Add(entity);
            this._dbContext.SaveChanges();

            throw new System.NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
