using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    class Tipos
    {
        List<String> tipoSexo = new List<string>();        
        
        public Tipos()
        {
            tipoSexo.Add("Feminino");
            tipoSexo.Add("Masculino");
        }
       
        public Tipos(List<String> tipoEstadoCivil)
        {
            tipoEstadoCivil.Add("Casado(a)");
            tipoEstadoCivil.Add("Solteiro(a)");
            tipoEstadoCivil.Add("Divorciado(a)");
            tipoEstadoCivil.Add("Viúvo(a)");
        }       
    }
}
