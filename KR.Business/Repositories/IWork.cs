using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Business.Repositories
{
    public interface IWork<T>
    {
        T Remove(int orderId, int workId);

        int Save(int orderId, T item);
    }
}
