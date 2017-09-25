
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Aluno : Usuario
    {

        private int ciclo;
        private int idAluno;

        public Aluno()
        {
        }

       [Required]
       [Display (Name = "Ciclo")]
        public int Ciclo
        {
            get { return ciclo; }
            set { ciclo = value; }
        }

        [Required]
        [Display (Name = "ID Aluno")]
        public int IdAluno
        {
            get { return idAluno; }
            set { idAluno = value; }
        }
    }
}