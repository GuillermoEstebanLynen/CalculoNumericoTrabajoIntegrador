using System;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Text;

namespace ConsoleTrabajoIntegrador
{
    class Menus
    {

        public static void Home()
        {
            Console.Clear();

            //Lista de Opciones
            List<string> opciones = new List<string>();
            opciones.Add("Productos");
            opciones.Add("Salir Programa");

            Formatos.DibujarMenu("Bienvenido", opciones);

            int opcionValidada = Validadores.ValidarEntero(opciones.Count);

            switch (opcionValidada)
            {
                case 1:
                    MenuProductos();
                    break;
                case 2:
                    SalidaPrograma();
                    break;
            }

        }

        public static void MenuProductos()
        {
            Console.Clear();

            //Lista de Opciones
            List<string> opciones = new List<string>();
            opciones.Add("Mostrar todos los Productos");
            opciones.Add("Mostrar cantidad de Productos");
            opciones.Add("Volver al menu Home");

            Formatos.DibujarMenu("Menu De Productos", opciones);

            int opcionValidada = Validadores.ValidarEntero(opciones.Count);

            switch (opcionValidada)
            {
                case 1:
                    MenuProductos();
                    break;
                case 2:
                    SalidaPrograma();
                    break;
                case 3:
                    Home();
                    break;
            }

        }

        public static void SalidaPrograma()
        {
            Console.Clear();

            Formatos.SetTextError();
            Console.WriteLine("");
            Console.WriteLine("¿Esta seguro que desea salir del programa? S/N");
            Formatos.SetTextNormal();

            ConsoleKeyInfo opcionValidada = Validadores.ValidarSalidaPrograma();

            if (opcionValidada.Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                Formatos.SetTextSucess();
                Console.WriteLine("");
                Console.WriteLine("--------- QUE TENGA UN BUEN DIA!!! ----------");
                Console.WriteLine("");
                Formatos.SetTextNormal();
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
