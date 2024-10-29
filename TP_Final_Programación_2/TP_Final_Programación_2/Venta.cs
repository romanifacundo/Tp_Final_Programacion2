using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TP_Final_Programación_2
{
    internal class Venta : EntidadBase
    {
        //__Propiedades privadas__
        private int P_IdVenta;
        private int P_IdCliente;
        private string P_NombreCliente;
        private int P_IdVehiculo;
        private string P_NombreVehiculo;
        private DateTime P_FechaCompra;
        private DateTime P_FechaEntrega;
        private int P_PrecioVehiculo;
        private float P_PorcentajeDescuento = 10f; 
        private float P_PorcentajeIva = 21f; 


        //__Constructores__
        public Venta(int idVen, int idCli, string nomCli , int idVehi, string nomVehi, string fechaC, string fechaE, int preVehiculo)
        {
            this.IdVenta = idVen;
            this.IdCliente = idCli;
            this.NombreCliente = nomCli;
            this.IdVehiculo = idVehi;
            this.NombreVehiculo= nomVehi;
            this.FechaCompra = DateTime.Parse(fechaC);
            this.FechaVenta = DateTime.Parse(fechaE);
            this.PrecioVehiculo = preVehiculo;
        }


        //__Metodos de propiedades publicas__
        public int IdVenta
        {
            get { return this.P_IdVenta; }
            set { this.P_IdVenta = value; }
        }
        public int IdCliente
        {
            get { return this.P_IdCliente; }
            set { this.P_IdCliente = value; }
        }

        public string NombreCliente
        {
            get { return this.P_NombreCliente; }
            set { this.P_NombreCliente = value; }
        }

        public int IdVehiculo
        {
            get { return this.P_IdVehiculo; }
            set { this.P_IdVehiculo = value; }
        }

        public string NombreVehiculo
        {
            get { return this.P_NombreVehiculo; }
            set { this.P_NombreVehiculo = value; }
        }

        public DateTime FechaCompra
        {
            get { return this.P_FechaCompra; }
            set { this.P_FechaCompra = value; }
        }

        public DateTime FechaVenta
        {
            get { return this.P_FechaEntrega; }
            set { this.P_FechaEntrega = value; }
        }

        public int PrecioVehiculo 
        {
            get { return this.P_PrecioVehiculo; }
            set { this.P_PrecioVehiculo = value; }
        }

        /* __Propiedades de solo lectura__ */
        public float Subtotal
        {
            get { return this.P_PrecioVehiculo; }
        }

        public float Descuento
        {
            get { return Subtotal * (P_PorcentajeDescuento / 100); }
        }

        public float Iva
        {
            get { return (Subtotal - Descuento) * (P_PorcentajeIva / 100); }
        }

        public float Total
        {
            get { return (Subtotal - Descuento) + Iva; }
        }

        //__Metodos__
        public override void MostrarDatos()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            Console.WriteLine($" VENTA: {this.IdVenta} | ID Cliente: {this.IdCliente} | Cliente: {this.NombreCliente} | " +
                              $"ID Vehículo: {this.IdVehiculo} | Vehículo: {this.NombreVehiculo} | " +
                              $"Fecha de Compra: {this.FechaCompra} | Fecha de Entrega: {this.FechaVenta} | " +
                              $"Subtotal: {this.Subtotal} | IVA: {this.Iva} | Descuento: {this.Descuento} | Total: {this.Total}");

            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            Console.ResetColor();
        }

    }
}
