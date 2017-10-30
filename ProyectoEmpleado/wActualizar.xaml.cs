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
        private void btnCambiarImagen_Click(object sender, RoutedEventArgs e)
        {
            string nombreImagen = "";
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
                    imgEmpleadoActualizar.Source = logo;
                }
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (empleado.Datos.Nombre != "")
                {
                    switch (empleado.GetType().ToString())
                    {
                        case "ProyectoEmpleado.EmpleadoBase":
                            SetDatosDesdeTextBox();
                            ((EmpleadoBase)empleado).SalarioBase = Convert.ToDouble(txtSalarioEmpleadoBase.Text);
                            break;
                        case "ProyectoEmpleado.EmpleadoJornada":
                            SetDatosDesdeTextBox();
                            ((EmpleadoJornada)empleado).NumeroDias = Convert.ToInt16(txtDias.Text);
                            ((EmpleadoJornada)empleado).SalarioXDia = Convert.ToDouble(txtPagoDia.Text);
                            break;
                        case "ProyectoEmpleado.EmpleadoSindicalizado":
                            SetDatosDesdeTextBox();
                            ((EmpleadoSindicalizado)empleado).SalarioBase = Convert.ToDouble(txtSalarioSindicalizadoBase.Text);
                            ((EmpleadoSindicalizado)empleado).HorasExtra = Convert.ToInt16(txtHoras.Text);
                            ((EmpleadoSindicalizado)empleado).SalarioXHoraExtra = Convert.ToDouble(txtPagoHoras.Text);
                            break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
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

                BitmapImage imagen = new BitmapImage();
                imagen.BeginInit();
                imagen.UriSource = new Uri(empleado.Datos.Fotografia, UriKind.RelativeOrAbsolute);
                imagen.EndInit();
                imgEmpleadoActualizar.Source = imagen;

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
            catch (Exception)
            {
                MessageBox.Show("Empleado no Encontrado");
            }

        }

        private void SetDatosDesdeTextBox()
        {
            empleado.Datos.Nombre = txtNombre.Text;
            empleado.Datos.Direccion = txtDireccion.Text;
            empleado.Datos.Email = txtEmail.Text;
            empleado.Datos.Telefono = txtTelefono.Text;
            empleado.Datos.Fotografia = imgEmpleadoActualizar.Source.ToString();
        }

    }
}
 