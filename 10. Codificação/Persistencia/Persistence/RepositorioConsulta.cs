using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Model.Models.Exceptions;


namespace Persistencia.Persistence
{
    public class RepositorioConsulta
    {
        private static List<Consulta_M> listaConsultas;

        static RepositorioConsulta()
        {
            listaConsultas = new List<Consulta_M>();
        }

        public Consulta_M Adicionar(Consulta_M consulta)
        {
            try
            {
                consulta.IdConsulta = listaConsultas.Count + 1;
                listaConsultas.Add(consulta);
                return consulta;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public void Editar(Consulta_M consulta)
        {
            try {
                int posicao = listaConsultas.FindIndex(e => e.IdConsulta == consulta.IdConsulta);
                listaConsultas[posicao] = consulta;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public void Remover(Consulta_M consulta)
        {
            try {
                int posicao = listaConsultas.FindIndex(e => e.IdConsulta == consulta.IdConsulta);
                listaConsultas.RemoveAt(posicao);
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
            
        }

        public Consulta_M Obter(Func<Consulta_M, bool> where)
        {
            try
            {
                return listaConsultas.Where(where).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }
           
        }

        public List<Consulta_M> ObterTodos()
        {
            try
            {
                return listaConsultas;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Não foi possivél completar a ação", e);
            }

        }
    }
}
