using System;
using System.Collections.Generic;
using ComercioModelo;

namespace ComercioControlador
{
    public class CategoriaController
    {

        /// <summary>
        /// Crea una categoria y la agrega como opcion al Comercio
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>Devuelve true si se agrego con exito la categoria</returns>
        public static bool Add(string nombre)
        {
            Comercio.categorias.Add(new Categoria(nombre));
            return true;
        }

        /// <summary>
        /// Borra una Categoria del Comercio
        /// </summary>
        /// <param name="indiceInventario">Es el inventario por el que se desea</param>
        /// <returns>Devuelve true si se elimino con exito la categoria</returns>
        public static bool Delete(int indiceCategoria)
        {
            Comercio.categorias.Remove(Comercio.categorias[indiceCategoria]);
            return true;
        }

        /// <summary>
        /// Edita la Categoria Elegida
        /// </summary>
        /// <param name="indiceInventario">Es el indice del producto del inventario del Comercio</param>
        /// <param name="nombre">Es el nombre por el cual se desea editar</param>
        /// <returns>Devuelve true si se edito con exito la categoria</returns>
        public static bool Edit(int indiceCategoria, string nombre)
        {
            Comercio.categorias[indiceCategoria].nombre = nombre;
            return true;
        }


        /// <summary>
        /// Lista con todas las categorias del comercio
        /// </summary>
        /// <returns>Devuelve lista de categorias del comercio</returns>
        public static List<Categoria> Show()
        {
            return Comercio.categorias;
        }

    }
}
