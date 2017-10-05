using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Model.Models.Exceptions;


namespace Persistencia.Persistence
{
    public class RepositorioProntuario
    {
        private static List<Prontuario> listaProntuarios;

        static RepositorioProntuario()
        {
            listaProntuarios = new List<Prontuario>();
        }

        public Prontuario Adicionar(Prontuario prontuario)
        {
            try
            {
                prontuario.IdProntuario = listaProntuarios.Count + 1;
                listaProntuarios.Add(prontuario);
                return prontuario;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public void Editar(Prontuario prontuario)
        {
            try {
                int posicao = listaProntuarios.FindIndex(e => e.IdProntuario == prontuario.IdProntuario);
                listaProntuarios[posicao] = prontuario;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public void Remover(Prontuario prontuario)
        {
            try
            {
                int posicao = listaProntuarios.FindIndex(e => e.IdProntuario == prontuario.IdProntuario);
                listaProntuarios.RemoveAt(posicao);
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public Prontuario Obter(Func<Prontuario, bool> where)
        {
            try
            {
                return listaProntuarios.Where(where).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public List<Prontuario> ObterTodos()
        {
            try
            {
                return listaProntuarios;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }
    }
}
