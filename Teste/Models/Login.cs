using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teste.Models
{
    /// <summary>
    /// Classe para ser na API para receber o JSO com os dados de login
    /// </summary>
    public class LoginVO
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}