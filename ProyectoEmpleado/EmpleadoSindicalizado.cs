using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEmpleado
{
    class EmpleadoSindicalizado : EmpleadoBase
    {
        private int horasExtra;
        private double salarioXHoraExtra;

        public int HorasExtra
        {
            get { return horasExtra; }
            set { horasExtra = value; }
        }
        public double SalarioXHoraExtra
        {
            get { return salarioXHoraExtra; }
            set { salarioXHoraExtra = value; }
        }

        public EmpleadoSindicalizado(DatosPersonales datos, double salarioBase, int horasExtra, double salarioXHoraExtra)
            : base(datos, salarioBase)
        {
            this.horasExtra = horasExtra;
            this.salarioXHoraExtra = salarioXHoraExtra;
        }

        public override double Salario()
        {
            return base.Salario() + (salarioXHoraExtra * horasExtra);
        }
    }
}
