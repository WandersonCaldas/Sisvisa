using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISVISA.Core.Response
{
    public class ResponseAtivo
    {
        public static readonly ResponseAtivo ATIVO = new ResponseAtivo("1", "ATIVO");
        public static readonly ResponseAtivo INATIVO = new ResponseAtivo("0", "INATIVO");

        private string _codigo;
        private string _txt;

        private ResponseAtivo(string codigo, string txt)
        {
            _codigo = codigo;
            _txt = txt;
        }

        public ResponseAtivo()
        {
        }

        public string Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;
            }
        }

        public string Texto
        {
            get
            {
                return _txt;
            }

            set
            {
                _txt = value;
            }
        }
    }
}
