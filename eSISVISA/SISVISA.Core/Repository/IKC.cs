using SISVISA.Core.Models;
using SISVISA.Core.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISVISA.Core.Repository
{
    public class IKC
    {
        public static DataTable RetornaDataTable(string sql)
        {
            DataTable retorno = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(sql, Conexao.GetInstance().GetConnection))
            {
                using (DataTable dt = new DataTable("registros"))
                {
                    da.Fill(dt);

                    retorno = dt;
                }
            }

            return retorno;
        }

        public DataTable RetornaDataTable(string sql, SqlParameter[] parameters)
        {
            DataTable retorno = new DataTable();

            using (SqlCommand cmd = new SqlCommand(sql, Conexao.GetInstance().GetConnection))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable("registros"))
                    {
                        da.Fill(dt);

                        retorno = dt;
                    }
                }
            }


            return retorno;
        }

        public static DataTable RetornaDataTableTrans(string sql)
        {
            DataTable retorno = new DataTable();

            Conexao conexao = Conexao.GetInstance();
            SqlTransaction transacao = conexao.BeginTrans(conexao.GetConnection);

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conexao.GetConnection;
                cmd.Transaction = transacao;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable("registros"))
                    {
                        da.Fill(dt);

                        retorno = dt;
                    }
                }
            }
            conexao.CommitTrans();

            return retorno;
        }

        public static Result ExecuteNonQuery(string sql)
        {
            Result retorno = new Result();

            Conexao conexao = Conexao.GetInstance();
            SqlTransaction transacao = conexao.BeginTrans(conexao.GetConnection);

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexao.GetConnection;
                    cmd.Transaction = transacao;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    retorno.resultado = cmd.ExecuteNonQuery().ToString();
                }

                conexao.CommitTrans();
                retorno.status = ResponseStatus.SUCESSO.Texto;
            }
            catch (Exception ex)
            {
                conexao.RollbackTrans();
                retorno.status = ResponseStatus.SQL_ERROR.Texto;
                retorno.mensagem = Erro.ErroOperacao(ex);
            }

            return retorno;
        }

        public static Result ExecuteNonQuery(SqlCommand sql, SqlParameter[] parameters)
        {
            Result retorno = new Result();

            Conexao conexao = Conexao.GetInstance();
            SqlTransaction transacao = conexao.BeginTrans(conexao.GetConnection);

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Conexao.GetInstance().GetConnection;
                    cmd.Transaction = transacao;
                    cmd.CommandType = sql.CommandType;
                    cmd.CommandText = sql.CommandText;
                    cmd.Parameters.AddRange(parameters);
                    retorno.resultado = cmd.ExecuteNonQuery().ToString(); ;
                }

                conexao.CommitTrans();
                retorno.status = ResponseStatus.SUCESSO.Texto;
            }
            catch (Exception ex)
            {
                conexao.RollbackTrans();
                retorno.status = ResponseStatus.SQL_ERROR.Texto;
                retorno.mensagem = Erro.ErroOperacao(ex);
            }

            return retorno;
        }

        public static Result ExecuteScalar(string sql)
        {
            Result retorno = new Result();

            Conexao conexao = Conexao.GetInstance();
            SqlTransaction transacao = conexao.BeginTrans(conexao.GetConnection);

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Conexao.GetInstance().GetConnection;
                    cmd.Transaction = transacao;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    retorno.resultado = cmd.ExecuteScalar().ToString();
                }

                conexao.CommitTrans();
                retorno.status = ResponseStatus.SUCESSO.Texto;
            }
            catch (Exception ex)
            {
                conexao.RollbackTrans();
                retorno.status = ResponseStatus.SQL_ERROR.Texto;
                retorno.mensagem = Erro.ErroOperacao(ex);
            }

            return retorno;
        }

        public static Result ExecuteScalar(SqlCommand sql, SqlParameter[] parameters)
        {
            Result retorno = new Result();

            Conexao conexao = Conexao.GetInstance();
            SqlTransaction transacao = conexao.BeginTrans(conexao.GetConnection);

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Conexao.GetInstance().GetConnection;
                    cmd.Transaction = transacao;
                    cmd.CommandType = sql.CommandType;
                    cmd.CommandText = sql.CommandText;
                    cmd.Parameters.AddRange(parameters);
                    retorno.resultado = cmd.ExecuteScalar().ToString();
                }

                conexao.CommitTrans();
                retorno.status = ResponseStatus.SUCESSO.Texto;
            }
            catch (Exception ex)
            {
                conexao.RollbackTrans();
                retorno.status = ResponseStatus.SQL_ERROR.Texto;
                retorno.mensagem = Erro.ErroOperacao(ex);
            }

            return retorno;
        }
    }
}
