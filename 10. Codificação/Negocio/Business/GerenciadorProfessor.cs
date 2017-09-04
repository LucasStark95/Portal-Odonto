using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorProfessor
    {
        private RepositorioProfessor proPersistencia;

        public GerenciadorProfessor()
        {
            proPersistencia = new RepositorioProfessor();
        }

        public Professor Adicionar(Professor professor)
        {
            proPersistencia.Adicionar(professor);
            return professor;
        }

        public void Editar(Professor professor)
        {
            proPersistencia.Editar(professor);
        }

        public void Remover(Professor professor)
        {
            proPersistencia.Remover(professor);
        }

        public Professor Obter(int id)
        {
            return proPersistencia.Obter(e => e.IdProfessor == id);
        }

        public List<Professor> ObterTodos()
        {
            return proPersistencia.ObterTodos();
        }

    }
}
