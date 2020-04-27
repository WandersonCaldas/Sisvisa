using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISVISA.Core.Models;
using Dapper;
using System.Data.SqlClient;

namespace SISVISA.Core.Repository
{
    public class TermoRepository
    {
        private SqlConnection _db = Conexao.GetInstance().GetConnection;

        public List<Termo> ListarTermos()
        {            
            return _db.Query<Termo>("SELECT * FROM tbl_termo").ToList();            
        }

        public Termo AlterarTermo(Termo obj)
        {
            Termo retorno = new Termo();
            try
            {
                var query = "UPDATE tbl_termo SET txt_sigla = @txt_sigla, txt_descricao = @txt_descricao, " +
                            " txt_observacao = @txt_observacao, cod_ativo = @cod_ativo WHERE cod_termo = " + obj.cod_termo;
                _db.Execute(query, obj);
                retorno.status = Response.ResponseStatus.SUCESSO.Texto;
            } catch (Exception ex)
            {
                retorno.status = Response.ResponseStatus.FALHA.Texto;
                retorno.mensagem = Erro.ErroOperacao(ex);
            }
            return retorno;
        }

        public Termo IncluirTermo(Termo obj)
        {
            Termo retorno = new Termo();
            try
            {
                var query = "INSERT INTO tbl_termo(txt_sigla, txt_descricao, txt_observacao, cod_ativo) " +
                            " VALUES(@txt_sigla, @txt_descricao, @txt_observacao, @cod_ativo)";
                _db.Execute(query, obj);
                retorno.status = Response.ResponseStatus.SUCESSO.Texto;
            }
            catch (Exception ex)
            {
                retorno.status = Response.ResponseStatus.FALHA.Texto;
                retorno.mensagem = Erro.ErroOperacao(ex);
            }
            return retorno;
        }
    }
}
