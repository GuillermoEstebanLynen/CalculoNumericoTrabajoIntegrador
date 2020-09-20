using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ConsoleTrabajoIntegrador
{
    class Formatos
    {

        public static void DibujarMenu(string encabezado, List<string> opciones)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            DibujarEncabezado(encabezado);
            DibujarOpciones(opciones);
            SetTextNormal();
        }

        public static void DibujarEncabezado(string encabezado)
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("{0}", encabezado);
            Console.WriteLine("------------------------------------------------------------");
        }

        public static void DibujarOpciones( List<string> opciones )
        {
            int contador = 1;

            foreach ( string opcion in opciones)
            {
                Console.WriteLine("{0} - {1}", contador, opcion);
                contador++;
            }

        }

        public static void SetTextNormal()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void SetTextError()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
        }

        public static void SetTextSucess()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
        }

    }
}
