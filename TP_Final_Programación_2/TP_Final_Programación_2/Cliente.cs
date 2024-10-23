using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Programación_2
{
    internal class Cliente : EntidadBase
    {
        //__Propiedades privadas__
        private int P_IdCliente;
        private string P_NombreCliente;
        private string P_CUIT;
        private string P_Domicilio;
        private string P_Telefono;
        private string P_Correo;
        private int P_IdLocalidad;
        private string P_NombreLocalidad;


        //__Constructores__
        public Cliente(int idCli, string NomCli, string CUIT, string dom, string tel, string correo, string nomLocal) 
        {
            this.IdCliente = idCli;
            this.NombreCliente = NomCli;
            this.CUIT = CUIT;
            this.Domicilio = dom;
            this.Telefono = tel;
            this.CorreoElectronico = correo;
            this.NombreLocalidad = nomLocal;
        }


        //__Metodos de propiedades publicas__
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

        public string CUIT
        {
            get { return this.P_CUIT; }
            set { this.P_CUIT = value; }
        }

        public string Domicilio
        {
            get { return this.P_Domicilio; }
            set { this.P_Domicilio = value; }
        }

        public string Telefono
        {
            get { return this.P_Telefono; }
            set { this.P_Telefono = value; }
        }

        public string CorreoElectronico
        {
            get { return this.P_Correo; }
            set { this.P_Correo = value; }
        }

        public int IdLocalidad
        {
            get { return this.P_IdLocalidad; }
            set { this.P_IdLocalidad = value; }
        }

        public string NombreLocalidad
        {
            get { return this.P_NombreLocalidad; }
            set { this.P_NombreLocalidad = value; }
        }

        
        //__Implementa metodo de la clase abstracta EntidadBase__
        public override void MostrarDatos()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine($" ID Cliente:{this.IdCliente} | Nombre:{this.NombreCliente} | CUIT:{this.CUIT} | " +
                                  $"Domicilio:{this.Domicilio} | Teléfono:{this.Telefono} | Correo Electrónico:{this.CorreoElectronico} | " +
                                  $" Localidad:{this.NombreLocalidad}");
            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }

    }
}
