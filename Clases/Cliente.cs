using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ComercioModelo
{
    public class Cliente : Persona
    {
        private int _nroDocumento;

        /// <summary>
        /// Verifica que no se cree un Cliente con un documento que ya existe
        /// </summary>
        public int nroDocumento
        {
            get { return _nroDocumento; }
            set
            {
                foreach ( Cliente cliente in Comercio.clientes )
                {
                    if ( value == cliente.nroDocumento )
                    {
                        throw new ArgumentException("Ya existe un cliente con ese numero de Documento");
                    }
                }
                this._nroDocumento = value;
            }
        }

        public Cliente(string nombre, string apellido, int nroDocumento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nroDocumento = nroDocumento;
        }

        /// <summary>
        /// Devuelve en una linea las propiedades del elemento
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"{this.nombre,-25} | {this.apellido,-25} | {this.nroDocumento,-25}");
        }

    }
}
