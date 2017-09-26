using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Model.Models.Exceptions;


namespace Persistencia.Persistence
{
    public class RepositorioPaciente
    {
        private static List<Paciente> listaPacientes;

        static RepositorioPaciente()
        {
            listaPacientes = new List<Paciente>();
        }

        public Paciente Adicionar(Paciente paciente)
        {
            try {
                paciente.IdPaciente = listaPacientes.Count + 1;
                listaPacientes.Add(paciente);
                return paciente;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public void Editar(Paciente paciente)
        {
            try
            {
                int posicao = listaPacientes.FindIndex(e => e.IdPaciente == paciente.IdPaciente);
                listaPacientes[posicao] = paciente;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public void Remover(Paciente paciente)
        {
            try
            {
                int posicao = listaPacientes.FindIndex(e => e.IdPaciente == paciente.IdPaciente);
                listaPacientes.RemoveAt(posicao);
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public Paciente Obter(Func<Paciente, bool> where)
        {
            try
            {
                return listaPacientes.Where(where).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public List<Paciente> ObterTodos()
        {
            try
            {
                return listaPacientes;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

    }
}

