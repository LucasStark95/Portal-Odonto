using System;
using System.Collections.Generic;
using System.Linq;
using Model.Models;
using Model.Models.Exceptions;



namespace Persistencia.Persistence
{
    public class RepositorioAluno
    {
        private static List<Aluno> listaAlunos;

        static RepositorioAluno()
        {
            listaAlunos = new List<Aluno>();
        }

        public Aluno Adicionar(Aluno aluno)
        {
            try
            {
                aluno.IdAluno = listaAlunos.Count + 1;
                listaAlunos.Add(aluno);
                return aluno;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public void Editar(Aluno aluno)
        {
            try {
                int posicao = listaAlunos.FindIndex(e => e.IdAluno == aluno.IdAluno);
                listaAlunos[posicao] = aluno;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public void Remover(Aluno aluno)
        {
            try {
                int posicao = listaAlunos.FindIndex(e => e.IdAluno == aluno.IdAluno);
                listaAlunos.RemoveAt(posicao);
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public Aluno Obter(Func<Aluno, bool> where)
        {
            try
            {
                return listaAlunos.Where(where).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public List<Aluno> ObterTodos()
        {
            try
            {
                return listaAlunos;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

    }
}
