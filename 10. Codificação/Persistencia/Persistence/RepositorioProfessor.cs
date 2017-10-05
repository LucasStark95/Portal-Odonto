using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Model.Models.Exceptions;


namespace Persistencia.Persistence
{
    public class RepositorioProfessor
    {
        private static List<Professor> listaProfessores;

        static RepositorioProfessor()
        {
            listaProfessores = new List<Professor>();
        }

        public Professor Adicionar(Professor professor)
        {
            try {
                professor.MatriculaUsuario = listaProfessores.Count + 1;
                listaProfessores.Add(professor);
                return professor;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public void Editar(Professor professor)
        {
            try
            {
                int posicao = listaProfessores.FindIndex(e => e.MatriculaUsuario == professor.MatriculaUsuario);
                listaProfessores[posicao] = professor;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public void Remover(Professor professor)
        {
            try {
                int posicao = listaProfessores.FindIndex(e => e.MatriculaUsuario == professor.MatriculaUsuario);
                listaProfessores.RemoveAt(posicao);
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public Professor Obter(Func<Professor, bool> where)
        {
            try
            {
                return listaProfessores.Where(where).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public List<Professor> ObterTodos()
        {
            try
            {
                return listaProfessores;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }
    }
}
