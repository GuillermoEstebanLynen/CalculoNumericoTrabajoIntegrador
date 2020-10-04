using System;
using System.Collections.Generic;
using System.Text;

namespace ComercioModelo
{
    public class Empleado : Persona
    {

        private int _nroLegajo;
        public int ventasRealizadas;
        public int montoFacturado;

        public int nroLegajo
        {
            get { return this._nroLegajo; }
        }


        public Empleado(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this._nroLegajo = Comercio.ultimoLegajoUsado + 1;
            Comercio.ultimoLegajoUsado += 1;
        }

        /// <summary>
        /// Devuelve en una linea las propiedades del elemento
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"{this.nombre,-25} | {this.apellido,-25} | {this._nroLegajo,-25}");
        }

    }
}
