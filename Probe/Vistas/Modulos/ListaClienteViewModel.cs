using Newtonsoft.Json;
using Probe.Modelo;
using Probe.Modelo.Modulos.Sistema;
using Probe.Negocio.Modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Probe.Vistas.Modulos
{
    public class ListaClienteViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Attributes

        bool busy = true;
        bool isEnabled;
        bool _isEnabledPage = true;
        string _nombreCliente = string.Empty;
        List<Empresa> _surveys;

        #endregion

        #region Properties

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
        public string NombreCliente
        {
            get { return _nombreCliente; }
            set
            {
                _nombreCliente = value;
                OnPropertyChanged("NombreCliente");
            }
        }
        public List<Empresa> Surveys
        {
            get { return _surveys; }
            set
            {
                _surveys = value;
                OnPropertyChanged("Surveys");
            }
        }
        public List<Empresa> ListaSurveys { get; set; }


        #endregion

        #region Comands
        public Command BuscarClienteCommand
        {
            get
            {
                return new Command(() =>
                {
                    BuscarCliente();
                });
            }
        }

        
        #endregion

        #region Constructors
        public ListaClienteViewModel()
        {
            LoadPage();
        }
        #endregion

        #region Methods

        async void LoadPage()
        {
            try
            {
                this.Busy = true;
                this.IsEnabledPage = false;
                EmpresaB objEmpresaB = new EmpresaB();

                // Obtener clientes.
                Respuesta objRespuesta = await objEmpresaB.GET_API_Cliente("http://api.rimrepuestos.com/api/survey/data").ConfigureAwait(false);
                if (objRespuesta.Valido)
                {
                    Stream objStream = objRespuesta.Resultado as Stream;

                    // Leemos la respuesta stream.
                    using (StreamReader sr1 = new StreamReader(objStream))
                    using (JsonReader reader1 = new JsonTextReader(sr1))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        var generalRutas = serializer.Deserialize<RespuestaAPI>(reader1);
                        if (generalRutas != null)
                        {
                            this.ListaSurveys = generalRutas.data.surveys;
                            this.Surveys = generalRutas.data.surveys;
                        }
                    }
                }
                else
                {
                    // Other error has occurred.
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        this.Busy = false;
                        this.IsEnabled = true;
                        this.IsEnabledPage = true;
                        await Application.Current.MainPage.DisplayAlert(
                            "Error",
                            "Petición no valida, Ha ocurrido un error: " + objRespuesta.Mensaje,
                            "Aceptar");
                    });
                }
            }
            catch (Exception exc)
            {
                // Other error has occurred.
                Device.BeginInvokeOnMainThread(async () =>
                {
                    this.Busy = false;
                    this.IsEnabled = true;
                    this.IsEnabledPage = true;
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ha ocurrido un error: " + exc.Message,
                        "Aceptar");
                });
            }

            this.Busy = false;
            this.IsEnabled = true;
            this.IsEnabledPage = true;
        }

        async void BuscarCliente()
        {
            try
            {
                if (string.IsNullOrEmpty(this.NombreCliente))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Aviso",
                        "Por favor, ingrese el nombre de un cliente.",
                        "Aceptar");

                    return;
                }

                // Filtramos.
                List<Empresa> listaBusquedaCliente = this.ListaSurveys.Where(x => x.NombreComercial.ToLower().Contains(this.NombreCliente)).ToList();

                // Asignamos.
                this.Surveys = listaBusquedaCliente.OrderBy(x => x.NombreComercial).ToList();
            }
            catch (Exception exc)
            {
                this.Busy = false;
                this.IsEnabledPage = true;
                // Other error has occurred.
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
