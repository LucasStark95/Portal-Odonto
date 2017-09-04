using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Persistence;
using Model.Models;


namespace Negocio.Business
{
    public class GerenciadorUsuario
    {
        private RepositorioUsuario usuarioPersistencia;

        public GerenciadorUsuario()
        {
            usuarioPersistencia = new RepositorioUsuario();
        }

        public Usuario Adicionar(Usuario usuario)
        {
            usuarioPersistencia.Adicionar(usuario);
            return usuario;
        }

        public void Editar(Usuario usuario)
        {
            usuarioPersistencia.Editar(usuario);
        }

        public void Remover(Usuario usuario)
        {
            usuarioPersistencia.Remover(usuario);
        }

        public Usuario Obter(int id)
        {
            return usuarioPersistencia.Obter(e => e.IdUsuario == id);
        }

        public List<Usuario> ObterTodos()
        {
            return usuarioPersistencia.ObterTodos();
        }
    }
}
