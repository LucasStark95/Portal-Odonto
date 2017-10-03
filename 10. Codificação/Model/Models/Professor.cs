
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Professor : Usuario
    {

        private int idProfessor;

        public Professor()
        {
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Professor")]
        public int IdProfessor
        {
            get { return idProfessor; }
            set { idProfessor = value; }
        }
    }
}