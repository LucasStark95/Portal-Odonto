using System;
using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;
using Model.Models.Exceptions;

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
                try {
                    admPersistencia.Adicionar(administrador);
                    return administrador;
                }
                catch (Exception e)
                {
                    throw new NegocioException("Não foi possivél adicionar", e);
                }                
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
