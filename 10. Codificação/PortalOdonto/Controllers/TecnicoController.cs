﻿using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using Model.Models.Exceptions;
using System;
using System.Collections.Generic;
using PortalOdonto.Util;


namespace PortalOdonto.Controllers
{
    [Authenticated]
    [CustomAuthorize(NivelAcesso = Util.TipoUsuario.TECNICO)]
    public class TecnicoController : Controller
    {

        private GerenciadorTriagem triagemGerenciador;
        private GerenciadorUsuario usuarioGerenciadora;
        private GerenciadorTriagem triagem;
        private GerenciadorPaciente paciente;
        private GerenciadorConsulta consulta;
        


        public TecnicoController()
        {

            usuarioGerenciadora = new GerenciadorUsuario();
            triagemGerenciador = new GerenciadorTriagem();
            triagem = new GerenciadorTriagem();
            paciente = new GerenciadorPaciente();
            consulta = new GerenciadorConsulta();

        }

        // GET: Tecnico
        
        public ActionResult Index()
        {
            return View();
        }


        // ============================ Triagem =========================================== //

       
        public ActionResult CadastrarTriagem()
        {
           Paciente p = new Paciente();
           ViewBag.Sexo = new SelectList(p.tipoSexo);
           ViewBag.EstadoCivil = new SelectList(p.tipoEstadoCivil);
           return View();
        }

        
        [HttpPost]
        public ActionResult CadastrarTriagem(FormCollection triagemD)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Triagem tria = new Triagem();                   
                    TryUpdateModel<Triagem>(tria, triagemD.ToValueProvider());
                    Paciente pac = tria.Paciente;
                    paciente.Adicionar(pac);
                    triagemGerenciador.Adicionar(tria);                 
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

        //GET: Triagem
        public ActionResult EditarTriagem(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Triagem triagem = triagemGerenciador.Obter(id);
                    if (triagem != null)
                        return View(triagem);
                }
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
            return View();

        }

        // POST: Triagem
        [HttpPost]
        public ActionResult EditarTriagem(int id, Triagem triagem)
        {
            try
            {
                triagemGerenciador.Editar(triagem);
                return RedirectToAction("Index");

            }
            catch (ControllerException e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a acão", e);
            }
        }		


       // ============================ Paciente =========================================== //

        public ActionResult ListarPacientes()
        {
            List<Triagem> triagem = triagemGerenciador.ObterTodos();
            if (triagem == null || triagem.Count == 0)
                triagem = null;
            return View(triagem);
        }

          //GET: Visualizar Paciente AINDA SERÁ ANALISADO SE É UTIL
        public ActionResult VisualizarPaciente(int? id)
        {
                Triagem triagem = triagemGerenciador.Obter(id);
                    return View(triagem);
        }   
        // ============================ Perfil =========================================== //

        // GET: Tecnico/EditarPerfil/
        public ActionResult EditarPerfil()
        {
            try
            {

                Usuario tec = SessionHelper.Get(SessionKey.USUARIO) as Usuario;
                if (tec != null)
                    return View(tec);

                return RedirectToAction("Index");
            }
            catch (ControllerException e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a acão", e);
            }

        }

        // POST: Te
        [HttpPost]
        public ActionResult EditarPerfil(Usuario tec)
        {
            try
            {
                usuarioGerenciadora.Editar(tec);
                return RedirectToAction("Index");

            }
            catch (ControllerException e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a acão", e);
            }
        }

        public ActionResult VisualizarPerfil()
        {
            try
            {
                Usuario user = SessionHelper.Get(SessionKey.USUARIO) as Usuario;
                if (user != null)
                    return View(user);
            }
            catch (ControllerException e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a acão", e);
            }
            return RedirectToAction("Index");
        }

        // ============================ Consulta =========================================== //
        //PRECISA DO ALUNO PRA FAZER ESSA PARTE
        public ActionResult CadastrarConsulta()
        {
            return View();
        }

        // POST: Tecnico/CadastroPaciente

        
        [HttpPost]
        public ActionResult CadastrarConsulta(Consulta_M con)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    consulta.Adicionar(con);
                    return RedirectToAction("Index");
                }
            }
            catch (ControllerException e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a acão", e);
            }
            return View();
        }        

        
        public ActionResult VisualizarConsulta(int id)
        {
            return View();
        }

        public ActionResult VisualizarConsultas()
        {
            return View();
        }

        // ============================ Aréa a ser debatida =========================================== //

        //NÃO PODE HAVER REMOÇÃO
        // GET: Tecnico/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tecnico/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch (ControllerException e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a acão", e);
            }
        }
    }
}

