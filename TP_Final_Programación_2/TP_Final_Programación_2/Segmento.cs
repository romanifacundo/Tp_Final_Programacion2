using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Programación_2
{
    internal class Segmento : EntidadBase
    {
        //__Propiedades privadas__
        private int P_IdSegmento;
        private string P_Segmento;


        //__Constructores__
        public Segmento(int idSeg, string segNom) 
        {
            this.IdSegmento = idSeg;
            this.SegmentoNombre = segNom;
        }


        //__Metodos de propiedades publicas__
        public int IdSegmento
        {
            get { return this.P_IdSegmento; }
            set { this.P_IdSegmento = value; }
        }

        public string SegmentoNombre
        {
            get { return this.P_Segmento; }
            set { this.P_Segmento = value; }
        }


        //__Metodos__
        public override void MostrarDatos()
        {
            Console.ForegroundColor = ConsoleColor.Green;      
            Console.WriteLine($"{this.IdSegmento} ; {this.SegmentoNombre}");
            Console.ResetColor();
        }
    }
}
