using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ComercioModelo
{
    public class Categoria
    {
        private string _nombre;

        /// <summary>
        /// Verifica que no se cree una Categoria que ya existe
        /// </summary>
        public string nombre
        {
            get { return _nombre; }
            set
            {
                foreach (Categoria categoria in Comercio.categorias)
                {
                    if (value == categoria.nombre)
                    {
                        throw new ArgumentException("Ya existe una Categoria con ese nombre.");
                    }
                }
                this._nombre = value;
            }
        }

        public Categoria(string Nombre)
        {
            nombre = Nombre;
        }

        /// <summary>
        /// Devuelve en una linea las propiedades del elemento
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"{this.nombre,-20}");
        }

    }
}
