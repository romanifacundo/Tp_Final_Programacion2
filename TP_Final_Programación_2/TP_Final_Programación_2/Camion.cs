using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Programación_2
{
    internal class Camion : Vehiculo
    {
        //__Propiedades privadas__
        private string P_CajaCarga;
        private int P_DimensionCaja;
        private int P_CargaMax;


        //__Constructores__
        public Camion(int idVehi, string pate, int kil, int anio, string mode, int pVenta, string obser, string col, string cajaCar, int dimCaja, int carMax, int idMar, int idSeg, int idCom) : base(idVehi, pate, kil, anio, mode, pVenta, obser, col, idMar, idSeg, idCom)
        {
            this.CajaCarga = cajaCar;
            this.DimensionCaja = dimCaja;
            this.CargaMaxima = carMax;
        }

        public Camion(int idVehi, string pate, int kil, int anio, string mode, int pVenta, string obser, string col, string cajaCar, int idMar, int idSeg, int idCom) : base(idVehi, pate, kil, anio, mode, pVenta, obser, col, idMar, idSeg, idCom)
        {
            this.CajaCarga = cajaCar;
        }


        //__Metodos de propiedades publicas__
        public string CajaCarga
        {
            get { return this.P_CajaCarga; }
            set { this.P_CajaCarga = value; }
        }

        public int DimensionCaja
        {
            get { return this.P_DimensionCaja; }
            set { this.P_DimensionCaja = value; }
        }

        public int CargaMaxima
        {
            get { return this.P_CargaMax; }
            set { this.P_CargaMax = value; }
        }


        //__Metodos__
        public override void MostrarDatos()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            Console.WriteLine($"Vehículo: {this.IdVehiculo} | Patente: {this.Patente} | KLM: {this.Kilometro} | Año: {this.Anio} | " +
                              $"Modelo: {this.Modelo} | Precio de Venta: {this.PrecioVenta} | Observaciones: {this.Observaciones} | " +
                              $"Color: {this.Color} | Marca: {this.IdMarca} | Segmento: {this.IdSegmento} | Combustible: {this.IdCombustible} | Caja de Carga: {this.CajaCarga}");

            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

     
            if (this.CajaCarga == "SI")
            {
                Console.WriteLine($"Caja de Carga: {this.CajaCarga} | Dimensiones de la Caja: {this.DimensionCaja} | Carga Máxima: {this.CargaMaxima}");
                Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            }

            Console.ResetColor();
        }
    }
}
