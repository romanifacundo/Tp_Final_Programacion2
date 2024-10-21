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
        //__Arvhivos .txt constanes para evaluar en el SWITCH__
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
        }


        //__Metodos de acciones cargar datos__
        //__Cliente__
        public void CargarCliente()
        {
            Console.WriteLine("\n");
            Console.WriteLine("**Ingresa ID del CLIENTE**");
            string idCli = Console.ReadLine();
            ValidarIdNumericoOExiste(idCli, _archivoClientes);

            Console.WriteLine("**Ingresa el Nombre del CLIENTE**");
            string clienteNombre = Console.ReadLine();

            Console.WriteLine("**Ingresa el C.U.I.T del CLIENTE**");
            string CUIT = Console.ReadLine();
            ValidarCUIT(CUIT);

            Console.WriteLine("**Ingresa el DOMICILIO del CLIENTE**");
            string domicilio = Console.ReadLine();

            Console.WriteLine("**Ingresa el TELEFONO del CLIENTE**");
            string tel = Console.ReadLine();
            ValidarTelefono(tel);

            Console.WriteLine("**Ingresa el Correo Electronico del CLIENTE**");
            string corrElect = Console.ReadLine();

            Console.WriteLine("**Ingresa el nombre de la Localidad del CLIENTE**");
            LeerArchivo(_archivoLocalidades); 
            ListarLocalidades(); 
            string local = Console.ReadLine();

            Cliente cli = new Cliente(int.Parse(idCli), clienteNombre, CUIT, domicilio, tel, corrElect, local);

            this._clientesList.Add(cli);

            Console.WriteLine("\n");
            Console.WriteLine("<<<<<<<Cliente agregado con EXITO>>>>>");
            Console.ReadKey();

            GrabarArchivo(_archivoClientes);
        }


        public void ActualizarCliente()
        {
            Actualizar(_archivoClientes);
        }


        public void BorrarCliente()
        {
            ListarClientes();
            Console.ResetColor();
            Console.WriteLine("\n");
            Console.WriteLine("**Ingresa ID del CLIENTE¨ que desea borrar**");
            string idCli = Console.ReadLine();
            idCli = ValidarIdSoloNumerico(idCli);
            int idCondicion = int.Parse(idCli);//__parsear para codicionar__

            for (int i = 0; i < this._clientesList.Count; i++)
            {
                if(idCondicion == this._clientesList[i].IdCliente)
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

            Console.ResetColor();
        }


        public void ListarProvincias()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("::::::::::::::::::::::::::::::::::::");

            for (int i = 0; i < this._provinciasList.Count; i++)
            {
                Console.WriteLine(this._provinciasList[i].NombreProvincia);
            }

            Console.WriteLine("::::::::::::::::::::::::::::::::::::");

            Console.ResetColor();
        }


        public void ListarLocalidades()
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


        public void ListarSegmento()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("::::::::::::::::::::::::::::::::::::");

            for (int i = 0; i < this._segmentosList.Count; i++)
            {
                Console.WriteLine(this._segmentosList[i].SegmentoNombre);
            }

            Console.WriteLine("::::::::::::::::::::::::::::::::::::");

            Console.ResetColor();
        }


        public void ListasMarca()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("::::::::::::::::::::::::::::::::::::");

            for (int i = 0; i < this._marcasList.Count; i++)
            {
                Console.Write(this._marcasList[i].NombreMarca);
            }

            Console.WriteLine("::::::::::::::::::::::::::::::::::::");

            Console.ResetColor();
        }


        public void ListarCombustible()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("::::::::::::::::::::::::::::::::::::");

            for (int i = 0; i < this._combustiblesList.Count; i++)
            {
                Console.WriteLine(this._combustiblesList[i].CombustibleNombre);
            }

            Console.WriteLine("::::::::::::::::::::::::::::::::::::");

            Console.ResetColor();
        }


        //__Vehiculo__
        public void CargarVehiculo()
        {
            Console.WriteLine("\n");
            Console.WriteLine("**QUE TIPO DE VEHICULO DESEAS CARGAR?**");
            Console.WriteLine("1) MOTO  2) AUTO/CAMIONETA  3) CAMION");
            int tipoVehiculo = int.Parse(Console.ReadLine());

            switch (tipoVehiculo)
            {
                case 1:
                    Console.WriteLine("\n");
                    Console.WriteLine("**Ingresa el ID del Vehiculo**");
                    string idVhiculo = Console.ReadLine();
                    ValidarIdNumericoOExiste(idVhiculo, _archivoMotos);

                    Console.WriteLine("**Ingresa Cilindrada **");
                    string cilindrada = Console.ReadLine();

                    Console.WriteLine("**Ingresa Patente **");
                    string patente = Console.ReadLine();

                    Console.WriteLine("**Ingresa los Kilometros**");
                    string km = Console.ReadLine();
                    ValidarIdSoloNumerico(km);

                    Console.WriteLine("**Ingresa el AÑO**");
                    string ano = Console.ReadLine();
                    ValidarIdSoloNumerico(ano);

                    Console.WriteLine("**Ingresa el numero de SEGMENTO de la correspondiente a la lista**");
                    LeerArchivo(_archivoSegmento);
                    ListarSegmento();
                    string idSeg = Console.ReadLine();
                    ValidarIdSoloNumerico(idSeg);

                    Console.WriteLine("**Ingresa el nombre del Modelo**");
                    string mod = Console.ReadLine();

                    Console.WriteLine("**Ingresa el precio VENTA**");
                    string pVenta = Console.ReadLine();
                    ValidarIdSoloNumerico(pVenta);

                    Console.WriteLine("**Ingresa Observaciones**");
                    string observ = Console.ReadLine();

                    Console.WriteLine("**Ingresa el Color**");
                    string color = Console.ReadLine();

                    Console.WriteLine("**Ingresa el numero de la MARCA correspondiente a la Lista**");
                    LeerArchivo(_archivoMarcas);
                    ListarSegmento();
                    string idMarca = Console.ReadLine();

                    Console.WriteLine("**Ingresa el numero correspondiente al TIPO del Combustible**");
                    LeerArchivo(_archivoCombustible);
                    string idCom = Console.ReadLine();
         
                    Moto moto = new Moto(int.Parse(idCom),cilindrada,patente,int.Parse(km),int.Parse(ano),mod,int.Parse(pVenta),observ,color,int.Parse(idMarca),int.Parse(idSeg),int.Parse(idCom));

                    this._motosList.Add(moto);

                    Console.WriteLine("\n");
                    Console.WriteLine("<<<<<<<Vehiculo agregado con EXITO>>>>>");
                    Console.ReadKey();

                    GrabarArchivo(_archivoMotos);

                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            //__Moto - AutoCamioneta - Camion-

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

            if (File.Exists(_archivo))
            {
                switch (_archivo)
                {
                    case _archivoClientes:

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
                                        datos[4],
                                        datos[5],
                                        datos[6]);

                                this._clientesList.Add(cli);
                            }
                            Leer.Close();
                            x.Close();
                        }                   

                        break;

                    case _archivoVentas:

                        x = new FileStream(_archivoVentas, FileMode.Open);
                        Leer = new StreamReader(x);

                        break;

                    case _archivoVehiculos:

                        x = new FileStream(_archivoVehiculos, FileMode.Open);
                        Leer = new StreamReader(x);

                        break;

                    case _archivoAutosCamionetas:

                        x = new FileStream(_archivoAutosCamionetas, FileMode.Open);
                        Leer = new StreamReader(x);

                        break;

                    case _archivoMotos:

                        x = new FileStream(_archivoMotos, FileMode.Open);
                        Leer = new StreamReader(x);

                        break;

                    case _archivoCamiones:

                        x = new FileStream(_archivoCamiones, FileMode.Open);
                        Leer = new StreamReader(x);

                        break;

                    case _archivoProvincias: //__Provincias__

                        if (this._provinciasList.Count == 0)
                        {
                            x = new FileStream(_archivoProvincias, FileMode.Open);
                            Leer = new StreamReader(x);

                            while (!Leer.EndOfStream)
                            {
                                cadena = Leer.ReadLine();
                                datos = cadena.Split('-');

                                Provincia prov = new Provincia(
                                        int.Parse(datos[0]),
                                        datos[1]);
                                       
                                this._provinciasList.Add(prov);
                            }
                            Leer.Close();
                            x.Close();
                        }
      
                        break;

                    case _archivoLocalidades: //__Localidades__

                        if (this._localidadesList.Count == 0)
                        {
                            x = new FileStream(_archivoLocalidades, FileMode.Open);
                            Leer = new StreamReader(x);

                            while (!Leer.EndOfStream)
                            {
                                cadena = Leer.ReadLine();
                                datos = cadena.Split('-');

                                Localidad loc = new Localidad(
                                        int.Parse(datos[0]),
                                        datos[1],
                                        int.Parse(datos[2]));

                                this._localidadesList.Add(loc);
                            }
                            Leer.Close();
                            x.Close();
                        }

                        break;

                    case _archivoSegmento: //__Segmentos__

                        if (this._segmentosList.Count == 0)
                        {
                            x = new FileStream(_archivoSegmento, FileMode.Open);
                            Leer = new StreamReader(x);

                            while (!Leer.EndOfStream)
                            {
                                cadena = Leer.ReadLine();
                                datos = cadena.Split('-');

                                Segmento seg = new Segmento(
                                        int.Parse(datos[0]),
                                        datos[1]);

                                this._segmentosList.Add(seg);
                            }
                            Leer.Close();
                            x.Close();
                        }

                        break;

                    case _archivoCombustible: //__Combustibles__

                        if (this._combustiblesList.Count == 0)
                        {
                            x = new FileStream(_archivoCombustible, FileMode.Open);
                            Leer = new StreamReader(x);

                            while (!Leer.EndOfStream)
                            {
                                cadena = Leer.ReadLine();
                                datos = cadena.Split('-');

                                Combustible com = new Combustible(
                                        int.Parse(datos[0]),
                                        datos[1]);

                                this._combustiblesList.Add(com);
                            }
                            Leer.Close();
                            x.Close();
                        }
                      
                        break;

                    case _archivoMarcas: //__Marcas__

                        if (this._marcasList.Count == 0)
                        {
                            x = new FileStream(_archivoMarcas, FileMode.Open);
                            Leer = new StreamReader(x);

                            while (!Leer.EndOfStream)
                            {
                                cadena = Leer.ReadLine();
                                datos = cadena.Split('-');

                                Marca mar = new Marca(
                                        int.Parse(datos[0]),
                                        datos[1]);

                                this._marcasList.Add(mar);
                            }
                            Leer.Close();
                            x.Close();
                        }

                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n El archivo no existe.");
            }
        }


        private void Actualizar(string archivo)
        {
            ListarClientes(); //__falta desarrollar si se quiere actualizar en su totalidad__
            Console.WriteLine("\n");
            LeerArchivo(archivo);

            Console.WriteLine("Ingresa el ID del CLIENTE a actualizar:");
            string idCli = Console.ReadLine();
            idCli = ValidarIdSoloNumerico(idCli);
            int idCondicion = int.Parse(idCli);//__parsear para codicionar__

            bool clienteEncontrado = false;  //__bandera para indicar si encontramos el cliente__

            for (int i = 0; i < this._clientesList.Count; i++)
            {
                if (this._clientesList[i].IdCliente == idCondicion)
                {
                    clienteEncontrado = true;  //__encontrado__
                    Console.WriteLine("Cliente encontrado. Qué campo deseas actualizar?");
                    Console.WriteLine("1- Nombre");
                    Console.WriteLine("2- CUIT");
                    Console.WriteLine("3- Domicilio");
                    Console.WriteLine("4- Teléfono");
                    Console.WriteLine("5- Correo Electrónico");
                    Console.WriteLine("6- Localidad");

                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Ingresa el nuevo Nombre:");           
                            string pal = this._clientesList[i].NombreCliente = Console.ReadLine();
                            SoloLetras(pal);
                            break;
                        case 2:
                            Console.WriteLine("Ingresa el nuevo CUIT:");
                            this._clientesList[i].CUIT = Console.ReadLine();
                            ValidarCUIT(_clientesList[i].CUIT);
                            break;
                        case 3:
                            Console.WriteLine("Ingresa el nuevo Domicilio:");
                            _clientesList[i].Domicilio = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Ingresa el nuevo Teléfono:");
                            this._clientesList[i].Telefono = Console.ReadLine();
                            ValidarTelefono(_clientesList[i].Telefono);
                            break;
                        case 5:
                            Console.WriteLine("Ingresa el nuevo Correo Electrónico:");
                            this._clientesList[i].CorreoElectronico = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Ingresa la nueva Localidad:");
                            this._clientesList[i].NombreLocalidad = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("La opcion no es valida!");
                            break;
                    }
                }
            }

            if (clienteEncontrado)
            {
                GrabarArchivo(archivo);
                Console.WriteLine("Cliente actualizado correctamente");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El CLIENTE no existe.");
                Console.ResetColor();
            }
        }


        //__Validaciones__
        private void ValidarIdNumericoOExiste(string _id, string _archivo)
        {
            bool idValido = false; //__bandera para el bucle__ 
            int idGenerico;

            switch (_archivo)//__refactorizar para cada .txt en switch para no usar muchos if()__
            {
                case _archivoClientes:

                    do
                    {
                        if (!int.TryParse(_id, out idGenerico) || idGenerico <= 0)
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
                                if (idGenerico == this._clientesList[i].IdCliente)
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

                    break;

                case _archivoVentas:

                    break;

                case _archivoVehiculos:
           
                    do
                    {
                        if (!int.TryParse(_id, out idGenerico) || idGenerico <= 0)
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
                                if (idGenerico == this._vehiculosList[i].IdVehiculo)
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

                    break;

                case _archivoAutosCamionetas:

                    break;

                case _archivoMotos:

                    break;

                case _archivoCamiones:

                    break;

                default:
                    break;
            }      
        }


        private string ValidarIdSoloNumerico(string _id)
        {
            //LeerArchivo(_archivoClientes);
            bool idValidoNum = false; //__bandera para el bucle__ 
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
                    idValidoNum = true;
                }

            } while (!idValidoNum);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Id CLIENTE valido");
            Console.ResetColor();

            return _id;
        }


        private void ValidarCUIT(string _cuit)
        {
            //LeerArchivo(_archivoClientes);

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


        private void ValidarTelefono(string _telefono)
        {

            bool telefono_Valido = false;//__bandera de corte__

            do
            {
                if (!(_telefono.Length == 10 && _telefono.All(char.IsDigit)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("_________________________________________________________________________________");
                    Console.WriteLine("El Numero de C.U.I.T debe contener 11 digitos y ser solo de caracter numerico.");
                    Console.WriteLine("_________________________________________________________________________________");
                    Console.ResetColor();
                    Console.WriteLine("Vuelve a ingresar el C.U.I.T nuevamente:");
                    _telefono = Console.ReadLine();
                }
                else
                {
                    telefono_Valido = true;
                }

            }while (!telefono_Valido);
        }


        private string SoloLetras(string _palabra)
        {
            bool palabra_Valida = false; // __bandera de corte__

            do
            {
                if (!_palabra.All(char.IsLetter))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("_________________________________________________");
                    Console.WriteLine("Palabra inválida");
                    Console.WriteLine("_________________________________________________");
                    Console.ResetColor();
                    Console.WriteLine("Vuelve a ingresar:");
                    _palabra = Console.ReadLine();
                }
               else
               {
                    palabra_Valida = true;
               }
                    
            } while (!palabra_Valida);

            return _palabra;
        }

    }
}
