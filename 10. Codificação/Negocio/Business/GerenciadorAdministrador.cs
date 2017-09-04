using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorAdministrador
    {
        
            private RepositorioAdministrador admPersistencia;

            public GerenciadorAdministrador()
            {
            admPersistencia = new RepositorioAdministrador();
            }

            public Administrador Adicionar(Administrador administrador)
            {
            admPersistencia.Adicionar(administrador);
                return administrador;
            }

            public void Editar(Administrador administrador)
            {
            admPersistencia.Editar(administrador);
            }

            public void Remover(Administrador administrador)
            {
            admPersistencia.Remover(administrador);
            }

            public Administrador Obter(int id)
            {
                return admPersistencia.Obter(e => e.IdAdministrador == id);
            }

            public List<Administrador> ObterTodos()
            {
                return admPersistencia.ObterTodos();
            }
        
    }
}
