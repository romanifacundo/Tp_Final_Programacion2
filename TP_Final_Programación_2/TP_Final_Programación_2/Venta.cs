﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Programación_2
{
    internal class Venta : EntidadBase
    {
        //__Propiedades privadas__
        private int P_IdCliente;
        private int P_IdVehiculo;
        private DateTime P_FechaCompra;
        private DateTime P_FechaEntrega;


        //__Constructores__
        public Venta(int idCli, int idVehi, string fechaC, string fechaE)
        {
            this.IdCliente = idCli;
            this.IdVehiculo = idVehi;
            this.FechaCompra = DateTime.Parse(fechaC);
            this.FechaVenta = DateTime.Parse(fechaE);
        }


        //__Metodos de propiedades publicas__
        public int IdCliente
        {
            get { return this.P_IdCliente; }
            set { P_IdCliente = value; }
        }

        public int IdVehiculo
        {
            get { return this.P_IdVehiculo; }
            set { P_IdVehiculo = value; }
        }

        public DateTime FechaCompra
        {
            get { return this.P_FechaCompra; }
            set { P_FechaCompra = value; }
        }

        public DateTime FechaVenta
        {
            get { return this.P_FechaEntrega; }
            set { P_FechaEntrega = value; }
        }

        /* __Propiedades de solo lectura__ */
        public float Subtotal
        {
            get { return 10.5f /*__A desarrollar*/; }
        }

        public float Iva
        {
            get { return 21.5f /*__A desarrollar*/; }
        }

        public float Total
        {
            get { return 21.5f /*__A desarrollar*/; }
        }

        public float Descuento
        {
            get { return 10.5f /*__A desarrollar*/; }
        }


        //__Metodos__
        public override void MostrarDatos()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            Console.WriteLine($" ID Cliente: {this.IdCliente} | ID Vehículo: {this.IdVehiculo} | " +
                              $"Fecha de Compra: {this.FechaCompra} | Fecha de Venta: {this.FechaVenta}");

            //__ Mostrar Subtotal IVA Total  Descuento__
            Console.WriteLine($"Subtotal: {this.Subtotal} | IVA: {this.Iva} | " +
                              $"Descuento: {this.Descuento} | Total: {this.Total}");

            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            Console.ResetColor();
        }

    }
}
