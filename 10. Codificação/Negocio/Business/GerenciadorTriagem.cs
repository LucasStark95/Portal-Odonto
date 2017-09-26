using System;
using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;
using Model.Models.Exceptions;

namespace Negocio.Business
{
    public class GerenciadorTriagem
    {
        private RepositorioTriagem triPersistencia;

        public GerenciadorTriagem()
        {
            triPersistencia = new RepositorioTriagem();
        }

        public Triagem Adicionar(Triagem triagem)
        {
            try
            {
                triPersistencia.Adicionar(triagem);
                return triagem;
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }
           
        }

        public void Editar(Triagem triagem)
        {
            try
            {
                triPersistencia.Editar(triagem);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }
           
        }

        public void Remover(Triagem triagem)
        {
            try
            {
                triPersistencia.Remover(triagem);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }
            
        }

        public Triagem Obter(int id)
        {
            try
            {
                return triPersistencia.Obter(e => e.IdTriagem == id);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }
         
        }

        public List<Triagem> ObterTodos()
        {
            try
            {
                return triPersistencia.ObterTodos();
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }
          
        }
    }
}
