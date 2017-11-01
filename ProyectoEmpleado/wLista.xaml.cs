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
    /// Interaction logic for wLista.xaml
    /// </summary>
    public partial class wLista : Window
    {
        private DataGrid dataGrid;

        public wLista()
        {
            InitializeComponent();
        }

        private void wLista1_Loaded(object sender, RoutedEventArgs e)
        {
            string tipo = "";
            foreach (Empleado aux in MainWindow.lista)
            {
                if (aux.GetType().ToString() == "ProyectoEmpleado.EmpleadoBase")
                    tipo = "Base";
                else if (aux.GetType().ToString() == "ProyectoEmpleado.EmpleadoJornada")
                    tipo = "Jornada";
                else
                    tipo = "Sindicalizado";

                textBlockLista.Text += string.Format("{0,0} {1,20} {2,20} {3,20}\n", aux.Datos.Nombre, aux.Datos.Telefono, aux.Datos.Email, tipo);
            }
            //}
        }
    }
}
