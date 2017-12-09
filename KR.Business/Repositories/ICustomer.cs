using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Business.Repositories
{
    public interface ICustomer<T>
    {
        IEnumerable<T> GetList();

        IEnumerable<T> GetList(string name, string surname, string age);

        T GetbyId(int id);

        int Edit(T item);

        T Delete(int id);

        void Save(T item);
    }
}
