using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorTecnico
    {
        private RepositorioTecnico tecPersistencia;

        public GerenciadorTecnico()
        {
            tecPersistencia = new RepositorioTecnico();
        }

        public Tecnico Adicionar(Tecnico tecnico)
        {
            tecPersistencia.Adicionar(tecnico);
            return tecnico;
        }

        public void Editar(Tecnico tecnico)
        {
            tecPersistencia.Editar(tecnico);
        }

        public void Remover(Tecnico tecnico)
        {
            tecPersistencia.Remover(tecnico);
        }

        public Tecnico Obter(int id)
        {
            return tecPersistencia.Obter(e => e.IdTecnico == id);
        }

        public List<Tecnico> ObterTodos()
        {
            return tecPersistencia.ObterTodos();
        }
    }
}
