using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using PortalOdonto.Util;
namespace PortalOdonto.Controllers
{

    [Authenticated]
    [CustomAuthorize(NivelAcesso = Util.TipoUsuario.ADMINISTRADOR, MetodoAcao = "Login", Controladora = "Usuario")]
    public class AdministradorController : Controller
    {
        
        private GerenciadorUsuario usuarioGerenciador;
        // GET: Usuario
        public AdministradorController()
        {           
            usuarioGerenciador = new GerenciadorUsuario();
        }

        
        public ActionResult Index()
        {
            List<Usuario> usuarios = usuarioGerenciador.ObterTodos();
            if (usuarios == null || usuarios.Count == 0)
                usuarios = null;
            return View(usuarios);
        }

       
        public ActionResult Details (int? id)
        {
            if (id.HasValue)
            {
                Usuario user = usuarioGerenciador.Obter(id);
                if (user != null)
                    return View(user);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection dadosForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    Usuario u = new Usuario();
                    TryUpdateModel<Usuario>(u, dadosForm.ToValueProvider());
                    if (!usuarioGerenciador.BuscarMatricula(u.MatriculaUsuario))
                    {
                        usuarioGerenciador.Adicionar(u);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Matricula já existente.");
                    }
                    
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                //implementar uma menssagem de erro
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Usuario user = usuarioGerenciador.Obter(id);
                if (user!= null)
                    return View(user);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(int id, Usuario user)
        {
            try
            {
                usuarioGerenciador.Editar(user);
                return RedirectToAction("Index");
                
            }
            catch
            {
                //TODO
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Usuario user = usuarioGerenciador.Obter(id);
                if (user!= null)
                    return View(user);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

       
        [HttpPost]
        public ActionResult Delete(int id, Usuario user)
        {
            try
            {
                usuarioGerenciador.Remover(usuarioGerenciador.Obter(id));
                return RedirectToAction("Index");
            }
            catch
            {
                
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Buscar(int? matricula)
        {
            List<Usuario> usuarios = usuarioGerenciador.Buscar(matricula);
            if (usuarios == null)
                usuarios = null;

            return View("Index", usuarios);
        }
    }
}
