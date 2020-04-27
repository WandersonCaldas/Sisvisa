using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISVISA.Core.Models;
using SISVISA.Core.Repository;

namespace SISVISA.Core.Regra
{
    public class TermoRegra
    {
        private TermoRepository _repository = new TermoRepository();
        public List<Termo> ListarTermos()
        {
            return _repository.ListarTermos();
        }
        
        public Termo AlterarTermo(Termo obj)
        {
            Termo retorno = new Termo();

            if(_repository.ListarTermos().Where(x => x.txt_sigla.Trim() == obj.txt_sigla.Trim() && x.cod_termo != obj.cod_termo).Count() > 0)
            {
                retorno.status = Response.ResponseStatus.FALHA.Texto;
                retorno.mensagem = Mensagem.MN002.TextoFormatado("TERMO");
                return retorno;
            }

            return _repository.AlterarTermo(obj);
        }

        public Termo IncluirTermo(Termo obj)
        {
            Termo retorno = new Termo();

            if (_repository.ListarTermos().Where(x => x.txt_sigla.Trim() == obj.txt_sigla.Trim()).Count() > 0)
            {
                retorno.status = Response.ResponseStatus.FALHA.Texto;
                retorno.mensagem = Mensagem.MN002.TextoFormatado("TERMO");
                return retorno;
            }

            return _repository.IncluirTermo(obj);
        }
    }
}
