using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teste_Clinica.Models
{
    public class Login
    {
        [Required (ErrorMessage ="Campo não pode ficar em branco")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Campo não pode ficar em branco")]
        public string Senha { get; set; }

        public static string UsuarioLogado = "";

        public string GetUsuarioLogado()
        {
            return UsuarioLogado;
        }

        public void SetUsuarioLogado(string usuario)
        {
            UsuarioLogado = usuario;
        }
    }
}