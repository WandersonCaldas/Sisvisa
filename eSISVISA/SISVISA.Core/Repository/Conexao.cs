using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SISVISA.Core.Repository
{
    public class Conexao
    {
        private static Conexao s_objDBConnect;
        private static SqlConnection s_objConnection;
        private bool disposed = false;

        private SqlTransaction transacaoUnica;
        private int numeroTransacoes = 0;

        protected Conexao()
        {
            s_objConnection = new SqlConnection();
            s_objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            s_objConnection.Open();
        }

        public static Conexao GetInstance()
        {
            if (s_objDBConnect == null)
                s_objDBConnect = new Conexao();

            return s_objDBConnect;
        }

        public SqlConnection GetConnection
        {
            get
            {
                return s_objConnection;
            }
        }

        public SqlTransaction GetTransaction
        {
            get
            {
                return transacaoUnica;
            }
        }

        public SqlTransaction BeginTrans(SqlConnection conexao)
        {
            if (transacaoUnica == null)
            {
                try
                {
                    transacaoUnica = conexao.BeginTransaction(IsolationLevel.ReadCommitted);

                    numeroTransacoes = 1;
                }
                catch (Exception ex)
                {
                }
            }
            else
                numeroTransacoes = numeroTransacoes + 1;

            return transacaoUnica;
        }

        public void CommitTrans()
        {
            try
            {
                if ((numeroTransacoes > 0))
                    numeroTransacoes = numeroTransacoes - 1;
                if (numeroTransacoes == 0)
                {
                    transacaoUnica.Commit();
                    transacaoUnica = null;
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void RollbackTrans()
        {
            try
            {
                if (transacaoUnica != null)
                    transacaoUnica.Rollback();
                numeroTransacoes = 0;
                transacaoUnica = null;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
