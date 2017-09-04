

using System.ComponentModel.DataAnnotations;


namespace Model.Models
{
    public class Tecnico : Usuario
    {

        private int idTecnico;

        public Tecnico()
        {
        }

        [Required]
        [Display (Name = "ID T�cnico")]
        public int IdTecnico
        {
            get { return idTecnico; }
            set { idTecnico = value; }
        }

    }
}