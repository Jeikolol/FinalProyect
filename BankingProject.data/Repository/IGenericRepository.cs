using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject.data.Repository
{
    interface IGenericRepository<T> where T:class
    {
        List<T> Get(int id);
        T GetDetail(int id);
        T Update(T entity);
        T Delete(T entity);
        T Insert(T entity);
    }
}
