using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Programación_2
{
    internal class Marca : EntidadBase
    {
        //__Propiedades privadas__
        private int P_IdMarca;
        private string P_Marca;


        //__Constructores__
        public Marca(int idMar, string nomMar)
        {
            this.IdMarca = idMar;
            this.NombreMarca = nomMar;
        }


        //__Metodos de propiedades publicas__
        public int IdMarca
        {
            get { return this.P_IdMarca; }
            set { this.P_IdMarca = value; }
        }

        public string NombreMarca
        {
            get { return this.P_Marca; }
            set { this.P_Marca = value; }
        }


        //__Metodos
        public override void MostrarDatos()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{this.IdMarca} | {this.NombreMarca} ");
            Console.ResetColor();
        }
    }
}
