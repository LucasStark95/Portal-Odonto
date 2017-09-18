
using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Prontuario
    {

        private DateTime dataAlteracao;
        private string diagnostico;
        private DateTime dataInicial;
        private string descricao;
        private int idProntuario;


        public Prontuario()
        {
        }

        [Required]       
        [Display(Name = "ID Prontu�rio")]
        public int IdProntuario
        {
            get { return idProntuario; }
            set { idProntuario = value; }
        }

        [DataType(DataType.Date)]
        [Display(Name = "Data da Altera��o")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataAlteracao
        {
            get { return dataAlteracao; }
            set { dataAlteracao = value; }
        }
        
        [Display(Name = "Diagn�stico")]
        [StringLength(200, MinimumLength = 200)]
        public string Diagnostico
        {
            get { return diagnostico; }
            set { diagnostico = value; }
        }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data Inicial")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataInicial
        {
            get { return dataInicial; }
            set { dataInicial = value; }
        }

        [Display(Name = "Descri��o")]
        [StringLength(200, MinimumLength = 0)]
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}