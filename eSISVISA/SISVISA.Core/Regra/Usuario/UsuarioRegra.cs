using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISVISA.Core.Models;
using SISVISA.Core.Repository;

namespace SISVISA.Core.Regra
{
    public class UsuarioRegra
    {
        private UsuarioRepository _repository = new UsuarioRepository();
        public List<Usuario> ListarUsuarios()
        {
            return _repository.ListarUsuarios();
        }
        
        public Usuario AlterarUsuario(Usuario obj)
        {
            Usuario retorno = new Usuario();

            if(_repository.ListarUsuarios().Where(x => x.txt_login.Trim() == obj.txt_login.Trim() && x.cod_usuario != obj.cod_usuario).Count() > 0)
            {
                retorno.status = Response.ResponseStatus.FALHA.Texto;
                retorno.mensagem = Mensagem.MN002.TextoFormatado("LOGIN");
                return retorno;
            }

            return _repository.AlterarUsuario(obj);
        }

        public Usuario IncluirUsuario(Usuario obj)
        {
            Usuario retorno = new Usuario();

            if (_repository.ListarUsuarios().Where(x => x.txt_login.Trim() == obj.txt_login.Trim()).Count() > 0)
            {
                retorno.status = Response.ResponseStatus.FALHA.Texto;
                retorno.mensagem = Mensagem.MN002.TextoFormatado("LOGIN");
                return retorno;
            }

            return _repository.IncluirUsuario(obj);
        }
    }
}
