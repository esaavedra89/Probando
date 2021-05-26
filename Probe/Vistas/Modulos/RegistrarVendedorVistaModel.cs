using Probe.Modelo;
using Probe.Modelo.Modulos.Sistema;
using Probe.Negocio.Modulos;
using Probe.Recursos;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Probe.Vistas.Modulos
{
    public class RegistrarVendedorVistaModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Atributos

        bool busy = false;
        bool isEnabled;
        bool _isEnabledPage = true;
        string _nombre = string.Empty;
        string _apellido = string.Empty;
        string _cedula = string.Empty;
        string _email = string.Empty;
        string _telefono = string.Empty;
        string _usuario = string.Empty;
        string _contrasenna = string.Empty;

        #endregion

        #region Propiedades

        public bool Busy
        {
            get { return busy; }
            set
            {
                busy = value;
                OnPropertyChanged("Busy");
            }
        }
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }
        public bool IsEnabledPage
        {
            get { return _isEnabledPage; }
            set
            {
                _isEnabledPage = value;
                OnPropertyChanged("IsEnabledPage");
            }
        }
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                OnPropertyChanged("Nombre");
            }
        }
        public string Apellido
        {
            get { return _apellido; }
            set
            {
                _apellido = value;
                OnPropertyChanged("Apellido");
            }
        }
        public string Cedula
        {
            get { return _cedula; }
            set
            {
                _cedula = value;
                OnPropertyChanged("Cedula");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Telefono
        {
            get { return _telefono; }
            set
            {
                _telefono = value;
                OnPropertyChanged("Telefono");
            }
        }
        public string Usuario
        {
            get { return _usuario; }
            set
            {
                _usuario = value;
                OnPropertyChanged("Usuario");
            }
        }
        public string Contrasenna
        {
            get { return _contrasenna; }
            set
            {
                _contrasenna = value;
                OnPropertyChanged("Contrasenna");
            }
        }

        #endregion

        #region Comandos

        public Command AcualizarCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Acualizar().ConfigureAwait(false);
                });
            }
        }

        #endregion

        #region Metodos

        async Task Acualizar()
        {
            try
            {
                this.Busy = true;
                this.IsEnabledPage = false;

                if (string.IsNullOrEmpty(this.Nombre) ||
                    string.IsNullOrEmpty(this.Apellido) ||
                    string.IsNullOrEmpty(this.Cedula) ||
                    string.IsNullOrEmpty(this.Email) ||
                    string.IsNullOrEmpty(this.Telefono) ||
                    string.IsNullOrEmpty(this.Usuario) ||
                    string.IsNullOrEmpty(this.Contrasenna))
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        this.Busy = false;
                        this.IsEnabledPage = true;
                        await Application.Current.MainPage.DisplayAlert(
                                "Error",
                                "Por favor, no dejar campos vacíos.",
                                "Aceptar");
                    });
                    
                    return;
                }

                Utilitarios objUtilitarios = new Utilitarios();
                if (!objUtilitarios.IsValidEmail(this.Email))
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        this.Busy = false;
                        this.IsEnabledPage = true;
                        await Application.Current.MainPage.DisplayAlert(
                                "Error",
                                "Por favor, ingrese un correo valido.",
                                "Aceptar");
                    });
                    
                    return;
                }

                if (this.Contrasenna.Length < 6)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        this.Busy = false;
                        this.IsEnabledPage = true;
                        await Application.Current.MainPage.DisplayAlert(
                                "Error",
                                "Por favor, la contraseña debe ser mayor a 5 dígitos.",
                                "Aceptar");
                    });
                    return;
                }

                // Creamos obj.
                Vendedor objVendedor = new Vendedor();
                objVendedor.Nombre = this.Nombre;
                objVendedor.Apellido = this.Apellido;
                objVendedor.Cedula = this.Cedula;
                objVendedor.Email = this.Email;
                objVendedor.Telefono = this.Telefono;
                objVendedor.Usuario = this.Usuario;
                objVendedor.Contrasenna = this.Contrasenna;

                // Instanciamos vendedor.
                VendedorB objVendedorB = new VendedorB();
                Respuesta consulta = await objVendedorB.GuardarAPI(objVendedor).ConfigureAwait(false);
                if (consulta.Valido)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        this.Busy = false;
                        this.IsEnabledPage = true;
                        await Application.Current.MainPage.DisplayAlert(
                                "Exito",
                                "Vendedor creado",
                                "Aceptar");

                        this.Nombre = string.Empty;
                        this.Apellido = string.Empty;
                        this.Cedula = string.Empty;
                        this.Email = string.Empty;
                        this.Telefono = string.Empty;
                        this.Usuario = string.Empty;
                        this.Contrasenna = string.Empty;

                    });

                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        this.Busy = false;
                        this.IsEnabledPage = true;
                        await Application.Current.MainPage.DisplayAlert(
                                "Error",
                                consulta.Mensaje,
                                "Aceptar");
                    });
                }

                this.Busy = false;
                this.IsEnabledPage = true;
            }
            catch (Exception exc)
            {
                this.Busy = false;
                this.IsEnabledPage = true;
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ha ocurrido un error: " + exc.Message,
                        "Aceptar");
            }
        }

        #endregion
    }
}
