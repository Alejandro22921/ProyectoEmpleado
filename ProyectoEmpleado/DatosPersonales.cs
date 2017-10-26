
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEmpleado
{
    public class DatosPersonales
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

        protected string fotografia;
        public string Fotografia
        {
            get { return fotografia; }
            set { fotografia = value; }
        }

        public DatosPersonales(string nombre, string direccion, string email, string telefono, string fotografia)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.email = email;
            this.telefono = telefono;
            this.fotografia = fotografia;
        }
    }
}