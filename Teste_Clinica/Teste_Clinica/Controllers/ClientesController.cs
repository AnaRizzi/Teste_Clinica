using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teste_Clinica.Models;
using Teste_Clinica.Models.BD;

namespace Teste_Clinica.Controllers
{
    public class ClientesController : Controller
    {
        Login login = new Login();

        Clientes cliente = new Clientes();
        // GET: Clientes
        public ActionResult Consulta()
        {
            if (login.GetUsuarioLogado() == "")
            {
                return RedirectToAction("Login", "Home").Mensagem("Faça o login antes de acessar o sistema!", "Usuário não encontrado");
            }
            ClienteBD clienteBD = new ClienteBD();
            
            return View(clienteBD.ListaClientes());
        }

        public ActionResult Cadastrar()
        {
            if (login.GetUsuarioLogado() == "")
            {
                return RedirectToAction("Login", "Home").Mensagem("Faça o login antes de acessar o sistema!", "Usuário não encontrado");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Clientes clientedigitado)
        {
            if (ModelState.IsValid)
            {
                ClienteBD clienteBD = new ClienteBD();
                clienteBD.Cadastrar(clientedigitado);
                if (clienteBD.mensagem == "")
                {
                    return RedirectToAction("Consulta", "Clientes").Mensagem("Cliente cadastrado com sucesso!", "Cadastro realizado");
                }
                else
                {
                    return View(clientedigitado).Mensagem(clienteBD.mensagem);
                }
            }
            return View(clientedigitado);
        }

        public ActionResult Detalhes(int id)
        {
            if (login.GetUsuarioLogado() == "")
            {
                return RedirectToAction("Login", "Home").Mensagem("Faça o login antes de acessar o sistema!", "Usuário não encontrado");
            }
            ClienteBD clienteBD = new ClienteBD();

            return View(clienteBD.Buscar(id));
        }

        public ActionResult Excluir(int id)
        {
            if (login.GetUsuarioLogado() == "")
            {
                return RedirectToAction("Login", "Home").Mensagem("Faça o login antes de acessar o sistema!", "Usuário não encontrado");
            }
            ClienteBD clienteBD = new ClienteBD();

            return View(clienteBD.Buscar(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(Clientes cliente)
        {
            ClienteBD clienteBD = new ClienteBD();
            clienteBD.Excluir(cliente.IdCliente);
            if (clienteBD.mensagem == "")
            {
                return RedirectToAction("Consulta", "Clientes").Mensagem("Cliente excluído com sucesso!", "Cliente excluído");
            }

            return View(cliente).Mensagem("Erro ao excluir!" + clienteBD.mensagem, "Erro");
        }

        public ActionResult Editar(int id)
        {
            if (login.GetUsuarioLogado() == "")
            {
                return RedirectToAction("Login", "Home").Mensagem("Faça o login antes de acessar o sistema!", "Usuário não encontrado");
            }
            ClienteBD clienteBD = new ClienteBD();

            return View(clienteBD.Buscar(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Clientes cliente)
        {
            ClienteBD clienteBD = new ClienteBD();
            clienteBD.Editar(cliente);
            if (clienteBD.mensagem == "")
            {
                return RedirectToAction("Consulta", "Clientes").Mensagem("Cliente alterado com sucesso!", "Cliente alterado");
            }

            return View(cliente).Mensagem("Erro ao alterar!" + clienteBD.mensagem, "Erro");
        }
    }
}