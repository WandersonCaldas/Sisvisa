using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISVISA.Core.Models
{
    public class Usuario
    {
        [Key]
        public int cod_usuario { get; set; }

        [Display(Name = "Nome")]
        [Required]
        public string txt_usuario { get; set; }

        [Display(Name = "E-mail")]        
        [EmailAddress]
        [Required]
        public string txt_email { get; set; }

        [Display(Name = "Login")]
        [Required]
        public string txt_login { get; set; }

        [Display(Name = "Senha")]
        [Required]
        [DataType(DataType.Password)]        
        public string txt_senha { get; set; }
        
        [Display(Name = "Ativo")]
        public bool cod_ativo { get; set; }

        [NotMapped]
        public string status { get; set; }

        [NotMapped]
        public string mensagem { get; set; }
    }
}
