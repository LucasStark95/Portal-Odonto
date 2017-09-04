using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistence;

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
            triPersistencia.Adicionar(triagem);
            return triagem;
        }

        public void Editar(Triagem triagem)
        {
            triPersistencia.Editar(triagem);
        }

        public void Remover(Triagem triagem)
        {
            triPersistencia.Remover(triagem);
        }

        public Triagem Obter(int id)
        {
            return triPersistencia.Obter(e => e.IdTriagem == id);
        }

        public List<Triagem> ObterTodos()
        {
            return triPersistencia.ObterTodos();
        }
    }
}
