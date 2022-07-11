using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAvenida.Dapper
{
    public sealed class Unidade : IUnidade
    {
        private readonly Conexao _conexao;

        public Unidade(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void BeginTransaction()
        {
            _conexao.Transaction = _conexao.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _conexao.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _conexao.Transaction.Rollback();
            Dispose();
        }

        public void Dispose() => _conexao.Transaction?.Dispose();
    }

}
