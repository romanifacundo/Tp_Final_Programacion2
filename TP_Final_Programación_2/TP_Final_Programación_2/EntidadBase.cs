using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Programación_2
{
    internal abstract class EntidadBase
    {
        /// <summary>
        /// Pensamos esta clase abstracta no para jerarquia de herencia pero si poder sobre escribir el metodo para mostrar los datos
        /// en clases como Cliente,Localidad,Provincia,Marca,Segmento,Combustible..
        /// </summary>

        public abstract void MostrarDatos();
    }
}
