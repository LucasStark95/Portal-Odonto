using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Model.Models.EDMX;

namespace Persistencia.Persistence
{
    /// <summary>
    /// Repositório Genérico para trabalhar com dados no SGBD.
    /// </summary>
    /// <typeparam name="T"> Um POCO (classe Model) que representa uma entidade no Entity Framework. </typeparam>
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class, new()
    {
        /// <summary>
        /// Objeto de Contexto para o SGBD.
        /// </summary>
        private PortalOdontoEntities _contexto;

        /// <summary>
        /// Inicializa uma nova instância do repositório.
        /// </summary>
        public RepositorioGenerico(PortalOdontoEntities contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Insere uma nova entidade no contexto.
        /// </summary>
        public T Inserir(T entidade)
        {
            if (entidade == null)
            {
                throw new ArgumentNullException("Entidade nula.");
            }

            _contexto.Set<T>().Add(entidade);
            return entidade;
        }

        /// <summary>
        /// Atualiza os dados de uma entidade.
        /// </summary>
        public void Editar(T entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Modified;
        }

        /// <summary>
        /// Remove a entidade especificada.
        /// </summary>
        public void Remover(T entidade)
        {
            if (entidade == null)
            {
                throw new ArgumentNullException("Entidade nula.");
            }
            _contexto.Set<T>().Remove(entidade);
        }

        /// <summary>
        /// Exclui várias entidade que atendem ao critério especificado (condição Where).
        /// </summary>
        public void Remover(Func<T, bool> where)
        {
            _contexto.Set<T>().Where(where).ToList().ForEach(entidade => _contexto.Set<T>().Remove(entidade));
        }

        /// <summary>
        /// Obtém uma única entidade de acordo com o critério (condição Where).
        /// </summary>
        public T ObterEntidade(Func<T, bool> where)
        {
            return _contexto.Set<T>().Single<T>(where);
        }

        /// <summary>
        /// Obtém a primeira entidade do conjunto que atende a um determinado critério (condição Where).
        /// </summary>
        public T ObterPrimeiro(Func<T, bool> where)
        {
            return _contexto.Set<T>().Where(where).FirstOrDefault();
        }

        /// <summary>
        /// Obter a lista de todas as entidades.
        /// </summary>
        public IEnumerable<T> ObterTodos()
        {
            return _contexto.Set<T>().ToList();
        }

        /// <summary>
        /// Obter conjunto de entidades que atende a um determinado critério (condição Where).
        /// </summary>
        public IEnumerable<T> Obter(Func<T, bool> where)
        {
            return _contexto.Set<T>().Where(where);
        }

        /// <summary>
        /// Obter objeto para criação de consulta específica.
        /// </summary>
        public IQueryable<T> GetQueryable()
        {
            return _contexto.Set<T>();
        }

        /// <summary>
        /// Remove de objeto da memória.
        /// </summary>
        public void Dispose()
        {
            if (_contexto != null)
            {
                _contexto.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}