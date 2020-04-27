using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISVISA.Core.Regra
{
    public class Mensagem
    {
        public static readonly Mensagem MN001 = new Mensagem("MN001", "OPERAÇÃO REALIZADA COM SUCESSO.");
        public static readonly Mensagem MN002 = new Mensagem("MN002", "{0} JÁ EXISTE NA BASE DE DADOS.");
        public static readonly Mensagem MN003 = new Mensagem("MN003", "REGISTRO NÃO ENCONTRADO.");
        public static readonly Mensagem MN004 = new Mensagem("MN004", "NENHUM REGISTRO ENCONTRADO");
        public static readonly Mensagem MN005 = new Mensagem("MN005", "CPF INVÁLIDO.");
        public static readonly Mensagem MN006 = new Mensagem("MN006", "CNPJ INVÁLIDO.");
        public static readonly Mensagem MN008 = new Mensagem("MN007", "DATA INVÁLIDA");

        private string _codigo, _txt;
        private Mensagem(string codigo, string txt)
        {
            _codigo = codigo;
            _txt = txt;
        }

        public string Codigo
        {
            get
            {
                return _codigo;
            }
        }

        public string Texto
        {
            get
            {
                return _txt;
            }
        }

        public string TextoFormatado(params string[] Args)
        {
            return string.Format(_txt, Args);
        }
    }
}
