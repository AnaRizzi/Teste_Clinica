﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Teste_Clinica.Models
{
    public class Clientes
    {
        [Display(Name="Id do Cliente")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Campo não pode ficar em branco")]
        [StringLength(50, ErrorMessage ="O Nome não pode ter mais de 50 caracteres")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Campo não pode ficar em branco")]
        [StringLength(15, ErrorMessage = "O CPF não pode ter mais de 15 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo não pode ficar em branco")]
        [StringLength(60, ErrorMessage = "O Endereço não pode ter mais de 60 caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo não pode ficar em branco")]
        [StringLength(20, ErrorMessage = "O Telefone não pode ter mais de 20 caracteres")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo não pode ficar em branco")]
        [StringLength(50, ErrorMessage = "O Email não pode ter mais de 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$", ErrorMessage = "Formato do E-mail Inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo não pode ficar em branco")]
        [StringLength(10, ErrorMessage = "O Sexo não pode ter mais de 10 caracteres")]
        public string Sexo { get; set; }

        //public List<SelectListItem> ListaSexo = new List<SelectListItem>();

        //public List<SelectListItem> GerarListaSexo()
        //{
        //    ListaSexo.Add(new SelectListItem { Text = "Feminino", Value = "Feminino", Selected = true });
        //    ListaSexo.Add(new SelectListItem { Text = "Masculino", Value = "Masculino" });
        //    return ListaSexo;
        //}


    }
}