using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComercioModelo
{
    public class Venta
    {
        public Empleado empleado;
        public Cliente cliente;
        public Producto producto;
        public int cantidad;
        public DateTime fechaCompra;

        public Venta (Empleado empleado, Cliente cliente, Producto producto, int cantidad)
        {
            this.empleado = empleado;
            this.cliente = cliente;
            this.producto = producto;
            this.cantidad = cantidad;
            this.fechaCompra = DateTime.UtcNow;

            producto.VentaProductos(cantidad);
            empleado.montoFacturado += (producto.precio * cantidad);
            empleado.ventasRealizadas++;
        }

        public override string ToString()
        {
            return string.Format($"| {this.empleado,-15} | {this.cliente,-15} {this.producto,-25} | {this.fechaCompra,-15}");
        }

    }
}
