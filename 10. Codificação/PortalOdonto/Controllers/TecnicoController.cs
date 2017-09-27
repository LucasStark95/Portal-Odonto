
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using Model.Models.Exceptions;
using System;

namespace PortalOdonto.Controllers
{
    public class TecnicoController : Controller
    {
        private GerenciadorTriagem triagem;
        private GerenciadorTecnico tecnico;
        private GerenciadorPaciente paciente;
        private GerenciadorConsulta consulta;

        public TecnicoController()
        {
            tecnico = new GerenciadorTecnico();
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

        // GET: Tecnico/CadastroTriagem
        public ActionResult CadastrarTriagem()
        {
            return View();
        }

        // POST: Tecnico/CadastroTriagem
        [HttpPost]
        public ActionResult CadastrarTriagem(Triagem triagemD)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Paciente p = triagemD.Paciente;                    
                    paciente.Adicionar(p);
                    triagem.Adicionar(triagemD);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            return View();
        }


        // ============================ Paciente =========================================== //

        // GET: Tecnico/CadastroPaciente
        public ActionResult CadastrarPaciente()
        {
            return View();
        }
        //Ainda será analisado se esse metodo vai permancer
        // POST: Tecnico/CadastroPaciente
        [HttpPost]
        public ActionResult CadastrarPaciente(Paciente pac)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    paciente.Adicionar(pac);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            return View();
        }

        public ActionResult ListarPacientes()
        {
            return View();
        }

        //Visualizar Paciente
        public ActionResult VisualizarPaciente(int? id)
        {
            if (id.HasValue)
            {
                Paciente pac = paciente.Obter(id);
                if (paciente != null)
                    return View(pac);

            }
            return RedirectToAction("index");
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
                    tecnico.Editar(t);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            return View();
        }

        // GET: Tecnico/EditarPerfil/
        public ActionResult EditarPerfil(int? id)
        {
            if (id.HasValue)
            {
                Tecnico tec = tecnico.Obter(id);
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
                tecnico.Editar(tec);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
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
            catch (Exception e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);
            }
            return View();
        }

        //Visualizar Consulta
        public ActionResult VisualizarConsulta(int id)
        {
            return View();
        }

        //Visualizar Consultas
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
            catch (Exception e)
            {
                throw new ControllerException("Não foi possivél completar a acão", e);

            }
        }
    }
}
