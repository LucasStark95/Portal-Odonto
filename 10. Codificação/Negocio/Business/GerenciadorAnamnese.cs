using System.Collections.Generic;
using System.Linq;
using Model.Models;
using Model.Models.Exceptions;
using Model.Models.EDMX;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorAnamnese
    {
        private IUnitOfWork unidadeDeTrabalho;
        private bool shared;

        /// <summary>
        /// Construtor pode ser acessado externamente e não compartilha contexto.
        /// </summary>
        public GerenciadorAnamnese()
        {
            this.unidadeDeTrabalho = new UnitOfWork();
            shared = false;
        }

        /// <summary>
        /// Construtor acessado apenas dentro do componente Negocio e permite compartilhar
        /// contexto com outras classes de negócio.
        /// </summary>
        public GerenciadorAnamnese(IUnitOfWork unidadeDeTrabalho)
        {
            this.unidadeDeTrabalho = unidadeDeTrabalho;
            shared = true;
        }

        /// <summary>
        /// Insere um novo registro na base de dados.
        /// </summary>
        /// <param name="anamnese"> Objeto Model. </param>
        /// <returns> Primary Key na base. </returns>
        public int Adicionar(Anamnese anamnese)
        {
            TB_Perguntas anamneseP = new TB_Perguntas();
            Atribuir(anamnese, anamneseP);
            unidadeDeTrabalho.RepositorioPerguntas.Inserir(anamneseP);
            unidadeDeTrabalho.Commit(shared);
            return anamneseP.SQC_Pergunta;
        }

        /// <summary>
        /// Altera um registro existente na base de dados.
        /// </summary>
        /// <param name="anamnese"> Objeto Model. </param>
        public void Editar(Anamnese anamnese)
        {
            try
            {
                TB_Perguntas anamneseP = new TB_Perguntas();
                Atribuir(anamnese, anamneseP);
                unidadeDeTrabalho.RepositorioPerguntas.Editar(anamneseP);
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
        /// <param name="anamnese"> Objeto Model a ser removido. </param>
        public void Remover(Anamnese anamnese)
        {
            unidadeDeTrabalho.RepositorioPerguntas.Remover(e => e.SQC_Pergunta == anamnese.IdAnamnese);
            unidadeDeTrabalho.Commit(shared);
        }

        /// <summary>
        /// Consulta padrão para retornar dados de Pessoa como Model.
        /// </summary>
        private IQueryable<Anamnese> GetQuery()
        {
            IQueryable<TB_Perguntas> anamneses = unidadeDeTrabalho.RepositorioPerguntas.GetQueryable();
            var query = from anamnese in anamneses
                        select new Anamnese
                        {
                            IdAnamnese = anamnese.SQC_Pergunta,
                            CodPergunta = anamnese.TB_Perguntas_SQC_Pergunta,
                            RespostaPergunta = anamnese.Pgt_Enunciado,
                            Conclusao = anamnese.Pgt_Conclusao
                        };
            return query;
        }

        /// <summary>
        /// Obtem um registro pelo identificador.
        /// </summary>
        /// <param name="id"> Id do Objeto Model. </param>
        public Anamnese Obter(int id)
        {
            return GetQuery().Where(e => e.IdAnamnese == id).FirstOrDefault();
        }

        /// <summary>
        /// Obter todos os registros cadastrados.
        /// </summary>
        public List<Anamnese> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Atribui dados do Model para o Entity.
        /// </summary>
        /// <param name="anamneseModel"> Objeto Model. </param>
        /// <param name="anamneseP"> Entity mapeada da base de dados. </param>
        private void Atribuir(Anamnese anamneseModel, TB_Perguntas anamneseP)
        {
            anamneseP.SQC_Pergunta = anamneseModel.IdAnamnese;
            anamneseP.Pgt_Enunciado = anamneseModel.RespostaPergunta;
            anamneseP.Pgt_Conclusao = anamneseModel.Conclusao;
            anamneseP.TB_Perguntas_SQC_Pergunta = anamneseModel.CodPergunta;
        }
    }
}