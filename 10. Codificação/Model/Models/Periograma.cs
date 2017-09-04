
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Periograma {

        private int numeroDente;
        private string diagnostico;
        private string proagnostico;
        private string dataInicial;
        private string dataReavaliacao;
        private int faceDistal;
        private int faceMesial;
        private string faceVestibular;
        private string faceLingual;
        private string facePalatina;
        private int faceMedialDistal;
        private int mobilidade;
        private string bifurcacao;
        private double indiceSagramento;
        private double indiceBioFilme;
        private int idPeriograma;


        public Periograma()
        {
        }

        [Required]
        [Display (Name = "ID Periograma")]
        public int IdPeriograma
        {
            get { return idPeriograma; }
            set { idPeriograma = value; }
        }

        [Required]
        [Display(Name = "Numero do Dente")]
        public int NumeroDente {
            get { return numeroDente; }
            set { numeroDente = value; }
        }

        [Required]
        [Display(Name = "Diagnóstico")]
        public string Diagnostico {
            get { return diagnostico; }
            set { diagnostico = value; }
        }

        [Required]
        [Display(Name = "Proagnóstico")]
        public string Proagnostico {
            get { return proagnostico; }
            set { proagnostico = value; }
        }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Inicio")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public string DataInicial {
            get { return dataInicial; }
            set { dataInicial = value; }
        }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data da Reavaliação")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public string DataReavaliacao {
            get { return dataReavaliacao; }
            set { dataReavaliacao = value; }
        }

        [Required]
        [Display(Name = "Face Distal")]
        public int FaceDistal { get
            { return faceDistal; }
            set { faceDistal = value; }
        }

        [Required]
        [Display(Name = "Face Mesial")]
        public int FaceMesial {
            get { return faceMesial; }
            set { faceMesial = value; }
        }

        [Required]
        [Display(Name = "Face Vestibular")]
        public string FaceVestibular {
            get { return faceVestibular; }
            set { faceVestibular = value; }
        }

        [Required]
        [Display(Name = "Face Lingual")]
        public string FaceLingual {
            get { return faceLingual; }
            set { faceLingual = value; }
        }

        [Required]
        [Display(Name = "Face Palatina")]
        public string FacePalatina {
            get { return facePalatina; }
            set { facePalatina = value; }
        }

        [Required]
        [Display(Name = "Face Medial Distal")]
        public int FaceMedialDistal {
            get { return faceMedialDistal; }
            set { faceMedialDistal = value; }
        }

        [Required]
        [Display(Name = "Mobilidade")]
        public int Mobilidade {
            get { return mobilidade; }
            set { mobilidade = value; }
        }

        [Required]
        [Display(Name = "Bifurcação")]
        public string Bifurcacao {
            get { return bifurcacao; }
            set { bifurcacao = value; }
        }

        [Required]
        [Display(Name = "Indice de Sangramento")]
        public double IndiceSagramento {
            get { return indiceSagramento; }
            set { indiceSagramento = value; }
        }

        [Required]
        [Display(Name = "Indice de Biofilme")]
        public double IndiceBioFilme {
            get { return indiceBioFilme; }
            set { indiceBioFilme = value; }
        }
    }
}