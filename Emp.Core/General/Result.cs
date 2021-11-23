using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Core.General
{
   public class Result<T>
    {
        public List<T> LsData { get; set; }
        public T Data { get; set; }
        public int CodError { get; set; }

        public string Mensaje { get; set; }

        public bool Exitoso { get; set; }

        public Result()
        {
            this.CodError = 0;
            this.Mensaje = "";
            this.Exitoso = false;
        }
    }
}
