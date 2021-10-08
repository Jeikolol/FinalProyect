using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject.data.Repository
{
    interface IGenericRepository<T> where T:class
    {
        List<T> Obtener();
        T ObtenerDetalle(int id);
        T Actualizar(T entidad);
        T Eliminar(T entidad);
        T Agregar(T entidad);
    }
}
