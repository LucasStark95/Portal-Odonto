

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
        [Display (Name = "ID Técnico")]
        public int IdTecnico
        {
            get { return idTecnico; }
            set { idTecnico = value; }
        }

    }
}