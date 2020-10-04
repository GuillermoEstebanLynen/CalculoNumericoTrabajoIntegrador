using ComercioConsola;
using ComercioModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTrabajoIntegrador.SubMenus
{
    class SubMenuFacturacion
    {
        internal static void MenuFacturacion()
        {
            Console.Clear();

            //Lista de Opciones
            List<string> opciones = new List<string>();
            opciones.Add("Mostrar Ventas");
            opciones.Add("Mostrar Producto que mas facturo");
            opciones.Add("Mostrar Producto que mas se vendio");
            opciones.Add("Mostrar Facturacion de todos los productos de mayor a menor");
            opciones.Add("Mostrar Facturacion de todos los productos de menor a mayor");
            opciones.Add("Ver Empleado con mas facturacion");
            opciones.Add("Ver Empleado con mas ventas");
            opciones.Add("Volver al menu Home");

            Formatos.DibujarMenu("Bienvenido", opciones);
            int opcionMenu = Validadores.ValidarOpcionMenu("Ingrese la opcion que desea elegir :", opciones.Count);

            List<Producto> listaOrdenada;
            switch (opcionMenu)
            {
                case 1:
                    Console.Clear();
                    TablaVentas(Comercio.ventas);
                    Validadores.EsperaTecla();
                    Console.Clear();
                    MenuFacturacion();
                    break;
                case 2:
                    SubMenuProducto.Show(Comercio.productoMasFactura);
                    Validadores.EsperaTecla();
                    Console.Clear();
                    MenuFacturacion();
                    break;
                case 3:
                    SubMenuProducto.Show(Comercio.productoMasVendido);
                    Validadores.EsperaTecla();
                    Console.Clear();
                    MenuFacturacion();
                    break;
                case 4:
                    listaOrdenada = Comercio.inventario.OrderByDescending(p => p.MontoFacturado).ToList();
                    SubMenuProducto.TablaProductos(listaOrdenada);
                    Validadores.EsperaTecla();
                    Console.Clear();
                    MenuFacturacion();
                    break;
                case 5:
                    listaOrdenada = Comercio.inventario.OrderBy(p => p.MontoFacturado).ToList();
                    SubMenuProducto.TablaProductos(listaOrdenada);
                    Validadores.EsperaTecla();
                    Console.Clear();
                    MenuFacturacion();
                    break;
                case 6:
                    SubMenuEmpleados.Show(Comercio.empleadoMasFactura);
                    Validadores.EsperaTecla();
                    Console.Clear();
                    MenuFacturacion();
                    break;
                case 7:
                    SubMenuEmpleados.Show(Comercio.empleadoMasVendio);
                    Validadores.EsperaTecla();
                    Console.Clear();
                    MenuFacturacion();
                    break;
                case 8:
                    Menus.Home();
                    break;
            }

        }

        public static void TablaVentas(List<Venta> ventas)
        {
            if (ventas.Count == 0)
            {
                Formatos.SetTextError("NO hay ninguna venta registrada.");
            }
            else
            {
                //Lista a dibujar
                List<string> ventasToString = new List<string>();

                foreach (Venta venta in ventas)
                {
                    ventasToString.Add(string.Format($"{venta.empleado.nombreCompleto,-25} | {venta.cliente.nombreCompleto,-25} {venta.producto.nombre,-25} | {venta.fechaCompra,-15}"));
                }

                string encabezadoTabla = string.Format($"#   | {"empleado",-25} | {"cliente",-25} {"producto",-25} | {"fechaCompra",-15}");

                Formatos.DibujarMenu(encabezadoTabla, ventasToString);
            }
        }
    }
}
