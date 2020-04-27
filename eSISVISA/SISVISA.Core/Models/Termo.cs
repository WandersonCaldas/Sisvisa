using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISVISA.Core.Models
{
    public class Termo
    {
        [Key]
        public int cod_termo { get; set; }

        [Display(Name = "Sigla")]
        [Required]
        public string txt_sigla { get; set; }

        [Display(Name = "Descrição")]        
        [Required]
        public string txt_descricao { get; set; }

        [Display(Name = "Observação")]
        public string txt_observacao { get; set; }

        [Display(Name = "Ativo")]
        public bool cod_ativo { get; set; }

        [NotMapped]
        public string status { get; set; }

        [NotMapped]
        public string mensagem { get; set; }
    }
}
