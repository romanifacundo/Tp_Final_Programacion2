﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Programación_2
{
    internal class Provincia
    {
        //__Propiedades privadas__
        private int P_IdProvincia;
        private string P_Provincia;


        //__Constructores__
        public Provincia(int IdProvi, string prov)
        {
            this.IdProvincia = IdProvi;
            this.P_Provincia = prov;
        }
        //hello world! 

        //__Metodos de propiedades publicas__
        public int IdProvincia
        {
            get { return this.P_IdProvincia; }
            set { this.P_IdProvincia = value; }
        }

        public string NombreProvincia
        {
            get { return this.P_Provincia; }
            set { this.P_Provincia = value; }
        }
    }
}
