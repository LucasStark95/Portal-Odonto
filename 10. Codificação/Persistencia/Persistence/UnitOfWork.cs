using System;
using Model.Models.EDMX;

namespace Persistencia.Persistence
{
    /// <summary>
    /// UnitWork é um padrão de projeto que permite trabalhar com vários repositórios compartilhando um mesmo contexto transacional.
    /// </summary>
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private PortalOdontoEntities _contexto;
        private IRepositorioGenerico<TB_Odontograma> _repOdontograma;
        private IRepositorioGenerico<TB_Paciente> _repPaciente;
        private IRepositorioGenerico<TB_Perguntas> _repPerguntas;
        private IRepositorioGenerico<TB_Periograma> _repPeriograma;
        private IRepositorioGenerico<TB_Pessoa> _repPessoa;
        private IRepositorioGenerico<TB_Triagem> _repTriagem;

        /// <summary>
        /// Construtor para Criar Contexto Transacional.
        /// </summary>
        public UnitOfWork()
        {
            _contexto = new PortalOdontoEntities();
        }

        #region IUnitOfWork Elementos

        /// <summary>
        /// Repositório para manipular dados persistidos de Odontograma.
        /// </summary>
        public IRepositorioGenerico<TB_Odontograma> RepositorioOdontograma
        {
            get
            {
                if (_repOdontograma == null)
                {
                    _repOdontograma = new RepositorioGenerico<TB_Odontograma>(_contexto);
                }
                return _repOdontograma;
            }
        }

        /// <summary>
        /// Repositório para manipular dados persistidos de Paciente.
        /// </summary>
        public IRepositorioGenerico<TB_Paciente> RepositorioPaciente
        {
            get
            {
                if (_repPaciente == null)
                {
                    _repPaciente = new RepositorioGenerico<TB_Paciente>(_contexto);
                }
                return _repPaciente;
            }
        }

        /// <summary>
        /// Repositório para manipular dados persistidos de Perguntas.
        /// </summary>
        public IRepositorioGenerico<TB_Perguntas> RepositorioPerguntas
        {
            get
            {
                if (_repPerguntas == null)
                {
                    _repPerguntas = new RepositorioGenerico<TB_Perguntas>(_contexto);
                }
                return _repPerguntas;
            }
        }

        /// <summary>
        /// Repositório para manipular dados persistidos de Periograma.
        /// </summary>
        public IRepositorioGenerico<TB_Periograma> RepositorioPeriograma
        {
            get
            {
                if (_repPeriograma == null)
                {
                    _repPeriograma = new RepositorioGenerico<TB_Periograma>(_contexto);
                }
                return _repPeriograma;
            }
        }

        /// <summary>
        /// Repositório para manipular dados persistidos de Pessoa.
        /// </summary>
        public IRepositorioGenerico<TB_Pessoa> RepositorioPessoa
        {
            get
            {
                if (_repPessoa == null)
                {
                    _repPessoa = new RepositorioGenerico<TB_Pessoa>(_contexto);
                }
                return _repPessoa;
            }
        }

        /// <summary>
        /// Repositório para manipular dados persistidos de Triagem.
        /// </summary>
        public IRepositorioGenerico<TB_Triagem> RepositorioTriagem
        {
            get
            {
                if (_repTriagem == null)
                {
                    _repTriagem = new RepositorioGenerico<TB_Triagem>(_contexto);
                }
                return _repTriagem;
            }
        }

        /// <summary>
        /// Salva todas as mudanças realizadas no contexto
        /// quando o contexto não for compartilhado.
        /// </summary>
        public void Commit(bool shared)
        {
            if (!shared)
                _contexto.SaveChanges();
        }

        #endregion

        private bool disposed = false;
        /// <summary>
        /// Retira da memória um determinado contexto.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Limpa contexto da memória.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}