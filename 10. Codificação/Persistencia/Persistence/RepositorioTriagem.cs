using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Model.Models.Exceptions;


namespace Persistencia.Persistence
{
    public class RepositorioTriagem
    {
        private static List<Triagem> listaTriagens;

        static RepositorioTriagem()
        {
            listaTriagens = new List<Triagem>();
        }

        public Triagem Adicionar(Triagem triagem)
        {
            try {
                triagem.IdTriagem = listaTriagens.Count + 1;
                listaTriagens.Add(triagem);
                return triagem;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);

            }
            
        }

        public void Editar(Triagem triagem)
        {
           try {               
                int posicao = listaTriagens.FindIndex(e => e.IdTriagem == triagem.IdTriagem);
                listaTriagens[posicao] = triagem;
            }
           catch (Exception e)
           {
				throw new PersistenciaException("Não foi possivél completar a ação", e);
		   }
            
        }

        public void Remover(Triagem triagem)
        {
            try
            {
                int posicao = listaTriagens.FindIndex(e => e.IdTriagem == triagem.IdTriagem);
                listaTriagens.RemoveAt(posicao);
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public Triagem Obter(Func<Triagem, bool> where)
        {
            try
            {
                return listaTriagens.Where(where).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public List<Triagem> ObterTodos()
        {
            try
            {
                return listaTriagens;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }
    }
}
