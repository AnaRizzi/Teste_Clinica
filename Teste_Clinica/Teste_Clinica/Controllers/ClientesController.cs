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
        Clientes cliente = new Clientes();
        // GET: Clientes
        public ActionResult Consulta()
        {
            ClienteBD clienteBD = new ClienteBD();
            
            return View(clienteBD.ListaClientes());
        }

        public ActionResult Cadastrar()
        {
            //ViewBag.ListaSexo = cliente.GerarListaSexo();
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
            //ViewBag.ListaSexo = cliente.GerarListaSexo();
            return View(clientedigitado);
        }

        public ActionResult Detalhes(int id)
        {
            ClienteBD clienteBD = new ClienteBD();

            return View(clienteBD.Buscar(id));
        }


    }
}