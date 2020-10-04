using System;
using System.Collections.Generic;
using System.Text;
using ComercioModelo;

namespace ComercioControlador
{
    public class ClienteController
    {

        /// <summary>
        /// Crea y lo asigna a la lista de clientes del Comercio
        /// </summary>
        /// <param name="nombre">Nombre del cliente que se creara</param>
        /// <param name="apellido">Apellido del cliente que se creara</param>
        /// <param name="nroDocumento">Nro de Documento del cliente</param>
        /// <returns>Devuelve true si se creo con exito el empleado</returns>
        public static bool Add(string nombre, string apellido, int nroDocumento)
        {
            Comercio.clientes.Add(new Cliente(nombre, apellido, nroDocumento));
            return true;
        }

        /// <summary>
        /// Elimina y lo quita de la lista de clientes del Comercio
        /// </summary>
        /// <param name="indiceCliente">Indice del cliente que se desea eliminar dentro de la lista de clientes del Comercio</param>
        /// <returns>Devuelve true si se elimino con exito el cliente</returns>
        public static bool Delete(int indiceCliente)
        {
            Comercio.clientes.Remove(Comercio.clientes[indiceCliente]);
            return true;
        }


        /// <summary>
        /// Eita un cliente de la lista de clientes del Comercio
        /// </summary>
        /// <param name="indiceCliente">Indice del empleado que se desea editar dentro de la lista de empleados del Comercio</param>
        /// <param name="nombre">Nombre del cliente que se reemplazara</param>
        /// <param name="apellido">Apellido del cliente que se reemplazara</param>
        /// <param name="nroDocumento">Nro de Documento del cliente</param>
        /// <returns>Devuelve true si se edita con exito el cliente</returns>
        public static bool Edit(int indiceCliente, string nombre, string apellido, int nroDocumento)
        {
            Comercio.clientes[indiceCliente].nombre = nombre;
            Comercio.clientes[indiceCliente].apellido = apellido;
            Comercio.clientes[indiceCliente].nroDocumento = nroDocumento;
            return true;
        }

        /// <summary>
        /// Lista todos los empleados del Comercio
        /// </summary>
        /// <returns>Devuelve la lista de empleados del comercio</returns>
        public static List<Cliente> Show()
        {
            return Comercio.clientes;
        }

    }
}
