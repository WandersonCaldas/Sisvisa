using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISVISA.Core.Models
{
    public class Menu
    {
        public int cod_menu { get; set; }
        public int nr_nivel { get; set; }
        public int nr_pai { get; set; }
        public string txt_nome { get; set; }
        public string txt_icone { get; set; }
        public int nr_ordem { get; set; }
        public int nr_modulo { get; set; }
        public string txt_acao { get; set; }
        public string txt_controle { get; set; }
        
    }
}
