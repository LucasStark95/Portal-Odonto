
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using Model.Models.Exceptions;
using System;
using System.Collections.Generic;
using PortalOdonto.Util;


namespace PortalOdonto.Controllers
{
    [Authenticated]
    [CustomAuthorize(NivelAcesso = Util.TipoUsuario.TECNICO, MetodoAcao = "Login", Controladora = "Usuario")]
    public class TecnicoController : Controller
    {

        private GerenciadorTriagem triagemGerenciador;
        private GerenciadorTecnico tecnicoGerenciador;
        private GerenciadorTriagem triagem;
        private GerenciadorPaciente paciente;
        private GerenciadorConsulta consulta;     


        public TecnicoController()
        {

            tecnicoGerenciador = new GerenciadorTecnico();
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
            if (id.HasValue)
            {
                Triagem triagem = triagemGerenciador.Obter(id);
                if (triagem != null)
                    return View(triagem);
            }
            return RedirectToAction("Index");
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
            //if (id.HasValue)
           // {
                Triagem triagem = triagemGerenciador.Obter(id);
                //if (triagem != null)
                    return View(triagem);
           // }
            //return RedirectToAction("index");
        }   
        // ============================ Perfil =========================================== //

        // GET: Tecnico/Perfil/
        public ActionResult CadastarTecnico()
        {
            return View();
        }

        public ActionResult CadastrarTecnico(Tecnico t)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tecnicoGerenciador.Editar(t);
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

        // GET: Tecnico/EditarPerfil/
        public ActionResult EditarPerfil(int? id)
        {
            if (id.HasValue)
            {
                Tecnico tec = tecnicoGerenciador.Obter(id);
                if (tec != null)
                    return View(tec);
            }
            return RedirectToAction("Index");
        }

        // POST: Te
        [HttpPost]
        public ActionResult EditarPerfil(int id, Tecnico tec)
        {
            try
            {
                tecnicoGerenciador.Editar(tec);
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

        // ============================ Consulta =========================================== //

        
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

        //Pode haver remoção?
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
