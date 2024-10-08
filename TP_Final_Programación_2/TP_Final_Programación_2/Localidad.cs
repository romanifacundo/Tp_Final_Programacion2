using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Programación_2
{
    internal class Localidad
    {
        //__Propiedades privadas__
        private int P_IdLocalidad;
        private string P_Localidad;
        private int P_IdProvincia;


        //__Constructores__
        public Localidad(int IdLocal, string Local, int IdProvi)
        {
            this.IdLocalidad = IdLocal;
            this.NombreLocalidad = Local;
            this.IdProvincia = IdProvi;
        }


        //__Metodos de propiedades publicas__
        public int IdLocalidad
        {
            get { return this.P_IdLocalidad; }
            set { this.P_IdLocalidad = value; }
        }

        public string NombreLocalidad
        {
            get { return this.P_Localidad; }
            set { this.P_Localidad = value; }
        }

        public int IdProvincia
        {
            get { return this.P_IdProvincia; }
            set { this.P_IdProvincia = value; }
        }
    }
}
