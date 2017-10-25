using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEmpleado
{
    class EmpleadoBase: Empleado
    {
        protected double salarioBase;
        public double SalarioBase
        {
            get { return salarioBase; }
            set { salarioBase = value; }
        }

        public EmpleadoBase(DatosPersonales datos, double salarioBase)
            : base(datos)
        {
            this.salarioBase = salarioBase;
        }

        //Definición del método salario.
        public override double Salario()
        {
            return SalarioBase;
        }
    }
}
