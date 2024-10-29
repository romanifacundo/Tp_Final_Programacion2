using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Programación_2
{
    internal class AutoCamioneta : Vehiculo
    {
        //__Constructores__
        public AutoCamioneta(int idVehi,string pate, int kil, int anio, string mode, int pVenta, string obser, string col, int idMar, string nomMar, int idSeg, string nomSeg, int idCom, string nomCom) : base(idVehi, pate, kil, anio, mode, pVenta, obser, col, idMar, nomMar, idSeg, nomSeg, idCom, nomCom)
        {
            
        } 
        
        public override void MostrarDatos()
        {
            base.MostrarDatos();
        }
        
    }
}
