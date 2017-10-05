using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Model.Models.Exceptions;


namespace Persistencia.Persistence
{
    public class RepositorioPeriograma
    {
        private static List<Periograma> listaPeriogramas;

        static RepositorioPeriograma()
        {
            listaPeriogramas = new List<Periograma>();
        }

        public Periograma Adicionar(Periograma periograma)
        {
            try {
                periograma.IdPeriograma = listaPeriogramas.Count + 1;
                listaPeriogramas.Add(periograma);
                return periograma;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public void Editar(Periograma periograma)
        {
            try {
                int posicao = listaPeriogramas.FindIndex(e => e.IdPeriograma == periograma.IdPeriograma);
                listaPeriogramas[posicao] = periograma;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public void Remover(Periograma periograma)
        {
            try
            {
                int posicao = listaPeriogramas.FindIndex(e => e.IdPeriograma == periograma.IdPeriograma);
                listaPeriogramas.RemoveAt(posicao);
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public Periograma Obter(Func<Periograma, bool> where)
        {
            try
            {
                return listaPeriogramas.Where(where).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public List<Periograma> ObterTodos()
        {
            try
            {
                return listaPeriogramas;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }
    }
}
