using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Modulo : BusinessEntities
    {
        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private string _ejecuta;
        public string Ejecuta 
        {
            get { return _ejecuta; }
            set { _ejecuta = value; } 
        }
    }
}
