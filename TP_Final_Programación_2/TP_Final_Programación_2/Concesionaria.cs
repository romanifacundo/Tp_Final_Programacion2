﻿using System;
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
        private const string _archivoCombustible = "combustibles.txt";
        private const string _archivoSegmento = "segmentos.txt";

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
            this._segmentosList = new List<Segmento>();
            this._combustiblesList = new List<Combustible>();
        }


        //__Metodos de acciones cargar datos__
        //__Cliente__
        public void CargarCliente()
        {
            Console.WriteLine("\n");
            Console.WriteLine("**Ingresa ID del CLIENTE**");
            string idCli = Console.ReadLine();
            idCli = ValidarIdNumericoOExiste(idCli, _archivoClientes);

            Console.WriteLine("**Ingresa el Nombre del CLIENTE**");
            string clienteNombre = Console.ReadLine();
            SoloLetras(clienteNombre);

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

            Cliente cli = new Cliente(int.Parse(idCli),
                                         clienteNombre,
                                         CUIT,
                                         domicilio,
                                         tel,
                                         corrElect,
                                         local);

            this._clientesList.Add(cli);

            Console.WriteLine("\n");
            Console.WriteLine("<<<<<<<Cliente agregado con EXITO>>>>>");
            Console.ReadKey();

            GrabarArchivo(_archivoClientes);
        }


        //__Vehiculo__
        public void CargarVehiculo()
        {
            int tipoVehiculo;
            bool opcionValida = false;

            do
            {

                Console.WriteLine("\n");
                Console.WriteLine("**¿QUÉ TIPO DE VEHÍCULO DESEAS CARGAR?**");
                Console.WriteLine("1) MOTO  2) AUTO/CAMIONETA  3) CAMIÓN");

                if (int.TryParse(Console.ReadLine(), out tipoVehiculo))
                {
                    switch (tipoVehiculo)
                    {
                        case 1:
                            Console.WriteLine("\n");
                            Console.WriteLine("**Ingresa el ID del Vehiculo**");
                            string idVhiculo = Console.ReadLine();
                            ValidarIdNumericoOExiste(idVhiculo, _archivoMotos);

                            Console.WriteLine("**Ingresa Cilindrada **");
                            string cilindrada = Console.ReadLine();
                            ValidarIdSoloNumerico(cilindrada);

                            Console.WriteLine("**Ingresa Patente **");
                            string patente = Console.ReadLine();

                            Console.WriteLine("**Ingresa los Kilometros**");
                            string km = Console.ReadLine();
                            ValidarIdSoloNumerico(km);

                            Console.WriteLine("**Ingresa el AÑO**");
                            string ano = Console.ReadLine();
                            ValidarIdSoloNumerico(ano);

                            Console.WriteLine("**Ingresa el nombre del Modelo**");
                            string mod = Console.ReadLine();

                            Console.WriteLine("**Ingresa el precio VENTA**");
                            string pVenta = Console.ReadLine();
                            ValidarIdSoloNumerico(pVenta);

                            Console.WriteLine("**Ingresa Observaciones**");
                            string observ = Console.ReadLine();

                            Console.WriteLine("**Ingresa el Color**");
                            string color = Console.ReadLine();
                            SoloLetras(color);

                            Console.WriteLine("**Ingresa el numero de la MARCA correspondiente a la Lista**");
                            LeerArchivo(_archivoMarcas);
                            ListarMarcas();
                            string idMarca = Console.ReadLine();

                            Console.WriteLine("**Ingresa el numero de SEGMENTO de la correspondiente a la lista**");
                            LeerArchivo(_archivoSegmento);
                            ListarSegmentos();
                            string idSeg = Console.ReadLine();
                            ValidarIdSoloNumerico(idSeg);

                            Console.WriteLine("**Ingresa el numero correspondiente al TIPO del Combustible**");
                            LeerArchivo(_archivoCombustible);
                            ListarCombustible();
                            string idCom = Console.ReadLine();

                            Moto moto = new Moto(
                                                  int.Parse(idCom),
                                                  int.Parse(cilindrada),
                                                  patente,
                                                  int.Parse(km),
                                                  int.Parse(ano),
                                                  mod,
                                                  int.Parse(pVenta),
                                                  observ,
                                                  color,
                                                  int.Parse(idMarca),
                                                  int.Parse(idSeg),
                                                  int.Parse(idCom));

                            this._motosList.Add(moto);

                            Console.WriteLine("\n");
                            Console.WriteLine("<<<<<<<Vehiculo agregado con EXITO>>>>>");
                            Console.ReadKey();

                            GrabarArchivo(_archivoMotos);
                            opcionValida = true;
                            break;

                        case 2:

                            Console.WriteLine("\n");
                            Console.WriteLine("**Ingresa el ID del Vehiculo**");
                            string idVhiculoAC = Console.ReadLine();
                            ValidarIdNumericoOExiste(idVhiculoAC, _archivoAutosCamionetas);

                            Console.WriteLine("**Ingresa Patente **");
                            string patenteAC = Console.ReadLine();

                            Console.WriteLine("**Ingresa los Kilometros**");
                            string kmAC = Console.ReadLine();
                            ValidarIdSoloNumerico(kmAC);

                            Console.WriteLine("**Ingresa el AÑO**");
                            string anoAC = Console.ReadLine();
                            ValidarIdSoloNumerico(anoAC);

                            Console.WriteLine("**Ingresa el numero de SEGMENTO de la correspondiente a la lista**");
                            LeerArchivo(_archivoSegmento);
                            ListarSegmentos();
                            string idSegAC = Console.ReadLine();
                            ValidarIdSoloNumerico(idSegAC);

                            Console.WriteLine("**Ingresa el nombre del Modelo**");
                            string modAC = Console.ReadLine();

                            Console.WriteLine("**Ingresa el precio VENTA**");
                            string pVentaAC = Console.ReadLine();
                            ValidarIdSoloNumerico(pVentaAC);

                            Console.WriteLine("**Ingresa Observaciones**");
                            string observAC = Console.ReadLine();

                            Console.WriteLine("**Ingresa el Color**");
                            string colorAC = Console.ReadLine();
                            SoloLetras(colorAC);

                            Console.WriteLine("**Ingresa el numero de la MARCA correspondiente a la Lista**");
                            LeerArchivo(_archivoMarcas);
                            ListarMarcas();
                            string idMarcaAC = Console.ReadLine();

                            Console.WriteLine("**Ingresa el numero correspondiente al TIPO del Combustible**");
                            LeerArchivo(_archivoCombustible);
                            ListarCombustible();
                            string idComAC = Console.ReadLine();

                            AutoCamioneta ac = new AutoCamioneta(
                                                    int.Parse(idVhiculoAC),
                                                    patenteAC,
                                                    int.Parse(kmAC),
                                                    int.Parse(anoAC),
                                                    modAC,
                                                    int.Parse(pVentaAC),
                                                    observAC,
                                                    colorAC,
                                                    int.Parse(idMarcaAC),
                                                    int.Parse(idSegAC),
                                                    int.Parse(idComAC));

                            this._autosCamionetasList.Add(ac);

                            Console.WriteLine("\n");
                            Console.WriteLine("<<<<<<<Vehiculo agregado con EXITO>>>>>");
                            Console.ReadKey();

                            GrabarArchivo(_archivoAutosCamionetas);
                            opcionValida = true;
                            break;

                        case 3:

                            string dimension = "";
                            string cargaMax = "";

                            Console.WriteLine("\n");
                            Console.WriteLine("**Ingresa el ID del Vehiculo**");
                            string idVhiculoCA = Console.ReadLine();
                            ValidarIdNumericoOExiste(idVhiculoCA, _archivoCamiones);

                            Console.WriteLine("**Ingresa Patente **");
                            string patenteCA = Console.ReadLine();

                            Console.WriteLine("**Ingresa los Kilometros**");
                            string kmCA = Console.ReadLine();
                            ValidarIdSoloNumerico(kmCA);

                            Console.WriteLine("**Ingresa el AÑO**");
                            string anoCA = Console.ReadLine();
                            ValidarIdSoloNumerico(anoCA);

                            Console.WriteLine("**Ingresa el numero de SEGMENTO de la correspondiente a la lista**");
                            LeerArchivo(_archivoSegmento);
                            ListarSegmentos();
                            string idSegCA = Console.ReadLine();
                            ValidarIdSoloNumerico(idSegCA);

                            Console.WriteLine("**Ingresa el nombre del Modelo**");
                            string modCA = Console.ReadLine();

                            Console.WriteLine("**Ingresa el precio VENTA**");
                            string pVentaCA = Console.ReadLine();
                            ValidarIdSoloNumerico(pVentaCA);

                            Console.WriteLine("**Ingresa Observaciones**");
                            string observCA = Console.ReadLine();

                            Console.WriteLine("**Ingresa el Color**");
                            string colorCA = Console.ReadLine();
                            SoloLetras(colorCA);

                            Console.WriteLine("**Tiene caja de carga? INGRESA (SI o NO)**");
                            string cajaCarga = Console.ReadLine();

                            while (cajaCarga != "SI" && cajaCarga != "NO")
                            {
                                Console.WriteLine("**Respuesta inválida. INGRESA (SI o NO) con Mayusculas**");
                                cajaCarga = Console.ReadLine();
                            }

                            if (cajaCarga == "SI")
                            {
                                Console.WriteLine("**INGRESA dimensión de la caja**");
                                dimension = Console.ReadLine();
                                ValidarIdSoloNumerico(dimension);

                                Console.WriteLine("**INGRESA la carga máxima**");
                                cargaMax = Console.ReadLine();
                                ValidarIdSoloNumerico(cargaMax);
                            }

                            Console.WriteLine("**Ingresa el numero de la MARCA correspondiente a la Lista**");
                            LeerArchivo(_archivoMarcas);
                            ListarMarcas();
                            string idMarcaCA = Console.ReadLine();

                            Console.WriteLine("**Ingresa el numero correspondiente al TIPO del Combustible**");
                            LeerArchivo(_archivoCombustible);
                            ListarCombustible();
                            string idComCA = Console.ReadLine();

                            Camion ca = new Camion(
                                                    int.Parse(idVhiculoCA),
                                                    patenteCA,
                                                    int.Parse(kmCA),
                                                    int.Parse(anoCA),
                                                    modCA,
                                                    int.Parse(pVentaCA),
                                                    observCA,
                                                    colorCA,
                                                    cajaCarga,
                                                    int.Parse(dimension),
                                                    int.Parse(cargaMax),
                                                    int.Parse(idMarcaCA),
                                                    int.Parse(idSegCA),
                                                    int.Parse(idComCA));

                            this._camionesList.Add(ca);

                            Console.WriteLine("\n");
                            Console.WriteLine("<<<<<<<Vehiculo agregado con EXITO>>>>>");
                            Console.ReadKey();

                            GrabarArchivo(_archivoCamiones);
                            opcionValida = true;

                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("_________________________________________________");
                            Console.WriteLine("Opción no válida. Por favor, elige una opción del 1 al 6.");
                            Console.WriteLine("_________________________________________________");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("_________________________________________________");
                    Console.WriteLine("Entrada no válida. Debes ingresar un número.");
                    Console.WriteLine("_________________________________________________");
                    Console.ResetColor();
                }
            } while (!opcionValida);

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
                if (idCondicion == this._clientesList[i].IdCliente)
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


        public void ListarVehiculos()
        {
            bool opcionValida = false;  //__bandera para verificar la opción__

            do
            {
                Console.WriteLine("Cliente VEHICULO desea Listar");
                Console.WriteLine("1) AUTOS/CAMIONETAS 2)CAMIONES 3)MOTOS");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:

                            LeerArchivo(_archivoAutosCamionetas);

                            foreach (AutoCamioneta i in this._autosCamionetasList)
                            {
                                i.MostrarDatos();
                            }
                            opcionValida = true;
                            break;

                        case 2:

                            LeerArchivo(_archivoCamiones);

                            foreach (Camion i in this._camionesList)
                            {
                                i.MostrarDatos();
                            }
                            opcionValida = true;
                            break;

                        case 3:
                           
                            LeerArchivo(_archivoMotos);

                            foreach (Moto i in this._motosList)
                            {
                                i.MostrarDatos();
                            }
                            opcionValida = true;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("_________________________________________________");
                            Console.WriteLine("Opción no válida. Por favor, elige una opción del 1 al 3.");
                            Console.WriteLine("_________________________________________________");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("_________________________________________________");
                    Console.WriteLine("Entrada no válida. Debes ingresar un número.");
                    Console.WriteLine("_________________________________________________");
                    Console.ResetColor();
                }

            } while (!opcionValida);
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
            LeerArchivo(_archivoLocalidades);

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("::::::::::::::::::::::::::::::::::::");

            for (int i = 0; i < this._localidadesList.Count; i++)
            {
                Console.WriteLine(this._localidadesList[i].NombreLocalidad);
            }

            Console.WriteLine("::::::::::::::::::::::::::::::::::::");

            Console.ResetColor();
        }


        public void ListarSegmentos()
        {
            LeerArchivo(_archivoSegmento);

            Console.ForegroundColor = ConsoleColor.Blue;

            foreach (Segmento i in this._segmentosList)
            {
                i.MostrarDatos();
            }

            Console.ResetColor();
        }


        public void ListarMarcas()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            foreach (Marca i in this._marcasList)
            {
                i.MostrarDatos();
            }

            Console.ResetColor();
        }


        public void ListarCombustible()
        {
            LeerArchivo(_archivoCombustible);

            foreach (Combustible i in this._combustiblesList)
            {
                i.MostrarDatos();
            }

            Console.ResetColor();
        }


        private string ObtenerNombreCombustible(int idCombustible, List<Combustible> combustibles)
        {
            LeerArchivo(_archivoCombustible);

            foreach (Combustible c in this._combustiblesList)
            {
                if (c.IdCombustible == idCombustible)
                {
                    return c.CombustibleNombre;
                }
            }
            return "xx"; 
        }


        private string ObtenerNombreMarca(int idMarca, List<Marca> marcas)
        {
            LeerArchivo(_archivoMarcas);

            foreach (Marca m in this._marcasList)
            {
                if (m.IdMarca == idMarca)
                {
                    return m.NombreMarca;
                }
            }
            return "xx";
        }


        private string ObtenerNombreSegmento(int idSegmento, List<Segmento> segmentos)
        {
            LeerArchivo(_archivoSegmento);

            foreach (Segmento s in this._segmentosList)
            {
                if (s.IdSegmento == idSegmento)
                {
                    return s.SegmentoNombre;
                }
            }
            return "xx";
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
                            grabar.WriteLine(this._clientesList[i].IdCliente + "|"
                                             + this._clientesList[i].NombreCliente + "|"
                                             + this._clientesList[i].CUIT + "|"
                                             + this._clientesList[i].Domicilio + "|"
                                             + this._clientesList[i].Telefono + "|"
                                             + this._clientesList[i].CorreoElectronico + "|"
                                             + this._clientesList[i].NombreLocalidad);

                        }
                        grabar.Close();
                        x.Close();

                        break;

                    case _archivoVentas:

                        x = new FileStream(_archivoVentas, FileMode.Create);
                        grabar = new StreamWriter(x);

                        break;

                    case _archivoMotos:

                        x = new FileStream(_archivoMotos, FileMode.Create);
                        grabar = new StreamWriter(x);

                        for (int i = 0; i < this._motosList.Count; i++)
                        {
                            //__nos permite trabajar con las prop de los objetos y darle los parametros a ObtenerNombreCombustible()__
                            Moto m = this._motosList[i];

                            //__obtener nombres correspondientes a los IDs__
                            string nombreCombustible = ObtenerNombreCombustible(m.IdCombustible, this._combustiblesList);
                            string nombreMarca = ObtenerNombreMarca(m.IdMarca, this._marcasList);
                            string nombreSegmento = ObtenerNombreSegmento(m.IdSegmento, this._segmentosList);

                            grabar.WriteLine(m.IdVehiculo + "|"
                                             + m.Cilindrada + "|"
                                             + m.Patente + "|"
                                             + m.Kilometro + "|"
                                             + m.Anio + "|"
                                             + m.Modelo + "|"
                                             + m.PrecioVenta + "|"
                                             + m.Observaciones + "|"
                                             + m.Color + "|"
                                             + nombreMarca + "|"
                                             + nombreSegmento + "|"
                                             + nombreCombustible);
                        }
                        grabar.Close();
                        x.Close();
                        break;

                    case _archivoAutosCamionetas:
                        
                        x = new FileStream(_archivoAutosCamionetas, FileMode.Create);
                        grabar = new StreamWriter(x);

                        for (int i = 0; i < this._autosCamionetasList.Count; i++)
                        {
                            //__nos permite trabajar con las prop de los objetos y darle los parametros a ObtenerNombreCombustible()__
                            AutoCamioneta ac = this._autosCamionetasList[i]; 

                            //__obtener nombres correspondientes a los IDs__
                            string nombreCombustible = ObtenerNombreCombustible(ac.IdCombustible, this._combustiblesList);
                            string nombreMarca = ObtenerNombreMarca(ac.IdMarca, this._marcasList);
                            string nombreSegmento = ObtenerNombreSegmento(ac.IdSegmento, this._segmentosList);
                
                            grabar.WriteLine(ac.IdVehiculo + "|"
                                             + ac.Patente + "|"
                                             + ac.Kilometro + "|"
                                             + ac.Anio + "|"
                                             + ac.Modelo + "|"
                                             + ac.PrecioVenta + "|"
                                             + ac.Observaciones + "|"
                                             + ac.Color + "|"
                                             + nombreMarca + "|"
                                             + nombreSegmento + "|"
                                             + nombreCombustible);
                        }

                        grabar.Close();
                        x.Close();
                        break;

                    case _archivoCamiones:

                        x = new FileStream(_archivoCamiones, FileMode.Create);
                        grabar = new StreamWriter(x);

                        for (int i = 0; i < this._camionesList.Count; i++)
                        {
                            //__nos permite trabajar con las prop de los objetos y darle los parametros a ObtenerNombreCombustible()__
                            Camion c = this._camionesList[i];

                            //__obtener nombres correspondientes a los IDs__
                            string nombreCombustible = ObtenerNombreCombustible(c.IdCombustible, this._combustiblesList);
                            string nombreMarca = ObtenerNombreMarca(c.IdMarca, this._marcasList);
                            string nombreSegmento = ObtenerNombreSegmento(c.IdSegmento, this._segmentosList);
                           
                            grabar.WriteLine(c.IdVehiculo + "|"
                                             + c.Patente + "|"
                                             + c.Kilometro + "|"
                                             + c.Anio + "|"
                                             + c.Modelo + "|"
                                             + c.PrecioVenta + "|"
                                             + c.Observaciones + "|"
                                             + c.Color + "|"
                                             + nombreMarca + "|"
                                             + nombreSegmento + "|"
                                             + nombreCombustible);


                            if (c.CajaCarga == "si")
                            {
                                grabar.Write("|" + c.CajaCarga + "|"
                                              + c.DimensionCaja + "|"
                                              + c.CargaMaxima);
                            }

                        }
                        grabar.Close();
                        x.Close();
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

                        if (this._motosList.Count == 0) 
                        {
                            x = new FileStream(_archivoMotos, FileMode.Open);
                            Leer = new StreamReader(x);

                            while (!Leer.EndOfStream)
                            {
                                cadena = Leer.ReadLine();
                                datos = cadena.Split('|');

                                Moto mo = new Moto(
                                            int.Parse(datos[0]), 
                                            int.Parse(datos[1]),           
                                            datos[2],           
                                            int.Parse(datos[3]), 
                                            int.Parse(datos[4]), 
                                            datos[5],            
                                            int.Parse(datos[6]), 
                                            datos[7],            
                                            datos[8],           
                                            ObtenerIdMarca(datos[9]),
                                            ObtenerIdSegmento(datos[10]), 
                                            ObtenerIdCombustible(datos[11])); 

                                this._motosList.Add(mo);
                            }
                            Leer.Close();
                            x.Close();
                        }
                        
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
                                datos = cadena.Split(';');

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
                    bool opcionValida = false;  //__bandera para verificar la opción__

                    do
                    {
                        Console.WriteLine("Cliente encontrado. Qué campo deseas actualizar?");
                        Console.WriteLine("1- Nombre");
                        Console.WriteLine("2- CUIT");
                        Console.WriteLine("3- Domicilio");
                        Console.WriteLine("4- Teléfono");
                        Console.WriteLine("5- Correo Electrónico");
                        Console.WriteLine("6- Localidad");

                        if (int.TryParse(Console.ReadLine(), out int opcion))
                        {
                            switch (opcion)
                            {
                                case 1:
                                    Console.WriteLine("Ingresa el nuevo Nombre:");
                                    string nuevoNombre = Console.ReadLine();
                                    nuevoNombre = SoloLetras(nuevoNombre);
                                    this._clientesList[i].NombreCliente = nuevoNombre;
                                    opcionValida = true; //__la opción es válida salir del bucle__
                                    break;

                                case 2:
                                    Console.WriteLine("Ingresa el nuevo CUIT:");
                                    string nuevoCUIT = Console.ReadLine();
                                    nuevoCUIT = ValidarCUIT(nuevoCUIT);
                                    this._clientesList[i].CUIT = nuevoCUIT;
                                    opcionValida = true;
                                    break;

                                case 3:
                                    Console.WriteLine("Ingresa el nuevo Domicilio:");
                                    this._clientesList[i].Domicilio = Console.ReadLine();
                                    opcionValida = true;
                                    break;

                                case 4:
                                    Console.WriteLine("Ingresa el nuevo Teléfono:");
                                    string nuevoTelefono = Console.ReadLine();
                                    nuevoTelefono = ValidarTelefono(nuevoTelefono);
                                    this._clientesList[i].Telefono = nuevoTelefono;
                                    opcionValida = true;
                                    break;

                                case 5:
                                    Console.WriteLine("Ingresa el nuevo Correo Electrónico:");
                                    this._clientesList[i].CorreoElectronico = Console.ReadLine();
                                    opcionValida = true;
                                    break;

                                case 6:
                                    Console.WriteLine("Ingresa la nueva Localidad:");
                                    string nuevaLocalidad = Console.ReadLine();
                                    nuevaLocalidad = SoloLetras(nuevaLocalidad);
                                    this._clientesList[i].NombreLocalidad = nuevaLocalidad;
                                    opcionValida = true;
                                    break;

                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("_________________________________________________");
                                    Console.WriteLine("Opción no válida. Por favor, elige una opción del 1 al 6.");
                                    Console.WriteLine("_________________________________________________");
                                    Console.ResetColor();
                                    break;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("_________________________________________________");
                            Console.WriteLine("Entrada no válida. Debes ingresar un número.");
                            Console.WriteLine("_________________________________________________");
                            Console.ResetColor();
                        }

                    } while (!opcionValida);
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
        private string ValidarIdNumericoOExiste(string _id, string _archivo)
        {

            bool idValido = false; //__bandera para el bucle__ 
            int idCli;
            switch (_archivo)
            {
                case _archivoClientes:

                    LeerArchivo(_archivoClientes);

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
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Id CLIENTE valido");
                            Console.ResetColor();
                        }
                    }
                    while (!idValido);
                    break;

                case _archivoVentas:

                    break;

                case _archivoMotos:

                    LeerArchivo(_archivoMotos);

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

                            for (int i = 0; i < this._motosList.Count; i++)
                            {
                                if (idCli == this._motosList[i].IdVehiculo)
                                {
                                    idValido = false;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("_________________________________________________");
                                    Console.WriteLine("Ya existe un VEHICULO con ese número de ID.");
                                    Console.WriteLine("_________________________________________________");
                                    Console.ResetColor();
                                    Console.WriteLine("Vuelve a ingresar otro ID:");
                                    _id = Console.ReadLine();
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("valido");
                            Console.ResetColor();
                        }
                    }
                    while (!idValido);

                    break;

                case _archivoLocalidades:

                    break;

                case _archivoProvincias:

                    break;

                case _archivoSegmento:

                    break;

                case _archivoMarcas:

                    break;
                default:
                    break;
            }


            return _id;
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
                    Console.WriteLine("No válido, deben ser solo números positivos!");
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
            Console.WriteLine("Valido");
            Console.ResetColor();

            return _id;
        }


        private string ValidarCUIT(string _cuit)
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

            return _cuit;
        }


        private string ValidarTelefono(string _telefono)
        {

            bool telefono_Valido = false;//__bandera de corte__

            do
            {
                if (!(_telefono.Length == 10 && _telefono.All(char.IsDigit)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("_________________________________________________________________________________");
                    Console.WriteLine("El Numero de TELEFONO debe contener 10 digitos y ser solo de caracter numerico.");
                    Console.WriteLine("_________________________________________________________________________________");
                    Console.ResetColor();
                    Console.WriteLine("Vuelve a ingresar el NUMERO de TELEFONO nuevamente:");
                    _telefono = Console.ReadLine();
                }
                else
                {
                    telefono_Valido = true;
                }

            } while (!telefono_Valido);

            return _telefono;
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


        public int ObtenerIdMarca(string nombreMarca)
        {
            for (int i = 0; i < this._marcasList.Count; i++)
            {
                if (this._marcasList[i].NombreMarca == nombreMarca) 
                {
                    return this._marcasList[i].IdMarca; 
                }
            }
            return 0;
        }


        public int ObtenerIdSegmento(string nombreSegmento)
        {
            for (int i = 0; i < this._segmentosList.Count; i++)
            {
                if (this._segmentosList[i].SegmentoNombre == nombreSegmento)
                {
                    return this._segmentosList[i].IdSegmento;
                }
            }
            return 0; 
        }


        public int ObtenerIdCombustible(string nombreCombustible)
        {
            for (int i = 0; i < this._combustiblesList.Count; i++)
            {
                if (this._combustiblesList[i].CombustibleNombre == nombreCombustible)
                {
                    return this._combustiblesList[i].IdCombustible ;
                }
            }
            return 0; 
        }


    }
}
