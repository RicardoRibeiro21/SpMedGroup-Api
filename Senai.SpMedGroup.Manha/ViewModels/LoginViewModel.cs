using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.Manha.Views
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        public string  Senha { get; set; }
    }
}
