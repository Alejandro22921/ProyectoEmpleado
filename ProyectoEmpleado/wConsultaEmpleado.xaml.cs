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
    /// Interaction logic for wConsultaEmpleado.xaml
    /// </summary>
    public partial class wConsultaEmpleado : Window
    {
        public wConsultaEmpleado()
        {
            InitializeComponent();
        }
        //Metodos de componentes
        //busqueda con enter txt
        private void txtEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Consulta();
            }
        }

        //busqueda por boton
        private void btnBuscarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Consulta();
        }

        //boton aceptar, salida de ventana
        private void btnAceptarConsulta_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
        public void Consulta()
            {
            try
            {
                string busqueda = txtEmpleado.Text;
                Empleado empleado = MainWindow.lista.Find(x => x.Datos.Nombre == busqueda);
                txtNombre.Text = Convert.ToString(empleado.Datos.Nombre);
                txtDireccion.Text = Convert.ToString(empleado.Datos.Direccion);
                txtEmail.Text = Convert.ToString(empleado.Datos.Email);
                txtTelefono.Text = Convert.ToString(empleado.Datos.Telefono);
                txtSalario.Text = Convert.ToString("$" + empleado.Salario());
            }
            catch (Exception)
            {
                MessageBox.Show("Empleado no encontrado");
            }
        }

    }
}
