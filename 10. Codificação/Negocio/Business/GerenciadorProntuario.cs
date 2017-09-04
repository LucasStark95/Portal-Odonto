using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorProntuario
    {
        private RepositorioProntuario proPersistencia;

        public GerenciadorProntuario()
        {
            proPersistencia = new RepositorioProntuario();
        }

        public Prontuario Adicionar(Prontuario prontuario)
        {
            proPersistencia.Adicionar(prontuario);
            return prontuario;
        }

        public Prontuario Obter(int id)
        {
            return proPersistencia.Obter(e => e.IdProntuario == id);
        }

        public List<Prontuario> ObterTodos()
        {
            return proPersistencia.ObterTodos();
        }
    }
}
