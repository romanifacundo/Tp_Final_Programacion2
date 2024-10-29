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
        public Moto(int idVehi, int cil, string pate, int kil, int anio, string mode, int pVenta, string obser, string col, int idMar, string nomMar, int idSeg, string nomSeg, int idCom, string nomCom) : base (idVehi, pate, kil, anio, mode, pVenta, obser, col, idMar, nomMar, idSeg, nomSeg, idCom, nomCom)
        {
            this.Cilindrada = cil;
        }


        //__Metodos de propiedades publicas__
        public int Cilindrada
        {
            get { return this.P_Cilindrada; }
            set { this.P_Cilindrada = value; }
        }


        public override void MostrarDatos()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            Console.WriteLine($" Vehículo: {this.IdVehiculo} | Patente: {this.Patente} | KLM: {this.Kilometro} | Año: {this.Anio} | " +
                              $"Modelo: {this.Modelo} | Precio de Venta: {this.PrecioVenta} | Observaciones: {this.Observaciones} | " +
                              $"Color: {this.Color} | Marca: {this.NombreMarca} | Segmento: {this.NombreSegmento} | Combustible: {this.NombreCombustible} | Cilindrada: {this.Cilindrada}");

            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            Console.ResetColor();
        }
    }
}

