using BankingProject.Data;
using System.Collections.Generic;
using System.Linq;

namespace BankingProject.data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public T Eliminar(T entidad)
        {
            var entidadActualizada = _dbContext.Set<T>().Remove(entidad);
            _dbContext.SaveChanges();
            return entidadActualizada.Entity;
        }

        public List<T> Obtener()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T ObtenerDetalle(int id)
        {
            return this._dbContext.Set<T>().Find(id);
        }

        public T Agregar(T entidad)
        {
            var entidadInsertada = _dbContext.Set<T>().Add(entidad);
            _dbContext.SaveChanges();
            return entidadInsertada.Entity;
        }

        public T Actualizar(T entidad)
        {
            var entidadActualizada= _dbContext.Set<T>().Update(entidad);
            _dbContext.SaveChanges();
            return entidadActualizada.Entity;
        }
    }
}
