using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Programación_2
{
    internal class Menu : Concesionaria
    {
        //__Procedimiento de Menu__
        public void MenuPrincipal()
        {
            string[] menuDeOpcionesPrincipal = { "1) CLIENTES", "2) VENTAS", "3) VEHICULOS", "4) PARAMETRICOS", "5) SALIR" };

            bool variableCorte = true;

            int seleccion = 0;

            ConsoleKeyInfo tecla;

            Console.CursorVisible = false;

            while (variableCorte)
            {
                Console.Clear();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("  SELECCIONA UNA OPCION DEL MENU PULSANDO LA TECLA ENTER ");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝");
                Console.ResetColor();
                Console.WriteLine("\n");

                Console.WriteLine("╔═════════════════╗");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" ╔════════════════╗");
                Console.WriteLine(" ║ MENU PRINCIPAL ║");
                Console.WriteLine(" ╚════════════════╝");
                Console.ResetColor();

                for (int i = 0; i < menuDeOpcionesPrincipal.Length; i++)
                {
                    if (seleccion == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("==" + (char)62 + " "); //__char62 icono flecha__
                    }
                    else
                    {
                        Console.Write(" . ");
                    }

                    Console.WriteLine(menuDeOpcionesPrincipal[i]);
                    Console.ResetColor();
                }

                Console.WriteLine("╚═════════════════╝");

                tecla = Console.ReadKey();

                switch (tecla.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            seleccion = Math.Max(0, seleccion - 1); //__Primer valor 0 determina el limite, seleccion - 1 para manejar rango del arrays__  
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            seleccion = Math.Min(menuDeOpcionesPrincipal.Length - 1, seleccion + 1); //__Largo de mi menu -1 para el rango__
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            //__Manupular menu principal__

                            switch (seleccion)
                            {
                                case 0:
                                    {
                                        MenuCliente();
                                        break;
                                    }
                                case 1:
                                    {

                                        break;
                                    }
                                case 2:
                                    {
                                        MenuVehiculos();
                                        break;
                                    }
                                case 3:
                                    {
                                        break;
                                    }
                                case 4:
                                    {
                                        variableCorte = false;//__Salir__
                                        break;
                                    }
                            }
                        }
                        break;
                }
            }

            //Console.ReadKey();
        }


        public void MenuCliente()
        {
            string[] subMenuDeOpcionesCliente = { "1) AGREGAR CLIENTE", "2) LISTAR CLIENTES", "3) ACTUALIZAR CLIENTE", "4) BORRAR CLIENTE", "5) VOLVER" };

            bool variableCorte = true;

            int seleccion = 0;

            ConsoleKeyInfo tecla;

            Console.CursorVisible = false;

            while (variableCorte)
            {
                Console.Clear();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("  SELECCIONA UNA OPCION DEL MENU PULSANDO LA TECLA ENTER ");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝");
                Console.ResetColor();
                Console.WriteLine("\n");


                Console.WriteLine("╔═════════════════════════╗");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  ╔══════════════════╗");
                Console.WriteLine("  ║ SUBMENU CLIENTES ║");
                Console.WriteLine("  ╚══════════════════╝");
                Console.ResetColor();


                for (int i = 0; i < subMenuDeOpcionesCliente.Length; i++)
                {
                    if (seleccion == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("==" + (char)62 + " ");
                    }
                    else
                    {
                        Console.Write(" . ");
                    }

                    Console.WriteLine(subMenuDeOpcionesCliente[i]);
                    Console.ResetColor();
                }

                Console.WriteLine("╚═════════════════════════╝");

                tecla = Console.ReadKey();

                switch (tecla.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            seleccion = Math.Max(0, seleccion - 1); //__Primer valor 0 determina el limite, seleccion - 1 para manejar rango del arrays__  
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            seleccion = Math.Min(subMenuDeOpcionesCliente.Length - 1, seleccion + 1); //__Largo de mi menu -1 para el rango__
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            switch (seleccion)
                            {
                                case 0:
                                    {
                                        CargarCliente();
                                        break;
                                    }
                                case 1:
                                    {
                                        ListarClientes();
                                        Console.ReadKey();
                                        break;
                                    }
                                case 2:
                                    {
                                        ActualizarCliente();
                                        break;
                                    }
                                case 3:
                                    {
                                        BorrarCliente();
                                        break;
                                    }
                                case 4:
                                    {
                                        variableCorte = false;
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
        }


        public void MenuVehiculos()
        {
            string[] subMenuDeOpcionesVehiculo = { "1) AGREGAR VEHICULO", "2) LISTAR VEHICULOS", "3) ACTUALIZAR VEHICULO", "4) BORRAR VEHICULO", "5) VOLVER" };

            bool variableCorte = true;

            int seleccion = 0;

            ConsoleKeyInfo tecla;

            Console.CursorVisible = false;

            while (variableCorte)
            {
                Console.Clear();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("  SELECCIONA UNA OPCION DEL MENU PULSANDO LA TECLA ENTER ");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝");
                Console.ResetColor();
                Console.WriteLine("\n");


                Console.WriteLine("╔═════════════════════════╗");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  ╔══════════════════╗");
                Console.WriteLine("  ║ SUBMENU VEHICULO ║");
                Console.WriteLine("  ╚══════════════════╝");
                Console.ResetColor();


                for (int i = 0; i < subMenuDeOpcionesVehiculo.Length; i++)
                {
                    if (seleccion == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("==" + (char)62 + " ");
                    }
                    else
                    {
                        Console.Write(" . ");
                    }

                    Console.WriteLine(subMenuDeOpcionesVehiculo[i]);
                    Console.ResetColor();
                }

                Console.WriteLine("╚═════════════════════════╝");

                tecla = Console.ReadKey();

                switch (tecla.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            seleccion = Math.Max(0, seleccion - 1); //__Primer valor 0 determina el limite, seleccion - 1 para manejar rango del arrays__  
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            seleccion = Math.Min(subMenuDeOpcionesVehiculo.Length - 1, seleccion + 1); //__Largo de mi menu -1 para el rango__
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            switch (seleccion)
                            {
                                case 0:
                                    {
                                        
                                        break;
                                    }
                                case 1:
                                    {
                                        
                                        Console.ReadKey();
                                        break;
                                    }
                                case 2:
                                    {
                                       
                                        break;
                                    }
                                case 3:
                                    {
                                        
                                        break;
                                    }
                                case 4:
                                    {
                                        variableCorte = false;
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
        }
    }
}
