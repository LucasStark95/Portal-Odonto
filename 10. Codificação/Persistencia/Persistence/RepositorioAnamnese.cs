using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Model.Models.Exceptions;


namespace Persistencia.Persistence
{
    public class RepositorioAnamnese
    {
        private static List<Anamnese> listaAnamneses;

        static RepositorioAnamnese()
        {
            listaAnamneses = new List<Anamnese>();
        }

        public Anamnese Adicionar(Anamnese anamnese)
        {
            try {
                anamnese.IdAnamnese = listaAnamneses.Count + 1;
                listaAnamneses.Add(anamnese);
                return anamnese;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public void Editar(Anamnese anamnese)
        {
            try {
                int posicao = listaAnamneses.FindIndex(e => e.IdAnamnese == anamnese.IdAnamnese);
                listaAnamneses[posicao] = anamnese;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public void Remover(Anamnese anamnese)
        {
            try {
                int posicao = listaAnamneses.FindIndex(e => e.IdAnamnese == anamnese.IdAnamnese);
                listaAnamneses.RemoveAt(posicao);
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public Anamnese Obter(Func<Anamnese, bool> where)
        {
            try
            {
                return listaAnamneses.Where(where).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public List<Anamnese> ObterTodos()
        {
            try
            {
                return listaAnamneses;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }
    }
}
