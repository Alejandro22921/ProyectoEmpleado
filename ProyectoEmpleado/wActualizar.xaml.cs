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
        public wActualizar()
        {
            InitializeComponent();
        }

        private void btnBuscarActualziar_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = MainWindow.lista.Find(s => s.Datos.Nombre == txtEmpleadoBusqueda.Text);
            txtNombre.Text = empleado.Datos.Nombre;
            txtDireccion.Text = empleado.Datos.Direccion;

        }
    }
}
