

using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Anamnese
    {

        private int cod_pergunta;
        private string respostaPergunta;
        private string conclusao;
        private int idAnamnese;

        public Anamnese()
        {
        }

        [Required]
        [Display(Name = "ID Anamnese")]
        public int IdAnamnese
        {
            get { return idAnamnese; }
            set { idAnamnese = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display (Name = "Codigo Pergunta")]
        public int CodPergunta
        {
            get { return cod_pergunta; }
            set { cod_pergunta = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display (Name = "Resposta")]
        public string RespostaPergunta
        {
            get { return respostaPergunta; }
            set { respostaPergunta = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display (Name = "Conclusão")]
        public string Conclusao
        {
            get { return conclusao; }
            set { conclusao = value; }
        }
    }
}