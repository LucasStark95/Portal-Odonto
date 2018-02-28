using System.Collections.Generic;
using System.Linq;
using Model.Models;
using Model.Models.Exceptions;
using Model.Models.EDMX;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorPaciente
    {
        private IUnitOfWork unidadeDeTrabalho;
        private bool shared;

        /// <summary>
        /// Construtor pode ser acessado externamente e não compartilha contexto.
        /// </summary>
        public GerenciadorPaciente()
        {
            this.unidadeDeTrabalho = new UnitOfWork();
            shared = false;
        }

        /// <summary>
        /// Construtor acessado apenas dentro do componente Negocio e permite compartilhar
        /// contexto com outras classes de negócio.
        /// </summary>
        public GerenciadorPaciente(IUnitOfWork unidadeDeTrabalho)
        {
            this.unidadeDeTrabalho = unidadeDeTrabalho;
            shared = true;
        }

        /// <summary>
        /// Insere um novo registro na base de dados.
        /// </summary>
        /// <param name="paciente"> Objeto Model. </param>
        /// <returns> Primary Key na base. </returns>
        public int Adicionar(Paciente paciente)
        {
            TB_Paciente pacienteP = new TB_Paciente();
            Atribuir(paciente, pacienteP);
            unidadeDeTrabalho.RepositorioPaciente.Inserir(pacienteP);
            unidadeDeTrabalho.Commit(shared);
            return pacienteP.SQC_Paciente;
        }

        /// <summary>
        /// Altera um registro existente na base de dados.
        /// </summary>
        /// <param name="Paciente"> Objeto Model. </param>
        public void Editar(Paciente paciente)
        {
            try
            {
                TB_Paciente pacienteP = new TB_Paciente();
                Atribuir(paciente, pacienteP);
                unidadeDeTrabalho.RepositorioPaciente.Editar(pacienteP);
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
        /// <param name="Paciente"> Objeto Model a ser removido. </param>
        public void Remover(Paciente paciente)
        {
            unidadeDeTrabalho.RepositorioPaciente.Remover(e => e.SQC_Paciente == paciente.IdPaciente);
            unidadeDeTrabalho.Commit(shared);
        }

        /// <summary>
        /// Consulta padrão para retornar dados de Paciente como Model.
        /// </summary>
        private IQueryable<Paciente> GetQuery()
        {
            IQueryable<TB_Paciente> pacientes = unidadeDeTrabalho.RepositorioPaciente.GetQueryable();
            var query = from paciente in pacientes
                        select new Paciente
                        {
                            IdPaciente = paciente.SQC_Paciente,
                            NomePaciente = paciente.Pac_Nome,
                            EnderecoPaciente = paciente.Pac_Endereco,
                            CpfPaciente = paciente.Pac_Cpf,
                            RgPaciente = paciente.Pac_Rg,
                            ResponsavelPaciente = paciente.Pac_Responsavel,
                            Dt_nascimentoPaciente = paciente.Pac_DataNascimento,
                            Sexo = paciente.Pac_Sexo,
                            Nacionalidade = paciente.Pac_Nacionalidade,
                            Cidade = paciente.Pac_Cidade,
                            Numero = paciente.Pac_Numero,
                            Cep = paciente.Pac_Cep,
                            Naturalidade = paciente.Pac_Naturalidade,
                            Estado = paciente.Pac_Estado,
                            EstadoCivil = paciente.Pac_EstadoCivil,
                            Raca = paciente.Pac_Raca,
                            Religiao = paciente.Pac_Religiao,
                            Peso = (decimal)paciente.Pac_Peso,
                            Altura = (decimal)paciente.Pac_Altura,
                            GrauDeInstrucao = paciente.Pac_GrauDeInstrucao,
                            Pai = paciente.Pac_Pai,
                            Mae = paciente.Pac_Mae,
                            NacionalidadeMae = paciente.Pac_NacionalidadeMae,
                            NacionalidadePai = paciente.Pac_NacionalidadePai,
                            Profissao = paciente.Pac_Profissao,
                            Zona = paciente.Pac_Zona,
                            Contato = paciente.Pac_Telefone,
                            PressaoArterial = (decimal)paciente.Pac_PressaoArterial,
                            BatimentoCardiaco = (decimal)paciente.Pac_BatimentoCardiaco
                        };
            return query;
        }

        /// <summary>
        /// Obtem um registro pelo identificador.
        /// </summary>
        /// <param name="id"> Id do Objeto Model. </param>
        public Paciente Obter(int id)
        {
            return GetQuery().Where(e => e.IdPaciente == id).FirstOrDefault();
        }

        /// <summary>
        /// Obter todos os registros cadastrados.
        /// </summary>
        public List<Paciente> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Atribui dados do Model para o Entity.
        /// </summary>
        /// <param name="pacienteModel"> Objeto Model. </param>
        /// <param name="pacienteP"> Entity mapeada da base de dados. </param>
        private void Atribuir(Paciente pacienteModel, TB_Paciente pacienteP)
        {
            pacienteP.SQC_Paciente = pacienteModel.IdPaciente;
            pacienteP.Pac_Nome = pacienteModel.NomePaciente;
            pacienteP.Pac_Endereco = pacienteModel.EnderecoPaciente;
            pacienteP.Pac_Cpf = pacienteModel.CpfPaciente;
            pacienteP.Pac_Rg = pacienteModel.RgPaciente;
            pacienteP.Pac_Responsavel = pacienteModel.ResponsavelPaciente;
            pacienteP.Pac_DataNascimento = pacienteModel.Dt_nascimentoPaciente;
            pacienteP.Pac_Sexo = pacienteModel.Sexo;
            pacienteP.Pac_Nacionalidade = pacienteModel.Nacionalidade;
            pacienteP.Pac_Cidade = pacienteModel.Cidade;
            pacienteP.Pac_Numero = pacienteModel.Numero;
            pacienteP.Pac_Cep = pacienteModel.Cep;
            pacienteP.Pac_Naturalidade = pacienteModel.Naturalidade;
            pacienteP.Pac_Estado = pacienteModel.Estado;
            pacienteP.Pac_EstadoCivil = pacienteModel.EstadoCivil;
            pacienteP.Pac_Raca = pacienteModel.Raca;
            pacienteP.Pac_Religiao = pacienteModel.Religiao;
            pacienteP.Pac_Peso = pacienteModel.Peso;
            pacienteP.Pac_Altura = pacienteModel.Altura;
            pacienteP.Pac_GrauDeInstrucao = pacienteModel.GrauDeInstrucao;
            pacienteP.Pac_Pai = pacienteModel.Pai;
            pacienteP.Pac_Mae = pacienteModel.Mae;
            pacienteP.Pac_NacionalidadeMae = pacienteModel.NacionalidadeMae;
            pacienteP.Pac_NacionalidadePai = pacienteModel.NacionalidadePai;
            pacienteP.Pac_Profissao = pacienteModel.Profissao;
            pacienteP.Pac_Zona = pacienteModel.Zona;
            pacienteP.Pac_Telefone = pacienteModel.Contato;
            pacienteP.Pac_PressaoArterial = pacienteModel.PressaoArterial;
            pacienteP.Pac_BatimentoCardiaco = pacienteModel.BatimentoCardiaco;
        }
    }
}