using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        private const string _archivoAutosCamionetas = "autos_camionetas.txt";
        private const string _archivoMotos = "motos.txt";
        private const string _archivoCamionesConCaja = "camionesConCaja.txt";
        private const string _archivoCamionesSinCaja = "camionesSinCaja.txt";
        private const string _archivoMarcas = "marcas.txt";
        private const string _archivoLocalidades = "localidades.txt";
        private const string _archivoProvincias = "provincias.txt";
        private const string _archivoCombustible = "combustibles.txt";
        private const string _archivoSegmento = "segmentos.txt";

        //__Declaracion Listas privadas con relacion de ensamble a clases__ 
        private List<AutoCamioneta> _autosCamionetasList;
        private List<Moto> _motosList;
        private List<Camion> _camionesConCajaList;
        private List<Camion> _camionesSinCajaList;
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
            this._autosCamionetasList = new List<AutoCamioneta>();
            this._motosList = new List<Moto>();
            this._camionesConCajaList = new List<Camion>();
            this._camionesSinCajaList = new List<Camion>();
            this._marcasList = new List<Marca>();
            this._ventasList = new List<Venta>();
            this._clientesList = new List<Cliente>();
            this._localidadesList = new List<Localidad>();
            this._provinciasList = new List<Provincia>();
            this._segmentosList = new List<Segmento>();
            this._combustiblesList = new List<Combustible>();
        }


        //Metodos de acciones cargar datos__
        //__Cliente__
        public void CargarCliente()
        {
            Console.WriteLine("**CLIENTES EXISTENTES**");
            ListarClientes();
            Console.WriteLine("\n");
            Console.WriteLine("**Ingresa ID del CLIENTE**");
            string idCli = Console.ReadLine();
            idCli = ValidarIdNumericoOExiste(idCli, _archivoClientes);

            Console.WriteLine("**Ingresa el Nombre del CLIENTE**");
            string clienteNombre = Console.ReadLine();
            clienteNombre = SoloLetras(clienteNombre);

            Console.WriteLine("**Ingresa el C.U.I.T del CLIENTE**");
            string CUIT = Console.ReadLine();
            CUIT = ValidarCUIT(CUIT);

            Console.WriteLine("**Ingresa el DOMICILIO del CLIENTE**");
            string domicilio = Console.ReadLine();

            Console.WriteLine("**Ingresa el TELEFONO del CLIENTE**");
            string tel = Console.ReadLine();
            tel = ValidarTelefono(tel);

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


        //__Venta__
        public void CargarVenta()
        {
            Console.WriteLine("\n**Ingresa el ID VENTA**");
            Console.WriteLine("\n___________________________________");
            string idVen = Console.ReadLine();
            idVen = ValidarIdSoloNumerico(idVen);

            Console.WriteLine("\n**Ingresa el ID del CLIENTE de la lista para cargar la VENTA**");
            ListarClientes();
            Console.WriteLine("\n___________________________________");
            string idCli = Console.ReadLine();
            idCli = ValidarIdSoloNumerico(idCli);

            Console.WriteLine("\n**Ingresa el Nombre del CLIENTE de la lista para cargar la VENTA**");
            string nombreCli = Console.ReadLine();
            nombreCli = SoloLetras(nombreCli);

            ListarVehiculos();
            Console.WriteLine("\n");
            Console.WriteLine("**Ingresa el ID del VEHÍCULO de la lista para cargar la VENTA**");
            Console.WriteLine("\n___________________________________");
            string idVehi = Console.ReadLine();
            idVehi = ValidarIdSoloNumerico(idVehi);

            Console.WriteLine("\n**Ingresa el Nombre del VEHICULO de la lista para cargar la VENTA**");
            string nombreVehi = Console.ReadLine();
            nombreVehi = SoloLetras(nombreVehi);

            Console.WriteLine("**Ingresa la FECHA DE COMPRA (formato: DD-MM-YYYY)**");
            Console.WriteLine("\n___________________________________");
            string fechaC = Console.ReadLine();

            Console.WriteLine("**Ingresa la FECHA DE ENTREGA (formato: DD-MM-YYYY)**");
            Console.WriteLine("\n___________________________________");
            string fechaE = Console.ReadLine();

            Console.WriteLine("**Ingresa el precio del VEHICULO**");
            Console.WriteLine("\n___________________________________");
            ListarVehiculos();
            string precioVenta = Console.ReadLine();
            precioVenta = ValidarIdSoloNumerico(precioVenta);

            Venta nuevaVenta = new Venta(int.Parse(idVen),
                                        int.Parse(idCli),
                                        nombreCli,
                                        int.Parse(idVehi),
                                        nombreVehi,
                                        fechaC,
                                        fechaE,
                                        int.Parse(precioVenta));

            this._ventasList.Add(nuevaVenta);

            Console.WriteLine("\nRegistro de venta creado exitosamente!");
            Console.ReadKey();
            GrabarArchivo(_archivoVentas);

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
                            string idVehiculo1 = Console.ReadLine();
                            idVehiculo1 = ValidarIdNumericoOExiste(idVehiculo1, _archivoMotos);

                            Console.WriteLine("**Ingresa Cilindrada **");
                            string cilindrada = Console.ReadLine();
                            ValidarIdSoloNumerico(cilindrada);

                            Console.WriteLine("**Ingresa Patente **");
                            string patente = Console.ReadLine();

                            Console.WriteLine("**Ingresa los Kilometros**");
                            string km = Console.ReadLine();
                            km = ValidarIdSoloNumerico(km);

                            Console.WriteLine("**Ingresa el AÑO**");
                            string ano = Console.ReadLine();
                            ano = ValidarIdSoloNumerico(ano);

                            Console.WriteLine("**Ingresa el nombre del Modelo**");
                            string mod = Console.ReadLine();

                            Console.WriteLine("**Ingresa el precio VENTA**");
                            string pVenta = Console.ReadLine();
                            pVenta = ValidarIdSoloNumerico(pVenta);

                            Console.WriteLine("**Ingresa Observaciones**");
                            string observ = Console.ReadLine();

                            Console.WriteLine("**Ingresa el Color**");
                            string color = Console.ReadLine();
                            color = SoloLetras(color);

                            Console.WriteLine("**Ingresa el numero de la MARCA correspondiente a la Lista**");
                            LeerArchivo(_archivoMarcas);
                            ListarMarcas();
                            string idMarca = Console.ReadLine();

                            Console.WriteLine("**Ingresa el nombre de la MARCA correspondiente a la Lista**");
                            string nombreMarcaMO = Console.ReadLine();
                            nombreMarcaMO = SoloLetras(nombreMarcaMO);

                            Console.WriteLine("**Ingresa el numero de SEGMENTO de la correspondiente a la lista**");
                            LeerArchivo(_archivoSegmento);
                            ListarSegmentos();
                            string idSeg = Console.ReadLine();
                            ValidarIdSoloNumerico(idSeg);

                            Console.WriteLine("**Ingresa el nombre del SEGMENTO correspondiente a la Lista**");
                            string nombreSegmentoMO = Console.ReadLine();
                            nombreSegmentoMO = SoloLetras(nombreSegmentoMO);

                            Console.WriteLine("**Ingresa el numero correspondiente al TIPO del Combustible**");
                            LeerArchivo(_archivoCombustible);
                            ListarCombustible();
                            string idCom = Console.ReadLine();

                            Console.WriteLine("**Ingresa el nombre del COMBUSTIBLE correspondiente a la Lista**");
                            string nombreComMO = Console.ReadLine();
                            nombreComMO = SoloLetras(nombreComMO);

                            Moto moto = new Moto(
                                                  int.Parse(idVehiculo1),
                                                  int.Parse(cilindrada),
                                                  patente,
                                                  int.Parse(km),
                                                  int.Parse(ano),
                                                  mod,
                                                  int.Parse(pVenta),
                                                  observ,
                                                  color,
                                                  int.Parse(idMarca),
                                                  nombreMarcaMO,
                                                  int.Parse(idSeg),
                                                  nombreSegmentoMO,
                                                  int.Parse(idCom),
                                                  nombreComMO);

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
                            string idVehiculoAC = Console.ReadLine();
                            idVehiculoAC = ValidarIdNumericoOExiste(idVehiculoAC, _archivoAutosCamionetas);

                            Console.WriteLine("**Ingresa Patente **");
                            string patenteAC = Console.ReadLine();

                            Console.WriteLine("**Ingresa los Kilometros**");
                            string kmAC = Console.ReadLine();
                            kmAC = ValidarIdSoloNumerico(kmAC);

                            Console.WriteLine("**Ingresa el AÑO**");
                            string anoAC = Console.ReadLine();
                            anoAC = ValidarIdSoloNumerico(anoAC);

                            Console.WriteLine("**Ingresa el numero de SEGMENTO de la correspondiente a la lista**");
                            LeerArchivo(_archivoSegmento);
                            ListarSegmentos();
                            string idSegAC = Console.ReadLine();
                            idSegAC = ValidarIdSoloNumerico(idSegAC);

                            Console.WriteLine("**Ingresa el nombre del SEGMENTO correspondiente a la Lista**");
                            string nombreSegmentoAC = Console.ReadLine();
                            nombreSegmentoAC = SoloLetras(nombreSegmentoAC);

                            Console.WriteLine("**Ingresa el nombre del Modelo**");
                            string modAC = Console.ReadLine();

                            Console.WriteLine("**Ingresa el precio VENTA**");
                            string pVentaAC = Console.ReadLine();
                            pVentaAC = ValidarIdSoloNumerico(pVentaAC);

                            Console.WriteLine("**Ingresa Observaciones**");
                            string observAC = Console.ReadLine();

                            Console.WriteLine("**Ingresa el Color**");
                            string colorAC = Console.ReadLine();
                            colorAC = SoloLetras(colorAC);

                            Console.WriteLine("**Ingresa el numero de la MARCA correspondiente a la Lista**");
                            LeerArchivo(_archivoMarcas);
                            ListarMarcas();
                            string idMarcaAC = Console.ReadLine();

                            Console.WriteLine("**Ingresa el nombre de la MARCA correspondiente a la Lista**");
                            string nombreMarcaAC = Console.ReadLine();
                            nombreMarcaAC = SoloLetras(nombreMarcaAC);

                            Console.WriteLine("**Ingresa el numero correspondiente al TIPO del Combustible**");
                            LeerArchivo(_archivoCombustible);
                            ListarCombustible();
                            string idComAC = Console.ReadLine();

                            Console.WriteLine("**Ingresa el nombre del COMBUSTIBLE correspondiente a la Lista**");
                            string nombreComAC = Console.ReadLine();
                            nombreComAC = SoloLetras(nombreComAC);

                            AutoCamioneta ac = new AutoCamioneta(
                                                    int.Parse(idVehiculoAC),
                                                    patenteAC,
                                                    int.Parse(kmAC),
                                                    int.Parse(anoAC),
                                                    modAC,
                                                    int.Parse(pVentaAC),
                                                    observAC,
                                                    colorAC,
                                                    int.Parse(idMarcaAC),
                                                    nombreMarcaAC,
                                                    int.Parse(idSegAC),
                                                    nombreSegmentoAC,
                                                    int.Parse(idComAC),
                                                    nombreComAC);

                            this._autosCamionetasList.Add(ac);

                            Console.WriteLine("\n");
                            Console.WriteLine("<<<<<<<Vehiculo agregado con EXITO>>>>>");
                            Console.ReadKey();

                            GrabarArchivo(_archivoAutosCamionetas);
                            opcionValida = true;
                            break;

                        case 3:

                            bool controlBucle = false;

                            while (!controlBucle)
                            {
                                Console.WriteLine("**¿Qué tipo de camión desea cargar?**");
                                Console.WriteLine("1. Camión con caja de carga");
                                Console.WriteLine("2. Camión sin caja de carga");
                                string tipoCamion = Console.ReadLine();
                                tipoCamion = ValidarIdSoloNumerico(tipoCamion);

                                if (tipoCamion == "1")
                                {
                                    controlBucle = true;

                                    Console.WriteLine("\n");
                                    Console.WriteLine("**Ingresa el ID del Vehiculo**");
                                    string idVehiculoCA = Console.ReadLine();
                                    idVehiculoCA = ValidarIdNumericoOExiste(idVehiculoCA, _archivoCamionesConCaja);

                                    Console.WriteLine("**Ingresa Patente **");
                                    string patenteCA = Console.ReadLine();

                                    Console.WriteLine("**Ingresa los Kilometros**");
                                    string kmCA = Console.ReadLine();
                                    kmCA = ValidarIdSoloNumerico(kmCA);

                                    Console.WriteLine("**Ingresa el AÑO**");
                                    string anoCA = Console.ReadLine();
                                    ValidarIdSoloNumerico(anoCA);

                                    Console.WriteLine("**Ingresa el numero de SEGMENTO de la correspondiente a la lista**");
                                    LeerArchivo(_archivoSegmento);
                                    ListarSegmentos();
                                    string idSegCA = Console.ReadLine();
                                    ValidarIdSoloNumerico(idSegCA);

                                    Console.WriteLine("**Ingresa el nombre del SEGMENTO correspondiente a la Lista**");
                                    string nombreSegmentoCC = Console.ReadLine();
                                    nombreSegmentoCC = SoloLetras(nombreSegmentoCC);

                                    Console.WriteLine("**Ingresa el nombre del Modelo**");
                                    string modCA = Console.ReadLine();

                                    Console.WriteLine("**Ingresa el precio VENTA**");
                                    string pVentaCA = Console.ReadLine();
                                    pVentaCA = ValidarIdSoloNumerico(pVentaCA);

                                    Console.WriteLine("**Ingresa Observaciones**");
                                    string observCA = Console.ReadLine();

                                    Console.WriteLine("**Ingresa el Color**");
                                    string colorCA = Console.ReadLine();
                                    colorCA = SoloLetras(colorCA);

                                    string cajaCarga = "SI";

                                    Console.WriteLine("**INGRESA dimensión de la caja**");
                                    string dimension = Console.ReadLine();
                                    dimension = ValidarIdSoloNumerico(dimension);

                                    Console.WriteLine("**INGRESA la carga máxima**");
                                    string cargaMax = Console.ReadLine();
                                    cargaMax = ValidarIdSoloNumerico(cargaMax);

                                    Console.WriteLine("**Ingresa el numero de la MARCA correspondiente a la Lista**");
                                    LeerArchivo(_archivoMarcas);
                                    ListarMarcas();
                                    string idMarcaCA = Console.ReadLine();

                                    Console.WriteLine("**Ingresa el nombre de la MARCA correspondiente a la Lista**");
                                    string nombreMarcaCC = Console.ReadLine();
                                    nombreMarcaCC = SoloLetras(nombreMarcaCC);

                                    Console.WriteLine("**Ingresa el numero correspondiente al TIPO del Combustible**");
                                    LeerArchivo(_archivoCombustible);
                                    ListarCombustible();
                                    string idComCA = Console.ReadLine();

                                    Console.WriteLine("**Ingresa el nombre del COMBUSTIBLE correspondiente a la Lista**");
                                    string nombreComCC = Console.ReadLine();
                                    nombreComCC = SoloLetras(nombreComCC);

                                    Camion ca = new Camion(
                                                            int.Parse(idVehiculoCA),
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
                                                            nombreMarcaCC,
                                                            int.Parse(idSegCA),
                                                            nombreSegmentoCC,
                                                            int.Parse(idComCA),
                                                            nombreComCC);

                                    this._camionesConCajaList.Add(ca);
                                    Console.WriteLine("\n");
                                    Console.WriteLine("<<<<<<<Vehiculo agregado con EXITO>>>>>");
                                    Console.ReadKey();

                                    GrabarArchivo(_archivoCamionesConCaja);

                                }
                                else if (tipoCamion == "2")
                                {
                                    controlBucle = true;

                                    Console.WriteLine("\n");
                                    Console.WriteLine("**Ingresa el ID del Vehiculo**");
                                    string idVehiculoCA = Console.ReadLine();
                                    idVehiculoCA = ValidarIdNumericoOExiste(idVehiculoCA, _archivoCamionesConCaja);

                                    Console.WriteLine("**Ingresa Patente **");
                                    string patenteCA = Console.ReadLine();

                                    Console.WriteLine("**Ingresa los Kilometros**");
                                    string kmCA = Console.ReadLine();
                                    ValidarIdSoloNumerico(kmCA);

                                    Console.WriteLine("**Ingresa el AÑO**");
                                    string anoCA = Console.ReadLine();
                                    anoCA = ValidarIdSoloNumerico(anoCA);

                                    Console.WriteLine("**Ingresa el numero de SEGMENTO de la correspondiente a la lista**");
                                    LeerArchivo(_archivoSegmento);
                                    ListarSegmentos();
                                    string idSegCA = Console.ReadLine();
                                    idSegCA = ValidarIdSoloNumerico(idSegCA);

                                    Console.WriteLine("**Ingresa el nombre del SEGMENTO correspondiente a la Lista**");
                                    string nombreSegmentoCSC = Console.ReadLine();
                                    nombreSegmentoCSC = SoloLetras(nombreSegmentoCSC);

                                    Console.WriteLine("**Ingresa el nombre del Modelo**");
                                    string modCA = Console.ReadLine();

                                    Console.WriteLine("**Ingresa el precio VENTA**");
                                    string pVentaCA = Console.ReadLine();
                                    pVentaCA = ValidarIdSoloNumerico(pVentaCA);

                                    Console.WriteLine("**Ingresa Observaciones**");
                                    string observCA = Console.ReadLine();

                                    Console.WriteLine("**Ingresa el Color**");
                                    string colorCA = Console.ReadLine();
                                    colorCA = SoloLetras(colorCA);

                                    string cajaCarga = "NO";

                                    Console.WriteLine("**Ingresa el numero de la MARCA correspondiente a la Lista**");
                                    LeerArchivo(_archivoMarcas);
                                    ListarMarcas();
                                    string idMarcaCA = Console.ReadLine();

                                    Console.WriteLine("**Ingresa el nombre de la MARCA correspondiente a la Lista**");
                                    string nombreMarcaCSC = Console.ReadLine();
                                    nombreMarcaCSC = SoloLetras(nombreMarcaCSC);

                                    Console.WriteLine("**Ingresa el numero correspondiente al TIPO del Combustible**");
                                    LeerArchivo(_archivoCombustible);
                                    ListarCombustible();
                                    string idComCA = Console.ReadLine();

                                    Console.WriteLine("**Ingresa el nombre del COMBUSTIBLE correspondiente a la Lista**");
                                    string nombreComCSC = Console.ReadLine();
                                    nombreComCSC = SoloLetras(nombreComCSC);

                                    Camion ca = new Camion(
                                                            int.Parse(idVehiculoCA),
                                                            patenteCA,
                                                            int.Parse(kmCA),
                                                            int.Parse(anoCA),
                                                            modCA,
                                                            int.Parse(pVentaCA),
                                                            observCA,
                                                            colorCA,
                                                            cajaCarga,
                                                            int.Parse(idMarcaCA),
                                                            nombreMarcaCSC,
                                                            int.Parse(idSegCA),
                                                            nombreSegmentoCSC,
                                                            int.Parse(idComCA),
                                                            nombreComCSC);

                                    this._camionesSinCajaList.Add(ca);
                                    Console.WriteLine("\n");
                                    Console.WriteLine("<<<<<<<Vehiculo agregado con EXITO>>>>>");
                                    Console.ReadKey();

                                    GrabarArchivo(_archivoCamionesSinCaja);

                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("<<<<<<<LA OPCION DEBE SER (1 0 2)>>>>>");
                                    Console.ResetColor();
                                }
                            }

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


        public void CargarParametricos()
        {
            int opc;
            bool opcionVali = false;

            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("**¿QUÉ DESEAS CARGAR?**");
                Console.WriteLine("1) MARCAS  2) SEGMENTOS  3) COMBUSTIBLES 4) LOCALIDADES 5) PROVINCIAS");

                if (int.TryParse(Console.ReadLine(), out opc))
                {
                    switch (opc)
                    {
                        case 1:

                            Console.WriteLine("\n**Ingresa el ID de la Marca**");
                            ListarMarcas();
                            string idMarca = Console.ReadLine();
                            idMarca = ValidarIdNumericoOExiste(idMarca, _archivoMarcas);

                            Console.WriteLine("**Ingresa el Nombre de la Marca**");
                            string nombreMarca = Console.ReadLine();
                            nombreMarca = SoloLetras(nombreMarca);

                            Marca nuevaMarca = new Marca(
                                                    int.Parse(idMarca),
                                                    nombreMarca);

                            this._marcasList.Add(nuevaMarca);

                            Console.WriteLine("\n");
                            Console.WriteLine("<<<<<<<Marca agregada con EXITO>>>>>");

                            GrabarArchivo(_archivoMarcas);
                            Console.ReadKey();

                            opcionVali = true;
                            break;

                        case 2:

                            Console.WriteLine("\n**Ingresa el ID del Segmento**");
                            ListarSegmentos();
                            string idSegmento = Console.ReadLine();
                            idSegmento = ValidarIdNumericoOExiste(idSegmento, _archivoSegmento);

                            Console.WriteLine("**Ingresa el Nombre del Segmento**");
                            string nombreSegmento = Console.ReadLine();
                            nombreSegmento = SoloLetras(nombreSegmento);

                            Segmento nuevoSegmento = new Segmento(
                                                    int.Parse(idSegmento),
                                                    nombreSegmento);

                            this._segmentosList.Add(nuevoSegmento);

                            Console.WriteLine("\n");
                            Console.WriteLine("<<<<<<<Segmento agregado con EXITO>>>>>");

                            GrabarArchivo(_archivoSegmento);
                            Console.ReadKey();

                            opcionVali = true;
                            break;

                        case 3:

                            Console.WriteLine("\n**Ingresa el ID del Combustible**");
                            ListarCombustible();
                            string idCombustible = Console.ReadLine();
                            idCombustible = ValidarIdNumericoOExiste(idCombustible, _archivoCombustible);

                            Console.WriteLine("**Ingresa el Nombre del Combustible**");
                            string nombreCombustible = Console.ReadLine();
                            nombreCombustible = SoloLetras(nombreCombustible);

                            Combustible nuevoCombustible = new Combustible(
                                                int.Parse(idCombustible),
                                                nombreCombustible);

                            this._combustiblesList.Add(nuevoCombustible);

                            Console.WriteLine("\n");
                            Console.WriteLine("<<<<<<<Combustible agregado con EXITO>>>>>");

                            GrabarArchivo(_archivoCombustible);
                            Console.ReadKey();
                            opcionVali = true;
                            break;

                        case 4:

                            Console.WriteLine("\n**Ingresa el ID de la Localidad**");
                            ListarLocalidades();
                            string idLocalidad = Console.ReadLine();
                            idLocalidad = ValidarIdNumericoOExiste(idLocalidad, _archivoLocalidades);

                            Console.WriteLine("**Ingresa el Nombre de la Localidad**");
                            string nombreLocalidad = Console.ReadLine();
                            nombreLocalidad = SoloLetras(nombreLocalidad);

                            Console.WriteLine("**Ingresa el ID de la Provincia**");
                            ListarProvincias();
                            string idProvincia = Console.ReadLine();
                            idProvincia = ValidarIdNumericoOExiste(idProvincia, _archivoProvincias);

                            Localidad nuevaLocalidad = new Localidad(
                                                int.Parse(idLocalidad),
                                                nombreLocalidad,
                                                int.Parse(idProvincia));

                            this._localidadesList.Add(nuevaLocalidad);

                            Console.WriteLine("\n");
                            Console.WriteLine("<<<<<<<Localidad agregada con EXITO>>>>>");

                            GrabarArchivo(_archivoLocalidades);
                            Console.ReadKey();
                            opcionVali = true;
                            break;

                        case 5:

                            Console.WriteLine("\n**Ingresa el ID de la Provincia**");
                            ListarProvincias();
                            string idProvin = Console.ReadLine();
                            idProvin = ValidarIdNumericoOExiste(idProvin, _archivoProvincias);

                            Console.WriteLine("**Ingresa el Nombre de la Provincia**");
                            string nombreProvincia = Console.ReadLine();
                            nombreProvincia = SoloLetras(nombreProvincia);

                            Provincia nuevaProvincia = new Provincia(
                                                int.Parse(idProvin),
                                                nombreProvincia);

                            this._provinciasList.Add(nuevaProvincia);

                            Console.WriteLine("\n");
                            Console.WriteLine("<<<<<<<Provincia agregada con EXITO>>>>>");

                            GrabarArchivo(_archivoProvincias);
                            Console.ReadKey();
                            opcionVali = true;
                            break;

                        default:
                            Console.WriteLine("Selecciona una opción entre 1 y 5.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingresa un número.");
                }
            } while (!opcionVali);
        }


        //__Metodos de acciones actualizar datos__
        public void ActualizarCliente()
        {
            Actualizar(_archivoClientes);
        }


        public void ActualizarVenta()
        {
            Actualizar(_archivoVentas);
        }


        public void AtualizarVehiculo()
        {
            bool opcionValida = false;  //__bandera para verificar la opción__

            do
            {
                Console.WriteLine("Que VEHICULO desea Actualizar");
                Console.WriteLine("1) AUTOS/CAMIONETAS 2)CAMIONES 3)MOTOS");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:

                            ListarVehiculos();
                            Console.WriteLine("\n");
                            LeerArchivo(_archivoAutosCamionetas);

                            Console.WriteLine("Ingresa el NUMERO del AUTO o CAMIONETA a actualizar:");
                            string idAC = Console.ReadLine();
                            idAC = ValidarIdSoloNumerico(idAC);
                            int idCondicion = int.Parse(idAC);//__parsear para codicionar__

                            bool vehiculoEncontrado = false;  //__bandera para indicar si encontramos el cliente__

                            for (int i = 0; i < this._autosCamionetasList.Count; i++)
                            {
                                if (this._autosCamionetasList[i].IdVehiculo == idCondicion)
                                {
                                    vehiculoEncontrado = true;  //__encontrado__
                                    bool opcionValida2 = false;  //__bandera para verificar la opción__

                                    do
                                    {
                                        Console.WriteLine("VEHICULO encontrado. Qué campo deseas actualizar?");
                                        Console.WriteLine("1- Patente");
                                        Console.WriteLine("2- Kilometraje");
                                        Console.WriteLine("3- Año");
                                        Console.WriteLine("4- Modelo");
                                        Console.WriteLine("5- Precio de Venta");
                                        Console.WriteLine("6- Observaciones");
                                        Console.WriteLine("7- Color");
                                        Console.WriteLine("8- Marca");
                                        Console.WriteLine("9- Segmento");
                                        Console.WriteLine("10- Combustible");

                                        if (int.TryParse(Console.ReadLine(), out int opcion2))
                                        {
                                            switch (opcion2)
                                            {
                                                case 1:
                                                    Console.WriteLine("Ingresa la nueva Patente:");
                                                    this._autosCamionetasList[i].Patente = Console.ReadLine();
                                                    opcionValida2 = true;
                                                    break;

                                                case 2:
                                                    Console.WriteLine("Ingresa el nuevo Kilometraje:");
                                                    string nuevoKilometraje = Console.ReadLine();
                                                    nuevoKilometraje = ValidarIdSoloNumerico(nuevoKilometraje);
                                                    this._autosCamionetasList[i].Kilometro = int.Parse(nuevoKilometraje);
                                                    opcionValida2 = true;
                                                    break;

                                                case 3:
                                                    Console.WriteLine("Ingresa el nuevo Año:");
                                                    string nuevoAnio = Console.ReadLine();
                                                    nuevoAnio = ValidarIdSoloNumerico(nuevoAnio);
                                                    this._autosCamionetasList[i].Anio = int.Parse(nuevoAnio);
                                                    opcionValida2 = true;
                                                    break;

                                                case 4:
                                                    Console.WriteLine("Ingresa el nuevo Modelo:");
                                                    string modelo = Console.ReadLine();
                                                    modelo = SoloLetras(modelo);
                                                    this._autosCamionetasList[i].Modelo = modelo;
                                                    opcionValida2 = true;
                                                    break;

                                                case 5:
                                                    Console.WriteLine("Ingresa el nuevo Precio de Venta:");
                                                    string nuevoPrecioVenta = Console.ReadLine();
                                                    nuevoPrecioVenta = ValidarIdSoloNumerico(nuevoPrecioVenta);
                                                    this._autosCamionetasList[i].PrecioVenta = int.Parse(nuevoPrecioVenta);
                                                    opcionValida2 = true;
                                                    break;

                                                case 6:
                                                    Console.WriteLine("Ingresa las nuevas Observaciones:");
                                                    this._autosCamionetasList[i].Observaciones = Console.ReadLine();
                                                    opcionValida2 = true;
                                                    break;

                                                case 7:
                                                    Console.WriteLine("Ingresa el nuevo Color:");
                                                    string color = Console.ReadLine();
                                                    color = SoloLetras(color);
                                                    this._autosCamionetasList[i].Color = color;
                                                    opcionValida2 = true;
                                                    break;

                                                case 8:
                                                    Console.WriteLine("Ingresa el nuevo Marca:");
                                                    string nuevoMarca = Console.ReadLine();
                                                    nuevoMarca = SoloLetras(nuevoMarca);
                                                    this._autosCamionetasList[i].NombreMarca = nuevoMarca;
                                                    opcionValida2 = true;
                                                    break;

                                                case 9:
                                                    Console.WriteLine("Ingresa el nuevo Segmento:");
                                                    string nuevoSegmento = Console.ReadLine();
                                                    nuevoSegmento = SoloLetras(nuevoSegmento);
                                                    this._autosCamionetasList[i].NombreSegmento = nuevoSegmento;
                                                    opcionValida2 = true;
                                                    break;

                                                case 10:
                                                    Console.WriteLine("Ingresa el nuevo Combustible:");
                                                    string nuevoCombustible = Console.ReadLine();
                                                    nuevoCombustible = SoloLetras(nuevoCombustible);
                                                    this._autosCamionetasList[i].NombreCombustible = nuevoCombustible;
                                                    opcionValida2 = true;
                                                    break;

                                                default:
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("_________________________________________________");
                                                    Console.WriteLine("Opción no válida. Por favor, elige una opción del 1 al 10.");
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

                                    } while (!opcionValida2);
                                }
                            }

                            if (vehiculoEncontrado)
                            {
                                GrabarArchivo(_archivoAutosCamionetas);
                                Console.WriteLine("AUTO-CAMIONETA actualizado correctamente");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("El VEHICULO no existe.");
                                Console.ResetColor();
                            }

                            opcionValida = true;
                            break;

                        case 2:

                            Console.WriteLine("QUE TIPO DE CAMIONES DESEA ACTUALIZAR CON CAJA/SIN CAJA");
                            Console.WriteLine("**Tiene caja de carga? INGRESA (SI o NO)**");
                            string respuesta = Console.ReadLine().ToUpper();

                            while (respuesta != "SI" && respuesta != "NO")
                            {
                                Console.WriteLine("**Respuesta inválida. INGRESA (SI o NO) con Mayusculas**");
                                respuesta = Console.ReadLine().ToUpper();
                            }

                            if (respuesta == "SI")
                            {
                                ListarVehiculos();
                                Console.WriteLine("\n");
                                LeerArchivo(_archivoCamionesConCaja);

                                Console.WriteLine("Ingresa el NUMERO del CAMION a actualizar:");
                                string idCA = Console.ReadLine();
                                idAC = ValidarIdSoloNumerico(idCA);
                                int idCondicion3 = int.Parse(idCA);//__parsear para codicionar__

                                bool vehiculoEncontradoCamion = false;  //__bandera para indicar si encontramos el vehiculo__

                                for (int i = 0; i < this._camionesConCajaList.Count; i++)
                                {
                                    if (this._camionesConCajaList[i].IdVehiculo == idCondicion3)
                                    {
                                        vehiculoEncontradoCamion = true;  //__encontrado__
                                        bool opcionValida3 = false;  //__bandera para verificar la opción__

                                        do
                                        {
                                            Console.WriteLine("CAMIÓN CON CAJA encontrado. ¿Qué campo deseas actualizar?");
                                            Console.WriteLine("1- Patente");
                                            Console.WriteLine("2- Kilómetros");
                                            Console.WriteLine("3- Año");
                                            Console.WriteLine("4- Modelo");
                                            Console.WriteLine("5- Precio de Venta");
                                            Console.WriteLine("6- Observaciones");
                                            Console.WriteLine("7- Color");
                                            Console.WriteLine("8- Dimensión de la Caja");
                                            Console.WriteLine("9- Carga Máxima");
                                            Console.WriteLine("10- Marca");
                                            Console.WriteLine("11- Segmento");
                                            Console.WriteLine("12- Combustible");


                                            if (int.TryParse(Console.ReadLine(), out int opcion2))
                                            {
                                                switch (opcion2)
                                                {
                                                    case 1:
                                                        Console.WriteLine("Ingresa la nueva Patente:");
                                                        this._camionesConCajaList[i].Patente = Console.ReadLine();
                                                        opcionValida3 = true;
                                                        break;

                                                    case 2:
                                                        Console.WriteLine("Ingresa los nuevos Kilómetros:");
                                                        string nuevoKilometraje = Console.ReadLine();
                                                        nuevoKilometraje = ValidarIdSoloNumerico(nuevoKilometraje);
                                                        this._camionesConCajaList[i].Kilometro = int.Parse(nuevoKilometraje);
                                                        opcionValida3 = true;
                                                        break;

                                                    case 3:
                                                        Console.WriteLine("Ingresa el nuevo Año:");
                                                        string nuevoAnio = Console.ReadLine();
                                                        nuevoAnio = ValidarIdSoloNumerico(nuevoAnio);
                                                        this._camionesConCajaList[i].Anio = int.Parse(nuevoAnio);
                                                        opcionValida3 = true;
                                                        break;

                                                    case 4:
                                                        Console.WriteLine("Ingresa el nuevo Modelo:");
                                                        string modelo = Console.ReadLine();
                                                        modelo = SoloLetras(modelo);
                                                        this._camionesConCajaList[i].Modelo = modelo;
                                                        opcionValida3 = true;
                                                        break;

                                                    case 5:
                                                        Console.WriteLine("Ingresa el nuevo Precio de Venta:");
                                                        string nuevoPrecioVenta = Console.ReadLine();
                                                        nuevoPrecioVenta = ValidarIdSoloNumerico(nuevoPrecioVenta);
                                                        this._camionesConCajaList[i].PrecioVenta = int.Parse(nuevoPrecioVenta);
                                                        opcionValida3 = true;
                                                        break;

                                                    case 6:
                                                        Console.WriteLine("Ingresa las nuevas Observaciones:");
                                                        this._camionesConCajaList[i].Observaciones = Console.ReadLine();
                                                        opcionValida3 = true;
                                                        break;

                                                    case 7:
                                                        Console.WriteLine("Ingresa el nuevo Color:");
                                                        string color = Console.ReadLine();
                                                        color = SoloLetras(color);
                                                        this._camionesConCajaList[i].Color = color;
                                                        opcionValida3 = true;
                                                        break;

                                                    case 8:
                                                        Console.WriteLine("Ingresa la nueva Dimensión de la Caja:");
                                                        string dimesionCaja = Console.ReadLine();
                                                        dimesionCaja = ValidarIdSoloNumerico(dimesionCaja);
                                                        this._camionesConCajaList[i].DimensionCaja = int.Parse(dimesionCaja);
                                                        opcionValida3 = true;
                                                        break;

                                                    case 9:
                                                        Console.WriteLine("Ingresa la nueva Carga Máxima:");
                                                        string cargaMax = Console.ReadLine();
                                                        cargaMax = ValidarIdSoloNumerico(cargaMax);
                                                        this._camionesConCajaList[i].CargaMaxima = int.Parse(cargaMax);
                                                        opcionValida3 = true;
                                                        break;

                                                    case 10:
                                                        Console.WriteLine("Ingresa la nueva Marca:");
                                                        string nuevoMarca = Console.ReadLine();
                                                        nuevoMarca = SoloLetras(nuevoMarca);
                                                        this._camionesConCajaList[i].NombreMarca = nuevoMarca;
                                                        opcionValida3 = true;
                                                        break;

                                                    case 11:
                                                        Console.WriteLine("Ingresa el nuevo ID Segmento:");
                                                        this._camionesConCajaList[i].NombreSegmento = Console.ReadLine();
                                                        opcionValida3 = true;
                                                        break;

                                                    case 12:
                                                        Console.WriteLine("Ingresa el nuevo Combustible:");
                                                        string nuevoSegmento = Console.ReadLine();
                                                        nuevoSegmento = SoloLetras(nuevoSegmento);
                                                        this._camionesConCajaList[i].NombreCombustible = nuevoSegmento;
                                                        opcionValida3 = true;
                                                        break;

                                                    default:
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Opción no válida. Por favor, elige una opción del 1 al 12.");
                                                        Console.ResetColor();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Entrada no válida. Debes ingresar un número.");
                                                Console.ResetColor();
                                            }

                                        } while (!opcionValida3);

                                        if (vehiculoEncontradoCamion)
                                        {
                                            GrabarArchivo(_archivoCamionesConCaja);
                                            Console.WriteLine("CAMIÓN CON CAJA actualizado correctamente.");
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("El VEHICULO no existe.");
                                            Console.ResetColor();
                                        }

                                    }
                                }

                            }

                            if (respuesta == "NO")
                            {
                                ListarVehiculos();
                                Console.WriteLine("\n");
                                LeerArchivo(_archivoCamionesSinCaja);

                                Console.WriteLine("Ingresa el NUMERO del CAMION a actualizar:");
                                string idCA = Console.ReadLine();
                                idAC = ValidarIdSoloNumerico(idCA);
                                int idCondicion4 = int.Parse(idCA);//__parsear para codicionar__

                                bool vehiculoEncontradoCamion = false;  //__bandera para indicar si encontramos el vehiculo__

                                for (int i = 0; i < this._camionesSinCajaList.Count; i++)
                                {
                                    if (this._camionesSinCajaList[i].IdVehiculo == idCondicion4)
                                    {
                                        vehiculoEncontradoCamion = true;  //__encontrado__
                                        bool opcionValida4 = false;  //__bandera para verificar la opción__

                                        do
                                        {
                                            Console.WriteLine("CAMIÓN SIN CAJA encontrado. ¿Qué campo deseas actualizar?");
                                            Console.WriteLine("1- Patente");
                                            Console.WriteLine("2- Kilómetros");
                                            Console.WriteLine("3- Año");
                                            Console.WriteLine("4- Modelo");
                                            Console.WriteLine("5- Precio de Venta");
                                            Console.WriteLine("6- Observaciones");
                                            Console.WriteLine("7- Color");
                                            Console.WriteLine("8- Nombre Marca");
                                            Console.WriteLine("9-Nombre Segmento");
                                            Console.WriteLine("10-Nombre Combustible");


                                            if (int.TryParse(Console.ReadLine(), out int opcion2))
                                            {
                                                switch (opcion2)
                                                {
                                                    case 1:
                                                        Console.WriteLine("Ingresa la nueva Patente:");
                                                        this._camionesSinCajaList[i].Patente = Console.ReadLine();
                                                        opcionValida4 = true;
                                                        break;

                                                    case 2:
                                                        Console.WriteLine("Ingresa los nuevos Kilómetros:");
                                                        string nuevoKilometraje = Console.ReadLine();
                                                        nuevoKilometraje = ValidarIdSoloNumerico(nuevoKilometraje);
                                                        this._camionesSinCajaList[i].Kilometro = int.Parse(nuevoKilometraje);
                                                        opcionValida4 = true;
                                                        break;

                                                    case 3:
                                                        Console.WriteLine("Ingresa el nuevo Año:");
                                                        string nuevoAnio = Console.ReadLine();
                                                        nuevoAnio = ValidarIdSoloNumerico(nuevoAnio);
                                                        this._camionesSinCajaList[i].Anio = int.Parse(nuevoAnio);
                                                        opcionValida4 = true;
                                                        break;

                                                    case 4:
                                                        Console.WriteLine("Ingresa el nuevo Modelo:");
                                                        string modelo = Console.ReadLine();
                                                        modelo = SoloLetras(modelo);
                                                        this._camionesSinCajaList[i].Modelo = modelo;
                                                        opcionValida4 = true;
                                                        break;

                                                    case 5:
                                                        Console.WriteLine("Ingresa el nuevo Precio de Venta:");
                                                        string nuevoPrecioVenta = Console.ReadLine();
                                                        nuevoPrecioVenta = ValidarIdSoloNumerico(nuevoPrecioVenta);
                                                        this._camionesSinCajaList[i].PrecioVenta = int.Parse(nuevoPrecioVenta);
                                                        opcionValida4 = true;
                                                        break;

                                                    case 6:
                                                        Console.WriteLine("Ingresa las nuevas Observaciones:");
                                                        this._camionesSinCajaList[i].Observaciones = Console.ReadLine();
                                                        opcionValida4 = true;
                                                        break;

                                                    case 7:
                                                        Console.WriteLine("Ingresa el nuevo Color:");
                                                        string color = Console.ReadLine();
                                                        color = SoloLetras(color);
                                                        this._camionesSinCajaList[i].Color = color;
                                                        opcionValida4 = true;
                                                        break;

                                                    case 8:
                                                        Console.WriteLine("Ingresa la nueva Marca:");
                                                        this._camionesSinCajaList[i].NombreMarca = Console.ReadLine();
                                                        opcionValida4 = true;
                                                        break;

                                                    case 9:
                                                        Console.WriteLine("Ingresa el nuevo Segmento:");
                                                        this._camionesSinCajaList[i].NombreSegmento = Console.ReadLine();
                                                        opcionValida4 = true;
                                                        break;

                                                    case 10:
                                                        Console.WriteLine("Ingresa el nuevo ID Combustible:");
                                                        this._camionesSinCajaList[i].NombreCombustible = Console.ReadLine();
                                                        opcionValida4 = true;
                                                        break;

                                                    default:
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Opción no válida. Por favor, elige una opción del 1 al 12.");
                                                        Console.ResetColor();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Entrada no válida. Debes ingresar un número.");
                                                Console.ResetColor();
                                            }

                                        } while (!opcionValida4);

                                        if (vehiculoEncontradoCamion)
                                        {
                                            GrabarArchivo(_archivoCamionesConCaja);
                                            Console.WriteLine("CAMIÓN CON CAJA actualizado correctamente.");
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("El VEHICULO no existe.");
                                            Console.ResetColor();
                                        }

                                    }
                                }

                            }

                            opcionValida = true;

                            break;

                        case 3:

                            ListarVehiculos();
                            Console.WriteLine("\n");
                            LeerArchivo(_archivoMotos);

                            Console.WriteLine("Ingresa el NUMERO de la MOTO a actualizar:");
                            string idMoto = Console.ReadLine();
                            idMoto = ValidarIdSoloNumerico(idMoto);
                            int idCondicionMoto = int.Parse(idMoto);

                            bool motoEncontrada = false;

                            for (int i = 0; i < this._motosList.Count; i++)
                            {
                                if (this._motosList[i].IdVehiculo == idCondicionMoto)
                                {
                                    motoEncontrada = true;
                                    bool opcionValidaMoto = false;

                                    do
                                    {
                                        Console.WriteLine("VEHÍCULO encontrado. ¿Qué campo deseas actualizar?");
                                        Console.WriteLine("1- Patente");
                                        Console.WriteLine("2- Cilindrada");
                                        Console.WriteLine("3- Año");
                                        Console.WriteLine("4- Modelo");
                                        Console.WriteLine("5- Precio de Venta");
                                        Console.WriteLine("6- Observaciones");
                                        Console.WriteLine("7- Color");
                                        Console.WriteLine("8- Nombre Marca");
                                        Console.WriteLine("9- Nombre Segmento");
                                        Console.WriteLine("10- Nombre Combustible");

                                        if (int.TryParse(Console.ReadLine(), out int opcionMoto))
                                        {
                                            switch (opcionMoto)
                                            {
                                                case 1:
                                                    Console.WriteLine("Ingresa la nueva Patente:");
                                                    this._motosList[i].Patente = Console.ReadLine();
                                                    opcionValidaMoto = true;
                                                    break;

                                                case 2:
                                                    Console.WriteLine("Ingresa la nueva Cilindrada:");
                                                    if (int.TryParse(Console.ReadLine(), out int nuevaCilindrada))
                                                    {
                                                        this._motosList[i].Cilindrada = nuevaCilindrada;
                                                        opcionValidaMoto = true;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Debes ingresar un números.");
                                                    }
                                                    break;

                                                case 3:
                                                    Console.WriteLine("Ingresa el nuevo Año:");
                                                    if (int.TryParse(Console.ReadLine(), out int nuevoAnio))
                                                    {
                                                        this._motosList[i].Anio = nuevoAnio;
                                                        opcionValidaMoto = true;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Debes ingresar un números.");
                                                    }
                                                    break;

                                                case 4:
                                                    Console.WriteLine("Ingresa el nuevo Modelo:");
                                                    string modelo = Console.ReadLine();
                                                    modelo = SoloLetras(modelo);
                                                    this._motosList[i].Modelo = modelo;
                                                    opcionValidaMoto = true;
                                                    break;

                                                case 5:
                                                    Console.WriteLine("Ingresa el nuevo Precio de Venta:");
                                                    if (int.TryParse(Console.ReadLine(), out int nuevoPrecioVenta))
                                                    {
                                                        this._motosList[i].PrecioVenta = nuevoPrecioVenta;
                                                        opcionValidaMoto = true;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Debes ingresar un número.");
                                                    }
                                                    break;

                                                case 6:
                                                    Console.WriteLine("Ingresa las nuevas Observaciones:");
                                                    this._motosList[i].Observaciones = Console.ReadLine();
                                                    opcionValidaMoto = true;
                                                    break;

                                                case 7:
                                                    Console.WriteLine("Ingresa el nuevo Color:");
                                                    string color = Console.ReadLine();
                                                    color = SoloLetras(color);
                                                    this._motosList[i].Color = color;
                                                    opcionValidaMoto = true;
                                                    break;

                                                case 8:
                                                    Console.WriteLine("Ingresa el nuevo Nombre de Marca:");
                                                    string nuevoMarca = Console.ReadLine();
                                                    nuevoMarca = SoloLetras(nuevoMarca);
                                                    this._motosList[i].NombreMarca = nuevoMarca;
                                                    opcionValidaMoto = true;
                                                    break;

                                                case 9:
                                                    Console.WriteLine("Ingresa el nuevo Nombre de Segmento:");
                                                    string nuevoSegmento = Console.ReadLine();
                                                    nuevoSegmento = SoloLetras(nuevoSegmento);
                                                    this._motosList[i].NombreSegmento = nuevoSegmento;
                                                    opcionValidaMoto = true;
                                                    break;

                                                case 10:
                                                    Console.WriteLine("Ingresa el nuevo Nombre de Combustible:");
                                                    string nuevoCombustible = Console.ReadLine();
                                                    nuevoCombustible = SoloLetras(nuevoCombustible);
                                                    this._motosList[i].NombreCombustible = nuevoCombustible;
                                                    opcionValidaMoto = true;
                                                    break;

                                                default:
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("_________________________________________________");
                                                    Console.WriteLine("Opción no válida. Por favor, elige una opción del 1 al 10.");
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

                                    } while (!opcionValidaMoto);
                                }
                            }

                            if (motoEncontrada)
                            {
                                GrabarArchivo(_archivoMotos);
                                Console.WriteLine("MOTO actualizada correctamente");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("La MOTO no existe.");
                                Console.ResetColor();
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


        public void ActualizarParametricos()
        {
            bool controlDeWhilePrincipal = false;
            int tipoEntidad;

            while (!controlDeWhilePrincipal)
            {
                Console.WriteLine("**¿QUÉ TIPO DE ENTIDAD DESEAS ACTUALIZAR?**");
                Console.WriteLine("1) MARCAS");
                Console.WriteLine("2) SEGMENTOS");
                Console.WriteLine("3) COMBUSTIBLES");
                Console.WriteLine("4) LOCALIDADES");
                Console.WriteLine("5) PROVINCIAS");

                if (int.TryParse(Console.ReadLine(), out tipoEntidad) && (tipoEntidad >= 1 && tipoEntidad <= 5))
                {

                    switch (tipoEntidad)
                    {
                        case 1:
                            Console.WriteLine("**Ingresa el nuevo nombre de la Marca**");
                            string nuevoNombreMar = Console.ReadLine();
                            nuevoNombreMar = SoloLetras(nuevoNombreMar);
                            this._marcasList[0].NombreMarca = nuevoNombreMar; 
                            GrabarArchivo(_archivoMarcas);
                            Console.WriteLine("**NOMBRE DE LA MARCA ACTUALIZADO CORRECTAMENTE**");
                            break;

                        case 2:
                            Console.WriteLine("**Ingresa el nuevo nombre del Segmento**");
                            string nuevoNombreSeg = Console.ReadLine();
                            nuevoNombreSeg = SoloLetras(nuevoNombreSeg);
                            this._segmentosList[0].SegmentoNombre = nuevoNombreSeg; 
                            GrabarArchivo(_archivoSegmento);
                            Console.WriteLine("**NOMBRE DEL SEGMENTO ACTUALIZADO CORRECTAMENTE**");
                            break;

                        case 3:
                            Console.WriteLine("**Ingresa el nuevo nombre del Combustible**");
                            string nuevoNombreCom = Console.ReadLine();
                            nuevoNombreCom = SoloLetras(nuevoNombreCom);
                            this._combustiblesList[0].CombustibleNombre = nuevoNombreCom; 
                            GrabarArchivo(_archivoCombustible);
                            Console.WriteLine("**NOMBRE DEL COMBUSTIBLE ACTUALIZADO CORRECTAMENTE**");
                            break;

                        case 4:
                            Console.WriteLine("**Ingresa el nuevo nombre de la Localidad**");
                            string nuevoNombreLoc = Console.ReadLine();
                            nuevoNombreLoc = SoloLetras(nuevoNombreLoc);
                            this._localidadesList[0].NombreLocalidad = nuevoNombreLoc; 
                            GrabarArchivo(_archivoLocalidades);
                            Console.WriteLine("**NOMBRE DE LA LOCALIDAD ACTUALIZADA CORRECTAMENTE**");
                            break;

                        case 5:
                            Console.WriteLine("**Ingresa el nuevo nombre de la Provincia**");
                            string nuevoNombreProv = Console.ReadLine();
                            nuevoNombreProv = SoloLetras(nuevoNombreProv);
                            this._provinciasList[0].NombreProvincia = nuevoNombreProv;
                            GrabarArchivo(_archivoProvincias);
                            Console.WriteLine("**NOMBRE DE LA PROVINCIA ACTUALIZADA CORRECTAMENTE**");
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Elige una opción del 1 al 5.");
                            Console.ResetColor();
                            break;

                    }
                    controlDeWhilePrincipal = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor, ingresa un número válido.");
                    Console.ResetColor();
                }
            }
        }


        //__Metodos de acciones borrar datos__
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


        public void BorrarVenta()
        {
            ListarVentas();
            Console.ResetColor();
            Console.WriteLine("\n");
            Console.WriteLine("**Ingresa el ID de la VENTA que deseas borrar**");
            string idVen = Console.ReadLine();
            idVen = ValidarIdSoloNumerico(idVen);
            int idCondicionVenta = int.Parse(idVen);

            for (int i = 0; i < this._ventasList.Count; i++)
            {
                if (idCondicionVenta == this._ventasList[i].IdVenta)
                {
                    this._ventasList.RemoveAt(i);
                }
            }
            Console.WriteLine("**VENTA BORRADA CORRECTAMENTE**");
            Console.ReadLine();
            GrabarArchivo(_archivoVentas);
        }


        public void BorrarVehiculo()
        {
            ListarVehiculos();

            Console.ResetColor();
            Console.WriteLine("\n");
            bool controlDeWhilePrincipal = false;
            int tipoVehiculo;

            while (!controlDeWhilePrincipal)
            {
                Console.WriteLine("**¿QUÉ TIPO DE VEHÍCULO DESEAS BORRAR?**");
                Console.WriteLine("1) MOTOS");
                Console.WriteLine("2) AUTOS/CAMIONETAS");
                Console.WriteLine("3) CAMIONES");

                if (int.TryParse(Console.ReadLine(), out tipoVehiculo) && (tipoVehiculo == 1 || tipoVehiculo == 2 || tipoVehiculo == 3))
                {

                    switch (tipoVehiculo)
                    {
                        case 1:

                            Console.WriteLine("**Ingresa el Numero del VEHICULO que desea borrar**");
                            string idMoto = Console.ReadLine();
                            idMoto = ValidarIdSoloNumerico(idMoto);
                            int idCondicion1 = int.Parse(idMoto);//__parsear para codicionar__

                            for (int i = 0; i < this._motosList.Count; i++)
                            {
                                if (idCondicion1 == this._motosList[i].IdVehiculo)
                                {
                                    this._motosList.RemoveAt(i);
                                }
                            }

                            Console.WriteLine("**MOTO BORRADA CORRECTAMENTE**");
                            Console.ReadLine();
                            GrabarArchivo(_archivoMotos);
                            controlDeWhilePrincipal = true;

                            break;

                        case 2:

                            Console.WriteLine("**Ingresa el Numero del VEHICULO que desea borrar**");
                            string idAC = Console.ReadLine();
                            idAC = ValidarIdSoloNumerico(idAC);
                            int idCondicion2 = int.Parse(idAC);//__parsear para codicionar__

                            for (int i = 0; i < this._autosCamionetasList.Count; i++)
                            {
                                if (idCondicion2 == this._autosCamionetasList[i].IdVehiculo)
                                {
                                    this._autosCamionetasList.RemoveAt(i);
                                }
                            }

                            Console.WriteLine("**AUTO/CAMIONETA BORRADA CORRECTAMENTE**");
                            Console.ReadLine();
                            GrabarArchivo(_archivoAutosCamionetas);
                            controlDeWhilePrincipal = true;

                            break;

                        case 3:

                            bool controlBucle = false;

                            while (!controlBucle)
                            {
                                Console.WriteLine("**¿Qué tipo de camión desea BORRAR?**");
                                Console.WriteLine("1. Camión con caja de carga");
                                Console.WriteLine("2. Camión sin caja de carga");
                                string tipoCamion = Console.ReadLine();
                                tipoCamion = ValidarIdSoloNumerico(tipoCamion);

                                if (tipoCamion == "1")
                                {
                                    controlBucle = true;

                                    Console.WriteLine("**Ingresa el Numero del VEHICULO que desea borrar**");
                                    string idCA = Console.ReadLine();
                                    idCA = ValidarIdSoloNumerico(idCA);
                                    int idCondicion3 = int.Parse(idCA);//__parsear para codicionar__

                                    for (int i = 0; i < this._camionesConCajaList.Count; i++)
                                    {
                                        if (idCondicion3 == this._camionesConCajaList[i].IdVehiculo)
                                        {
                                            this._camionesConCajaList.RemoveAt(i);
                                        }
                                    }

                                    Console.WriteLine("**CAMION BORRADO CORRECTAMENTE**");
                                    Console.ReadLine();
                                    GrabarArchivo(_archivoCamionesConCaja);

                                }
                                else if (tipoCamion == "2")
                                {
                                    controlBucle = true;

                                    Console.WriteLine("**Ingresa el Numero del VEHICULO que desea borrar**");
                                    string idCA = Console.ReadLine();
                                    idCA = ValidarIdSoloNumerico(idCA);
                                    int idCondicion3 = int.Parse(idCA);//__parsear para codicionar__

                                    for (int i = 0; i < this._camionesSinCajaList.Count; i++)
                                    {
                                        if (idCondicion3 == this._camionesSinCajaList[i].IdVehiculo)
                                        {
                                            this._camionesSinCajaList.RemoveAt(i);
                                        }
                                    }

                                    Console.WriteLine("**CAMION BORRADO CORRECTAMENTE**");
                                    Console.ReadLine();
                                    GrabarArchivo(_archivoCamionesSinCaja);

                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("<<<<<<<LA OPCION DEBE SER (1 0 2)>>>>>");
                                    Console.ResetColor();
                                }
                            }
                            controlDeWhilePrincipal = true;
                            break;

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor, ingresa un número válido.");
                    Console.ResetColor();
                }

            }

        }


        public void BorrarParametricos()
        {

            bool controlDeWhilePrincipal = false;
            int tipoEntidad;

            while (!controlDeWhilePrincipal)
            {
                Console.WriteLine("**¿QUÉ TIPO DE ENTIDAD DESEAS BORRAR?**");
                Console.WriteLine("1) MARCAS");
                Console.WriteLine("2) SEGMENTOS");
                Console.WriteLine("3) COMBUSTIBLES");
                Console.WriteLine("4) LOCALIDADES");
                Console.WriteLine("5) PROVINCIAS");

                if (int.TryParse(Console.ReadLine(), out tipoEntidad) && (tipoEntidad >= 1 && tipoEntidad <= 5))
                {
                    switch (tipoEntidad)
                    {
                        case 1:
                            Console.WriteLine("**Ingresa el ID de la Marca que deseas borrar**");
                            string idMarca = Console.ReadLine();
                            idMarca = ValidarIdSoloNumerico(idMarca);
                            int idCondicionMarca = int.Parse(idMarca);

                            for (int i = 0; i < this._marcasList.Count; i++)
                            {
                                if (idCondicionMarca == this._marcasList[i].IdMarca)
                                {
                                    this._marcasList.RemoveAt(i);
                                    Console.WriteLine("**MARCA BORRADA CORRECTAMENTE**");
                                    break;
                                }
                            }

                            GrabarArchivo(_archivoMarcas);
                            controlDeWhilePrincipal = true;
                            break;

                        case 2:
                            Console.WriteLine("**Ingresa el ID del Segmento que deseas borrar**");
                            string idSegmento = Console.ReadLine();
                            idSegmento = ValidarIdSoloNumerico(idSegmento);
                            int idCondicionSegmento = int.Parse(idSegmento);

                            for (int i = 0; i < this._segmentosList.Count; i++)
                            {
                                if (idCondicionSegmento == this._segmentosList[i].IdSegmento)
                                {
                                    this._segmentosList.RemoveAt(i);
                                    Console.WriteLine("**SEGMENTO BORRADO CORRECTAMENTE**");
                                    break;
                                }
                            }

                            GrabarArchivo(_archivoSegmento);
                            controlDeWhilePrincipal = true;
                            break;

                        case 3:
                            Console.WriteLine("**Ingresa el ID del Combustible que deseas borrar**");
                            string idCombustible = Console.ReadLine();
                            idCombustible = ValidarIdSoloNumerico(idCombustible);
                            int idCondicionCombustible = int.Parse(idCombustible);

                            for (int i = 0; i < this._combustiblesList.Count; i++)
                            {
                                if (idCondicionCombustible == this._combustiblesList[i].IdCombustible)
                                {
                                    this._combustiblesList.RemoveAt(i);
                                    Console.WriteLine("**COMBUSTIBLE BORRADO CORRECTAMENTE**");
                                    break;
                                }
                            }

                            GrabarArchivo(_archivoCombustible);
                            controlDeWhilePrincipal = true;
                            break;

                        case 4:
                            Console.WriteLine("**Ingresa el ID de la Localidad que deseas borrar**");
                            string idLocalidad = Console.ReadLine();
                            idLocalidad = ValidarIdSoloNumerico(idLocalidad);
                            int idCondicionLocalidad = int.Parse(idLocalidad);

                            for (int i = 0; i < this._localidadesList.Count; i++)
                            {
                                if (idCondicionLocalidad == this._localidadesList[i].IdLocalidad)
                                {
                                    this._localidadesList.RemoveAt(i);
                                    Console.WriteLine("**LOCALIDAD BORRADA CORRECTAMENTE**");
                                    break;
                                }
                            }

                            GrabarArchivo(_archivoLocalidades);
                            controlDeWhilePrincipal = true;
                            break;

                        case 5:
                            Console.WriteLine("**Ingresa el ID de la Provincia que deseas borrar**");
                            string idProvincia = Console.ReadLine();
                            idProvincia = ValidarIdSoloNumerico(idProvincia);
                            int idCondicionProvincia = int.Parse(idProvincia);

                            for (int i = 0; i < this._provinciasList.Count; i++)
                            {
                                if (idCondicionProvincia == this._provinciasList[i].IdProvincia)
                                {
                                    this._provinciasList.RemoveAt(i);
                                    Console.WriteLine("**PROVINCIA BORRADA CORRECTAMENTE**");
                                    break;
                                }
                            }

                            GrabarArchivo(_archivoProvincias);
                            controlDeWhilePrincipal = true;
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor, ingresa un número válido.");
                    Console.ResetColor();
                }
            }
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
                Console.WriteLine("Que VEHICULO desea Listar");
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

                            Console.WriteLine("¿QUÉ TIPO DE CAMIONES DESEA LISTAR?");
                            Console.WriteLine("**INGRESA 1 PARA CAMIONES CON CAJA / 2 PARA CAMIONES SIN CAJA**");

                            int opcionCamiones;
                            bool entradaValida = int.TryParse(Console.ReadLine(), out opcionCamiones);

                            while (!entradaValida || (opcionCamiones < 1 || opcionCamiones > 2))
                            {
                                Console.WriteLine("**Opción inválida. INGRESA 1 para CAMIONES CON CAJA o 2 para CAMIONES SIN CAJA**");
                                entradaValida = int.TryParse(Console.ReadLine(), out opcionCamiones);
                            }

                            if (opcionCamiones == 1)
                            {
                                this._camionesConCajaList.Clear();
                                LeerArchivo(_archivoCamionesConCaja);

                                foreach (Camion i in this._camionesConCajaList)
                                {
                                    i.MostrarDatos();
                                }
                            }
                            else if (opcionCamiones == 2)
                            {
                                this._camionesSinCajaList.Clear(); //__Limpiamos lista para no generar repeticion de datos__
                                LeerArchivo(_archivoCamionesSinCaja);

                                foreach (Camion i in this._camionesSinCajaList)
                                {
                                    i.MostrarDatosCamionesSinCaja();
                                }
                            }
                            else if (opcionCamiones == 3)
                            {
                                LeerArchivo(_archivoMotos);

                                foreach (Moto i in this._motosList)
                                {
                                    i.MostrarDatos();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("_________________________________________________");
                                Console.WriteLine("Opción no válida. Por favor, elige una opción del 1 al 3.");
                                Console.WriteLine("_________________________________________________");
                                Console.ResetColor();
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


        public void ListarVentas()
        {
            LeerArchivo(_archivoVentas);

            foreach (Venta i in this._ventasList)
            {
                i.MostrarDatos();
            }

            Console.ResetColor();

        }


        public void ListarPrametricos()
        {

            bool controlDeWhilePrincipal = false;
            int tipoEntidad;

            while (!controlDeWhilePrincipal)
            {
                Console.WriteLine("**¿QUÉ TIPO DE ENTIDAD DESEAS BORRAR?**");
                Console.WriteLine("1) MARCAS");
                Console.WriteLine("2) SEGMENTOS");
                Console.WriteLine("3) COMBUSTIBLES");
                Console.WriteLine("4) LOCALIDADES");
                Console.WriteLine("5) PROVINCIAS");

                if (int.TryParse(Console.ReadLine(), out tipoEntidad) && (tipoEntidad >= 1 && tipoEntidad <= 5))
                {
                    switch (tipoEntidad)
                    {
                        case 1:
                            ListarMarcas();
                            controlDeWhilePrincipal = true;
                            break;

                        case 2:
                            ListarSegmentos();
                            controlDeWhilePrincipal = true;
                            break;

                        case 3:
                            ListarCombustible();
                            controlDeWhilePrincipal = true;
                            break;

                        case 4:
                            ListarLocalidades();
                            controlDeWhilePrincipal = true;
                            break;

                        case 5:
                            ListarProvincias();
                            controlDeWhilePrincipal = true;
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor, ingresa un número válido.");
                    Console.ResetColor();
                }
            }

        }


        //__Metodos privados de la clase__
        private void ListarProvincias()
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


        private void ListarLocalidades()
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


        private void ListarSegmentos()
        {
            LeerArchivo(_archivoSegmento);

            Console.ForegroundColor = ConsoleColor.Blue;

            foreach (Segmento i in this._segmentosList)
            {
                i.MostrarDatos();
            }

            Console.ResetColor();
        }


        private void ListarMarcas()
        {
            LeerArchivo(_archivoMarcas);
            Console.ForegroundColor = ConsoleColor.Blue;

            foreach (Marca i in this._marcasList)
            {
                i.MostrarDatos();
            }

            Console.ResetColor();
        }


        private void ListarCombustible()
        {
            LeerArchivo(_archivoCombustible);

            foreach (Combustible i in this._combustiblesList)
            {
                i.MostrarDatos();
            }

            Console.ResetColor();
        }


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

                        for (int i = 0; i < this._ventasList.Count; i++)
                        {
                            grabar.WriteLine(+this._ventasList[i].IdVenta + "|"
                                             + this._ventasList[i].IdCliente + "|"
                                             + this._ventasList[i].NombreCliente + "|"
                                             + this._ventasList[i].IdVehiculo + "|"
                                             + this._ventasList[i].NombreVehiculo + "|"
                                             + this._ventasList[i].FechaCompra + "|"
                                             + this._ventasList[i].FechaVenta);
                        }
                        grabar.Close();
                        x.Close();

                        break;

                    case _archivoMotos:

                        x = new FileStream(_archivoMotos, FileMode.Create);
                        grabar = new StreamWriter(x);

                        for (int i = 0; i < this._motosList.Count; i++)
                        {
                            grabar.WriteLine(this._motosList[i].IdVehiculo + "|"
                                             + this._motosList[i].Cilindrada + "|"
                                             + this._motosList[i].Patente + "|"
                                             + this._motosList[i].Kilometro + "|"
                                             + this._motosList[i].Anio + "|"
                                             + this._motosList[i].Modelo + "|"
                                             + this._motosList[i].PrecioVenta + "|"
                                             + this._motosList[i].Observaciones + "|"
                                             + this._motosList[i].Color + "|"
                                             + this._motosList[i].IdMarca + "|"
                                             + this._motosList[i].NombreMarca + "|"
                                             + this._motosList[i].IdSegmento + "|"
                                             + this._motosList[i].NombreSegmento + "|"
                                             + this._motosList[i].IdCombustible + "|"
                                             + this._motosList[i].NombreCombustible);
                        }
                        grabar.Close();
                        x.Close();
                        break;

                    case _archivoAutosCamionetas:

                        x = new FileStream(_archivoAutosCamionetas, FileMode.Create);
                        grabar = new StreamWriter(x);

                        for (int i = 0; i < this._autosCamionetasList.Count; i++)
                        {
                            grabar.WriteLine(this._autosCamionetasList[i].IdVehiculo + "|"
                                             + this._autosCamionetasList[i].Patente + "|"
                                             + this._autosCamionetasList[i].Kilometro + "|"
                                             + this._autosCamionetasList[i].Anio + "|"
                                             + this._autosCamionetasList[i].Modelo + "|"
                                             + this._autosCamionetasList[i].PrecioVenta + "|"
                                             + this._autosCamionetasList[i].Observaciones + "|"
                                             + this._autosCamionetasList[i].Color + "|"
                                             + this._autosCamionetasList[i].IdMarca + "|"
                                             + this._autosCamionetasList[i].NombreMarca + "|"
                                             + this._autosCamionetasList[i].IdSegmento + "|"
                                             + this._autosCamionetasList[i].NombreSegmento + "|"
                                             + this._autosCamionetasList[i].IdCombustible + "|"
                                             + this._autosCamionetasList[i].NombreCombustible);
                        }
                        grabar.Close();
                        x.Close();
                        break;

                    case _archivoCamionesConCaja:

                        x = new FileStream(_archivoCamionesConCaja, FileMode.Create);
                        grabar = new StreamWriter(x);

                        for (int i = 0; i < this._camionesConCajaList.Count; i++)
                        {
                            grabar.WriteLine(this._camionesConCajaList[i].IdVehiculo + "|"
                                             + this._camionesConCajaList[i].Patente + "|"
                                             + this._camionesConCajaList[i].Kilometro + "|"
                                             + this._camionesConCajaList[i].Anio + "|"
                                             + this._camionesConCajaList[i].Modelo + "|"
                                             + this._camionesConCajaList[i].PrecioVenta + "|"
                                             + this._camionesConCajaList[i].Observaciones + "|"
                                             + this._camionesConCajaList[i].Color + "|"
                                             + this._camionesConCajaList[i].CajaCarga + "|"
                                             + this._camionesConCajaList[i].DimensionCaja + "|"
                                             + this._camionesConCajaList[i].CargaMaxima + "|"
                                             + this._camionesConCajaList[i].IdMarca + "|"
                                             + this._camionesConCajaList[i].NombreMarca + "|"
                                             + this._camionesConCajaList[i].IdSegmento + "|"
                                             + this._camionesConCajaList[i].NombreSegmento + "|"
                                             + this._camionesConCajaList[i].IdCombustible + "|"
                                             + this._camionesConCajaList[i].NombreCombustible);
                        }
                        grabar.Close();
                        x.Close();
                        break;

                    case _archivoCamionesSinCaja:

                        x = new FileStream(_archivoCamionesSinCaja, FileMode.Open);
                        grabar = new StreamWriter(x);

                        for (int i = 0; i < this._camionesSinCajaList.Count; i++)
                        {
                            grabar.WriteLine(this._camionesSinCajaList[i].IdVehiculo + "|"
                                             + this._camionesSinCajaList[i].Patente + "|"
                                             + this._camionesSinCajaList[i].Kilometro + "|"
                                             + this._camionesSinCajaList[i].Anio + "|"
                                             + this._camionesSinCajaList[i].Modelo + "|"
                                             + this._camionesSinCajaList[i].PrecioVenta + "|"
                                             + this._camionesSinCajaList[i].Observaciones + "|"
                                             + this._camionesSinCajaList[i].Color + "|"
                                             + this._camionesSinCajaList[i].CajaCarga + "|"
                                             + this._camionesSinCajaList[i].IdMarca + "|"
                                             + this._camionesSinCajaList[i].NombreMarca + "|"
                                             + this._camionesSinCajaList[i].IdSegmento + "|"
                                             + this._camionesSinCajaList[i].NombreSegmento + "|"
                                             + this._camionesSinCajaList[i].IdCombustible + "|"
                                             + this._camionesSinCajaList[i].NombreCombustible);
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

                        if (this._ventasList.Count == 0)
                        {
                            x = new FileStream(_archivoVentas, FileMode.Open);
                            Leer = new StreamReader(x);

                            while (!Leer.EndOfStream)
                            {
                                cadena = Leer.ReadLine();
                                datos = cadena.Split('|');

                                Venta venta = new Venta(
                                    int.Parse(datos[0]),
                                    int.Parse(datos[1]),
                                    datos[2],
                                    int.Parse(datos[3]),
                                    datos[4],
                                    datos[5],
                                    datos[6],
                                    int.Parse(datos[7]));

                                this._ventasList.Add(venta);
                            }
                            Leer.Close();
                            x.Close();
                        }

                        break;

                    case _archivoAutosCamionetas:

                        if (this._autosCamionetasList.Count == 0)
                        {
                            x = new FileStream(_archivoAutosCamionetas, FileMode.Open);
                            Leer = new StreamReader(x);

                            while (!Leer.EndOfStream)
                            {
                                cadena = Leer.ReadLine();
                                datos = cadena.Split('|');

                                AutoCamioneta ac = new AutoCamioneta(
                                        int.Parse(datos[0]),
                                        datos[1],
                                        int.Parse(datos[2]),
                                        int.Parse(datos[3]),
                                        datos[4],
                                        int.Parse(datos[5]),
                                        datos[6],
                                        datos[7],
                                        int.Parse(datos[8]),
                                        datos[9],
                                        int.Parse(datos[10]),
                                        datos[11],
                                        int.Parse(datos[12]),
                                        datos[13]);

                                this._autosCamionetasList.Add(ac);
                            }
                            Leer.Close();
                            x.Close();
                        }
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
                                         int.Parse(datos[9]),
                                         datos[10],
                                         int.Parse(datos[11]),
                                         datos[12],
                                         int.Parse(datos[13]),
                                         datos[14]);

                                this._motosList.Add(mo);
                            }
                            Leer.Close();
                            x.Close();
                        }
                        break;

                    case _archivoCamionesConCaja:

                        if (this._camionesConCajaList.Count == 0)
                        {
                            x = new FileStream(_archivoCamionesConCaja, FileMode.Open);
                            Leer = new StreamReader(x);

                            while (!Leer.EndOfStream)
                            {
                                cadena = Leer.ReadLine();
                                datos = cadena.Split('|');

                                Camion ca = new Camion(
                                        int.Parse(datos[0]),
                                        datos[1],
                                        int.Parse(datos[2]),
                                        int.Parse(datos[3]),
                                        datos[4],
                                        int.Parse(datos[5]),
                                        datos[6],
                                        datos[7],
                                        datos[8],
                                        int.Parse(datos[9]),
                                        int.Parse(datos[10]),
                                        int.Parse(datos[11]),
                                        datos[12],
                                        int.Parse(datos[13]),
                                        datos[14],
                                        int.Parse(datos[15]),
                                        datos[16]);

                                this._camionesConCajaList.Add(ca);
                            }
                            Leer.Close();
                            x.Close();

                        }

                        break;

                    case _archivoCamionesSinCaja:

                        if (this._camionesSinCajaList.Count == 0)
                        {
                            x = new FileStream(_archivoCamionesSinCaja, FileMode.Open);
                            Leer = new StreamReader(x);

                            while (!Leer.EndOfStream)
                            {
                                cadena = Leer.ReadLine();
                                datos = cadena.Split('|');

                                Camion caSC = new Camion(
                                        int.Parse(datos[0]),
                                        datos[1],
                                        int.Parse(datos[2]),
                                        int.Parse(datos[3]),
                                        datos[4],
                                        int.Parse(datos[5]),
                                        datos[6],
                                        datos[7],
                                        datos[8],
                                        int.Parse(datos[9]),
                                        datos[10],
                                        int.Parse(datos[11]),
                                        datos[12],
                                        int.Parse(datos[13]),
                                        datos[14]);

                                this._camionesSinCajaList.Add(caSC);
                            }
                            Leer.Close();
                            x.Close();

                        }

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
                                datos = cadena.Split(';');

                                Marca mar = new Marca(
                                        int.Parse(datos[0]),
                                        datos[1].Trim());

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


        private void Actualizar(string _archivo)
        {

            switch (_archivo)
            {
                case _archivoClientes:

                    ListarClientes();
                    Console.WriteLine("\n");
                    LeerArchivo(_archivoClientes);

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
                                Console.WriteLine("Qué campo deseas actualizar?");
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
                        GrabarArchivo(_archivoClientes);
                        Console.WriteLine("Cliente actualizado correctamente");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El CLIENTE no existe.");
                        Console.ResetColor();
                    }

                    break;

                case _archivoVentas:

                    ListarVentas();
                    Console.WriteLine("\n");

                    LeerArchivo(_archivoVentas);

                    Console.WriteLine("Ingresa el ID de la VENTA a actualizar:");
                    string idVenta = Console.ReadLine();
                    idVenta = ValidarIdSoloNumerico(idVenta);
                    int idCondicion2 = int.Parse(idVenta);

                    bool ventaEncontrada = false;

                    for (int i = 0; i < this._ventasList.Count; i++)
                    {
                        if (this._ventasList[i].IdCliente == idCondicion2)
                        {
                            ventaEncontrada = true;
                            bool opcionValida = false;

                            do
                            {
                                Console.WriteLine("Qué campo deseas actualizar?");
                                Console.WriteLine("1- Nombre Cliente");
                                Console.WriteLine("2- Nombre Vehículo");
                                Console.WriteLine("3- Fecha de Compra");
                                Console.WriteLine("4- Fecha de Entrega");

                                if (int.TryParse(Console.ReadLine(), out int opcion))
                                {
                                    switch (opcion)
                                    {
                                        case 1:
                                            Console.WriteLine("Ingresa el nuevo Nombre Cliente:");
                                            string nuevoNombreCliente = Console.ReadLine();
                                            nuevoNombreCliente = SoloLetras(nuevoNombreCliente);
                                            this._ventasList[i].NombreCliente = nuevoNombreCliente;
                                            opcionValida = true;
                                            break;

                                        case 2:
                                            Console.WriteLine("Ingresa el nuevo Nombre Vehículo:");
                                            string nuevoNombreVehiculo = Console.ReadLine();
                                            nuevoNombreVehiculo = SoloLetras(nuevoNombreVehiculo);
                                            this._ventasList[i].NombreVehiculo = nuevoNombreVehiculo;
                                            opcionValida = true;
                                            break;

                                        case 3:
                                            Console.WriteLine("Ingresa la nueva Fecha de Compra (dd/mm/yyyy):");
                                            string nuevaFechaCompra = Console.ReadLine();
                                            if (DateTime.TryParse(nuevaFechaCompra, out DateTime fechaCompraValida))
                                            {
                                                this._ventasList[i].FechaCompra = fechaCompraValida;
                                                opcionValida = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Fecha inválida. Intenta de nuevo.");
                                            }
                                            break;

                                        case 4:
                                            Console.WriteLine("Ingresa la nueva Fecha de Entrega (dd/mm/yyyy):");
                                            string nuevaFechaEntrega = Console.ReadLine();
                                            if (DateTime.TryParse(nuevaFechaEntrega, out DateTime fechaEntregaValida))
                                            {
                                                this._ventasList[i].FechaVenta = fechaEntregaValida;
                                                opcionValida = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Fecha inválida. Intenta de nuevo.");
                                            }
                                            break;

                                        default:
                                            Console.WriteLine("Opción no válida.");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Entrada inválida. Por favor, ingresa un número.");
                                }
                            } while (!opcionValida);

                        }
                    }

                    if (ventaEncontrada)
                    {
                        GrabarArchivo(_archivoVentas);
                        Console.WriteLine("Venta actualizado correctamente");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La Venta no existe.");
                        Console.ResetColor();
                    }

                    break;

                default:
                    break;
            }
        }


        //__Validaciones__
        private string ValidarIdNumericoOExiste(string _id, string _archivo)
        {

            bool idValido = false; //__bandera para el bucle__ 
            int id;
            switch (_archivo)
            {
                case _archivoClientes:

                    LeerArchivo(_archivoClientes);

                    do
                    {
                        if (!int.TryParse(_id, out id) || id <= 0)
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
                                if (id == this._clientesList[i].IdCliente)
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
                        if (idValido)
                        {
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
                        if (!int.TryParse(_id, out id) || id <= 0)
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
                                if (id == this._motosList[i].IdVehiculo)
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
                        }
                        if (idValido)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("ID válido.");
                            Console.ResetColor();
                        }
                    }
                    while (!idValido);

                    break;

                case _archivoCamionesConCaja:

                    LeerArchivo(_archivoCamionesConCaja);

                    do
                    {
                        if (!int.TryParse(_id, out id) || id <= 0)
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

                            for (int i = 0; i < this._camionesConCajaList.Count; i++)
                            {
                                if (id == this._camionesConCajaList[i].IdVehiculo)
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
                        }
                        if (idValido)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("ID válido.");
                            Console.ResetColor();
                        }
                    }
                    while (!idValido);

                    break;

                case _archivoCamionesSinCaja:

                    LeerArchivo(_archivoCamionesSinCaja);

                    do
                    {
                        if (!int.TryParse(_id, out id) || id <= 0)
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

                            for (int i = 0; i < this._camionesSinCajaList.Count; i++)
                            {
                                if (id == this._camionesSinCajaList[i].IdVehiculo)
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
                        }
                        if (idValido)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("ID válido.");
                            Console.ResetColor();
                        }
                    }
                    while (!idValido);

                    break;

                case _archivoAutosCamionetas:

                    LeerArchivo(_archivoAutosCamionetas);

                    do
                    {
                        if (!int.TryParse(_id, out id) || id <= 0)
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

                            for (int i = 0; i < this._autosCamionetasList.Count; i++)
                            {
                                if (id == this._autosCamionetasList[i].IdVehiculo)
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
                        }
                        if (idValido)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("ID válido.");
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
                if (!_palabra.All(c => char.IsLetter(c) || c == ' ')) //__Vrifica espacios funcion lamda__
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("_________________________________________________");
                    Console.WriteLine("Solo se permiten letras.");
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
