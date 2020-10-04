using System;

namespace ComercioModelo
{
    public class Persona
    {
        public string nombre;
        public string apellido;

        public string nombreCompleto { get { return string.Format("{0} {1}", this.nombre, this.apellido); } }
    }
}
