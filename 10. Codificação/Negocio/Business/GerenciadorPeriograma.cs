using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorPeriograma
    {
        private RepositorioPeriograma periPersistencia;

        public GerenciadorPeriograma()
        {
            periPersistencia = new RepositorioPeriograma();
        }

        public Periograma Adicionar(Periograma periograma)
        {
            periPersistencia.Adicionar(periograma);
            return periograma;
        }

        public void Editar(Periograma periograma)
        {
            periPersistencia.Editar(periograma);
        }

        public Periograma Obter(int id)
        {
            return periPersistencia.Obter(e => e.IdPeriograma == id);
        }

        public List<Periograma> ObterTodos()
        {
            return periPersistencia.ObterTodos();
        }
    }
}
