using System.Collections.Generic;
using System.Linq;
using Model.Models;
using Model.Models.Exceptions;
using Model.Models.EDMX;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorUsuario
    {
        private IUnitOfWork unidadeDeTrabalho;
        private bool shared;

        /// <summary>
        /// Construtor pode ser acessado externamente e não compartilha contexto.
        /// </summary>
        public GerenciadorUsuario()
        {
            this.unidadeDeTrabalho = new UnitOfWork();
            shared = false;
        }

        /// <summary>
        /// Construtor acessado apenas dentro do componente Negocio e permite compartilhar
        /// contexto com outras classes de negócio.
        /// </summary>
        public GerenciadorUsuario(IUnitOfWork unidadeDeTrabalho)
        {
            this.unidadeDeTrabalho = unidadeDeTrabalho;
            shared = true;
        }

        /// <summary>
        /// Insere um novo registro na base de dados.
        /// </summary>
        /// <param name="usuario"> Objeto Model. </param>
        /// <returns> Primary Key na base. </returns>
        public int Adicionar(Usuario usuario)
        {
            TB_Pessoa usuarioP = new TB_Pessoa();
            Atribuir(usuario, usuarioP);
            unidadeDeTrabalho.RepositorioPessoa.Inserir(usuarioP);
            unidadeDeTrabalho.Commit(shared);
            return usuarioP.SQC_Pessoa;
        }

        /// <summary>
        /// Altera um registro existente na base de dados.
        /// </summary>
        /// <param name="usuario"> Objeto Model. </param>
        public void Editar(Usuario usuario)
        {
            try
            {
                TB_Pessoa usuarioP = new TB_Pessoa();
                Atribuir(usuario, usuarioP);
                unidadeDeTrabalho.RepositorioPessoa.Editar(usuarioP);
                unidadeDeTrabalho.Commit(shared);
            }
            catch (PersistenciaException persistExcep)
            {
                throw new NegocioException("Falha ao editar a editora.", persistExcep);
            }
        }

        /// <summary>
        /// Remove um registro da base de dados.
        /// </summary>
        /// <param name="Usuário"> Objeto Model a ser removido. </param>
        public void Remover(Usuario usuario)
        {
            unidadeDeTrabalho.RepositorioPessoa.Remover(e => e.SQC_Pessoa == usuario.IdUsuario);
            unidadeDeTrabalho.Commit(shared);
        }

        /// <summary>
        /// Consulta padrão para retornar dados de Pessoa como Model.
        /// </summary>
        private IQueryable<Usuario> GetQuery()
        {
            IQueryable<TB_Pessoa> usuarios = unidadeDeTrabalho.RepositorioPessoa.GetQueryable();
            var query = from usuario in usuarios
                        select new Usuario
                        {
                            IdUsuario = usuario.SQC_Pessoa,
                            NomeUsuario = usuario.Pes_Nome,
                            MatriculaUsuario = usuario.Pes_Matricula,
                            TipoUsuario = usuario.Pes_TipoUsuario,
                            SenhaUsuario = usuario.Pes_Senha,
                            EmailUsuario = usuario.Pes_Email,
                            Endereco = usuario.Pes_Endereco,
                            Bairro = usuario.Pes_Bairro,
                            Cep = usuario.Pes_Cep,
                            Cidade = usuario.Pes_Cidade,
                            DataNascimento = usuario.Pes_DataNascimento,
                            NumeroUsuario = usuario.Pes_Numero,
                            NomeMae = usuario.Pes_NomeMae                          
                        };
            return query;
        }

        /// <summary>
        /// Obtem um registro pelo identificador.
        /// </summary>
        /// <param name="id"> Id do Objeto Model. </param>
        public Usuario Obter(int id)
        {
            return GetQuery().Where(e => e.IdUsuario == id).FirstOrDefault();
        }

        /// <summary>
        /// Obter todos os registros cadastrados.
        /// </summary>
        public List<Usuario> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Atribui dados do Model para o Entity.
        /// </summary>
        /// <param name="usuarioModel"> Objeto Model. </param>
        /// <param name="usuarioP"> Entity mapeada da base de dados. </param>
        private void Atribuir(Usuario usuarioModel, TB_Pessoa usuarioP)
        {
            usuarioP.SQC_Pessoa = usuarioModel.IdUsuario;
            usuarioP.Pes_Nome = usuarioModel.NomeUsuario;
            usuarioP.Pes_Endereco = usuarioModel.Endereco;
            usuarioP.Pes_Numero = usuarioModel.NumeroUsuario;
            usuarioP.Pes_Bairro = usuarioModel.Bairro;
            usuarioP.Pes_Cep = usuarioModel.Cep;
            usuarioP.Pes_Cidade = usuarioModel.Cidade;
            usuarioP.Pes_DataNascimento = usuarioModel.DataNascimento;
            usuarioP.Pes_Email = usuarioModel.EmailUsuario;
            usuarioP.Pes_Matricula = usuarioModel.MatriculaUsuario;
            usuarioP.Pes_TipoUsuario = usuarioModel.TipoUsuario;
            usuarioP.Pes_Senha = usuarioModel.SenhaUsuario;
            usuarioP.Pes_NomeMae = usuarioModel.NomeMae; 
        }

        public List<Usuario> Buscar(string matricula)
        {
            return GetQuery().Where(e => e.MatriculaUsuario.Intersect(matricula).Any()).ToList();
        }

        public bool BuscarMatricula(string matricula)
        {
            return System.Convert.ToBoolean(GetQuery().Where(e => e.MatriculaUsuario == matricula).FirstOrDefault()) ;
        }

        public Usuario ObterByMatricula(string matricula)
        {
            return GetQuery().Where(e => e.MatriculaUsuario == matricula).FirstOrDefault();
        }

        public Usuario ObterByLoginSenha(string login, string senha)
        {
            return GetQuery().Where(u => u.EmailUsuario == login && u.SenhaUsuario == senha).FirstOrDefault();
        }

        public bool BuscarUsuario(string email, string mae, string matricula)
        {
            return System.Convert.ToBoolean(GetQuery().Where(e => e.MatriculaUsuario == matricula && e.NomeMae == mae && e.EmailUsuario == email).FirstOrDefault());
        }

        public bool BuscarPreCadastro(string email, string matricula)
        {
            return System.Convert.ToBoolean(GetQuery().Where(e => e.MatriculaUsuario == matricula && e.EmailUsuario == email).FirstOrDefault());
        }
    }


}