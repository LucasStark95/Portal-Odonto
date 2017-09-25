
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Consulta_M
    {

        private string dataConsulta;
        private string nomeAluno;
        private string nomePaciente;
        private int idConsulta;


        public Consulta_M()
        {
        }

        [Required]
        [Display (Name = "ID Consulta")]
        public int IdConsulta
        {
            get { return idConsulta; }
            set { idConsulta = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date)]
        [Display(Name = "Data da Consulta")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public string DataConsulta
        {
            get { return dataConsulta; }
            set { dataConsulta = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display (Name = "Nome do Aluno")]
        public string NomeAluno
        {
            get { return nomeAluno; }
            set { nomeAluno = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display (Name = "Nome do Paciente")]
        public string NomePaciente
        {
            get { return nomePaciente; }
            set { nomePaciente = value; }
        }
    }
}