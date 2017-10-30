using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoEmpleado
{
    /// <summary>
    /// Interaction logic for wActualizar.xaml
    /// </summary>
    public partial class wActualizar : Window
    {
        Empleado empleado;
        public wActualizar()
        {
            InitializeComponent();
        }

        private void btnBuscarActualziar_Click(object sender, RoutedEventArgs e)
        {
            BusquedaYLlenado();
        }

        private void txtEmpleadoBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                BusquedaYLlenado();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void BusquedaYLlenado()
        {
            try
            {
                empleado = MainWindow.lista.Find(s => s.Datos.Nombre == txtEmpleadoBusqueda.Text);
                txtNombre.Text = empleado.Datos.Nombre;
                txtDireccion.Text = empleado.Datos.Direccion;
                txtEmail.Text = empleado.Datos.Email;
                txtTelefono.Text = empleado.Datos.Telefono.ToString();
                switch (empleado.GetType().ToString())
                {
                    case "ProyectoEmpleado.EmpleadoBase":
                        gridEmpleadoBase.Visibility = System.Windows.Visibility.Visible;
                        gridJornada.Visibility = System.Windows.Visibility.Hidden;
                        gridSindicalizado.Visibility = System.Windows.Visibility.Hidden;
                        txtSalarioEmpleadoBase.Text = empleado.Salario().ToString();
                        break;
                    case "ProyectoEmpleado.EmpleadoJornada":
                        gridEmpleadoBase.Visibility = System.Windows.Visibility.Hidden;
                        gridJornada.Visibility = System.Windows.Visibility.Visible;
                        gridSindicalizado.Visibility = System.Windows.Visibility.Hidden;
                        txtDias.Text = ((EmpleadoJornada)empleado).NumeroDias.ToString();
                        txtPagoDia.Text = ((EmpleadoJornada)empleado).SalarioXDia.ToString();
                        break;
                    case "ProyectoEmpleado.EmpleadoSindicalizado":
                        gridEmpleadoBase.Visibility = System.Windows.Visibility.Hidden;
                        gridJornada.Visibility = System.Windows.Visibility.Hidden;
                        gridSindicalizado.Visibility = System.Windows.Visibility.Visible;
                        txtSalarioSindicalizadoBase.Text = ((EmpleadoSindicalizado)empleado).SalarioBase.ToString();
                        txtHoras.Text = ((EmpleadoSindicalizado)empleado).HorasExtra.ToString();
                        txtPagoHoras.Text = ((EmpleadoSindicalizado)empleado).SalarioXHoraExtra.ToString();
                        break;
                    default:
                        //MessageBox.Show("uy no");
                        break;
                } 
            }
            catch(Exception)
            {
                MessageBox.Show("Empleado no Encontrado");
            }

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (empleado.Datos.Nombre!="")
            {
                switch (empleado.GetType().ToString())
                {
                    case "ProyectoEmpleado.EmpleadoBase":
                        ((EmpleadoBase)empleado).Datos.Nombre="";
                        ((EmpleadoBase)empleado).Datos.Direccion = "";
                        ((EmpleadoBase)empleado).Datos.Email = "";
                        ((EmpleadoBase)empleado).Datos.Telefono = "";
                        ((EmpleadoBase)empleado).Datos.Fotografia = "";
                        break;
                    case "ProyectoEmpleado.EmpleadoJornada":
                        break;
                    case "ProyectoEmpleado.EmpleadoSindicalizado":
                        break;
                }
            }
        }

        


    }
}
