using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Programación_2
{
    internal class Vehiculo
    {
        //__Propiedades privadas__
        private int P_IdVehiculo;
        private string P_Patente;
        private int P_Kilometro;
        private int P_Anio;
        private string P_Modelo;
        private int P_PrecioVta;
        private string P_Observaciones;
        private string P_Color;
        private int P_IdMarca;
        private int P_IdSegmento;
        private int P_IdCombustible;
       

        //__Constructores__
        public Vehiculo(int idVehi, string pate, int kil, int anio, string mode, int pVenta, string obser, string col, int idMar, int idSeg, int idCom)
        {
            this.IdVehiculo = idVehi;
            this.Patente = pate;
            this.Kilometro = kil;
            this.Anio = anio;
            this.Modelo = mode;
            this.PrecioVenta = pVenta;
            this.Observaciones = obser;
            this.Color = col;
            this.IdMarca = idMar;
            this.IdSegmento = idSeg;
            this.IdCombustible = idCom;
        }


        //__Metodos de propiedades publicas__
        public int IdVehiculo 
        {
            get { return this.P_IdVehiculo; }
            set { this.P_IdVehiculo = value; }
        }

        public string Patente
        {
            get { return this.P_Patente; }
            set { this.P_Patente = value; }
        }

        public int Kilometro
        {
            get { return this.P_Kilometro; }
            set { this.P_Kilometro = value; }
        }

        public int Anio
        {
            get { return this.P_Anio; }
            set { this.P_Anio = value; }
        }

        public string Modelo
        {
            get { return this.P_Modelo; }
            set { this.P_Modelo = value; }
        }

        public int PrecioVenta
        {
            get { return this.P_PrecioVta; }
            set { this.P_PrecioVta = value; }
        }

        public string Observaciones
        {
            get { return this.P_Observaciones; }
            set { this.P_Observaciones = value; }
        }

        public string Color
        {
            get { return this.P_Color; }
            set { this.P_Color = value; }
        }

        public int IdMarca
        {
            get { return this.P_IdMarca; }
            set { this.P_IdMarca = value; }
        }

        public int IdSegmento
        {
            get { return this.P_IdSegmento; }
            set { this.P_IdSegmento = value; }
        }

        public int IdCombustible
        {
            get { return this.P_IdCombustible; }
            set { this.P_IdCombustible = value; }
        }


        //__Metodos__
        public virtual void MostrarDatos()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            Console.WriteLine($" ID Vehículo: {this.IdVehiculo} | Patente: {this.Patente} | Kilómetros: {this.Kilometro} | Año: {this.Anio} | " +
                              $"Modelo: {this.Modelo} | Precio de Venta: {this.PrecioVenta} | Observaciones: {this.Observaciones} | " +
                              $"Color: {this.Color} | Marca: {this.IdMarca} | Segmento: {this.IdSegmento} | Combustible: {this.IdCombustible}");

            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            Console.ResetColor(); 
        }

    }
}
