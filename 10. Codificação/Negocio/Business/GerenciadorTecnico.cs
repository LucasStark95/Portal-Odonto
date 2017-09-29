using System;
using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;
using Model.Models.Exceptions;

namespace Negocio.Business
{
    public class GerenciadorTecnico
    {
        private RepositorioTecnico tecPersistencia;

        public GerenciadorTecnico()
        {
            tecPersistencia = new RepositorioTecnico();
        }

        public Tecnico Adicionar(Tecnico tecnico)
        {
            try
            {
                tecPersistencia.Adicionar(tecnico);
                return tecnico;
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Editar(Tecnico tecnico)
        {
            try
            {
                tecPersistencia.Editar(tecnico);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Remover(Tecnico tecnico)
        {
            try
            {
                tecPersistencia.Remover(tecnico);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public Tecnico Obter(int? id)
        {
            try
            {
                return tecPersistencia.Obter(e => e.IdTecnico == id);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public List<Tecnico> ObterTodos()
        {
            try
            {
                return tecPersistencia.ObterTodos();
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }
    }
}
