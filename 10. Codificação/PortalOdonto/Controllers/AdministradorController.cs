using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using PortalOdonto.Util;
using Model.Models.Exceptions;
namespace PortalOdonto.Controllers
{

    [Authenticated]
    [CustomAuthorize(NivelAcesso = Util.TipoUsuario.ADMINISTRADOR)]
    public class AdministradorController : Controller
    {
        
        private GerenciadorUsuario usuarioGerenciador;
        

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
                return View();
            }
            catch (ControllerException e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            catch (Exception e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
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
        public ActionResult Edit(int id, FormCollection user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario aux = new Usuario();
                    TryUpdateModel<Usuario>(aux, user.ToValueProvider());
                    usuarioGerenciador.Editar(aux);
                    return RedirectToAction("Index");
                }
                
                
            }
            catch (ControllerException e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            catch (Exception e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }

            return View();
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

            catch (ControllerException e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            catch (Exception e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }            
        }

        [HttpPost]
        public ActionResult Buscar(string matricula)
        {
            List<Usuario> usuarios = usuarioGerenciador.Buscar(matricula);
            if (usuarios == null)
                usuarios = usuarioGerenciador.ObterTodos();

            return View("Index", usuarios);
        }
    }
}
