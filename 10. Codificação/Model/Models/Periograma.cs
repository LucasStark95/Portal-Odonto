
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

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display (Name = "ID Periograma")]
        public int IdPeriograma
        {
            get { return idPeriograma; }
            set { idPeriograma = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Numero do Dente")]
        public int NumeroDente {
            get { return numeroDente; }
            set { numeroDente = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Diagnóstico")]
        public string Diagnostico {
            get { return diagnostico; }
            set { diagnostico = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Proagnóstico")]
        public string Proagnostico {
            get { return proagnostico; }
            set { proagnostico = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Inicio")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public string DataInicial {
            get { return dataInicial; }
            set { dataInicial = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date)]
        [Display(Name = "Data da Reavaliação")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public string DataReavaliacao {
            get { return dataReavaliacao; }
            set { dataReavaliacao = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Face Distal")]
        public int FaceDistal { get
            { return faceDistal; }
            set { faceDistal = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Face Mesial")]
        public int FaceMesial {
            get { return faceMesial; }
            set { faceMesial = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Face Vestibular")]
        public string FaceVestibular {
            get { return faceVestibular; }
            set { faceVestibular = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Face Lingual")]
        public string FaceLingual {
            get { return faceLingual; }
            set { faceLingual = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Face Palatina")]
        public string FacePalatina {
            get { return facePalatina; }
            set { facePalatina = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Face Medial Distal")]
        public int FaceMedialDistal {
            get { return faceMedialDistal; }
            set { faceMedialDistal = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Mobilidade")]
        public int Mobilidade {
            get { return mobilidade; }
            set { mobilidade = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Bifurcação")]
        public string Bifurcacao {
            get { return bifurcacao; }
            set { bifurcacao = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Indice de Sangramento")]
        public double IndiceSagramento {
            get { return indiceSagramento; }
            set { indiceSagramento = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Indice de Biofilme")]
        public double IndiceBioFilme {
            get { return indiceBioFilme; }
            set { indiceBioFilme = value; }
        }
    }
}