using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        //private string _archivoVehiculos = "";
        //private string _archivoAutosCamionetas = "";
        //private string _archivoMotos = "";
        //private string _archivoCamiones = "";
        //private string _archivoMarcas = "";
        //private string _archivoVentas = "";
        //private string _archivoClientes = "clientes.txt";
        //private string _archivoLocalidades = "";
        //private string _archivoProvincias = "";
        //private string _archivoCombustible = "";
        //private string _archivoSegmento = "";
        //__Arvhivos .txt constanes para evaluar en sl SWITCH__
        private const string _archivoClientes = "clientes.txt";
        private const string _archivoVentas = "ventas.txt";
        private const string _archivoVehiculos = "vehiculos.txt";
        private const string _archivoAutosCamionetas = "autos_camionetas.txt";
        private const string _archivoMotos = "motos.txt";
        private const string _archivoCamiones = "camiones.txt";
        private const string _archivoMarcas = "marcas.txt";
        private const string _archivoLocalidades = "localidades.txt";
        private const string _archivoProvincias = "provincias.txt";
        private const string _archivoCombustible = "combustible.txt";
        private const string _archivoSegmento = "segmento.txt";


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


        //__Metodos de acciones cargar datos__
        public void CargarCliente()
        {
            Console.WriteLine("\n");
            Console.WriteLine("**Ingresa ID del CLIENTE**");
            string idCli = Console.ReadLine();
            ValidarIdNumericoOExiste(idCli);

            Console.WriteLine("**Ingresa el Nombre del CLIENTE**");
            string clienteNombre = Console.ReadLine();

            Console.WriteLine("**Ingresa el C.U.I.T del CLIENTE**");
            string CUIT = Console.ReadLine();
            ValidarCUIT(CUIT);

            Console.WriteLine("**Ingresa el DOMICILIO del CLIENTE**");
            string domicilio = Console.ReadLine();

            Console.WriteLine("**Ingresa el TELEFONO del CLIENTE**");
            long tel = long.Parse(Console.ReadLine());

            Console.WriteLine("**Ingresa el Correo Electronico del CLIENTE**");
            string corrElect = Console.ReadLine();

            Console.WriteLine("**Ingresa el nombre de la Localidad del CLIENTE**");
            MostrarLocalidades();
            string local = Console.ReadLine();


            Cliente cli = new Cliente(int.Parse(idCli), clienteNombre, CUIT, domicilio, tel, corrElect, local);

            this._clientesList.Add(cli);

            Console.WriteLine("\n");
            Console.WriteLine("<<<<<<<Cliente agregado con EXITO>>>>>");
            Console.ReadKey();

            GrabarArchivo(_archivoClientes);
        }

        public void ActualizarCliente() //__REVISAR Metodo INCOMPLETO!!__
        {
            ListarClientes();

            Console.WriteLine("\n");
            Console.WriteLine("**Ingresa ID del CLIENTE¨ que desea actualizar**");
            string idCli = Console.ReadLine();
            ValidarIdSoloNumerico(idCli);

            for (int i = 0; i < this._clientesList.Count; i++)
            {
                if (int.Parse(idCli) == this._clientesList[i].IdCliente)
                {
                    Console.WriteLine("Que datos desea Actualizar? (INGRESE LA PALABRA)");
                    string palabra = Console.ReadLine();

                    switch (palabra) 
                    {
                        case "Nombre":
                            Console.WriteLine("**Ingresa el Nombre del CLIENTE**");
                            string clienteNombre = Console.ReadLine();
                            GrabarArchivo(_archivoClientes);
                            break;
                        case "CUIT":
                            break;
                        case "Domicilio":
                            break;
                    }

                }
            }

            GrabarArchivo(_archivoClientes);
        }

        public void BorrarCliente()
        {
            ListarClientes();
            Console.ResetColor();
            Console.WriteLine("\n");
            Console.WriteLine("**Ingresa ID del CLIENTE¨ que desea borrar**");
            string idCli = Console.ReadLine();
            ValidarIdSoloNumerico(idCli);

            for (int i = 0; i < this._clientesList.Count; i++)
            {
                if(int.Parse(idCli) == this._clientesList[i].IdCliente)
                {
                    this._clientesList.RemoveAt(i);
                }
            }

            Console.WriteLine("**CLIENTE BORRADO CORRECTAMENTE**");
            Console.ReadLine();
            GrabarArchivo(_archivoClientes);   
        }


        //__Metodos de acciones listar datos__
        public void ListarClientes()
        {
            LeerArchivo(_archivoClientes);

            foreach (Cliente i in this._clientesList)
            {
                i.MostrarDatos();
            }
        }


        //__Metodos privados de la clase__
        private void GrabarArchivo(string _archivo)
        {
            LeerArchivo(_archivo);

            FileStream x;
            StreamWriter grabar;

            if (File.Exists(_archivo))
            {
                switch (_archivo)//__refactorizar para cada .txt en switch para no usar muchos if()__
                {
                    case _archivoClientes:

                        x = new FileStream(_archivoClientes, FileMode.Create);
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

                        break;

                    case _archivoVentas:

                        x = new FileStream(_archivoVentas, FileMode.Create);
                        grabar = new StreamWriter(x);

                        break;

                    case _archivoVehiculos:

                        x = new FileStream(_archivoVehiculos, FileMode.Create);
                        grabar = new StreamWriter(x);

                        break;

                    case _archivoAutosCamionetas:

                        x = new FileStream(_archivoAutosCamionetas, FileMode.Create);
                        grabar = new StreamWriter(x);

                        break;

                    case _archivoMotos:

                        x = new FileStream(_archivoMotos, FileMode.Create);
                        grabar = new StreamWriter(x);

                        break;

                    case _archivoCamiones:

                        x = new FileStream(_archivoCamiones, FileMode.Create);
                        grabar = new StreamWriter(x);

                        break;

                    default:
                        break;
                }
            }

        }


        private void LeerArchivo(string _archivo)
        {
            FileStream x;
            StreamReader Leer;
            string cadena;
            string[] datos;

            if (File.Exists(_archivoClientes))
            {
                if (this._clientesList.Count == 0)
                {
                    x = new FileStream(_archivoClientes, FileMode.Open);
                    Leer = new StreamReader(x);

                    while (!Leer.EndOfStream)
                    {
                        cadena = Leer.ReadLine();
                        datos = cadena.Split('|');

                        Cliente cli = new Cliente(
                                int.Parse(datos[0]),
                                datos[1],
                                datos[2],
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
            else
            {
                Console.WriteLine("\n El archivo no existe.");
            }
        }


        private void MostrarLocalidades()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("::::::::::::::::::::::::::::::::::::");

            for (int i = 0; i < this._localidadesList.Count; i++)
            {
                Console.WriteLine(this._localidadesList[i].NombreLocalidad);
            }

            Console.WriteLine("::::::::::::::::::::::::::::::::::::");

            Console.ResetColor();
        }


        //__Validaciones__
        private void ValidarIdNumericoOExiste(string _id)
        {
            LeerArchivo(_archivoClientes);

            bool idValido = false; //__bandera para el bucle__ 
            int idCli;

            do
            {
                if (!int.TryParse(_id, out idCli) || idCli <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("_________________________________________________");
                    Console.WriteLine("ID no válido, deben ser solo números positivos!");
                    Console.WriteLine("_________________________________________________");
                    Console.ResetColor();
                    _id = Console.ReadLine();
                }
                else
                {
                    idValido = true;//__paso bandera a true en caso de que recorra la list y no encuentre un id existente sale del do while__

                    for (int i = 0; i < this._clientesList.Count; i++)
                    {
                        if (idCli == this._clientesList[i].IdCliente)
                        {
                            idValido = false;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("_________________________________________________");
                            Console.WriteLine("Ya existe un CLIENTE con ese número de ID.");
                            Console.WriteLine("_________________________________________________");
                            Console.ResetColor();
                            Console.WriteLine("Vuelve a ingresar otro ID:");
                            _id = Console.ReadLine();
                        }
                    }
                }
            }
            while (!idValido);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Id CLIENTE valido");
            Console.ResetColor();
        }


        public void ValidarIdSoloNumerico(string _id)
        {
            LeerArchivo(_archivoClientes);

            int idCli;

            if (!int.TryParse(_id, out idCli) || idCli <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("_________________________________________________");
                Console.WriteLine("ID no válido, deben ser solo números positivos!");
                Console.WriteLine("_________________________________________________");
                Console.ResetColor();
                _id = Console.ReadLine();
            }
        }


        private void ValidarCUIT(string _cuit)
        {
            LeerArchivo(_archivoClientes);

            bool CUIT_Valido = false;//__bandera de corte__

            do
            {
                /* learn.microsoft.com/en-us/dotnet/api/system.char.isdigit?view=net-8.0 
                 * es.stackoverflow.com/questions/107972/funcion-para-verificar-que-una-cadena-tenga-solo-letras-c-consola
                 * de aqui se tomo el All(char.IsLetter) All(char.IsDigit) para validar que solo sean num en la cadena o solo letras */

                if (!(_cuit.Length == 11 && _cuit.All(char.IsDigit)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("_________________________________________________________________________________");
                    Console.WriteLine("El Numero de C.U.I.T debe contener 11 digitos y ser solo de caracter numerico.");
                    Console.WriteLine("_________________________________________________________________________________");
                    Console.ResetColor();
                    Console.WriteLine("Vuelve a ingresar el C.U.I.T nuevamente:");
                    _cuit = Console.ReadLine();
                }
                else
                {
                    CUIT_Valido = true;//__paso bandera a true saldo del do while__
                }
            }
            while (!CUIT_Valido);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("El CUIT es valido");
            Console.ResetColor();
        }
    }
}
