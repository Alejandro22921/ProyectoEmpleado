﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoEmpleado
{
    public abstract class Empleado
    {
        private DatosPersonales datos;
        public DatosPersonales Datos
        {
            get { return datos; }
            set { datos = value; }
        }

        public Empleado(DatosPersonales datos)
        {
            this.datos = datos;
        }

        //Método abstracto.
        public abstract double Salario();
    }
}