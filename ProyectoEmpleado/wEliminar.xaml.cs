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
    /// Interaction logic for wEliminar.xaml
    /// </summary>
    public partial class wEliminar : Window
    {
        public wEliminar()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = MainWindow.lista.Find(x => x.Datos.Nombre == txtNombre.Text);
            if (empleado != null)
            {
                MessageBoxResult result = MessageBox.Show("¿Desea Eliminar El Empleado Seleccionado?", "Confirmación", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    MainWindow.lista.Remove(empleado);
                    txtNombre.Text = "";
                }
            }
            else
            {
                MessageBox.Show("No se ha encontrado el empleado :(");
            }
        }
    }
}


