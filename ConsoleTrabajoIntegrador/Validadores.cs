using System;
using System.Collections.Generic;
using System.Text;

namespace ComercioConsola
{
    class Validadores
    {

        /// <summary>
        /// Recibe un mensaje y pide el ingreso de un texto diferente de ""
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public static string ValidarTexto(string mensaje)
        {
            string textoIngresado;
            do
            {

                Console.WriteLine("");
                Console.Write(mensaje);
                textoIngresado = Console.ReadLine();

                //Rechaza el ingreso
                if (textoIngresado == "")
                {
                    Formatos.SetTextError("La opcion ingresada no es valida. Presione una tecla para continuar");
                    Console.ReadKey();
                }
            } while (textoIngresado == "");

            return textoIngresado;

        }

        /// <summary>
        /// Recibe un titulo y una lista de opciones, lo dibuja y obliga a ingresar una opcion valida
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public static int ValidarEntero(string mensaje)
        {

            int opcionIngresada;
            bool estadoValidado;
            do
            {

                Console.WriteLine("");
                Console.Write($"{mensaje}");
                string lectura = Console.ReadLine();
                estadoValidado = int.TryParse(lectura, out opcionIngresada);

                //Rechaza el ingreso
                if (estadoValidado == false)
                {
                    Formatos.SetTextError("La opcion ingresada no es valida. Presione una tecla para continuar");
                    Console.ReadKey();
                }
            } while (estadoValidado == false);

            return opcionIngresada;

        }

        /// <summary>
        /// Recibe un titulo y una lista de opciones, lo dibuja y obliga a ingresar una opcion valida
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="cantOpciones"></param>
        /// <returns></returns>
        public static int ValidarOpcionMenu(string mensaje, int cantOpciones)
        {

            int opcionIngresada;
            bool estadoValidado;
            do
            {
                Console.WriteLine("");
                Console.Write($"{mensaje}");
                string lectura = Console.ReadLine();
                estadoValidado = int.TryParse(lectura, out opcionIngresada);

                //Si la conversion fue exitosa evalua si la opcion ingresada es mayor a la maxima permitida y setea en false en caso de serlo
                if (estadoValidado == true)
                {
                    if (opcionIngresada > cantOpciones)
                    {
                        estadoValidado = false;
                    }
                }

                //Rechaza el ingreso
                if (estadoValidado == false)
                {
                    Formatos.SetTextError("La opcion ingresada no es valida. Presione una tecla para continuar");
                    Console.ReadKey();
                }
            } while (estadoValidado == false);

            return opcionIngresada;

        }

        /// <summary>
        /// Repregunta la salida del programa y valida mediante una tecla
        /// </summary>
        /// <returns></returns>
        public static ConsoleKeyInfo ValidarSalidaPrograma()
        {

            ConsoleKeyInfo lectura;
            bool estadoValidado;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("¿Esta seguro que desea salir del programa? Ingrese Y para confirmar o N para cancelar");
                Console.WriteLine("");

                lectura = Console.ReadKey();

                if (lectura.Key == ConsoleKey.N || lectura.Key == ConsoleKey.Y)
                {
                    estadoValidado = true;
                    return lectura;
                }
                else
                {
                    estadoValidado = false;
                    Formatos.SetTextError("La tecla ingresada no es valida.");
                    Console.WriteLine("");
                }
            } while (estadoValidado == false);

            return lectura;
        }


        public static void EsperaTecla()
        {
            Console.WriteLine();
            Console.WriteLine("Presione Cualquier tecla para continuar ...");
            Console.ReadKey();
        }
    }
}
