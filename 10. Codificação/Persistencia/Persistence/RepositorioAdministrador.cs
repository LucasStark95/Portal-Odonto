using System;
using System.Collections.Generic;
using System.Linq;
using Model.Models;
using Model.Models.Exceptions;


namespace Persistencia.Persistence
{
    public class RepositorioAdministrador
    {
        private static List<Administrador> listaAdministradores;

        static RepositorioAdministrador()
        {
            listaAdministradores = new List<Administrador>();
        }

        public Administrador Adicionar(Administrador administrador)
        {
            try {
                administrador.IdAdministrador = listaAdministradores.Count + 1;
                listaAdministradores.Add(administrador);
                return administrador;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public void Editar(Administrador administrador)
        {
            try
            {
                int posicao = listaAdministradores.FindIndex(e => e.IdAdministrador == administrador.IdAdministrador);
                listaAdministradores[posicao] = administrador;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public void Remover(Administrador administrador)
        {
            try
            {
                int posicao = listaAdministradores.FindIndex(e => e.IdAdministrador == administrador.IdAdministrador);
                listaAdministradores.RemoveAt(posicao);
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public Administrador Obter(Func<Administrador, bool> where)
        {
            try
            {
                return listaAdministradores.Where(where).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public List<Administrador> ObterTodos()
        {
            try
            {
                return listaAdministradores;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }
    }
}
