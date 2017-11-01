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
    /// Interaction logic for wAltaEmpleado.xaml
    /// </summary>
    public partial class wAltaEmpleado : Window
    {
        List<string> empleadoList = new List<string> { "BASE", "JORNADA", "SINDICALIZADO" };
        private string nombreImagen = "";
        public string NombreImagen
        {
            get { return nombreImagen; }
            set { nombreImagen = value; }
        }
        public wAltaEmpleado()
        {
            InitializeComponent();
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            DatosPersonales datos;
            if (nombreImagen == "")
            {
                Uri nombre = new Uri("/ProyectoEmpleado;component/sources/usuarioAñadir.png", UriKind.Relative);
                datos = new DatosPersonales(txtNombre.Text, txtDireccion.Text, txtEmail.Text, txtTelefono.Text, nombre.ToString());
            }
            else
            {
                datos = new DatosPersonales(txtNombre.Text, txtDireccion.Text, txtEmail.Text, txtTelefono.Text, nombreImagen);
            }

            nombreImagen = "";
            Empleado empleado = null;

            try { 
            if(cmbEmpleado.SelectedIndex == 0) //Empleado base.
            {
                double salario = Convert.ToDouble(txtBase_Base.Text);
                empleado = new EmpleadoBase(datos, salario);

            } else if (cmbEmpleado.SelectedIndex == 1) //Empleado jornada.
            {
                int dias = Convert.ToInt32(txtSalario_Jornada.Text);
                double salarioXDia = Convert.ToDouble(txtDias_Jornada.Text);
                empleado = new EmpleadoJornada(datos, dias, salarioXDia);
            } 
            else
            { 
                double salarioBase = Convert.ToDouble(txtSalario_Sindicalizado.Text);
                int horasExtras = Convert.ToInt32(txtHoras_Sindicalizado.Text);
                double salarioXHoraExtra = Convert.ToDouble(txtSalarioExtra_Sindicalizado.Text);
                empleado = new EmpleadoSindicalizado(datos, salarioBase, horasExtras, salarioXHoraExtra);
            }

            if (empleado != null)
            {
                MainWindow.lista.Add(empleado);
                MessageBox.Show("Empleado Añadido Exitosamente :)");
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtEmail.Text = "";
                txtTelefono.Text = "";
                txtBase_Base.Text = "";
                txtDias_Jornada.Text = "";
                txtSalario_Jornada.Text = "";
                txtHoras_Sindicalizado.Text = "";
                txtSalario_Sindicalizado.Text = "";
                txtSalarioExtra_Sindicalizado.Text = "";

                BitmapImage imagen = new BitmapImage();
                imagen.BeginInit();
                imagen.UriSource = new Uri("/ProyectoEmpleado;component/sources/usuarioAñadir.png", UriKind.RelativeOrAbsolute);
                imagen.EndInit();
                imagenEmpleado.Source = imagen;
            }
            
            }catch(Exception){
                MessageBox.Show("Datos Inválidos.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nombreImagen = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|JPEG FIles (*.jpeg)|*.jpeg|GIF Files (*.gif)|*.gif";
            dlg.DefaultExt = ".jpg";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                nombreImagen = dlg.FileName;
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                if (nombreImagen != "")
                {
                    logo.UriSource = new Uri(nombreImagen);
                    logo.EndInit();
                    imagenEmpleado.Source = logo;
                }
            }
        }

        private void wAltaEmpleado1_Loaded(object sender, RoutedEventArgs e)
        {
            cmbEmpleado.ItemsSource = empleadoList;
            cmbEmpleado.SelectedIndex = 0;
        }

        private void cmbEmpleado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbEmpleado.SelectedIndex == 0)
            {
                blockBase.Visibility = System.Windows.Visibility.Visible;
                blockJornada.Visibility = System.Windows.Visibility.Hidden;
                blockSindicalizado.Visibility = System.Windows.Visibility.Hidden;
                wAltaEmpleado1.Height = 385.75;
            }
            else if (cmbEmpleado.SelectedIndex == 1)
            {
                blockBase.Visibility = System.Windows.Visibility.Hidden;
                blockJornada.Visibility = System.Windows.Visibility.Visible;
                blockSindicalizado.Visibility = System.Windows.Visibility.Hidden;
                wAltaEmpleado1.Height = 415.75;
            }
            else
            {
                blockBase.Visibility = System.Windows.Visibility.Hidden;
                blockJornada.Visibility = System.Windows.Visibility.Hidden;
                blockSindicalizado.Visibility = System.Windows.Visibility.Visible;
                wAltaEmpleado1.Height = 450.75;
            }
        }
    }
}
