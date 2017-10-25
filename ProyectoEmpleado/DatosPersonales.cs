
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEmpleado
{
    class DatosPersonales
    {
        protected string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        protected string direccion;
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        protected string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        protected string telefono;
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public DatosPersonales(string nombre, string direccion, string email, string telefono)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.email = email;
            this.telefono = telefono;
        }
    }
}