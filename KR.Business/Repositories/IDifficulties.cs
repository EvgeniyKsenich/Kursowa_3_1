using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Business.Repositories
{
    public interface IDifficulties<T>
    {
        int Save(int orderId, int DifficultsId);

        T Remove(int orderId, int DifficultsId);
    }
}
