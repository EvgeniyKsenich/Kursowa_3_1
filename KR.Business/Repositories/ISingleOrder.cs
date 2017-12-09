using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Business.Repositories
{
    public interface ISingleOrder<T>
    {
        T GetbyId(int id);
    }
}
