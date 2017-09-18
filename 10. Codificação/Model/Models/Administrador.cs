

using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Administrador : Usuario
    {

        private int idAdministrador;

        public Administrador()
        {
        }

        [Required]
        [Display (Name = "ID Administrador")]
        public int IdAdministrador
        {
            get { return idAdministrador; }
            set { idAdministrador = value; }
        }

    }
}