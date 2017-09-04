using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistence;

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
            aluPersistencia.Adicionar(aluno);
            return aluno;
        }

        public void Editar(Aluno aluno)
        {
            aluPersistencia.Editar(aluno);
        }

        public void Remover(Aluno aluno)
        {
            aluPersistencia.Remover(aluno);
        }

        public Aluno Obter(int id)
        {
            return aluPersistencia.Obter(e => e.IdAluno == id);
        }

        public List<Aluno> ObterTodos()
        {
            return aluPersistencia.ObterTodos();
        }
    }
}
