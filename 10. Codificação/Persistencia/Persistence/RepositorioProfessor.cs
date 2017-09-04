using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;


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
            professor.MatriculaUsuario = listaProfessores.Count + 1;
            listaProfessores.Add(professor);
            return professor;
        }

        public void Editar(Professor professor)
        {
            int posicao = listaProfessores.FindIndex(e => e.MatriculaUsuario == professor.MatriculaUsuario);
            listaProfessores[posicao] =professor;
        }

        public void Remover(Professor professor)
        {
            int posicao = listaProfessores.FindIndex(e => e.MatriculaUsuario == professor.MatriculaUsuario);
            listaProfessores.RemoveAt(posicao);
        }

        public Professor Obter(Func<Professor, bool> where)
        {
            return listaProfessores.Where(where).FirstOrDefault();
        }

        public List<Professor> ObterTodos()
        {
            return listaProfessores;
        }
    }
}
