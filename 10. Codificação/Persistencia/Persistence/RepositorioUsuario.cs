using System;
using System.Collections.Generic;
using System.Linq;
using Model.Models;

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
            usuario.IdUsuario = listaUsuarios.Count + 1;
            listaUsuarios.Add(usuario);
            return usuario;
        }

        public void Editar(Usuario usuario)
        {
            int posicao = listaUsuarios.FindIndex(e => e.IdUsuario == usuario.IdUsuario);
            usuario.TipoUsuario = listaUsuarios[posicao].TipoUsuario;
            listaUsuarios[posicao] = usuario;
        }


        public void Remover(Usuario usuario)
        {
            int posicao = listaUsuarios.FindIndex(e => e.IdUsuario == usuario.IdUsuario);
            listaUsuarios.RemoveAt(posicao);
        }

        public Usuario Obter(Func<Usuario, bool> where)
        {
            return listaUsuarios.Where(where).FirstOrDefault();
        }

        public List<Usuario> Buscar(Func<Usuario, bool> where)
        {
            return listaUsuarios.Where(where).ToList();
        }

        public List<Usuario> ObterTodos()
        {
            return listaUsuarios;
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
