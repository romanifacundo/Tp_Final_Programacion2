using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Programación_2
{
    internal class Concesionaria
    {
        /// <summary>
        /// Pensamos una estructura mas limpia de codigo y mejor organizada centralizando las collecciones en esta clase, con los archivos .txt
        /// almacenados en string para que sea responsable de tener la logica en las operaciones del ABM para las clases.
        /// </summary>

        //__Arvhivos .txt__
        private string _archivoVehiculos = "";
        private string _archivoAutosCamionetas = "";
        private string _archivoMotos = "";
        private string _archivoCamiones = "";
        private string _archivoMarcas = "";
        private string _archivoVentas = "";
        private string _archivoClientes = "clientes.txt";
        private string _archivoLocalidades = "";
        private string _archivoProvincias = "";
        private string _archivoCombustible = "";
        private string _archivoSegmento = "";

        //__Declaracion Listas privadas con relacion de ensamble a clases__ 
        private List<Vehiculo> _vehiculosList;
        private List<AutoCamioneta> _autosCamionetasList;
        private List<Moto> _motosList;
        private List<Camion> _camionesList;
        private List<Marca> _marcasList;
        private List<Venta> _ventasList;
        private List<Cliente> _clientesList;
        //__Declaracion Listas privadas y para ser inicializadas__
        private List<Combustible> _combustiblesList;
        private List<Segmento> _segmentosList;
        private List<Localidad> _localidadesList;
        private List<Provincia> _provinciasList;


        //__Constructores__
        public Concesionaria()
        {
            this._vehiculosList = new List<Vehiculo>();
            this._autosCamionetasList = new List<AutoCamioneta>();
            this._motosList = new List<Moto>();
            this._camionesList = new List<Camion>();
            this._marcasList = new List<Marca>();
            this._ventasList = new List<Venta>();
            this._clientesList = new List<Cliente>();
            this._localidadesList = new List<Localidad>();
            this._provinciasList = new List<Provincia>();


            //__List incializadas__
            this._segmentosList = new List<Segmento>
            {
                new Segmento(1, "Sedan"),
                new Segmento(2, "Coupe"),
                new Segmento(3, "Suv"),
                new Segmento(4, "Pickup"),
                new Segmento(5, "Scooter"),
                new Segmento(6, "Enduro"),
                new Segmento(7, "Ruta"),
                new Segmento(8, "Camion")
            };


            this._combustiblesList = new List<Combustible>
            {
                new Combustible(1, "Nafta"),
                new Combustible(2, "Diesel"),
                new Combustible(3, "Gnc"),
                new Combustible(4, "Electrico")
            };


            this._localidadesList = new List<Localidad>
            {
                new Localidad(1,"San Nicolas",1),
                new Localidad(2,"Rosario", 5),
                new Localidad(3,"Pergamino",1),
                new Localidad(4,"Ramallo", 1),
                new Localidad(5,"San Pedro",1)
            };


            this._provinciasList = new List<Provincia>
            {
                 new Provincia(1, "Buenos Aires"),
                 new Provincia(2, "Córdoba"),
                 new Provincia(3, "Entre Ríos"),
                 new Provincia(4, "San Luis"),
                 new Provincia(5, "Santa Fe")
            };
        }


        //__Metodos de acciones ABM__

        public void CargarCliente()
        {
            Console.WriteLine("**Ingresa ID del CLIENTE**");
            int idCli = int.Parse(Console.ReadLine());

            Console.WriteLine("**Ingresa el Nombre del CLIENTE**");
            string clienteNombre = Console.ReadLine();

            Console.WriteLine("**Ingresa el C.U.I.T del CLIENTE**");
            long CUIT = long.Parse(Console.ReadLine());

            Console.WriteLine("**Ingresa el DOMICILIO del CLIENTE**");
            string domicilio = Console.ReadLine();

            Console.WriteLine("**Ingresa el TELEFONO del CLIENTE**");
            long tel = long.Parse(Console.ReadLine());

            Console.WriteLine("**Ingresa el Correo Electronico del CLIENTE**");
            string corrElect = Console.ReadLine();

            Console.WriteLine("**Ingresa el nombre de la Localidad del CLIENTE**");
            MostrarLocalidades();
            string local = Console.ReadLine();


            Cliente cli = new Cliente(idCli, clienteNombre, CUIT, domicilio, tel, corrElect, local);

            this._clientesList.Add(cli);

            Console.WriteLine("\n");
            Console.WriteLine("<<<<<<<Cliente agregado con EXITO>>>>>");

            GrabarArchivo(this._archivoClientes);
        }

        public void ListarClientes() 
        {
            LeerArchivo(this._archivoClientes);

            foreach (Cliente i in this._clientesList)
            {
                i.MostrarDatos();
            }
        }


        //__Metodos privados de la clase__

        private void GrabarArchivo(string _archivo)
        {
            FileStream x;
            StreamWriter grabar;

            if (_archivo == this._archivoClientes)
            {
                if (File.Exists(this._archivoClientes))
                {
                    x = new FileStream(this._archivoClientes, FileMode.Append);
                    grabar = new StreamWriter(x);

                    for (int i = 0; i < this._clientesList.Count; i++)
                    {
                        grabar.WriteLine(this._clientesList[i].IdCliente + " | "
                                         + this._clientesList[i].NombreCliente + " | "
                                         + this._clientesList[i].CUIT + " | "
                                         + this._clientesList[i].Domicilio + " | "
                                         + this._clientesList[i].Telefono + " | "
                                         + this._clientesList[i].CorreoElectronico + " | "
                                         + this._clientesList[i].NombreLocalidad);

                    }

                    grabar.Close();
                    x.Close();
                }

            }

        }

        private void LeerArchivo(string _archivo)
        {
            FileStream x;
            StreamReader Leer;
            string cadena;
            string[] datos;

            if (File.Exists(this._archivoClientes))
            {
                x = new FileStream(this._archivoClientes, FileMode.Open);
                Leer = new StreamReader(x);

                while (!Leer.EndOfStream)
                {
                    cadena = Leer.ReadLine();
                    datos = cadena.Split('|');

                    Cliente cli = new Cliente(
                            int.Parse(datos[0]),
                            datos[1],
                            long.Parse(datos[2]),
                            datos[3],
                            long.Parse(datos[4]),
                            datos[5],
                            datos[6]);

                    this._clientesList.Add(cli);
                }

                Leer.Close();
                x.Close();
            }
        }

        private void MostrarLocalidades()
        {
            for (int i = 0; i < this._localidadesList.Count; i++)
            {
                Console.WriteLine(this._localidadesList[i].NombreLocalidad);
            }
        }

    }
}
