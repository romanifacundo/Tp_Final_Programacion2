using System;
using System.Collections.Generic;
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
        private string _archivoClientes = "";
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
        private List<Localidad> _localidadesList;
        private List<Provincia> _provinciasList;
        //__Declaracion Listas privadas y para ser inicializadas__
        private List<Combustible> _combustiblesList;
        private List<Segmento> _segmentosList;


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
        }


        //__Metodos de acciones__

    }
}
