using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teste_Clinica.Models.BD;

namespace Teste_Clinica.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Consulta()
        {
            ClienteBD clienteBD = new ClienteBD();
            
            return View(clienteBD.ListaClientes());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }
    }
}