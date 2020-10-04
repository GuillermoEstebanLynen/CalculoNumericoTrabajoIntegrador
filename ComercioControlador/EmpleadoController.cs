using System;
using System.Collections.Generic;
using System.Text;
using ComercioModelo;

namespace ComercioControlador
{
    public class EmpleadoController
    {

        /// <summary>
        /// Crea y lo asigna a la lista de empleados del Comercio
        /// </summary>
        /// <param name="nombre">Nombre del empleado que se creara</param>
        /// <param name="apellido">Apellido del empleado que se creara</param>
        /// <returns>Devuelve true si se creo con exito el empleado</returns>
        public static bool Add(string nombre,  string apellido)
        {
            Comercio.empleados.Add(new Empleado(nombre, apellido));
            return true;
        }

        /// <summary>
        /// Elimina y lo quita de la lista de empleados del Comercio
        /// </summary>
        /// <param name="indiceEmpleado">Indice del empleado que se desea eliminar dentro de la lista de empleados del Comercio</param>
        /// <returns>Devuelve true si se elimino con exito el empleado</returns>
        public static bool Delete(int indiceEmpleado)
        {
            Comercio.empleados.Remove(Comercio.empleados[indiceEmpleado]);
            return true;
        }


        /// <summary>
        /// Eita un empleado de la lista de empleados del Comercio
        /// </summary>
        /// <param name="indiceEmpleado">Indice del empleado que se desea editar dentro de la lista de empleados del Comercio</param>
        /// <param name="nombre">Nombre del empleado que se reemplazara</param>
        /// <param name="apellido">Apellido del empleado que se reemplazara</param>
        /// <returns>Devuelve true si se edita con exito el empleado</returns>
        public static bool Edit(int indiceEmpleado, string nombre, string apellido)
        {
            Comercio.empleados[indiceEmpleado].nombre = nombre;
            Comercio.empleados[indiceEmpleado].apellido = apellido;
            return true;
        }

        /// <summary>
        /// Lista todos los empleados del Comercio
        /// </summary>
        /// <returns>Devuelve la lista de empleados del comercio</returns>
        public static List<Empleado> Show()
        {
            return Comercio.empleados;
        }

    }
}
