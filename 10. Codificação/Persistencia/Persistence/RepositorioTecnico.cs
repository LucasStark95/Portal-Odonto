using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Model.Models.Exceptions;


namespace Persistencia.Persistence
{
    public class RepositorioTecnico
    {
        private static List<Tecnico> listaTecnicos;

        static RepositorioTecnico()
        {
            listaTecnicos = new List<Tecnico>();
        }

        public Tecnico Adicionar(Tecnico tecnico)
        {
            try
            {
                tecnico.IdTecnico = listaTecnicos.Count + 1;
                listaTecnicos.Add(tecnico);
                return tecnico;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public void Editar(Tecnico tecnico)
        {
            try {
                int posicao = listaTecnicos.FindIndex(e => e.IdTecnico == tecnico.IdTecnico);
                listaTecnicos[posicao] = tecnico;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public void Remover(Tecnico tecnico)
        {
            try
            {
                int posicao = listaTecnicos.FindIndex(e => e.IdTecnico == tecnico.IdTecnico);
                listaTecnicos.RemoveAt(posicao);
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public Tecnico Obter(Func<Tecnico, bool> where)
        {
            try
            {
                return listaTecnicos.Where(where).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public List<Tecnico> ObterTodos()
        {
            try
            {
                return listaTecnicos;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }
    }
}
