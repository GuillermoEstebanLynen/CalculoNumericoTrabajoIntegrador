using System;
using System.Collections.Generic;
using System.Text;
using ComercioConsola;
using ComercioControlador;
using ComercioModelo;

namespace ConsoleTrabajoIntegrador.SubMenus
{
    class SubMenuEmpleados
    {
        public static void MenuEmpleados()
        {
            Console.Clear();

            //Lista de Opciones
            List<string> opciones = new List<string>();
            opciones.Add("Mostrar todos los Empleados");
            opciones.Add("Agregar Empleado");
            opciones.Add("Editar Empleado");
            opciones.Add("Eliminar Empleado");
            opciones.Add("Volver al menu Home");

            Formatos.DibujarMenu("Empleados", opciones);
            int opcionElegida = Validadores.ValidarOpcionMenu("Ingrese la opcion que desea elegir: ", opciones.Count);

            switch (opcionElegida)
            {
                case 1:
                    Show();
                    MenuEmpleados();
                    break;
                case 2:
                    Add();
                    MenuEmpleados();
                    break;
                case 3:
                    Edit();
                    MenuEmpleados();
                    break;
                case 4:
                    Delete();
                    MenuEmpleados();
                    break;
                case 5:
                    Menus.Home();
                    break;
            }

        }

        private static void Show()
        {
            Console.Clear();
            TablaEmpleados(Comercio.empleados);
            Validadores.EsperaTecla();
        }

        public static void Show(Empleado empleado)
        {
            Console.WriteLine();
            Console.WriteLine("Nombre del Empleado : {0}", empleado.nombre);
            Console.WriteLine("Apellido del Empleado : {0}", empleado.apellido);
            Console.WriteLine("Numero del Legajo del Empleado : {0}", empleado.nroLegajo);
            Console.WriteLine();
        }

        private static void Add()
        {
            try
            {
                string nombreElegido = Validadores.ValidarTexto("Escriba el nombre del Empleado que desea crear: ");
                string apellidoElegido = Validadores.ValidarTexto("Escriba el apellido del Empleado que desea crear: ");

                bool resultado = EmpleadoController.Add(nombreElegido, apellidoElegido);
                if (resultado)
                {
                    Formatos.SetTextSucess("Empleado Creado Satisfactoriamente!!!");
                    Console.WriteLine("Aprete Cualquier tecla para volver al menu");
                    Console.ReadKey();
                }
                else
                {
                    Formatos.SetTextError("Empleado NO Creado por un error desconocido");
                    Console.WriteLine("Aprete Cualquier tecla para volver al menu");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Formatos.SetTextError(string.Format("Se ha producido el siguiene error: {0}", e.Message));
                Console.WriteLine();
                Console.ReadKey();
            }
        }

        private static void Edit()
        {
            Console.Clear();
            try
            {
                Console.Clear();

                TablaEmpleados(Comercio.empleados);

                int indiceEmpleadoElegido = Validadores.ValidarOpcionMenu("Elija el Empleado que desea editar: ", Comercio.inventario.Count);
                indiceEmpleadoElegido -= 1;

                string nombreAReemplezar = Validadores.ValidarTexto("Ingrese el nombre correcto del Empleado : ");
                string apellidoAReemplezar = Validadores.ValidarTexto("Ingrese el apellido correcto del Empleado : ");

                bool resultado = EmpleadoController.Edit(indiceEmpleadoElegido, nombreAReemplezar, apellidoAReemplezar);

                if (resultado)
                {
                    Formatos.SetTextSucess("Empleado Editado Satisfactoriamente!!!");
                    Console.WriteLine("Aprete Cualquier tecla para volver al menu");
                    Console.ReadKey();
                }
                else
                {
                    Formatos.SetTextError("Empleado NO Editado por un error desconocido");
                    Console.WriteLine("Aprete Cualquier tecla para volver al menu");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Formatos.SetTextError(string.Format("Se ha producido el siguiene error: {0}", e.Message));
                Console.WriteLine();
                Console.ReadKey();
            }
        }

        private static void Delete()
        {
            Console.Clear();
            try
            {
                Console.Clear();

                TablaEmpleados(Comercio.empleados);

                int indiceEmpleadoElegido = Validadores.ValidarOpcionMenu("Elija el Empleado que desea eliminar: ", Comercio.inventario.Count);
                indiceEmpleadoElegido -= 1;

                bool resultado = EmpleadoController.Delete(indiceEmpleadoElegido);

                if (resultado)
                {
                    Formatos.SetTextSucess("Empleado Eliminado Satisfactoriamente!!!");
                    Console.WriteLine("Aprete Cualquier tecla para volver al menu");
                    Console.ReadKey();
                }
                else
                {
                    Formatos.SetTextError("Empleado NO Eliminado por un error desconocido");
                    Console.WriteLine("Aprete Cualquier tecla para volver al menu");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Formatos.SetTextError(string.Format("Se ha producido el siguiene error: {0}", e.Message));
                Console.WriteLine();
                Console.ReadKey();
            }
        }

        public static void TablaEmpleados(List<Empleado> empleados)
        {
            //Lista a dibujar
            List<string> empleadosToString = new List<string>();

            foreach (Empleado empleado in empleados)
            {
                empleadosToString.Add(empleado.ToString());
            }

            string encabezadoTabla = string.Format($"{"#   |"} {"Nombre",-25} | {"Apellido",-25} | {"NroLegajo",-25}");

            Formatos.DibujarMenu(encabezadoTabla, empleadosToString);
        }

    }
}
