using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;



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
            aluno.IdAluno =listaAlunos.Count + 1;
            listaAlunos.Add(aluno);
            return aluno;
        }

        public void Editar(Aluno aluno)
        {
            int posicao = listaAlunos.FindIndex(e => e.IdAluno == aluno.IdAluno);
            listaAlunos[posicao] = aluno;
        }

        public void Remover(Aluno aluno)
        {
            int posicao = listaAlunos.FindIndex(e => e.IdAluno == aluno.IdAluno);
            listaAlunos.RemoveAt(posicao);
        }

        public Aluno Obter(Func<Aluno, bool> where)
        {
            return listaAlunos.Where(where).FirstOrDefault();
        }

        public List<Aluno> ObterTodos()
        {
            return listaAlunos;
        }

    }
}
