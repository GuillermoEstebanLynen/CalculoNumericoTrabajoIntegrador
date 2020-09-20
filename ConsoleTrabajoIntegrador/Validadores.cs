using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTrabajoIntegrador
{
    class Validadores
    {

        public static int ValidarEntero(int max)
        {

            int opcionIngresada;
            bool estadoValidado;
            do
            {
                Console.WriteLine();
                Console.Write("Ingrese el numero de opcion: ");
                string lectura = Console.ReadLine();
                estadoValidado = int.TryParse(lectura, out opcionIngresada);

                //Si la conversion fue exitosa evalua si la opcion ingresada es mayor a la maxima permitida y setea en false en caso de serlo
                if (estadoValidado == true)
                {
                    if (opcionIngresada > max)
                    {
                        estadoValidado = false;
                    }
                }

                //Rechaza el ingreso
                if (estadoValidado == false)
                {
                    Console.WriteLine();
                    Formatos.SetTextError();
                    Console.WriteLine("La opcion ingresada no es valida");
                    Formatos.SetTextNormal();
                }
            } while (estadoValidado == false);

            return opcionIngresada;

        }

        public static ConsoleKeyInfo ValidarSalidaPrograma()
        {

            ConsoleKeyInfo lectura;
            bool estadoValidado;
            do
            {
                Console.WriteLine("");
                Console.Write("Ingrese Y para confirmar o N para cancelar : ");
                lectura = Console.ReadKey();

                if (lectura.Key == ConsoleKey.N || lectura.Key == ConsoleKey.Y)
                {
                    return lectura;
                }
                else
                {
                    estadoValidado = false;
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Formatos.SetTextError();
                    Console.WriteLine("La opcion ingresada no es valida. Debe Ingresar 'Y' o 'N'");
                    Formatos.SetTextNormal();
                }
            } while (estadoValidado == false);

            return lectura;
        }

    }
}
