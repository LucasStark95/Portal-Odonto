using System;
using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;
using Model.Models.Exceptions;

namespace Negocio.Business
{
    public class GerenciadorConsulta
    {
        private RepositorioConsulta conPersistencia;

        public GerenciadorConsulta()
        {
            conPersistencia = new RepositorioConsulta();
        }

        public Consulta_M Adicionar(Consulta_M consulta)
        {
            try
            {
                conPersistencia.Adicionar(consulta);
                return consulta;
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Editar(Consulta_M consulta)
        {
            try
            {
                conPersistencia.Editar(consulta);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Remover(Consulta_M consulta)
        {
            try
            {
                conPersistencia.Remover(consulta);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public Consulta_M Obter(int id)
        {
            try
            {
                return conPersistencia.Obter(e => e.IdConsulta == id);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public List<Consulta_M> ObterTodos()
        {
            try
            {
                return conPersistencia.ObterTodos();
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

    }
}
