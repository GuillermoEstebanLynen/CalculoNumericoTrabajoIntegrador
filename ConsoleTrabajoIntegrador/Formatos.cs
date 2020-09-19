using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTrabajoIntegrador
{
    class Formatos
    {

        public static void DibujarMenu(string encabezado, List<string> opciones)
        {
            DibujarEncabezado(encabezado);
            DibujarOpciones(opciones);
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

    }
}
