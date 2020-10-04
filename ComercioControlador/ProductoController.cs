using ComercioModelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComercioControlador
{
    public class ProductoController
    {

        /// <summary>
        /// Crea el producto el y lo agrega al INventario del COmercio
        /// </summary>
        /// <param name="id">id del producto que se creara</param>
        /// <param name="nombre">nombre del producto que se creara</param>
        /// <param name="stock">stock del producto que se creara</param>
        /// <returns>Devuelve true si se creo con exito el Producto</returns>
        public static bool Add(int id, string nombre, Categoria categoria, int precio, int stock)
        {
            Comercio.inventario.Add(new Producto(id, nombre, categoria, precio, stock));
            return true;
        }

        /// <summary>
        /// Recibe un indice el cual es la categoria a eliminar del comercio y devuelve un bool con el resultado de la operacion
        /// </summary>
        /// <param name="indiceProducto">Indice del producto que se desea eliminar dentro del inventario del Comercio </param>
        /// <returns>Devuelve true si se elimno con exito el Producto</returns>
        public static bool Delete(int indiceProducto)
        {
            Comercio.inventario.Remove(Comercio.inventario[indiceProducto]);
            return true;
        }

        /// <summary>
        /// Edita un Producto del Inventario del Comercio
        /// </summary>
        /// <param name="indiceProducto">Indice del producto que se desea eliminar dentro del inventario del Comercio </param>
        /// <param name="id">id del producto por el cual se editara</param>
        /// <param name="nombre">nombre del producto por el cual se editara</param>
        /// <param name="categoria">Categoria del producto por el cual se editara</param>
        /// <param name="precio">precio del producto por el cual se editara</param>
        /// <returns>Devuelve true si se edito con exito el Producto</returns>
        public static bool Edit(int indiceProducto, int id, string nombre, int indiceCategoria, int precio)
        {
            if (id != Comercio.inventario[indiceProducto].id)
            {
                Comercio.inventario[indiceProducto].id = id;
            }
            if (nombre != Comercio.inventario[indiceProducto].nombre)
            {
                Comercio.inventario[indiceProducto].nombre = nombre;
            }
            if (Comercio.categorias[indiceCategoria] != Comercio.inventario[indiceProducto].categoria)
            {
                Comercio.inventario[indiceProducto].categoria = Comercio.categorias[indiceCategoria];
            }
            if (precio != Comercio.inventario[indiceProducto].precio)
            {
                Comercio.inventario[indiceProducto].precio = precio;
            }
            return true;
        }


        /// <summary>
        /// Muestra todos los productos en el inventario del Comercio 
        /// </summary>
        /// <returns>Devuelve la lista de productos del inventario del Comercio</returns>
        public static List<Producto> Show()
        {
            return Comercio.inventario;
        }

        /// <summary>
        /// Devuelve todos los productos que coinciden con la categoria que se brindo
        /// </summary>
        /// <param name="categoriaBusqueda">Nombre de la categoria que utilizara para la busqueda</param>
        /// <returns>Lista de productos que coinciden con la categoria que se brindo</returns>
        public static List<Producto> SeachByCategoria(string categoriaBusqueda)
        {
            List<Producto> listaFiltrada = new List<Producto>();

            foreach (Producto producto in Comercio.inventario)
            {
                if (producto.categoria.nombre == categoriaBusqueda)
                {
                    listaFiltrada.Add(producto);
                }
            }
            return listaFiltrada;
        }

        /// <summary>
        /// Devuelve todos los productos que disponen de 100 o mas unidades de stock
        /// </summary>
        /// <returns>Lista de productos que tienen 100 o mas de stock</returns>
        public static List<Producto> SeachStockMayorCien()
        {
            List<Producto> listaFiltrada = new List<Producto>();

            foreach (Producto producto in Comercio.inventario)
            {
                if (producto.stock < 100)
                {
                    listaFiltrada.Add(producto);
                }
            }
            return listaFiltrada;
        }

        /// <summary>
        /// Devuelve todos los productos que disponen de 100 o mas unidades de stock
        /// </summary>
        /// <returns>Lista de productos que tienen 100 o mas de stock</returns>
        public static List<Producto> SeachStockMenorCien()
        {
            List<Producto> listaFiltrada = new List<Producto>();

            foreach (Producto producto in Comercio.inventario)
            {
                if (producto.stock >= 100)
                {
                    listaFiltrada.Add(producto);
                }
            }
            return listaFiltrada;
        }

        /// <summary>
        /// Devuelve todos los productos que disponen de 0 unidades de Stock
        /// </summary>
        /// <returns>Lista de productos que tienen 0 de stock</returns>
        public static List<Producto> SeachStockCero()
        {
            List<Producto> listaFiltrada = new List<Producto>();

            foreach (Producto producto in Comercio.inventario)
            {
                if (producto.stock == 0)
                {
                    listaFiltrada.Add(producto);
                }
            }
            return listaFiltrada;
        }

        /// <summary>
        /// Devuelve todos los productos que tienen el nombre buscado
        /// </summary>
        /// <param name="nombreBusqueda">Nombre que se utilizzara para la busqueda</param>
        /// <returns>Lista de productos que tienen el nombre buscado</returns>
        public static List<Producto> SeachByName(string nombreBusqueda)
        {
            List<Producto> listaFiltrada = new List<Producto>();

            foreach (Producto producto in Comercio.inventario)
            {
                if (producto.nombre == nombreBusqueda)
                {
                    listaFiltrada.Add(producto);
                }
            }
            return listaFiltrada;
        }

        /// <summary>
        /// Devuelve todos los productos que tienen el id buscado 
        /// </summary>
        /// <param name="idBusqueda">Id buscado</param>
        /// <returns>Lista de productos que tienen el nombre buscado</returns>
        public static List<Producto> SeachById(int idBusqueda)
        {
            List<Producto> listaFiltrada = new List<Producto>();

            foreach (Producto producto in Comercio.inventario)
            {
                if (producto.id == idBusqueda)
                {
                    listaFiltrada.Add(producto);
                }
            }
            return listaFiltrada;
        }
    }
}
