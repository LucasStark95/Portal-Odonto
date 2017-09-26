using System;
using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;
using Model.Models.Exceptions;

namespace Negocio.Business
{
    public class GerenciadorProntuario
    {
        private RepositorioProntuario proPersistencia;

        public GerenciadorProntuario()
        {
            proPersistencia = new RepositorioProntuario();
        }

        public Prontuario Adicionar(Prontuario prontuario)
        {
            try {
                proPersistencia.Adicionar(prontuario);
                return prontuario;
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }
            
        }

        public Prontuario Obter(int id)
        {
            try
            {
                return proPersistencia.Obter(e => e.IdProntuario == id);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }
            
        }

        public List<Prontuario> ObterTodos()
        {
            try
            {
                return proPersistencia.ObterTodos();
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }
            
        }
    }
}
