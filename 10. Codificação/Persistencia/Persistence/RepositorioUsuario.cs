using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Model.Models.Exceptions;

namespace Persistencia.Persistence
{
    public class RepositorioUsuario
    {
        private static List<Usuario> listaUsuarios;

        static RepositorioUsuario()
        {
            listaUsuarios = new List<Usuario>();
        }

        public Usuario Adicionar(Usuario usuario)
        {
            try
            {
                usuario.IdUsuario = listaUsuarios.Count + 1;
                listaUsuarios.Add(usuario);
                return usuario;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }

        }

        public void Editar(Usuario usuario)
        {
            try
            {
                int posicao = listaUsuarios.FindIndex(e => e.IdUsuario == usuario.IdUsuario);
                listaUsuarios[posicao] = usuario;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }

        }

        public void Remover(Usuario usuario)
        {
            try
            {
                int posicao = listaUsuarios.FindIndex(e => e.IdUsuario == usuario.IdUsuario);
                listaUsuarios.RemoveAt(posicao);
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }

        }

        public Usuario Obter(Func<Usuario, bool> where)
        {
            try
            {
                return listaUsuarios.Where(where).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }

        }

        public List<Usuario> Buscar(Func<Usuario, bool> where)
        {
            try
            {
                return listaUsuarios.Where(where).ToList();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }

        }

        public List<Usuario> ObterTodos()
        {
            try
            {
                return listaUsuarios;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }

        }
    }
}
