using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorPaciente
    {
        private RepositorioPaciente pacPersistencia;

        public GerenciadorPaciente()
        {
            pacPersistencia = new RepositorioPaciente();
        }

        public Paciente Adicionar(Paciente paciente)
        {
            pacPersistencia.Adicionar(paciente);
            return paciente;
        }

        public void Editar(Paciente paciente)
        {
            pacPersistencia.Editar(paciente);
        }

        public void Remover(Paciente paciente)
        {
            pacPersistencia.Remover(paciente);
        }

        public Paciente Obter(int? id)
        {
            return pacPersistencia.Obter(e => e.IdPaciente == id);
        }

        public List<Paciente> ObterTodos()
        {
            return pacPersistencia.ObterTodos();
        }

    }
}
