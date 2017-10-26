using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEmpleado
{
    class Empresa
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        List<Empleado> lista;
        internal List<Empleado> Lista
        {
            get { return lista; }
            set { lista = value; }
        }

        //Constructor.
        public Empresa(string nombre)
        {
            this.nombre = nombre;
            lista = new List<Empleado>();
        }

        public void Nomina()
        {
            Console.Clear();
            Console.WriteLine(Nombre + "\n\n");
            Console.WriteLine("{0,-20} {1,10}", "Nombre", "Salario");
            foreach (Empleado empleado in Lista)
                Console.WriteLine("{0,-20} {1,10}", empleado.Datos.Nombre, "$" + empleado.Salario());

            Console.WriteLine("\n\nPulse una tecla para continuar...");
            Console.ReadKey();
        }

        

        public void Update()
        {
            Console.Clear();
            Console.Write("<------------------Actualizar Empleado------------------>\nNombre del Empleado a Actualizar: ");        //Empleado que quiere ser modificado
            string modificarEmpleado = Convert.ToString(Console.ReadLine());

            //Se combrueba que exista el empleado.
            Empleado exist = lista.Find(item => item.Datos.Nombre == modificarEmpleado);
            if (exist != null)
            {
                Empleado empleado = lista.Find(item => item.Datos.Nombre == modificarEmpleado);

                Console.Write("\n<-------------------Datos Del Empleado------------------>\nNuevo Nombre: ");
                string nuevoNombre = Convert.ToString(Console.ReadLine());
                Console.Write("Nueva Dirección: ");
                string nuevoDireccion = Convert.ToString(Console.ReadLine());
                Console.Write("Nuevo E-mail: ");
                string nuevoEmail = Convert.ToString(Console.ReadLine());
                Console.Write("Nuevo Teléfono: ");
                string nuevoTelefono = Convert.ToString(Console.ReadLine());

                empleado.Datos.Nombre = nuevoNombre;
                empleado.Datos.Direccion = nuevoDireccion;
                empleado.Datos.Email = nuevoEmail;
                empleado.Datos.Telefono = nuevoTelefono;
                Console.Write("\n<------------------------Salario------------------------>\n");

                if (empleado.GetType().Name == "EmpleadoBase")
                {
                    Console.Write("Nuevo Salario Base: $ ");
                    double nuevoSalarioBase = Convert.ToDouble(Console.ReadLine());
                    ((EmpleadoBase)empleado).SalarioBase = nuevoSalarioBase;
                }
                else if (empleado.GetType().Name == "EmpleadoJornada")
                {
                    Console.Write("Nuevo Número de Dias: # ");
                    int nuevoNumeroDias = Convert.ToInt32(Console.ReadLine());
                    ((EmpleadoJornada)empleado).NumeroDias = nuevoNumeroDias;

                    Console.Write("Nuevo SalarioXDía: $ ");
                    double nuevoSalarioXDia = Convert.ToDouble(Console.ReadLine());
                    ((EmpleadoJornada)empleado).SalarioXDia = nuevoSalarioXDia;

                }
                else
                {

                    Console.Write("Nuevo Salario Base: $ ");
                    double nuevoSalarioBase = Convert.ToDouble(Console.ReadLine());
                    ((EmpleadoSindicalizado)empleado).SalarioBase = nuevoSalarioBase;

                    Console.Write("Nuevo Horas Extras: # ");
                    int nuevoHorasExtra = Convert.ToInt32(Console.ReadLine());
                    ((EmpleadoSindicalizado)empleado).HorasExtra = nuevoHorasExtra;

                    Console.Write("Nuevo SalarioXHoraExtra: $ ");
                    double nuevoSalarioXHoraExtra = Convert.ToDouble(Console.ReadLine());
                    ((EmpleadoSindicalizado)empleado).SalarioXHoraExtra = nuevoSalarioXHoraExtra;

                }

            }
            else
            {
                Console.Write("\nEmpleado No Encontrado :(\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
