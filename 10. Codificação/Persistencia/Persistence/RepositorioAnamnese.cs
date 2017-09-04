using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;


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
            anamnese.IdAnamnese = listaAnamneses.Count + 1;
            listaAnamneses.Add(anamnese);
            return anamnese;
        }

        public void Editar(Anamnese anamnese)
        {
            int posicao = listaAnamneses.FindIndex(e => e.IdAnamnese == anamnese.IdAnamnese);
            listaAnamneses[posicao] = anamnese;
        }

        public void Remover(Anamnese anamnese)
        {
            int posicao = listaAnamneses.FindIndex(e => e.IdAnamnese == anamnese.IdAnamnese);
            listaAnamneses.RemoveAt(posicao);
        }

        public Anamnese Obter(Func<Anamnese, bool> where)
        {
            return listaAnamneses.Where(where).FirstOrDefault();
        }

        public List<Anamnese> ObterTodos()
        {
            return listaAnamneses;
        }
    }
}
