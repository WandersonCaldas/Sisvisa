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
    public class UsuarioRepository
    {
        private SqlConnection _db = Conexao.GetInstance().GetConnection;

        public List<Usuario> ListarUsuarios()
        {            
            return _db.Query<Usuario>("SELECT * FROM tbl_usuario").ToList();            
        }

        public Usuario AlterarUsuario(Usuario obj)
        {
            Usuario retorno = new Usuario();
            try
            {
                var query = "UPDATE tbl_usuario SET txt_usuario = @txt_usuario, txt_email = @txt_email, " +
                            " txt_login = @txt_login, cod_ativo = @cod_ativo WHERE cod_usuario = " + obj.cod_usuario;
                _db.Execute(query, obj);
                retorno.status = Response.ResponseStatus.SUCESSO.Texto;
            } catch (Exception ex)
            {
                retorno.status = Response.ResponseStatus.FALHA.Texto;
                retorno.mensagem = Erro.ErroOperacao(ex);
            }
            return retorno;
        }

        public Usuario IncluirUsuario(Usuario obj)
        {
            Usuario retorno = new Usuario();
            try
            {
                var query = "INSERT INTO tbl_usuario(txt_usuario, txt_email, txt_login, txt_senha, cod_ativo) " +
                            " VALUES(@txt_usuario, @txt_email, @txt_login, @txt_senha, @cod_ativo)";
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
