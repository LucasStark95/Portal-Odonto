using System;
using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;
using Model.Models.Exceptions;

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
            try
            {
                pacPersistencia.Adicionar(paciente);
                return paciente;
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Editar(Paciente paciente)
        {
            try
            {
                pacPersistencia.Editar(paciente);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Remover(Paciente paciente)
        {
            try
            {
                pacPersistencia.Remover(paciente);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public Paciente Obter(int? id)
        {
            try
            {
                return pacPersistencia.Obter(e => e.IdPaciente == id);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public List<Paciente> ObterTodos()
        {
            try
            {
                return pacPersistencia.ObterTodos();
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }
        }

    }
}
