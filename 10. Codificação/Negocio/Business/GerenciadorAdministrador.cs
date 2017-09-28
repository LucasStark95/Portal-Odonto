using System;
using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;
using Model.Models.Exceptions;

namespace Negocio.Business
{
    public class GerenciadorAdministrador
    {

        private RepositorioAdministrador admPersistencia;

        public GerenciadorAdministrador()
        {
            admPersistencia = new RepositorioAdministrador();
        }

        public Administrador Adicionar(Administrador administrador)
        {
            try
            {
                admPersistencia.Adicionar(administrador);
                return administrador;
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }         
        }

        public void Editar(Administrador administrador)
        {
            try
            {
                admPersistencia.Editar(administrador);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Remover(Administrador administrador)
        {
            try
            {
                admPersistencia.Remover(administrador);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public Administrador Obter(int id)
        {
            try
            {
                return admPersistencia.Obter(e => e.IdAdministrador == id);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }           
        }

        public List<Administrador> ObterTodos()
        {
            try
            {
                return admPersistencia.ObterTodos();
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }
        }
    }
}
