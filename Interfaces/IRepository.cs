using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroSeries.Interfaces
{
    interface IRepository<T>
    {
        List<T> List();
        T ReturnById(int Id);
        void Insert(T entity);
        void Delete(int Id);
        void Update(int Id, T entity);
        int ProximoId();
    }
}
