
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Triagem
    {

        private int idPaciente;
        private DateTime dataTriagem;
        private string motivoConsulta;   
        private bool procedimento;
        private bool radiologia;
        private bool periapical;
        private bool panoramica;
        private bool interproximal;
        private bool dentistica;
        private bool classeI;
        private bool classeII;
        private bool classeIII;
        private bool classeIV;
        private bool classeV;
        private bool clareamento;
        private bool periodontia;
        private bool cirurgia;
        private bool cirugiaSimples;
        private bool cirugiaAvancada;
        private bool endodontia;
        private bool pediatria;
        private bool protese;
        private bool protesePt;
        private bool protesePpr;
        private bool proteseFixa;
        private int idTriagem;
        private Paciente paciente;

        public Triagem()
        {
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "ID do Paciente")]
        public int IdPaciente
        {
            get { return idPaciente; }
            set { idPaciente = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "ID da Triagem ")]
        public int IdTriagem
        {
            get { return idTriagem; }
            set { idTriagem = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date)]
        [Display(Name = "Data da Triagem")]       
        public DateTime DataTriagem
        {
            get { return dataTriagem; }
            set { dataTriagem = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Motivo da Consulta")]
        [StringLength(200, MinimumLength = 0)]
        public string MotivoConsulta
        {
            get { return motivoConsulta; }
            set { motivoConsulta = value; }
        }

        [Display(Name = "Procedimento")]        
        public bool Procedimento
        {
            get { return procedimento; }
            set { procedimento = value; }
        }

        [Display(Name = "Radiologia")]
        public bool Radiologia
        {
            get { return radiologia; }
            set { radiologia = value; }
        }

        [Display(Name = "Periapical")]
        public bool Periapical
        {
            get { return periapical; }
            set { periapical = value; }
        }

        [Display(Name = "Panorâmica")]
        public bool Panoramica
        {
            get { return panoramica; }
            set { panoramica = value; }
        }

        [Display(Name = "Interproximal")]
        public bool Interproximal
        {
            get { return interproximal; }
            set { interproximal = value; }
        }

        [Display(Name = "Dentística")]
        public bool Dentistica
        {
            get { return dentistica; }
            set { dentistica = value; }
        }

        [Display(Name = "Classe I")]
        public bool ClasseI
        {
            get { return classeI; }
            set { classeI = value; }
        }

        [Display(Name = "Classe II")]
        public bool ClasseII
        {
            get { return classeII; }
            set { classeII = value; }
        }

        [Display(Name = "Classe III")]
        public bool ClasseIII
        {
            get { return classeIII; }
            set { classeIII = value; }
        }

        [Display(Name = "Classe IV")]
        public bool ClasseIV
        {
            get { return classeIV; }
            set { classeIV = value; }
        }

        [Display(Name = "Classe V")]
        public bool ClasseV
        {
            get { return classeV; }
            set { classeV = value; }
        }

        [Display(Name = "Clareamento")]
        public bool Clareamento
        {
            get { return clareamento; }
            set { clareamento = value; }
        }

        [Display(Name = "Periodontia")]
        public bool Periodontia
        {
            get { return periodontia; }
            set { periodontia = value; }
        }

        [Display(Name = "Cirurgia")]
        public bool Cirurgia
        {
            get { return cirurgia; }
            set { cirurgia = value; }
        }

        [Display(Name = "Cirurgia Simples")]
        public bool CirugiaSimples
        {
            get { return cirugiaSimples; }
            set { cirugiaSimples = value; }
        }

        [Display(Name = "Procedimento")]
        public bool CirugiaAvancada
        {
            get { return cirugiaAvancada; }
            set { cirugiaAvancada = value; }
        }

        [Display(Name = "Endodontia")]
        public bool Endodontia
        {
            get { return endodontia; }
            set { endodontia = value; }
        }

        [Display(Name = "Pediatria")]
        public bool Pediatria
        {
            get { return pediatria; }
            set { pediatria = value; }
        }

        [Display(Name = "Protese")]
        public bool Protese
        {
            get { return protese; }
            set { protese = value; }
        }

        [Display(Name = "Prótese PT")]
        public bool ProtesePt
        {
            get { return protesePt; }
            set { protesePt = value; }
        }

        [Display(Name = "Prótese PPR")]
        public bool ProtesePpr
        {
            get { return protesePpr; }
            set { protesePpr = value; }
        }

        [Display(Name = "Prótese Fixa")]
        public bool ProteseFixa
        {
            get { return proteseFixa; }
            set { proteseFixa = value; }
        }

        public Paciente Paciente
        {
            get { return paciente; }
            set { paciente = value; }
        }
    }
}