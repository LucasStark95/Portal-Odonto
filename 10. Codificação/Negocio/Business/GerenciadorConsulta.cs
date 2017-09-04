using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorConsulta
    {
        private RepositorioConsulta conPersistencia;

        public GerenciadorConsulta()
        {
            conPersistencia = new RepositorioConsulta();
        }

        public Consulta_M Adicionar(Consulta_M consulta)
        {
            conPersistencia.Adicionar(consulta);
            return consulta;
        }

        public void Editar(Consulta_M consulta)
        {
            conPersistencia.Editar(consulta);
        }

        public void Remover(Consulta_M consulta)
        {
            conPersistencia.Remover(consulta);
        }

        public Consulta_M Obter(int id)
        {
            return conPersistencia.Obter(e => e.IdConsulta == id);
        }

        public List<Consulta_M> ObterTodos()
        {
            return conPersistencia.ObterTodos();
        }

    }
}
