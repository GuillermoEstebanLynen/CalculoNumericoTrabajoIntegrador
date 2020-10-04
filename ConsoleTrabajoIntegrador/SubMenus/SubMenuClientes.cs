using System;
using System.Collections.Generic;
using System.Text;
using ComercioConsola;
using ComercioControlador;
using ComercioModelo;

namespace ConsoleTrabajoIntegrador.SubMenus
{
    class SubMenuClientes
    {
        public static void MenuClientes()
        {
            Console.Clear();

            //Lista de Opciones
            List<string> opciones = new List<string>();
            opciones.Add("Mostrar todos los Clientes");
            opciones.Add("Agregar Cliente");
            opciones.Add("Editar Cliente");
            opciones.Add("Eliminar Cliente");
            opciones.Add("Volver al menu Home");

            Formatos.DibujarMenu("Clientes", opciones);
            int opcionElegida = Validadores.ValidarOpcionMenu("Ingrese la opcion que desea elegir: ", opciones.Count);

            switch (opcionElegida)
            {
                case 1:
                    Show();
                    MenuClientes();
                    break;
                case 2:
                    Add();
                    MenuClientes();
                    break;
                case 3:
                    Edit();
                    MenuClientes();
                    break;
                case 4:
                    Delete();
                    MenuClientes();
                    break;
                case 5:
                    Menus.Home();
                    break;
            }

        }

        private static void Show()
        {
            Console.Clear();

            TablaClientes(ClienteController.Show());

            Console.WriteLine();
            Console.WriteLine("Aprete una tecla cualquiera para volver al menu");
            Console.ReadKey();
        }

        private static void Add()
        {
            try
            {
                string nombreElegido = Validadores.ValidarTexto("Escriba el nombre del Cliente que desea crear: ");
                string apellidoElegido = Validadores.ValidarTexto("Escriba el apellido del Cliente que desea crear: ");
                int dniElegido = Validadores.ValidarEntero("Escriba el Numero de Documento del Cliente que desea crear: ");

                bool resultado = ClienteController.Add(nombreElegido, apellidoElegido, dniElegido);
                if (resultado)
                {
                    Formatos.SetTextSucess("Cliente Creado Satisfactoriamente!!!");
                    Console.WriteLine("Aprete Cualquier tecla para volver al menu");
                    Console.ReadKey();
                }
                else
                {
                    Formatos.SetTextError("Cliente NO Creado por un error desconocido");
                    Console.WriteLine("Aprete Cualquier tecla para volver al menu");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Formatos.SetTextError(string.Format("Se ha producido el siguiene error: {0}", e.Message));
                Console.WriteLine();
                Console.ReadKey();
            }
        }

        private static void Edit()
        {
            Console.Clear();
            try
            {
                Console.Clear();

                TablaClientes(ClienteController.Show());

                int indiceClienteElegido = Validadores.ValidarOpcionMenu("Elija el Cliente que desea editar: ", Comercio.clientes.Count);
                indiceClienteElegido -= 1;

                string nombreAReemplezar = Validadores.ValidarTexto("Ingrese el nombre correcto del Cliente : ");
                string apellidoAReemplezar = Validadores.ValidarTexto("Ingrese el apellido correcto del Cliente : ");
                int dniElegido = Validadores.ValidarEntero("Escriba el Numero de Documento correctodel Cliente : ");

                bool resultado = ClienteController.Edit(indiceClienteElegido, nombreAReemplezar, apellidoAReemplezar, dniElegido);

                if (resultado)
                {
                    Formatos.SetTextSucess("Cliente Editado Satisfactoriamente!!!");
                    Console.WriteLine("Aprete Cualquier tecla para volver al menu");
                    Console.ReadKey();
                }
                else
                {
                    Formatos.SetTextError("Cliente NO Editado por un error desconocido");
                    Console.WriteLine("Aprete Cualquier tecla para volver al menu");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Formatos.SetTextError(string.Format("Se ha producido el siguiene error: {0}", e.Message));
                Console.WriteLine();
                Console.ReadKey();
            }
        }

        private static void Delete()
        {
            Console.Clear();
            try
            {
                Console.Clear();

                TablaClientes(ClienteController.Show());

                int indiceClienteElegido = Validadores.ValidarOpcionMenu("Elija el Cliente que desea eliminar: ", Comercio.clientes.Count);
                indiceClienteElegido -= 1;

                bool resultado = ClienteController.Delete(indiceClienteElegido);

                if (resultado)
                {
                    Formatos.SetTextSucess("Cliente Eliminado Satisfactoriamente!!!");
                    Console.WriteLine("Aprete Cualquier tecla para volver al menu");
                    Console.ReadKey();
                }
                else
                {
                    Formatos.SetTextError("Cliente NO Eliminado por un error desconocido");
                    Console.WriteLine("Aprete Cualquier tecla para volver al menu");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Formatos.SetTextError(string.Format("Se ha producido el siguiene error: {0}", e.Message));
                Console.WriteLine();
                Console.ReadKey();
            }
        }

        public static void TablaClientes(List<Cliente> clientes)
        {
            //Lista a dibujar
            List<string> clientesToString = new List<string>();

            foreach (Cliente cliente in clientes)
            {
                clientesToString.Add(cliente.ToString());
            }

            string encabezadoTabla = string.Format($"{"#   |"} {"Nombre",-25} | {"Apellido",-25} | {"NroDocumento",-25}");

            Formatos.DibujarMenu(encabezadoTabla, clientesToString);
        }

    }
}
