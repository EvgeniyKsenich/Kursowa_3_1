using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Business.Repositories
{
    public interface IZakaz<T>
    {
        IEnumerable<T> GetList();

        T Save(T item);

        T Edit(T item);

        T Get(int id);
    }
}
