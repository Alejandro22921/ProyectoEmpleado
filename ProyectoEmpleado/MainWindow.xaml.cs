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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoEmpleado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Empleado> lista;
   
        Empresa empresa;
        public MainWindow()
        {
            InitializeComponent();
            empresa = new Empresa("Tenaris Tamsa S.A. de C.V.");
            lista = new List<Empleado>();
        }
        
        //menu items metodos
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuAgregar_Click(object sender, RoutedEventArgs e)
        {
            (new wAltaEmpleado()).ShowDialog();
        }

        private void MenuEliminarClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuActualizarClick(object sender, RoutedEventArgs e)
        {
            (new wActualizar()).ShowDialog();
        }

        private void MenuConsulta_Click(object sender, RoutedEventArgs e)
        {
            (new wConsultaEmpleado()).ShowDialog();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {

        }


        
    }
}
