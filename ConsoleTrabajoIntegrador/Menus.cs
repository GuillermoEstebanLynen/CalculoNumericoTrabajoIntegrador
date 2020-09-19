using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTrabajoIntegrador
{
    class Menus
    {

        public static void Home()
        {

            //Lista de Opciones
            List<string> opciones = new List<string>();
            opciones.Add("Productos");

            Formatos.DibujarMenu("Bienvenido", opciones);
        }

        public static void MenuProductos()
        {

            //Lista de Opciones
            List<string> opciones = new List<string>();
            opciones.Add("Mostrar todos los Productos");
            opciones.Add("Mostrar cantidad de Productos");

            Formatos.DibujarMenu("Bienvenido", opciones);
        }

    }
}
