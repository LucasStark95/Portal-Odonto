using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;


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
            tecnico.IdTecnico = listaTecnicos.Count + 1;
            listaTecnicos.Add(tecnico);
            return tecnico;
        }

        public void Editar(Tecnico tecnico)
        {
            int posicao = listaTecnicos.FindIndex(e => e.IdTecnico == tecnico.IdTecnico);
            listaTecnicos[posicao] = tecnico;
        }

        public void Remover(Tecnico tecnico)
        {
            int posicao = listaTecnicos.FindIndex(e => e.IdTecnico == tecnico.IdTecnico);
            listaTecnicos.RemoveAt(posicao);
        }

        public Tecnico Obter(Func<Tecnico, bool> where)
        {
            return listaTecnicos.Where(where).FirstOrDefault();
        }

        public List<Tecnico> ObterTodos()
        {
            return listaTecnicos;
        }
    }
}
