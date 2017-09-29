using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;
using Model.Models.Exceptions;
using System;

namespace Negocio.Business
{
    public class GerenciadorAluno
    {
        private RepositorioAluno aluPersistencia;

        public GerenciadorAluno()
        {
            aluPersistencia = new RepositorioAluno();
        }

        public Aluno Adicionar(Aluno aluno)
        {
            try
            {
                aluPersistencia.Adicionar(aluno);
                return aluno;
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Editar(Aluno aluno)
        {
            try
            {
                aluPersistencia.Editar(aluno);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Remover(Aluno aluno)
        {
            try
            {
                aluPersistencia.Remover(aluno);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public Aluno Obter(int id)
        {
            try
            {
                return aluPersistencia.Obter(e => e.IdAluno == id);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public List<Aluno> ObterTodos()
        {
            try
            {
                return aluPersistencia.ObterTodos();
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }
    }
}
