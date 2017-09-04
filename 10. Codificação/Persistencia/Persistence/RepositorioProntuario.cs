using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;


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
            prontuario.IdProntuario = listaProntuarios.Count + 1;
            listaProntuarios.Add(prontuario);
            return prontuario;
        }

        public void Editar(Prontuario prontuario)
        {
            int posicao = listaProntuarios.FindIndex(e => e.IdProntuario == prontuario.IdProntuario);
            listaProntuarios[posicao] = prontuario;
        }

        public void Remover(Prontuario prontuario)
        {
            int posicao = listaProntuarios.FindIndex(e => e.IdProntuario == prontuario.IdProntuario);
            listaProntuarios.RemoveAt(posicao);
        }

        public Prontuario Obter(Func<Prontuario, bool> where)
        {
            return listaProntuarios.Where(where).FirstOrDefault();
        }

        public List<Prontuario> ObterTodos()
        {
            return listaProntuarios;
        }
    }
}
