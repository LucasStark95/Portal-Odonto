using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorAnamnese
    {
        private RepositorioAnamnese anaPersistencia;

        public GerenciadorAnamnese()
        {
            anaPersistencia = new RepositorioAnamnese();
        }

        public Anamnese Adicionar(Anamnese anamnese)
        {
            anaPersistencia.Adicionar(anamnese);
            return anamnese;
        }

        public void Editar(Anamnese anamnese)
        {
            anaPersistencia.Editar(anamnese);
        }

        public void Remover(Anamnese anamnese)
        {
            anaPersistencia.Remover(anamnese);
        }

        public Anamnese Obter(int id)
        {
            return anaPersistencia.Obter(e => e.IdAnamnese == id);
        }

        public List<Anamnese> ObterTodos()
        {
            return anaPersistencia.ObterTodos();
        }
    }
}
