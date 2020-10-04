using System;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Text;
using System.ComponentModel.DataAnnotations;
using ComercioModelo;
using ConsoleTrabajoIntegrador.SubMenus;
using System.Runtime.CompilerServices;

namespace ComercioConsola
{
    class Menus
    {

        public static void Home()
        {
            Console.Clear();

            //Lista de Opciones
            List<string> opciones = new List<string>();
            opciones.Add("Categorias");
            opciones.Add("Productos");
            opciones.Add("Empleados");
            opciones.Add("Clientes");
            opciones.Add("Realizar Venta");
            opciones.Add("Facturación");
            opciones.Add("Salir Programa");

            Formatos.DibujarMenu("Bienvenido", opciones);
            int opcionMenu = Validadores.ValidarOpcionMenu("Ingrese la opcion que desea elegir :", opciones.Count);

            switch (opcionMenu)
            {
                case 1:
                    SubMenuCategorias.MenuCategorias();
                    break;
                case 2:
                    SubMenuProducto.MenuProductos();
                    break;
                case 3:
                    SubMenuEmpleados.MenuEmpleados();
                    break;
                case 4:
                    SubMenuClientes.MenuClientes();
                    break;
                case 5:
                    RealizarVenta();
                    break;
                case 6:
                    SubMenuFacturacion.MenuFacturacion();
                    break;
            }

        }

        private static void RealizarVenta()
        {
            try
            {
                SubMenuEmpleados.TablaEmpleados(Comercio.empleados);
                int empleado = Validadores.ValidarOpcionMenu("Ingrese el Empleado que raliza la venta : ", Comercio.inventario.Count);
                SubMenuClientes.TablaClientes(Comercio.clientes);
                int cliente = Validadores.ValidarOpcionMenu("Ingrese el cliente que compra : ", Comercio.inventario.Count);
                SubMenuProducto.TablaProductos(Comercio.inventario);
                int producto = Validadores.ValidarOpcionMenu("Ingrese el producto que se vende : ", Comercio.inventario.Count);
                int cantidad = Validadores.ValidarEntero("Ingrese la cantidad que se vende : ");

                Comercio.ventas.Add(new Venta(Comercio.empleados[empleado-1], Comercio.clientes[cliente-1], Comercio.inventario[producto-1], cantidad));
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Formatos.SetTextError(string.Format("Se ha producido el siguiene error: {0}", e.Message));
                Validadores.EsperaTecla();
            }
            Home();
        }

        public static void SalidaPrograma()
        {
            Console.Clear();

            Formatos.SetTextError("¿Esta seguro que desea salir del programa? S/N");

            ConsoleKeyInfo opcionValidada = Validadores.ValidarSalidaPrograma();

            if (opcionValidada.Key == ConsoleKey.Y)
            {
                Formatos.SetTextSucess("--------- QUE TENGA UN BUEN DIA!!! ----------");
                Thread.Sleep(2000);
                Environment.Exit(1);
            }
            else
            {
                Home();
            }

        }

    }
}
