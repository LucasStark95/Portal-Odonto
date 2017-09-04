
using System;
using System.ComponentModel.DataAnnotations;


namespace Model.Models
{
    public enum TipoUsuario { PROFESSOR, TECNICO, ALUNO }

    public class Usuario
    {
        private int idUsuario;
        private string nomeUsuario;
        private int matriculaUsuario;
        private string emailUsuario;
        private string senhaUsuario;
        private string nomeMae;
        private string endereco;
        private string bairro;
        private string cep;
        private string cidade;
        private DateTime dataNascimento;

        public Usuario() { }

        [Required]
        [StringLength(300, MinimumLength = 2)]
        [Display(Name = "Nome Completo")]
        public string NomeUsuario
        {
            get { return nomeUsuario; }
            set { nomeUsuario = value; }
        }

        [Required]
        [Display(Name = "Matricula")]
        public int MatriculaUsuario
        {
            get { return matriculaUsuario; }
            set { matriculaUsuario = value; }
        }

        
        [Key]
        [Display(Name = "ID Usuário")]
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        [StringLength (200, MinimumLength = 5)]
        [Display (Name = "Endereço")]
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        [StringLength(200, MinimumLength = 10)]
        [Display(Name = "Bairro")]
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        [StringLength(40, MinimumLength = 10)]
        [Display(Name = "Cep")]
        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        [StringLength(40, MinimumLength = 10)]
        [Display(Name = "Cidade")]
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }
       
        [StringLength(60, MinimumLength = 10)]
        [Display(Name = "Mãe")]
        public string NomeMae
        {
            get { return nomeMae; }
            set { nomeMae = value; }
        }

        [Required]
        [StringLength(30, MinimumLength = 10)]
        [DataType (DataType.EmailAddress) ]
        [Display(Name = "Email")]
        public string EmailUsuario
        {
            get { return emailUsuario; }
            set { emailUsuario = value; }
        }

        
        [StringLength(20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display (Name = "Senha")]
        public string SenhaUsuario
        {
            get { return senhaUsuario; }
            set { senhaUsuario = value; }
        }

        
        [DataType(DataType.Date)]
        [Display (Name = "Data Nascimento")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }
    }
}