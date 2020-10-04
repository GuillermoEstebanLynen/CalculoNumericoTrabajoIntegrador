using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ComercioModelo
{
    public class Producto
    {
        private int _id;
        private string _nombre;
        public Categoria categoria;
        public int precio;
        private int _stock;
        public int cantVentas;

        public int stock
        {
            get { return this._stock; }
        }

        /// <summary>
        /// Valida que no se cree un Producto con un Id ya existente
        /// </summary>
        public int id
        {
            get { return this._id; }
            set
            {
                foreach (Producto producto in Comercio.inventario)
                {
                    if (value == producto.id)
                    {
                        throw new ArgumentException("Ya existe un Producto con ese id.");
                    }
                }
                this._id = value;
            }
        }

        /// <summary>
        /// Valida que no se cree un Producto con un nombre ya existente
        /// </summary>
        public string nombre
        {
            get { return this._nombre; }
            set
            {
                foreach (Producto producto in Comercio.inventario)
                {
                    if (value == producto.nombre)
                    {
                        throw new ArgumentException("Ya existe un Producto con ese id.");
                    }
                }
                this._nombre = value;
            }
        }

        public int MontoFacturado
        {
            get
            {
                return this.precio * this.cantVentas;
            }
        }

        public Producto(int id, string nombre, Categoria categoria, int precio, int stock)
        {
            this.id = id;
            this.nombre = nombre;
            this.categoria = categoria;
            this.precio = precio;
            this._stock = stock;
            this.cantVentas = 0;
        }

        public void SumaStock(int cantidadUnidades)
        {
            this._stock += cantidadUnidades;
        }

        public void VentaProductos(int cantidadUnidades)
        {
            this._stock -= cantidadUnidades;
            this.cantVentas++;
        }

        public override string ToString()
        {
            return string.Format($"{this.id,-5} | {this.nombre,-25} {this.categoria,-20} | {this.precio,-10} | {this.stock,-10} | {this.MontoFacturado,-15}");
        }

    }

}
