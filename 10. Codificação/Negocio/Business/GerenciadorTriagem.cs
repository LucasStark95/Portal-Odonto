using System.Collections.Generic;
using System.Linq;
using Model.Models;
using Model.Models.Exceptions;
using Model.Models.EDMX;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorTriagem
    {
        private IUnitOfWork unidadeDeTrabalho;
        private bool shared;

        /// <summary>
        /// Construtor pode ser acessado externamente e não compartilha contexto.
        /// </summary>
        public GerenciadorTriagem()
        {
            this.unidadeDeTrabalho = new UnitOfWork();
            shared = false;
        }

        /// <summary>
        /// Construtor acessado apenas dentro do componente Negocio e permite compartilhar
        /// contexto com outras classes de negócio.
        /// </summary>
        public GerenciadorTriagem(IUnitOfWork unidadeDeTrabalho)
        {
            this.unidadeDeTrabalho = unidadeDeTrabalho;
            shared = true;
        }

        /// <summary>
        /// Insere um novo registro na base de dados.
        /// </summary>
        /// <param name="triagem"> Objeto Model. </param>
        /// <returns> Primary Key na base. </returns>
        public int Adicionar(Triagem triagem)
        {
            TB_Triagem triagemP = new TB_Triagem();
            Atribuir(triagem, triagemP);
            unidadeDeTrabalho.RepositorioTriagem.Inserir(triagemP);
            unidadeDeTrabalho.Commit(shared);
            return triagemP.SQC_Triagem;
        }

        /// <summary>
        /// Altera um registro existente na base de dados.
        /// </summary>
        /// <param name="triagem"> Objeto Model. </param>
        public void Editar(Triagem triagem)
        {
            try
            {
                TB_Triagem triagemP = new TB_Triagem();
                Atribuir(triagem, triagemP);
                unidadeDeTrabalho.RepositorioTriagem.Editar(triagemP);
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
        /// <param name="triagem"> Objeto Model a ser removido. </param>
        public void Remover(Triagem triagem)
        {
            unidadeDeTrabalho.RepositorioTriagem.Remover(e => e.SQC_Triagem == triagem.IdTriagem);
            unidadeDeTrabalho.Commit(shared);
        }

        /// <summary>
        /// Consulta padrão para retornar dados de Pessoa como Model.
        /// </summary>
        private IQueryable<Triagem> GetQuery()
        {
            IQueryable<TB_Triagem> triagens = unidadeDeTrabalho.RepositorioTriagem.GetQueryable();
            var query = from triagem in triagens
                        select new Triagem
                        {
                            IdTriagem = triagem.SQC_Triagem,
                            IdPaciente = triagem.TB_Paciente_SQC_Paciente,
                            CirugiaAvancada = (bool)triagem.Tri_Avancado,
                            CirugiaSimples = (bool)triagem.Tri_Simples,
                            Cirurgia = (bool)triagem.Tri_Cirurgia,
                            Clareamento = (bool)triagem.Tri_Clareamento,
                            ClasseI = (bool)triagem.Tri_ClasseI,
                            ClasseII = (bool)triagem.Tri_ClasseII,
                            ClasseIII = (bool)triagem.Tri_ClasseIII,
                            ClasseIV = (bool)triagem.Tri_ClasseIV,
                            ClasseV = (bool)triagem.Tri_ClasseV,
                            DataTriagem = (System.DateTime)triagem.Tri_DataRealizacao,
                            Dentistica = (bool)triagem.Tri_Dentistica,
                            Endodontia = (bool)triagem.Tri_Endodontia,
                            Interproximal = (bool)triagem.Tri_Interproximal,
                            MotivoConsulta = triagem.Tri_MotivoConsulta,
                            //Paciente = Objeto
                            Panoramica = (bool)triagem.Tri_Panoramica,
                            Pediatria = (bool)triagem.Tri_Pediatria,
                            Periapical = (bool)triagem.Tri_Periapical,
                            Periodontia = (bool)triagem.Tri_Periodontia,
                            Procedimento = (bool)triagem.Tri_Procedimento,
                            Protese = (bool)triagem.Tri_Protese,
                            ProteseFixa = (bool) triagem.Tri_ProteseFixa,
                            ProtesePpr = (bool) triagem.Tri_ProtesePpr,
                            ProtesePt = (bool) triagem.Tri_ProtesePt,
                            Radiologia = (bool) triagem.Tri_Radiologia
                        };
            return query;
        }

        /// <summary>
        /// Obtem um registro pelo identificador.
        /// </summary>
        /// <param name="id"> Id do Objeto Model. </param>
        public Triagem Obter(int? id)
        {
            return GetQuery().Where(e => e.IdTriagem == id).FirstOrDefault();
        }

        /// <summary>
        /// Obter todos os registros cadastrados.
        /// </summary>
        public List<Triagem> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Atribui dados do Model para o Entity.
        /// </summary>
        /// <param name="triagemModel"> Objeto Model. </param>
        /// <param name="triagemP"> Entity mapeada da base de dados. </param>
        private void Atribuir(Triagem triagemModel, TB_Triagem triagemP)
        {
            triagemP.SQC_Triagem = triagemModel.IdTriagem;
            triagemP.TB_Paciente_SQC_Paciente = triagemModel.IdPaciente;
            triagemP.Tri_Avancado = triagemModel.CirugiaAvancada;
            triagemP.Tri_Simples = triagemModel.CirugiaSimples;
            triagemP.Tri_Cirurgia = triagemModel.Cirurgia;
            triagemP.Tri_Clareamento = triagemModel.Clareamento;
            triagemP.Tri_ClasseI = triagemModel.ClasseI;
            triagemP.Tri_ClasseII = triagemModel.ClasseII;
            triagemP.Tri_ClasseIII = triagemModel.ClasseIII;
            triagemP.Tri_ClasseIV = triagemModel.ClasseIV;
            triagemP.Tri_ClasseV = triagemModel.ClasseV;
            triagemP.Tri_DataRealizacao = triagemModel.DataTriagem;
            triagemP.Tri_Dentistica = triagemModel.Dentistica;
            triagemP.Tri_Endodontia = triagemModel.Endodontia;
            triagemP.Tri_Interproximal = triagemModel.Interproximal;
            triagemP.Tri_MotivoConsulta = triagemModel.MotivoConsulta;
            triagemP.Tri_Panoramica = triagemModel.Panoramica;
            triagemP.Tri_Pediatria = triagemModel.Pediatria;
            triagemP.Tri_Periapical = triagemModel.Periapical;
            triagemP.Tri_Periodontia = triagemModel.Periodontia;
            triagemP.Tri_Procedimento = triagemModel.Procedimento;
            triagemP.Tri_Protese = triagemModel.Protese;
            triagemP.Tri_ProteseFixa = triagemModel.ProteseFixa;
            triagemP.Tri_ProtesePpr = triagemModel.ProtesePpr;
            triagemP.Tri_ProtesePt = triagemModel.ProtesePt;
            triagemP.Tri_Radiologia = triagemModel.Radiologia;
        }
    }
}