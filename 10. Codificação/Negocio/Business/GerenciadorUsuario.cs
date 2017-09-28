
using System.Collections.Generic;
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

        public Usuario ObterByLoginSenha(string login, string senha)
        {
            return usuarioPersistencia.Obter(e => e.EmailUsuario.ToLowerInvariant().Equals(login.ToLowerInvariant()) &&
                e.SenhaUsuario.ToLowerInvariant().Equals(senha.ToLowerInvariant()));
        }

        public Usuario Obter(int? id)
        {
            return usuarioPersistencia.Obter(e => e.IdUsuario == id);
        }

        public Usuario ObterByMatricula(int? matricula)
        {
            return usuarioPersistencia.Obter(e => e.MatriculaUsuario == matricula);
        }

        public List<Usuario> Buscar(int? matricula)
        {
            return usuarioPersistencia.Buscar(e => e.MatriculaUsuario == matricula);
        }

        public bool BuscarMatricula(int? matricula)
        {
            return usuarioPersistencia.BuscarMatricula(e => e.MatriculaUsuario == matricula);
        }

        public bool BuscarPreCadastro(int? matricula, string email)
        {
            if(usuarioPersistencia.Obter(e => e.EmailUsuario.ToLowerInvariant().Equals(email.ToLowerInvariant()) &&
                e.MatriculaUsuario == matricula) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool BuscarUsuario(string email, string mae, int matricula)
        {
            if (usuarioPersistencia.Obter(e => e.EmailUsuario.ToLowerInvariant().Equals(email.ToLowerInvariant()) &&
                 (e.MatriculaUsuario == matricula) && e.NomeMae.ToLowerInvariant().Equals(mae.ToLowerInvariant())) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Usuario> ObterTodos()
        {
            return usuarioPersistencia.ObterTodos();
        }
    }
}
