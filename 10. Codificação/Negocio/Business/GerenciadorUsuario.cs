
using System.Collections.Generic;
using Persistencia.Persistence;
using Model.Models;
using Model.Models.Exceptions;


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
            try
            {
                usuarioPersistencia.Adicionar(usuario);
                return usuario;
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Editar(Usuario usuario)
        {
            try
            {
                usuarioPersistencia.Editar(usuario);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public void Remover(Usuario usuario)
        {
            try
            {
                usuarioPersistencia.Remover(usuario);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public Usuario ObterByLoginSenha(string login, string senha)
        {
            return usuarioPersistencia.Obter(e => e.EmailUsuario.ToLowerInvariant().Equals(login.ToLowerInvariant()) &&
                e.SenhaUsuario.ToLowerInvariant().Equals(senha.ToLowerInvariant()));
        }

        public Usuario Obter(int? id)
        {
            try
            {
                return usuarioPersistencia.Obter(e => e.IdUsuario == id);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public Usuario ObterByMatricula(string matricula)
        {
            return usuarioPersistencia.Obter(e => e.MatriculaUsuario == matricula);
        }

        public List<Usuario> Buscar(string matricula)
        {
            try
            {
                return usuarioPersistencia.Buscar(matricula);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }

        public bool BuscarMatricula(string matricula)
        {
            return usuarioPersistencia.BuscarMatricula(e => e.MatriculaUsuario == matricula);
        }

        public bool BuscarPreCadastro(string matricula, string email)
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

        public bool BuscarUsuario(string email, string mae, string matricula)
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
            try
            {
                return usuarioPersistencia.ObterTodos();
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Não foi possivél completar a ação", e);
            }

        }
    }
}
