using System;
using System.Collections.Generic;
using System.Text;
using ComercioConsola;
using ComercioControlador;
using ComercioModelo;

namespace ConsoleTrabajoIntegrador.SubMenus
{
    public class SubMenuProducto
    {
        public static void MenuProductos()
        {
            Console.Clear();

            //Lista de Opciones
            List<string> opciones = new List<string>();
            opciones.Add("Mostrar todas las productos");
            opciones.Add("Agregar Producto");
            opciones.Add("Editar Producto");
            opciones.Add("Eliminar Producto");
            opciones.Add("Buscar Productos");
            opciones.Add("Sumar Stock a un Producto");
            opciones.Add("Volver al menu Home");

            Formatos.DibujarMenu("Productos", opciones);
            int opcionElegida = Validadores.ValidarOpcionMenu("Ingrese la opcion que desea elegir: ", opciones.Count);

            switch (opcionElegida)
            {
                case 1:
                    Show();
                    MenuProductos();
                    break;
                case 2:
                    Add();
                    MenuProductos();
                    break;
                case 3:
                    Edit();
                    MenuProductos();
                    break;
                case 4:
                    Delete();
                    MenuProductos();
                    break;
                case 5:
                    BuscarProducto();
                    break;
                case 6:
                    SumarStock();
                    break;
                case 7:
                    Menus.Home();
                    break;
            }

        }

        private static void Show()
        {
            Console.Clear();
            TablaProductos(Comercio.inventario);
            Validadores.EsperaTecla();
        }

        public static void Show(Producto producto)
        {
            Console.WriteLine();
            Console.WriteLine("Id del Producto : {0}", producto.id);
            Console.WriteLine("Nombre del Producto : {0}", producto.nombre);
            Console.WriteLine("Categoria del Producto : {0}", producto.categoria.nombre);
            Console.WriteLine("Precio del Producto : {0}", producto.precio);
            Console.WriteLine("Stock del Producto : {0}", producto.stock);
            Console.WriteLine();
        }

