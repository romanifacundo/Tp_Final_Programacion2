using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Programación_2
{
    internal class Cliente
    {
        //__Propiedades privadas__
        private int P_IdCliente;
        private string P_NombreCliente;
        private long P_CUIT;
        private string P_Domicilio;
        private long P_Telefono;
        private string P_Correo;
        private int P_IdLocalidad;


        //__Constructores__
        public Cliente(int idCli, string NomCli, long CUIT, string dom, long tel, string correo, int idLocali) 
        {
            this.IdCliente = idCli;
            this.NombreCliente = NomCli;
            this.CUIT = CUIT;
            this.Domicilio = dom;
            this.Telefono = tel;
            this.CorreoElectronico = correo;
            this.IdLocalidad = idLocali;
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

        public long CUIT
        {
            get { return this.P_CUIT; }
            set { this.P_CUIT = value; }
        }

        public string Domicilio
        {
            get { return this.P_Domicilio; }
            set { this.P_Domicilio = value; }
        }

        public long Telefono
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
    }
}
