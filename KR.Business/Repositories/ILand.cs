using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Business.Repositories
{
    public interface ILand<T>
    {
        IEnumerable<T> GetList();

        IEnumerable<T> GetListForUser(int userId);

        T GetbyId(int id);

        int Edit(T item);

        T Delete(int id);

        void Save(T item);
    }
}
