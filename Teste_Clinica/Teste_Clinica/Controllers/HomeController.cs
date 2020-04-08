using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teste_Clinica.Models;
using Teste_Clinica.Models.BD;

namespace Teste_Clinica.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                LoginBD verificaLogin = new LoginBD();
                verificaLogin.verificarLogin(login.Usuario, login.Senha);
                if (verificaLogin.T)
                {
                    login.SetUsuarioLogado(login.Usuario);
                    return RedirectToAction("Index", "Sistema").Mensagem("Usuário logado com sucesso!", "Login efetuado");
                }                
                if (verificaLogin.mensagem != "")
                {
                    return View(login).Mensagem(verificaLogin.mensagem);
                }
            }
            return View(login).Mensagem("Erro no acesso ao sistema, verifique o usuário e a senha.");
        }

        public ActionResult Deslogar()
        {
            Login login = new Login();
            login.SetUsuarioLogado("");
            return RedirectToAction("Index", "Home").Mensagem("Usuário deslogado com sucesso", "Usuário deslogado");
        }
    }
}