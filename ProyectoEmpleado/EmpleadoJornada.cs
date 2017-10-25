using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEmpleado
{
    class EmpleadoJornada : Empleado
    {
        protected int numeroDias;
        public int NumeroDias
        {
            get { return numeroDias; }
            set { numeroDias = value; }
        }

        private double salarioXDia;
        public double SalarioXDia
        {
            get { return salarioXDia; }
            set { salarioXDia = value; }
        }

        //Constructor.
        public EmpleadoJornada(DatosPersonales datos, int dias, double salarioXDia)
            : base(datos)
        {
            this.numeroDias = dias;
            this.salarioXDia = salarioXDia;
        }

        public override double Salario()
        {
            return numeroDias * salarioXDia;
        }
    }
}
