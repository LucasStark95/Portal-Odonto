using System;
using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;
using Model.Models.Exceptions;

namespace Negocio.Business
{
    public class GerenciadorProfessor
    {
        private RepositorioProfessor proPersistencia;

        public GerenciadorProfessor()
        {
            proPersistencia = new RepositorioProfessor();
        }

        public Professor Adicionar(Professor professor)
        {
            try {
                proPersistencia.Adicionar(professor);
                return professor;
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Editar(Professor professor)
        {
            try
            {
                proPersistencia.Editar(professor);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Remover(Professor professor)
        {
            try
            {
                proPersistencia.Remover(professor);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public Professor Obter(int id)
        {
            try
            {
                return proPersistencia.Obter(e => e.IdProfessor == id);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public List<Professor> ObterTodos()
        {
            try
            {
                return proPersistencia.ObterTodos();
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

    }
}