        private static void Add()
        {
            try
            {
                int idElegido = Validadores.ValidarEntero("Escriba el id del producto que desea crear: ");
                string nombreElegido = Validadores.ValidarTexto("Escriba el nombre del producto que desea crear: ");
                SubMenuCategorias.TablaCategorias(Comercio.categorias);
                int indiceCategoriaElegida = Validadores.ValidarEntero("Ingrese la categoria que desea asignar al producto que desea crear: ");
                indiceCategoriaElegida -= 1;
                Categoria categoriaElegida = Comercio.categorias[indiceCategoriaElegida];
                int precioElegido = Validadores.ValidarEntero("Ingrese el precio del producto que desea crear: ");
                int stockElegido = Validadores.ValidarEntero("Ingrese el stock inicial del producto que desea crear: ");

                bool resultado = ProductoController.Add(idElegido, nombreElegido, categoriaElegida, precioElegido, stockElegido);
                if (resultado)
                {
                    Formatos.SetTextSucess("Producto Creado Satisfactoriamente!!!");
                    Validadores.EsperaTecla();
                }
                else
                {
                    Formatos.SetTextError("Producto NO Creado por un error desconocido");
                    Validadores.EsperaTecla();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Formatos.SetTextError(string.Format("Se ha producido el siguiene error: {0}", e.Message));
                Validadores.EsperaTecla();
            }
        }

        private static void Edit()
        {
            Console.Clear();
            try
            {
                Console.Clear();

                List<Producto> productos = ProductoController.Show();
                TablaProductos(productos);

                int indiceProductoElegida = Validadores.ValidarOpcionMenu("Elija el producto que desea editar: ", Comercio.inventario.Count);

                int idAReemplazar = Validadores.ValidarEntero("Ingrese el id del producto : ");
                string nombreAReemplezar = Validadores.ValidarTexto("Ingrese el nombre del producto : ");
                SubMenuCategorias.TablaCategorias(Comercio.categorias);
                int indiceCategoriaElegida = Validadores.ValidarEntero("Ingrese la categoria que desea asignar : ");
                indiceCategoriaElegida -= 1;
                int precioAReemplazar = Validadores.ValidarEntero("Ingrese el precio del producto : ");

                indiceProductoElegida -= 1;

                bool resultado = ProductoController.Edit(indiceProductoElegida, idAReemplazar, nombreAReemplezar, indiceCategoriaElegida, precioAReemplazar);

                if (resultado)
                {
                    Formatos.SetTextSucess("Categoria Editada Satisfactoriamente!!!");
                    Validadores.EsperaTecla();
                }
                else
                {
                    Formatos.SetTextError("Categoria NO Editada por un error desconocido");
                    Validadores.EsperaTecla();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Formatos.SetTextError(string.Format("Se ha producido el siguiene error: {0}", e.Message));
                Validadores.EsperaTecla();
            }
        }

        private static void Delete()
        {
            Console.Clear();
            try
            {
                Console.Clear();

                List<Producto> productos = ProductoController.Show();
                TablaProductos(productos);

                int indiceProductoElegido = Validadores.ValidarOpcionMenu("Elija el producto que desea eliminar: ", Comercio.inventario.Count);

                indiceProductoElegido -= 1;

                bool resultado = ProductoController.Delete(indiceProductoElegido);

                if (resultado)
                {
                    Formatos.SetTextSucess("Producto Eliminado Satisfactoriamente!!!");
                    Validadores.EsperaTecla();
                }
                else
                {
                    Formatos.SetTextError("Producto NO Eliminado por un error desconocido");
                    Validadores.EsperaTecla();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Formatos.SetTextError(string.Format("Se ha producido el siguiene error: {0}", e.Message));
                Validadores.EsperaTecla();
            }
        }

        private static void BuscarProducto()
        {
            Console.Clear();

            //Lista de Opciones
            List<string> opciones = new List<string>();
            opciones.Add("Buscar Productos por Categoria");
            opciones.Add("Buscar Producto por Stock Mayor o Igual a 100");
            opciones.Add("Buscar Producto por Stock Menor a 100");
            opciones.Add("Buscar Producto sin Stock");
            opciones.Add("Buscar Producto por Nombre");
            opciones.Add("Buscar Producto por Id");
            opciones.Add("Volver al menu Anterior");

            Formatos.DibujarMenu("Productos", opciones);
            int opcionElegida = Validadores.ValidarOpcionMenu("Ingrese la opcion que desea elegir: ", opciones.Count);

            switch (opcionElegida)
            {
                case 1:
                    SubMenuCategorias.TablaCategorias(Comercio.categorias);
                    int categoria = Validadores.ValidarOpcionMenu("Ingrese la categoria por la que desea buscar : ", Comercio.categorias.Count);
                    TablaProductos(ProductoController.SeachByCategoria(Comercio.categorias[categoria].nombre));
                    Validadores.EsperaTecla();
                    BuscarProducto();
                    break;
                case 2:
                    TablaProductos(ProductoController.SeachStockMayorCien());
                    Validadores.EsperaTecla();
                    BuscarProducto();
                    break;
                case 3:
                    TablaProductos(ProductoController.SeachStockMenorCien());
                    Validadores.EsperaTecla();
                    BuscarProducto();
                    break;
                case 4:
                    TablaProductos(ProductoController.SeachStockCero());
                    Validadores.EsperaTecla();
                    BuscarProducto();
                    break;
                case 5:
                    string nombreBusqueda = Validadores.ValidarTexto("Ingrese el nombre del producto que desea buscar : ");
                    TablaProductos(ProductoController.SeachByName(nombreBusqueda));
                    Validadores.EsperaTecla();
                    BuscarProducto();
                    break;
                case 6:
                    int idBusqueda = Validadores.ValidarEntero("Ingrese el id del producto que desea buscar : ");
                    TablaProductos(ProductoController.SeachById(idBusqueda));
                    Validadores.EsperaTecla();
                    BuscarProducto();
                    break;
                case 7:
                    MenuProductos();
                    break;
            }

        }

        private static void SumarStock()
        {
            TablaProductos(Comercio.inventario);
            int indiceInventario = Validadores.ValidarOpcionMenu("Ingrese el producto al que desea sumarle stock : ",Comercio.inventario.Count);
            int sumarStock = Validadores.ValidarEntero("Ingrese la cantidad que desea sumar de stock : ");
            try
            {
                Comercio.inventario[(indiceInventario-1)].SumaStock(sumarStock);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Formatos.SetTextError(string.Format("Se ha producido el siguiene error: {0}", e.Message));
                Validadores.EsperaTecla();
            }
            MenuProductos();
        }

        public static void TablaProductos(List<Producto> productos)
        {

            //Lista a dibujar
            List<string> productosToString = new List<string>();

            foreach (Producto producto in productos)
            {
                productosToString.Add(producto.ToString());
            }

            string encabezadoTabla = string.Format($"{"#   |"} {"id",-5} | {"nombre",-25} {"categoria",-20} | {"precio",-10} | {"stock",-10} | {"$ Facturado",-15}");

            Formatos.DibujarMenu(encabezadoTabla, productosToString);
        }

    }
}
