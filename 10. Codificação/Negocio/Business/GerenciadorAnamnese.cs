using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;
using Model.Models.Exceptions;
using System;

namespace Negocio.Business
{
    public class GerenciadorAnamnese
    {
        private RepositorioAnamnese anaPersistencia;

        public GerenciadorAnamnese()
        {
            anaPersistencia = new RepositorioAnamnese();
        }

        public Anamnese Adicionar(Anamnese anamnese)
        {
            try
            {
                anaPersistencia.Adicionar(anamnese);
                return anamnese;
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Editar(Anamnese anamnese)
        {
            try
            {
                anaPersistencia.Editar(anamnese);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Remover(Anamnese anamnese)
        {
            try
            {
                anaPersistencia.Remover(anamnese);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public Anamnese Obter(int id)
        {
            try
            {
                return anaPersistencia.Obter(e => e.IdAnamnese == id);
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public List<Anamnese> ObterTodos()
        {
            try
            {
                return anaPersistencia.ObterTodos();
            }
            catch (Exception e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }
    }
}
