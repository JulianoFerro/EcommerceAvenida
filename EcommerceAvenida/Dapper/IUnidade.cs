using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAvenida.Dapper
{
    public interface IUnidade: IDisposable
        {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
    
}
