using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISVISA.Core.Regra
{
    public class Erro
    {
        public static string ErroOperacao(Exception ex)
        {
            return ex.Source + " - " + ex.Message + " - " + ex.StackTrace;
        }

    }
}
