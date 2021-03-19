using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PArcial
{
    class datos
    {
        string nombre, temperatura;
        DateTime fecha;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Temperatura { get => temperatura; set => temperatura = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
