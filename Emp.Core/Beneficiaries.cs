using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Core
{
    public class Beneficiaries
    {
        public int idBenficiario { get; set; }

        public int idEmpleado { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }

        public string AMaterno { get; set; }

        public DateTime FNacimiento { get; set; }
        public int NumEmpleado { get; set; }
        public string Curp { get; set; }
        public string SSN { get; set; }
        public string Telefono { get; set; }
        public int Nacionalidad { get; set; }
        public decimal Porcentaje { get; set; }
    }
}
