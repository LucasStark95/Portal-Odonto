using System;
using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;
using Model.Models.Exceptions;

namespace Negocio.Business
{
    public class GerenciadorPeriograma
    {
        private RepositorioPeriograma periPersistencia;

        public GerenciadorPeriograma()
        {
            periPersistencia = new RepositorioPeriograma();
        }

        public Periograma Adicionar(Periograma periograma)
        {
            try
            {
                periPersistencia.Adicionar(periograma);
                return periograma;
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Editar(Periograma periograma)
        {
            try
            {
                periPersistencia.Editar(periograma);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public Periograma Obter(int id)
        {
            try
            {
                return periPersistencia.Obter(e => e.IdPeriograma == id);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public List<Periograma> ObterTodos()
        {
            try
            {
                return periPersistencia.ObterTodos();
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }
    }
}
