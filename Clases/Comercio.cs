using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;

namespace ComercioModelo
{
    public static class Comercio
    {
        const string nombreComercio = "FERRETERIA";
        public static int ultimoLegajoUsado = 0;

        public static List<Categoria> categorias;
        public static List<Producto> inventario;
        public static List<Empleado> empleados;
        public static List<Cliente> clientes;
        public static List<Venta> ventas;

        /// <summary>
        /// Recorre todo el inventario y devuelte el producto que mas facturo
        /// </summary>
        public static Producto productoMasFactura
        {
            get
            {
                int montoMasFacturado = 0;
                Producto productoMasFacturado =  null;

                foreach (Producto producto in inventario)
                {
                    if (producto.cantVentas > 0)
                    {
                        if (producto.MontoFacturado > montoMasFacturado)
                        {
                            montoMasFacturado = producto.MontoFacturado;
                            productoMasFacturado = producto;
                        }
                    }
                }
                return productoMasFacturado;
            }
        }

        /// <summary>
        ///  Recorre el inventario y devuelve el producto con mas ventas independietemente de la factuación
        /// </summary>
        public static Producto productoMasVendido
        {
            get
            {
                int mayorCantVentas = 0;
                Producto productoMasVendido = null;

                foreach (Producto producto in inventario)
                {
                    if (producto.cantVentas > mayorCantVentas)
                    {
                        mayorCantVentas = producto.cantVentas;
                        productoMasVendido = producto;
                    }
                }
                return productoMasVendido;
            }
        }

        public static Empleado empleadoMasFactura
        {
            get
            {
                int montoMasFacturado = 0;
                Empleado empleadoMasFacturo = null;

                foreach (Empleado empleado in empleados)
                {
                    if (empleado.montoFacturado > 0)
                    {
                        if (empleado.montoFacturado > montoMasFacturado)
                        {
                            montoMasFacturado = empleado.montoFacturado;
                            empleadoMasFacturo = empleado;
                        }
                    }
                }
                return empleadoMasFacturo;
            }
        }

        public static Empleado empleadoMasVendio
        {
            get
            {
                int mayorCantVentas = 0;
                Empleado empleadoMasVendio = null;

                foreach (Empleado empleado in empleados)
                {
                    if (empleado.ventasRealizadas > mayorCantVentas)
                    {
                        mayorCantVentas = empleado.ventasRealizadas;
                        empleadoMasVendio = empleado;
                    }
                }
                return empleadoMasVendio;
            }
        }

        /// <summary>
        /// Devuelve el total de monto facturado de todos los productos
        /// </summary>
        public static int totalFacturado
        {
            get
            {
                int montoFacturado = 0;

                foreach (Producto producto in inventario)
                {
                    montoFacturado += producto.MontoFacturado;
                }
                return montoFacturado;
            }
        }

        static Comercio()
        {
            categorias = new List<Categoria>();
            inventario = new List<Producto>();
            empleados = new List<Empleado>();
            clientes = new List<Cliente>();
            ventas = new List<Venta>();
            CargaInicial();
        }

        #region Carga Inicial del Comercio

        /// <summary>
        /// Carga todos los elementos Predefinidos del Comercio
        /// </summary>
        private static void CargaInicial()
        {
            CargaCategoriasInicial();
            CargaInventarioInicial();
            CargaEmpleadosInicial();
            CargaClientesInicial();
        }

        /// <summary>
        /// Agrega al Comercio las categorias Predefinidas
        /// </summary>
        private static void CargaCategoriasInicial()
        {
            try
            {
                categorias.Add(new Categoria("Construcción"));
                categorias.Add(new Categoria("Plomería"));
                categorias.Add(new Categoria("Herramientas"));
                categorias.Add(new Categoria("Electricidad"));
            }
            catch (Exception excepcion)
            {
                Console.WriteLine($"Error producido : {excepcion.Message}");
            }
        }

        /// <summary>
        /// Agrega al inventario del Comercio los Productos
        /// </summary>
        private static void CargaInventarioInicial()
        {
            try
            {
                inventario.Add(new Producto(12, "Ladrillo", categorias[0], 80, 120));
                inventario.Add(new Producto(10, "Flexible caño", categorias[1], 100, 5));
                inventario.Add(new Producto(15, "Destornillador", categorias[2], 95, 124));
                inventario.Add(new Producto(11, "Canillas", categorias[1], 45, 15));
                inventario.Add(new Producto(4, "Bombillas", categorias[3], 20, 300));
                inventario.Add(new Producto(90, "Bolsa Arena", categorias[0], 60, 45));
                inventario.Add(new Producto(1, "Caños de agua", categorias[1], 100, 0));
                inventario.Add(new Producto(31, "Martillo", categorias[2], 120, 150));
                inventario.Add(new Producto(9, "Pinza", categorias[2], 135, 80));
                inventario.Add(new Producto(7, "Cable (por metro)", categorias[3], 50, 98));
            }
            catch (Exception excepcion)
            {
                Console.WriteLine($"Error producido : {excepcion.Message}");
            }
        }

        /// <summary>
        /// Carga un Empleado Predefinido
        /// </summary>
        private static void CargaEmpleadosInicial()
        {
            try
            {
                empleados.Add(new Empleado("Administrador", "Total"));
            }
            catch (Exception excepcion)
            {
                Console.WriteLine($"Error producido : {excepcion.Message}");
            }
        }

        /// <summary>
        /// Crea un cliente predefinido
        /// </summary>
        private static void CargaClientesInicial()
        {
            try
            {
                clientes.Add(new Cliente("Cliente", "Predefinido", 1111111111));
            }
            catch (Exception excepcion)
            {
                Console.WriteLine($"Error producido : {excepcion.Message}");
            }
        }

        #endregion

    }
}
