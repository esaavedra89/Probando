using Probe.Modelo.Modulos.Sistema;
using Probe.Negocio.Modulos;
using Probe.Vistas.Modulos;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Probe.Vistas
{
    public class LoginVistaModel : INotifyPropertyChanged
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

        public Command AccederCommand
        {
            get
            {
                return new Command(async () =>
                {
                    this.Busy = true;
                    this.IsEnabledPage = false;
                    await Acceder().ConfigureAwait(false);
                    this.Busy = false;
                    this.IsEnabledPage = true;
                });
            }
        }

        public Command NavegarRegistroCommand
        {
            get
            {
                return new Command(async () =>
                {
                    this.Busy = true;
                    this.IsEnabledPage = false;
                    await NavegarRegistro().ConfigureAwait(false);
                    this.Busy = false;
                    this.IsEnabledPage = true;
                });
            }
        }

        #endregion

        #region Constructores

        public LoginVistaModel()
        {
            this.Usuario = "admin";
            this.Contrasenna = "admin123";
        } 

        #endregion

        #region Metodos

        async Task Acceder()
        {
            try
            {
                this.Busy = true;
                this.IsEnabledPage = false;

                if (string.IsNullOrEmpty(this.Usuario) || string.IsNullOrEmpty(this.Contrasenna))
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        this.Busy = false;
                        this.IsEnabledPage = true;
                        await Application.Current.MainPage.DisplayAlert(
                            "Error",
                            "Por favor, no deje campos en blanco.",
                            "Aceptar");
                    });

                    return;
                }


                // Instanciamos vendedorB.
                VendedorB objVendedorB = new VendedorB();

                Respuesta peticion = await objVendedorB.AutenticarAPI(this.Usuario, this.Contrasenna).ConfigureAwait(false);
                if (peticion.Valido)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        this.Busy = false;
                        this.IsEnabledPage = true;
                        await Application.Current.MainPage.Navigation.PushAsync(new Home(), false);
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
                            peticion.Mensaje,
                            "Aceptar");
                    });
                }
            }
            catch (Exception exc)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    this.Busy = false;
                    this.IsEnabledPage = true;
                    await Application.Current.MainPage.DisplayAlert(
                            "Error",
                            "Ha ocurrido un error: " + exc.Message,
                            "Aceptar");
                });
            }
        }

        async Task NavegarRegistro()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new RegistrarVendedor(), false);
            }
            catch (Exception exc)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ha ocurrido un error: " + exc.Message,
                        "Aceptar");
                });
            }
        }

        #endregion
    }
}
