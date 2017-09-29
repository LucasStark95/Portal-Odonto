using System;
using System.Collections.Generic;
using System.Linq;
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

            Usuario adm = new Usuario("lucas.d1995@gmail.com", "lp1995lp", 0,0,1);
            Usuario tec = new Usuario("nada.d1995@gmail.com", "lucas1995", 2,123,2);
            Usuario pro = new Usuario("aqui.d1995@live.com", "lucas95", 1,222,3);
            Usuario alu = new Usuario("ali.d1995@hotmail.com", "lp1995lp", 3,333,4);

            if (!listaUsuarios.Contains(adm) && !listaUsuarios.Contains(tec))
            {
                listaUsuarios.Add(adm);
                listaUsuarios.Add(tec);
                listaUsuarios.Add(pro);
                listaUsuarios.Add(alu);
            }
                
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
<<<<<<< .mine

=======

>>>>>>> .theirs
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

        public bool BuscarMatricula(Func<Usuario, bool> where)
        {
            if (listaUsuarios.Where(where).FirstOrDefault() == null)
                return false;
            else
                return true;
        }
    }
}
