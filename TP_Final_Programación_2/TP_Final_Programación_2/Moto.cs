using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Programación_2
{
    internal class Moto : Vehiculo
    {
        //__Propiedades privadas__
        private int P_Cilindrada;


        //__Constructores__
        public Moto(int cil, int idVehi, string pate, int kil, int anio, string mode, int pVenta, string obser, string col, int idMar, int idSeg, int idCom) : base (idVehi, pate, kil, anio, mode, pVenta, obser, col, idMar, idSeg, idCom)
        {
            this.Cilindrada = cil;
        }


        //__Metodos de propiedades publicas__
        public int Cilindrada
        {
            get { return this.P_Cilindrada; }
            set { this.P_Cilindrada = value; }
        }
    }
}
