using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Programación_2
{
    internal class Combustible
    {
        //__Propiedades privadas__
        private int P_IdCombustible;
        private string P_Combustible;


        //__Constuctores__
        public Combustible(int IdComb , string nomComb)
        {
            this.IdCombustible = IdComb;
            this.CombustibleNombre = nomComb;
        }


        //__Metodos de propiedades publicas__
        public int IdCombustible
        {
            get { return this.P_IdCombustible; }
            set { this.P_IdCombustible = value; }
        }

        public string CombustibleNombre
        {
            get { return this.P_Combustible; }
            set { this.P_Combustible = value; }
        }

    }
}
