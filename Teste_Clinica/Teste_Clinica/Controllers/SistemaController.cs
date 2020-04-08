using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teste_Clinica.Models;

namespace Teste_Clinica.Controllers
{
    public class SistemaController : Controller
    {
        Login usuario = new Login();

        // GET: Sistema
        public ActionResult Index()
        {
            ViewBag.Usuario = usuario.GetUsuarioLogado();
            return View();
        }
    }
}