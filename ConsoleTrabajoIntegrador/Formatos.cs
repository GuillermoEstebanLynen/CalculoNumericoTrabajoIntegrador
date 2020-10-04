using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ComercioConsola
{
    class Formatos
    {

        /// <summary>
        /// Recibe el encabezado y la lista de Opciones y las dibuja a ambas
        /// </summary>
        /// <param name="encabezado"></param>
        /// <param name="opciones"></param>
        public static void DibujarMenu(string encabezado, List<string> opciones)
        {
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 1; i <= opciones.Max(o=>o.Length); i++)
            {
                Console.Write("-");
            }
            Console.Write("\n");

            Console.WriteLine();
            Console.WriteLine(encabezado);
            Console.WriteLine();

            for (int i = 1; i <= opciones.Max(o => o.Length); i++)
            {
                Console.Write("-");
            }
            Console.Write("\n");
            Console.WriteLine();

            int contador = 1;

            foreach (string opcion in opciones)
            {
                Console.WriteLine($"{contador, -3} | {opcion}");
                contador++;
            }
        }

        /// <summary>
        /// Setea el Color del texto y el fondo al default del CMD
        /// </summary>
        private static void SetTextNormal()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Recibe un mensaje y lo dibuja en una linea con letra blanca y fondo rojo y lo vuelve a la normalidad antes de terminar
        /// </summary>
        /// <param name="mensaje"></param>
        public static void SetTextError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine(mensaje);
            Console.WriteLine();
            SetTextNormal();
        }

        /// <summary>
        /// Recibe un mensaje y lo dibuja en una linea con letra blanca y fondo verde y lo vuelve a la normalidad antes de terminar
        /// </summary>
        /// <param name="mensaje"></param>
        public static void SetTextSucess(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(mensaje);
            Console.WriteLine();
            SetTextNormal();
        }

    }
}
