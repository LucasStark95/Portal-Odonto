
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;

namespace PortalOdonto.Controllers
{
    public class TecnicoController : Controller
    {
        private GerenciadorTriagem triagem;
        private GerenciadorPaciente paciente;
        private GerenciadorConsulta consulta;

        public TecnicoController()
        {
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
        public ActionResult CadastrarTriagem(Triagem tria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    triagem.Adicionar(tria);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                //Tratamento de exceção para controladoras
            }
            return View();
        }


        // ============================ Paciente =========================================== //

        // GET: Tecnico/CadastroPaciente
        public ActionResult CadastrarPaciente()
        {
            return View();
        }

        // POST: Tecnico/CadastroPaciente
        [HttpPost]
        public ActionResult CadastrarPaciente(Paciente pac)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    paciente.Adicionar(pac);
                    return RedirectToAction("CadastrarTriagem");
                }
            }
            catch
            {
                //Tratamento de exceção para controladoras
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
               Paciente pac =  paciente.Obter(id);
                if (paciente != null)
                    return View(pac);
          
            }
            return RedirectToAction("index");
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
            catch
            {
                //Tratamento de exceção para controladoras
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
            catch
            {
                return View();
            }
        }
    }
}
