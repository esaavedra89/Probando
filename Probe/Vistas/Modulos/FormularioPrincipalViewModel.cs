using Probe.Modelo;
using Probe.Modelo.Modulos.Sistema;
using Probe.Negocio.Modulos;
using Probe.Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Probe.Vistas.Modulos
{
    public class FormularioPrincipalViewModel : INotifyPropertyChanged
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
        bool _modoLectura = true;
        string _rif = string.Empty;
        string _razonSocial = string.Empty;
        string _nombreComercial = string.Empty;
        string _email1 = string.Empty;
        string _email2 = string.Empty;
        string _telefono1 = string.Empty;
        string _telefono2 = string.Empty;
        string _web = string.Empty;
        string _instagram = string.Empty;
        string _facebook = string.Empty;
        string _whatsappBusiness = string.Empty;
        string _direccion = string.Empty;
        string _parroquia = string.Empty;
        string _municipio = string.Empty;
        string _ciudad = string.Empty;
        string _codigoPostal = string.Empty;
        string _estado = string.Empty;
        decimal _latitud = 0;
        decimal _longitud = 0;

        string _numeroCliente = string.Empty;
        string _clienteEstado = string.Empty;
        string _prospecto = string.Empty;

        string _nombreContacto1 = string.Empty;
        string _apellidoContacto1 = string.Empty;
        string _email11 = string.Empty;
        string _email12 = string.Empty;
        string _telefono11 = string.Empty;
        string _telefono12 = string.Empty;
        string _instagram1 = string.Empty;
        string _facebook1 = string.Empty;
        string _hobbies1 = string.Empty;
        string _personaRelacionada1 = string.Empty;

        string _nombreContacto2 = string.Empty;
        string _apellidoContacto2 = string.Empty;
        string _email21 = string.Empty;
        string _email22 = string.Empty;
        string _telefono21 = string.Empty;
        string _telefono22 = string.Empty;
        string _instagram2 = string.Empty;
        string _facebook2 = string.Empty;
        string _hobbies2 = string.Empty;
        string _personaRelacionada2 = string.Empty;

        string _sectorComercial = string.Empty;

        string _mineral15w40 = string.Empty;
        string _mineral20w50 = string.Empty;
        string _semiSintetico15w40 = string.Empty;
        string _semiSintetico20w50 = string.Empty;
        string _dexronIII = string.Empty;
        string _motos4T = string.Empty;
        string _iSO80w90 = string.Empty;
        string _diesel50 = string.Empty;
        string _diesel15w40 = string.Empty;
        string _hidraulico68 = string.Empty;
        string _ligaFrenoDot3 = string.Empty;
        string _flushing;

        string _observaciones = string.Empty;
        DateTime _primeraVisitaSelected = DateTime.Today;
        DateTime _primeraCompraSelected = DateTime.Today;
        string _siguienteAccion = string.Empty;
        DateTime _siguienteAccionSelected = DateTime.Today;
        string _vendedorEncargado = string.Empty;
        List<Options> _listaEstadoCliente;
        Options _estadoClienteSeleccionada;
        List<Options> _listaSectorComercial;
        Options _sectorComercialSeleccionada;
        bool _isVisible1 = true;
        bool _isVisible2 = false;
        bool _isVisible3 = false;
        bool _isVisible4 = false;
        bool _isVisible5 = false;

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
        public bool ModoLectura
        {
            get { return _modoLectura; }
            set
            {
                _modoLectura = value;
                OnPropertyChanged("ModoLectura");
            }
        }
        public bool IsVisible1
        {
            get { return _isVisible1; }
            set
            {
                _isVisible1 = value;
                OnPropertyChanged("IsVisible1");
            }
        }
        public bool IsVisible2
        {
            get { return _isVisible2; }
            set
            {
                _isVisible2 = value;
                OnPropertyChanged("IsVisible2");
            }
        }
        public bool IsVisible3
        {
            get { return _isVisible3; }
            set
            {
                _isVisible3 = value;
                OnPropertyChanged("IsVisible3");
            }
        }
        public bool IsVisible4
        {
            get { return _isVisible4; }
            set
            {
                _isVisible4 = value;
                OnPropertyChanged("IsVisible4");
            }
        }
        public bool IsVisible5
        {
            get { return _isVisible5; }
            set
            {
                _isVisible5 = value;
                OnPropertyChanged("IsVisible5");
            }
        }

        #region Part1
        public string RIF
        {
            get { return _rif; }
            set
            {
                _rif = value;
                OnPropertyChanged("RIF");
            }
        }
        public string RazonSocial
        {
            get { return _razonSocial; }
            set
            {
                _razonSocial = value;
                OnPropertyChanged("RazonSocial");
            }
        }
        public string NombreComercial
        {
            get { return _nombreComercial; }
            set
            {
                _nombreComercial = value;
                OnPropertyChanged("NombreComercial");
            }
        }
        public string Email1
        {
            get { return _email1; }
            set
            {
                _email1 = value;
                OnPropertyChanged("Email1");
            }
        }
        public string Email2
        {
            get { return _email2; }
            set
            {
                _email2 = value;
                OnPropertyChanged("Email2");
            }
        }
        public string Telefono1
        {
            get { return _telefono1; }
            set
            {
                _telefono1 = value;
                OnPropertyChanged("Telefono1");
            }
        }
        public string Telefono2
        {
            get { return _telefono2; }
            set
            {
                _telefono2 = value;
                OnPropertyChanged("Telefono2");
            }
        }
        public string Web
        {
            get { return _web; }
            set
            {
                _web = value;
                OnPropertyChanged("Web");
            }
        }
        public string Instagram
        {
            get { return _instagram; }
            set
            {
                _instagram = value;
                OnPropertyChanged("Instagram");
            }
        }
        public string Facebook
        {
            get { return _facebook; }
            set
            {
                _facebook = value;
                OnPropertyChanged("Facebook");
            }
        }
        public string WhatsappBusiness
        {
            get { return _whatsappBusiness; }
            set
            {
                _whatsappBusiness = value;
                OnPropertyChanged("WhatsappBusiness");
            }
        }
        public string Direccion
        {
            get { return _direccion; }
            set
            {
                _direccion = value;
                OnPropertyChanged("Direccion");
            }
        }
        public string Parroquia
        {
            get { return _parroquia; }
            set
            {
                _parroquia = value;
                OnPropertyChanged("Parroquia");
            }
        }
        public string Municipio
        {
            get { return _municipio; }
            set
            {
                _municipio = value;
                OnPropertyChanged("Municipio");
            }
        }
        public string Ciudad
        {
            get { return _ciudad; }
            set
            {
                _ciudad = value;
                OnPropertyChanged("Ciudad");
            }
        }
        public string CodigoPostal
        {
            get { return _codigoPostal; }
            set
            {
                _codigoPostal = value;
                OnPropertyChanged("CodigoPostal");
            }
        }
        public string Estado
        {
            get { return _estado; }
            set
            {
                _estado = value;
                OnPropertyChanged("Estado");
            }
        }
        public decimal Latitud
        {
            get { return _latitud; }
            set
            {
                _latitud = value;
                OnPropertyChanged("Latitud");
            }
        }
        public decimal Longitud
        {
            get { return _longitud; }
            set
            {
                _longitud = value;
                OnPropertyChanged("Longitud");
            }
        }
        
        #endregion

        #region Estado

        public string NumeroCliente
        {
            get { return _numeroCliente; }
            set
            {
                _numeroCliente = value;
                OnPropertyChanged("NumeroCliente");
            }
        }
        public string ClienteEstado
        {
            get { return _clienteEstado; }
            set
            {
                _clienteEstado = value;
                OnPropertyChanged("ClienteEstado");
            }
        }
        public string Prospecto
        {
            get { return _prospecto; }
            set
            {
                _prospecto = value;
                OnPropertyChanged("Prospecto");
            }
        }
        public List<Options> ListaEstadoCliente
        {
            get { return _listaEstadoCliente; }
            set
            {
                _listaEstadoCliente = value;
                OnPropertyChanged("ListaEstadoCliente");
            }
        }
        public Options EstadoClienteSeleccionada
        {
            get { return _estadoClienteSeleccionada; }
            set
            {
                _estadoClienteSeleccionada = value;
                OnPropertyChanged("EstadoClienteSeleccionada");
            }
        }
        public List<Options> ListaSectorComercial
        {
            get { return _listaSectorComercial; }
            set
            {
                _listaSectorComercial = value;
                OnPropertyChanged("ListaSectorComercial");
            }
        }
        public Options SectorComercialSeleccionada
        {
            get { return _sectorComercialSeleccionada; }
            set
            {
                _sectorComercialSeleccionada = value;
                OnPropertyChanged("SectorComercialSeleccionada");
            }
        }

        #endregion

        #region Contato #1

        public string NombreContacto1
        {
            get { return _nombreContacto1; }
            set
            {
                _nombreContacto1 = value;
                OnPropertyChanged("NombreContacto1");
            }
        }
        public string ApellidoContacto1
        {
            get { return _apellidoContacto1; }
            set
            {
                _apellidoContacto1 = value;
                OnPropertyChanged("ApellidoContacto1");
            }
        }
        public string Email11
        {
            get { return _email11; }
            set
            {
                _email11 = value;
                OnPropertyChanged("Email11");
            }
        }
        public string Email12
        {
            get { return _email12; }
            set
            {
                _email12 = value;
                OnPropertyChanged("Email12");
            }
        }
        public string Telefono11
        {
            get { return _telefono11; }
            set
            {
                _telefono11 = value;
                OnPropertyChanged("Telefono11");
            }
        }
        public string Telefono12
        {
            get { return _telefono12; }
            set
            {
                _telefono12 = value;
                OnPropertyChanged("Telefono12");
            }
        }
        public string Instagram1
        {
            get { return _instagram1; }
            set
            {
                _instagram1 = value;
                OnPropertyChanged("Instagram1");
            }
        }
        public string Facebook1
        {
            get { return _facebook1; }
            set
            {
                _facebook1 = value;
                OnPropertyChanged("Facebook1");
            }
        }
        public string Hobbies1
        {
            get { return _hobbies1; }
            set
            {
                _hobbies1 = value;
                OnPropertyChanged("Hobbies1");
            }
        }
        public string PersonaRelacionada1
        {
            get { return _personaRelacionada1; }
            set
            {
                _personaRelacionada1 = value;
                OnPropertyChanged("PersonaRelacionada1");
            }
        }
        #endregion

        #region Contato #2

        public string NombreContacto2
        {
            get { return _nombreContacto2; }
            set
            {
                _nombreContacto2 = value;
                OnPropertyChanged("NombreContacto2");
            }
        }
        public string ApellidoContacto2
        {
            get { return _apellidoContacto2; }
            set
            {
                _apellidoContacto2 = value;
                OnPropertyChanged("ApellidoContacto2");
            }
        }
        public string Email21
        {
            get { return _email21; }
            set
            {
                _email21 = value;
                OnPropertyChanged("Email21");
            }
        }
        public string Email22
        {
            get { return _email22; }
            set
            {
                _email22 = value;
                OnPropertyChanged("Email22");
            }
        }
        public string Telefono21
        {
            get { return _telefono21; }
            set
            {
                _telefono21 = value;
                OnPropertyChanged("Telefono21");
            }
        }
        public string Telefono22
        {
            get { return _telefono22; }
            set
            {
                _telefono22 = value;
                OnPropertyChanged("Telefono22");
            }
        }
        public string Instagram2
        {
            get { return _instagram2; }
            set
            {
                _instagram2 = value;
                OnPropertyChanged("Instagram2");
            }
        }
        public string Facebook2
        {
            get { return _facebook2; }
            set
            {
                _facebook2 = value;
                OnPropertyChanged("Facebook2");
            }
        }
        public string Hobbies2
        {
            get { return _hobbies2; }
            set
            {
                _hobbies2 = value;
                OnPropertyChanged("Hobbies2");
            }
        }
        public string PersonaRelacionada2
        {
            get { return _personaRelacionada2; }
            set
            {
                _personaRelacionada2 = value;
                OnPropertyChanged("PersonaRelacionada2");
            }
        }
        #endregion

        public string SectorComercial
        {
            get { return _sectorComercial; }
            set
            {
                _sectorComercial = value;
                OnPropertyChanged("SectorComercial");
            }
        }

        #region Consumo
        public string Mineral15w40
        {
            get { return _mineral15w40; }
            set
            {
                _mineral15w40 = value;
                OnPropertyChanged("Mineral15w40");
            }
        }
        public string Mineral20w50
        {
            get { return _mineral20w50; }
            set
            {
                _mineral20w50 = value;
                OnPropertyChanged("Mineral20w50");
            }
        }
        public string SemiSintetico15w40
        {
            get { return _semiSintetico15w40; }
            set
            {
                _semiSintetico15w40 = value;
                OnPropertyChanged("SemiSintetico15w40");
            }
        }
        public string SemiSintetico20w50
        {
            get { return _semiSintetico20w50; }
            set
            {
                _semiSintetico20w50 = value;
                OnPropertyChanged("SemiSintetico20w50");
            }
        }
        public string DexronIII
        {
            get { return _dexronIII; }
            set
            {
                _dexronIII = value;
                OnPropertyChanged("DexronIII");
            }
        }
        public string Motos4T
        {
            get { return _motos4T; }
            set
            {
                _motos4T = value;
                OnPropertyChanged("Motos4T");
            }
        }
        public string ISO80w90
        {
            get { return _iSO80w90; }
            set
            {
                _iSO80w90 = value;
                OnPropertyChanged("ISO80w90");
            }
        }
        public string Diesel50
        {
            get { return _diesel50; }
            set
            {
                _diesel50 = value;
                OnPropertyChanged("Diesel50");
            }
        }
        public string Diesel15w40
        {
            get { return _diesel15w40; }
            set
            {
                _diesel15w40 = value;
                OnPropertyChanged("Diesel15w40");
            }
        }
        public string Hidraulico68
        {
            get { return _hidraulico68; }
            set
            {
                _hidraulico68 = value;
                OnPropertyChanged("Hidraulico68");
            }
        }
        public string LigaFrenoDot3
        {
            get { return _ligaFrenoDot3; }
            set
            {
                _ligaFrenoDot3 = value;
                OnPropertyChanged("LigaFrenoDot3");
            }
        }
        public string Flushing
        {
            get { return _flushing; }
            set
            {
                _flushing = value;
                OnPropertyChanged("Flushing");
            }
        }
        #endregion

        public string Observaciones
        {
            get { return _observaciones; }
            set
            {
                _observaciones = value;
                OnPropertyChanged("Observaciones");
            }
        }
        public DateTime PrimeraVisitaSelected
        {
            get { return _primeraVisitaSelected; }
            set
            {
                _primeraVisitaSelected = value;
                OnPropertyChanged("PrimeraVisitaSelected");
            }
        }
        public DateTime PrimeraCompraSelected
        {
            get { return _primeraCompraSelected; }
            set
            {
                _primeraCompraSelected = value;
                OnPropertyChanged("PrimeraCompraSelected");
            }
        }
        public string SiguienteAccion
        {
            get { return _siguienteAccion; }
            set
            {
                _siguienteAccion = value;
                OnPropertyChanged("SiguienteAccion");
            }
        }
        public DateTime SiguienteAccionSelected
        {
            get { return _siguienteAccionSelected; }
            set
            {
                _siguienteAccionSelected = value;
                OnPropertyChanged("SiguienteAccionSelected");
            }
        }
        public string VendedorEncargado
        {
            get { return _vendedorEncargado; }
            set
            {
                _vendedorEncargado = value;
                OnPropertyChanged("VendedorEncargado");
            }
        }

        public Empresa ObjVendedor { get; set; }

        #endregion

        #region Comandos

        public Command AcualizarCommand
        {
            get
            {
                return new Command(async () =>
                {
                    this.Busy = true;
                    this.IsEnabledPage = false;
                    await Validar().ConfigureAwait(false);
                    this.Busy = false;
                    this.IsEnabledPage = true;
                });
            }
        }
        public Command ObtenerUbicacionCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await ObtenerUbicacion().ConfigureAwait(false);
                });
            }
        }
        public Command IsVisible1Command
        {
            get
            {
                return new Command(() =>
                {
                    Pestanas(1);
                });
            }
        }
        public Command IsVisible2Command
        {
            get
            {
                return new Command(() =>
                {
                    Pestanas(2);
                });
            }
        }
        public Command IsVisible3Command
        {
            get
            {
                return new Command(() =>
                {
                    Pestanas(3);
                });
            }
        }
        public Command IsVisible4Command
        {
            get
            {
                return new Command(() =>
                {
                    Pestanas(4);
                });
            }
        }
        public Command IsVisible5Command
        {
            get
            {
                return new Command(() =>
                {
                    Pestanas(5);
                });
            }
        }

        public Command EnviarEmail1Command
        {
            get
            {
                return new Command(() =>
                {
                    ValidarEmail(1);
                });
            }
        }
        public Command EnviarEmail2Command
        {
            get
            {
                return new Command(() =>
                {
                    ValidarEmail(2);
                });
            }
        }
        public Command LlamarTelefono1Command
        {
            get
            {
                return new Command(() =>
                {
                    LlamarNumero(this.Telefono1);
                });
            }
        }
        public Command LlamarTelefono2Command
        {
            get
            {
                return new Command(() =>
                {
                    LlamarNumero(this.Telefono2);
                });
            }
        }
        public Command OpenMapCommand
        {
            get
            {
                return new Command(() =>
                {
                    OpenMap();
                });
            }
        }
        
        #endregion

        #region Constructores

        public FormularioPrincipalViewModel()
        {
            //LlenarCampos();
            PageLoad();
        }

        public FormularioPrincipalViewModel(Empresa objVendedor)
        {
            this.ModoLectura = false;

            this.ObjVendedor = objVendedor;

            LoadData();
        }

        #endregion

        #region Metodos

        private void LoadData()
        {
            try
            {
                CargarListas();

                this.RIF = this.ObjVendedor.RIF;
                this.RazonSocial = this.ObjVendedor.RazonSocial;
                this.NombreComercial = this.ObjVendedor.NombreComercial;
                this.Email1 = this.ObjVendedor.Email1;
                this.Email2 = this.ObjVendedor.Email2;
                this.Telefono1 = this.ObjVendedor.Telefono1;
                this.Telefono2 = this.ObjVendedor.Telefono2;
                this.Latitud = this.ObjVendedor.position.lat;
                this.Longitud = this.ObjVendedor.position.lng;
                this.Web = this.ObjVendedor.SitioWeb;
                this.Instagram = this.ObjVendedor.Instagram;
                this.Facebook = this.ObjVendedor.Facebook;
                this.WhatsappBusiness = this.ObjVendedor.WhatsappBusiness;
                this.Direccion = this.ObjVendedor.Direccion;
                this.Parroquia = this.ObjVendedor.Parroquia;
                this.Municipio = this.ObjVendedor.Municipio;
                this.Ciudad = this.ObjVendedor.Ciudad;
                this.CodigoPostal =this.ObjVendedor.CodigoPostal;
                this.Estado = this.ObjVendedor.Estado;

                this.EstadoClienteSeleccionada = this.ListaEstadoCliente.Find(x => x.Name == this.ObjVendedor.NombreEstadoCliente);

                this.SectorComercialSeleccionada = this.ListaSectorComercial.Find(x => x.Name == this.ObjVendedor.SectorComercial);

                this.Observaciones = this.ObjVendedor.Observaciones;
                this.PrimeraVisitaSelected = this.ObjVendedor.FechaPrimeraVisita;
                this.PrimeraCompraSelected = this.ObjVendedor.FechaPrimeraCompra;
                this.SiguienteAccion = this.ObjVendedor.SiguienteAccion;
                this.SiguienteAccionSelected = this.ObjVendedor.FechaSiguienteAccion;

                this.NombreContacto1 = this.ObjVendedor.contacts.contact_1.NombreContacto1;
                this.ApellidoContacto1 = this.ObjVendedor.contacts.contact_1.ApellidoContacto1;
                this.Email11 = this.ObjVendedor.contacts.contact_1.Email11;
                this.Email12 = this.ObjVendedor.contacts.contact_1.Email12;
                this.Telefono11 = this.ObjVendedor.contacts.contact_1.Telefono11;
                this.Telefono12 = this.ObjVendedor.contacts.contact_1.Telefono12;
                this.Instagram1 = this.ObjVendedor.contacts.contact_1.Instagram1;
                this.Facebook1 = this.ObjVendedor.contacts.contact_1.Facebook1;
                this.Hobbies1 = this.ObjVendedor.contacts.contact_1.Hobbies1;
                this.PersonaRelacionada1 = this.ObjVendedor.contacts.contact_1.PersonaRelacionada1;

                this.NombreContacto2 = this.ObjVendedor.contacts.contact_2.NombreContacto2;
                this.ApellidoContacto2 = this.ObjVendedor.contacts.contact_2.ApellidoContacto2;
                this.Email21 = this.ObjVendedor.contacts.contact_2.Email21;
                this.Email22 = this.ObjVendedor.contacts.contact_2.Email22;
                this.Telefono21 = this.ObjVendedor.contacts.contact_2.Telefono21;
                this.Telefono22 = this.ObjVendedor.contacts.contact_2.Telefono22;
                this.Instagram2 = this.ObjVendedor.contacts.contact_2.Instagram2;
                this.Facebook2 = this.ObjVendedor.contacts.contact_2.Facebook12;
                this.Hobbies2 = this.ObjVendedor.contacts.contact_2.Hobbies2;
                this.PersonaRelacionada2 = this.ObjVendedor.contacts.contact_2.PersonaRelacionada2;

                this.Mineral15w40 = this.ObjVendedor.Consumo.Mineral15w40.ToString();
                this.Mineral20w50 = this.ObjVendedor.Consumo.Mineral20w50.ToString();
                this.SemiSintetico15w40 = this.ObjVendedor.Consumo.SemiSintetico15w40.ToString();
                this.SemiSintetico20w50 = this.ObjVendedor.Consumo.SemiSintetico20w50.ToString();
                this.DexronIII = this.ObjVendedor.Consumo.DexronIII.ToString();
                this.Motos4T = this.ObjVendedor.Consumo.Motos4t.ToString();
                this.ISO80w90 = this.ObjVendedor.Consumo.ISO80w90.ToString();
                this.Diesel50 = this.ObjVendedor.Consumo.Diesel50.ToString();
                this.Diesel15w40 = this.ObjVendedor.Consumo.Diesel15w40.ToString();
                this.Hidraulico68 = this.ObjVendedor.Consumo.Hidraulico68.ToString();
                this.LigaFrenoDot3 = this.ObjVendedor.Consumo.LigaFrenoDot3.ToString();
                this.Flushing = this.ObjVendedor.Consumo.Flushing.ToString();
            }
            catch (Exception exc)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ha ocurrido un error: " + exc.Message,
                        "Aceptar");
                    // Mostramos mensaje.
                });
            }
        }

        void PageLoad()
        {
            try
            {
                CargarListas();
            }
            catch (Exception exc)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ha ocurrido un error: " + exc.Message,
                        "Aceptar");
                    // Mostramos mensaje.
                });
            }
        }

        void CargarListas()
        {
            try
            {
                this.ListaEstadoCliente = new List<Options>();
                this.ListaEstadoCliente.Add(new Options
                {
                    Index = 1,
                    Name = "Prospecto"
                });
                this.ListaEstadoCliente.Add(new Options
                {
                    Index = 2,
                    Name = "Cliente"
                });
                this.ListaEstadoCliente.Add(new Options
                {
                    Index = 3,
                    Name = "Ex-Cliente"
                });

                // Sector Comercial.
                this.ListaSectorComercial = new List<Options>();
                this.ListaSectorComercial.Add(new Options
                {
                    Index = 1,
                    Name = "Tienda de Repuestos"
                });
                this.ListaSectorComercial.Add(new Options
                {
                    Index = 2,
                    Name = "Tienda de Consumibles"
                });
                this.ListaSectorComercial.Add(new Options
                {
                    Index = 3,
                    Name = "Tienda de Autoperiquitos"
                });
                this.ListaSectorComercial.Add(new Options
                {
                    Index = 4,
                    Name = "Venta Informal"
                });
                this.ListaSectorComercial.Add(new Options
                {
                    Index = 5,
                    Name = "Distribuidor/Revendedor"
                });
                this.ListaSectorComercial.Add(new Options
                {
                    Index = 6,
                    Name = "Concesionario"
                });
                this.ListaSectorComercial.Add(new Options
                {
                    Index = 7,
                    Name = "Transporte"
                });
                this.ListaSectorComercial.Add(new Options
                {
                    Index = 8,
                    Name = "Industria Manufactura"
                });
                this.ListaSectorComercial.Add(new Options
                {
                    Index = 9,
                    Name = "Industria Azúcar"
                });
                this.ListaSectorComercial.Add(new Options
                {
                    Index = 10,
                    Name = "Industria Minería"
                });
                this.ListaSectorComercial.Add(new Options
                {
                    Index = 11,
                    Name = "Productor Agrícola"
                });
                this.ListaSectorComercial.Add(new Options
                {
                    Index = 12,
                    Name = "Industria Petrolera"
                });
                this.ListaSectorComercial.Add(new Options
                {
                    Index = 13,
                    Name = "Otros"
                });
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        async Task Validar()
        {
            try
            {
                if (string.IsNullOrEmpty(this.RIF))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Aviso",
                        "Por favor, ingrese el RIF.",
                        "Aceptar");

                    return;
                }

                if (string.IsNullOrEmpty(this.RazonSocial))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Aviso",
                        "Por favor, ingrese la razón social.",
                        "Aceptar");

                    return;
                }

                if (string.IsNullOrEmpty(this.NombreComercial))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Aviso",
                        "Por favor, ingrese el nombre comercial.",
                        "Aceptar");

                    return;
                }

                if (string.IsNullOrEmpty(this.Telefono1))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Aviso",
                        "Por favor, ingrese el número telefónico #1.",
                        "Aceptar");

                    return;
                }

                if (string.IsNullOrEmpty(this.Telefono2))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Aviso",
                        "Por favor, ingrese el número telefónico #2.",
                        "Aceptar");

                    return;
                }

                if (string.IsNullOrEmpty(this.Direccion))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Aviso",
                        "Por favor, ingrese la dirección.",
                        "Aceptar");

                    return;
                }

                if (string.IsNullOrEmpty(this.Ciudad))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Aviso",
                        "Por favor, ingrese la ciudad.",
                        "Aceptar");

                    return;
                }

                if (Latitud == 0 && Longitud == 0)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Aviso",
                        "Debe obtener la ubicación.",
                        "Aceptar");

                    return;
                }

                Utilitarios objUtilitarios = new Utilitarios();

                if (!string.IsNullOrEmpty(Email1) && !objUtilitarios.IsValidEmail(Email1))
                {
                    this.Busy = false;
                    this.IsEnabledPage = true;
                    await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Correo electrónico #1 no tiene formato valido.",
                    "Aceptar");
                }

                if (!string.IsNullOrEmpty(Email2) && !objUtilitarios.IsValidEmail(Email2))
                {
                    this.Busy = false;
                    this.IsEnabledPage = true;
                    await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Correo electrónico #2 no tiene formato valido.",
                    "Aceptar");
                }

                if (!string.IsNullOrEmpty(Email11) && !objUtilitarios.IsValidEmail(Email11))
                {
                    this.Busy = false;
                    this.IsEnabledPage = true;
                    await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Correo electrónico #1 de sección Contacto #1 no tiene formato valido.",
                    "Aceptar");
                }

                if (!string.IsNullOrEmpty(Email12) && !objUtilitarios.IsValidEmail(Email12))
                {
                    this.Busy = false;
                    this.IsEnabledPage = true;
                    await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Correo electrónico #2 de sección Contacto #1 no tiene formato valido.",
                    "Aceptar");
                }

                if (!string.IsNullOrEmpty(Email21) && !objUtilitarios.IsValidEmail(Email21))
                {
                    this.Busy = false;
                    this.IsEnabledPage = true;
                    await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Correo electrónico #1 de sección Contacto #2 no tiene formato valido.",
                    "Aceptar");
                }

                if (!string.IsNullOrEmpty(Email22) && !objUtilitarios.IsValidEmail(Email22))
                {
                    this.Busy = false;
                    this.IsEnabledPage = true;
                    await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Correo electrónico #2 de sección Contacto #2 no tiene formato valido.",
                    "Aceptar");
                }

                await Escanear().ConfigureAwait(false);
            }
            catch (Exception exc)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ha ocurrido un error: " + exc.Message,
                        "Aceptar");
                    // Mostramos mensaje.
                });
            }
        }

        async Task Escanear()
        {
            try
            {
                // Instanciamos.
                EngineData engineData = EngineData.Instance();

                Empresa objEmpresa = new Empresa();
                objEmpresa.IdEmpresa = 1;
                objEmpresa.IdVendedor = engineData.IdVendedor;
                objEmpresa.RIF = this.RIF;
                objEmpresa.RazonSocial = this.RazonSocial;
                objEmpresa.NombreComercial = this.NombreComercial;
                objEmpresa.Email1 = this.Email1;
                objEmpresa.Email2 = this.Email2;
                objEmpresa.Telefono1 = this.Telefono1;
                objEmpresa.Telefono2 = this.Telefono2;
                objEmpresa.SitioWeb = this.Web;
                objEmpresa.Instagram = this.Instagram;
                objEmpresa.Facebook = this.Facebook;
                objEmpresa.WhatsappBusiness = this.WhatsappBusiness;
                objEmpresa.Direccion = this.Direccion;
                objEmpresa.Parroquia = this.Parroquia;
                objEmpresa.Municipio = this.Municipio;
                objEmpresa.Ciudad = this.Ciudad;
                objEmpresa.CodigoPostal = this.CodigoPostal;
                objEmpresa.Estado = this.Estado;
                //objEmpresa.Latitud = this.Latitud;
                //objEmpresa.Longitud = this.Longitud;
                objEmpresa.position = new position();
                objEmpresa.position.lat = this.Latitud;
                objEmpresa.position.lng = this.Longitud;
                objEmpresa.IdEstadoCliente = (this.EstadoClienteSeleccionada != null ? this.EstadoClienteSeleccionada.Index : 0);
                objEmpresa.NombreEstadoCliente = (this.EstadoClienteSeleccionada != null ? this.EstadoClienteSeleccionada.Name : "");

                // Estado.
                //objEmpresa.EstadoObjeto = new Estado();
                //objEmpresa.EstadoObjeto.NumeroCliente = Convert.ToInt32(this.NumeroCliente);
                //objEmpresa.EstadoObjeto.Cliente = this.ClienteEstado;
                //objEmpresa.EstadoObjeto.Prospecto = this.Prospecto;

                // Contacto #1.
                objEmpresa.contacts = new Contacts();
                objEmpresa.contacts.contact_1 = new Contacto1();
                objEmpresa.contacts.contact_1.NombreContacto1 = this.NombreContacto1;
                objEmpresa.contacts.contact_1.ApellidoContacto1 = this.ApellidoContacto1;
                objEmpresa.contacts.contact_1.Email11 = this.Email11;
                objEmpresa.contacts.contact_1.Email12 = this.Email12;
                objEmpresa.contacts.contact_1.Telefono11 = this.Telefono11;
                objEmpresa.contacts.contact_1.Telefono12 = this.Telefono12;
                objEmpresa.contacts.contact_1.Instagram1 = this.Instagram1;
                objEmpresa.contacts.contact_1.Facebook1 = this.Facebook1;
                objEmpresa.contacts.contact_1.Hobbies1 = this.Hobbies1;
                objEmpresa.contacts.contact_1.PersonaRelacionada1 = this.PersonaRelacionada1;

                // Contacto #2.
                objEmpresa.contacts.contact_2 = new Contacto2();
                objEmpresa.contacts.contact_2.NombreContacto2 = this.NombreContacto2;
                objEmpresa.contacts.contact_2.ApellidoContacto2 = this.ApellidoContacto2;
                objEmpresa.contacts.contact_2.Email21 = this.Email21;
                objEmpresa.contacts.contact_2.Email22 = this.Email22;
                objEmpresa.contacts.contact_2.Telefono21 = this.Telefono21;
                objEmpresa.contacts.contact_2.Telefono22 = this.Telefono22;
                objEmpresa.contacts.contact_2.Instagram2 = this.Instagram2;
                objEmpresa.contacts.contact_2.Facebook12 = this.Facebook2;
                objEmpresa.contacts.contact_2.Hobbies2 = this.Hobbies2;
                objEmpresa.contacts.contact_2.PersonaRelacionada2 = this.PersonaRelacionada2;

                objEmpresa.IdSectorComercial = (this.SectorComercialSeleccionada != null ? this.SectorComercialSeleccionada.Index : 0);
                objEmpresa.SectorComercial = (this.SectorComercialSeleccionada != null ? this.SectorComercialSeleccionada.Name : "");

                // Consumo mensual aproximado en litros.
                objEmpresa.Consumo = new Consumo();
                objEmpresa.Consumo.Mineral15w40 = Convert.ToDecimal(this.Mineral15w40);
                objEmpresa.Consumo.Mineral20w50 = Convert.ToDecimal(this.Mineral20w50);
                objEmpresa.Consumo.SemiSintetico15w40 = Convert.ToDecimal(this.SemiSintetico15w40);
                objEmpresa.Consumo.SemiSintetico20w50 = Convert.ToDecimal(this.SemiSintetico20w50);
                objEmpresa.Consumo.DexronIII = Convert.ToDecimal(this.DexronIII);
                objEmpresa.Consumo.Motos4t = Convert.ToDecimal(this.Motos4T);
                objEmpresa.Consumo.ISO80w90 = Convert.ToDecimal(this.ISO80w90);
                objEmpresa.Consumo.Diesel50 = Convert.ToDecimal(this.Diesel50);
                objEmpresa.Consumo.Diesel15w40 = Convert.ToDecimal(this.Diesel15w40);
                objEmpresa.Consumo.Hidraulico68 = Convert.ToDecimal(this.Hidraulico68);
                objEmpresa.Consumo.LigaFrenoDot3 = Convert.ToDecimal(this.LigaFrenoDot3);
                objEmpresa.Consumo.Flushing = Convert.ToDecimal(this.Flushing);

                objEmpresa.Observaciones = this.Observaciones;
                objEmpresa.FechaPrimeraVisita = this.PrimeraVisitaSelected;
                objEmpresa.FechaPrimeraCompra = this.PrimeraCompraSelected;
                objEmpresa.SiguienteAccion = this.SiguienteAccion;
                objEmpresa.FechaSiguienteAccion = this.SiguienteAccionSelected;
                objEmpresa.VendedorEncargado = engineData.User;

                EmpresaB objEmpresaB = new EmpresaB();

                Respuesta peticionApi = await objEmpresaB.GuardarAPI(objEmpresa).ConfigureAwait(false);
                if (peticionApi.Valido)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert(
                            "Exitos",
                            "Guardado exitosamente",
                            "Aceptar");

                        LimpiarCampos();
                    });

                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ha ocurrido un error en la petición: " + peticionApi.Mensaje,
                        "Aceptar");
                    });
                }
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

        async Task<Location> ObtenerUbicacion()
        {
            Location locacion = new Location();

            try
            {
                locacion = await Geolocation.GetLocationAsync(new GeolocationRequest()
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });
                if (locacion == null)
                {
                    throw new Exception("GPS apagado");
                }
                else
                {
                    this.Latitud = Convert.ToDecimal(locacion.Latitude);
                    this.Longitud = Convert.ToDecimal(locacion.Longitude);
                }
            }
            catch (Xamarin.Essentials.FeatureNotEnabledException)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Aviso",
                        "GPS apagado",
                        "Aceptar");
                    // Mostramos mensaje.
                });
            }
            catch (Exception exc)
            {
                throw exc;
            }

            return locacion;
        }

        void LimpiarCampos()
        {
            try
            {
                this.RIF = string.Empty;
                this.RazonSocial = string.Empty;
                this.NombreComercial = string.Empty;
                this.Email1 = string.Empty;
                this.Email2 = string.Empty;
                this.Telefono1 = string.Empty;
                this.Telefono2 = string.Empty;
                this.Web = string.Empty;
                this.Instagram = string.Empty;
                this.Facebook = string.Empty;
                this.WhatsappBusiness = string.Empty;
                this.Direccion = string.Empty;
                this.Parroquia = string.Empty;
                this.Municipio = string.Empty;
                this.Ciudad = string.Empty;
                this.CodigoPostal = string.Empty;
                this.Estado = string.Empty;
                this.Latitud = 0;
                this.Longitud = 0;

                // Estado.
                this.NumeroCliente = string.Empty;
                this.ClienteEstado = string.Empty;
                this.Prospecto = string.Empty;

                // Contacto #1.

                this.Email11 = string.Empty;
                this.Email12 = string.Empty;
                this.Telefono11 = string.Empty;
                this.Telefono12 = string.Empty;
                this.Instagram1 = string.Empty;
                this.Facebook1 = string.Empty;
                this.Hobbies1 = string.Empty;
                this.PersonaRelacionada1 = string.Empty;

                // Contacto #2.

                this.Email21 = string.Empty;
                this.Email22 = string.Empty;
                this.Telefono21 = string.Empty;
                this.Telefono22 = string.Empty;
                this.Instagram2 = string.Empty;
                this.Facebook2 = string.Empty;
                this.Hobbies2 = string.Empty;
                this.PersonaRelacionada2 = string.Empty;

                this.SectorComercial = string.Empty;

                // Consumo mensual aproximado en litros.

                this.Mineral15w40 = string.Empty;
                this.Mineral20w50 = string.Empty;
                this.SemiSintetico15w40 = string.Empty;
                this.SemiSintetico20w50 = string.Empty;
                this.DexronIII = string.Empty;
                this.Motos4T = string.Empty;
                this.ISO80w90 = string.Empty;
                this.Diesel50 = string.Empty;
                this.Diesel15w40 = string.Empty;
                this.Hidraulico68 = string.Empty;
                this.LigaFrenoDot3 = string.Empty;
                this.Flushing = string.Empty;

                this.Observaciones = string.Empty;
                this.PrimeraVisitaSelected = DateTime.Today;
                this.PrimeraCompraSelected = DateTime.Today;
                this.SiguienteAccion = string.Empty;
                this.SiguienteAccionSelected = DateTime.Today;
                this.VendedorEncargado = string.Empty;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        void LlenarCampos()
        {
            try
            {
                this.RIF = "J-12345678";
                this.RazonSocial = "AirDrop SA";
                this.NombreComercial = "AirDrop SA";
                this.Email1 = "AirDropSA@gm.com";
                this.Email2 = "AirDropSA2@gm.com";
                this.Telefono1 = "04128577485";
                this.Telefono2 = "04128577486";
                this.Web = "www.intent.com";
                this.Instagram = "AirDrop89";
                this.Facebook = "Air Drop";
                this.WhatsappBusiness = "584155142536";
                this.Direccion = "Sector Costo Arriba";
                this.Parroquia = "San Simón";
                this.Municipio = "Los Godos";
                this.Ciudad = "Caracas";
                this.CodigoPostal = "8974";
                this.Estado = "Acarigua";
                this.Latitud = 0;
                this.Longitud = 0;

                // Estado.
                this.NumeroCliente = "123456";
                this.ClienteEstado = "Activo";
                this.Prospecto = "Si";

                // Contacto #1.

                this.Email11 = "AirDropS123A@gm.com";
                this.Email12 = "AirDropSA456@gm.com";
                this.Telefono11 = "417523631";
                this.Telefono12 = "04121874585";
                this.Instagram1 = string.Empty;
                this.Facebook1 = string.Empty;
                this.Hobbies1 = "Caza y la pesca";
                this.PersonaRelacionada1 = string.Empty;

                // Contacto #2.

                this.Email21 = "AirDropSA789@gm.com";
                this.Email22 = string.Empty;
                this.Telefono21 = "04268547485";
                this.Telefono22 = string.Empty;
                this.Instagram2 = string.Empty;
                this.Facebook2 = string.Empty;
                this.Hobbies2 = string.Empty;
                this.PersonaRelacionada2 = "Maria Romero";

                this.SectorComercial = "Mineria";

                // Consumo mensual aproximado en litros.

                this.Mineral15w40 = "5";
                this.Mineral20w50 = "86";
                this.SemiSintetico15w40 = "0";
                this.SemiSintetico20w50 = "85";
                this.DexronIII = "0";
                this.Motos4T = "4";
                this.ISO80w90 = "56";
                this.Diesel50 = "4";
                this.Diesel15w40 = "8";
                this.Hidraulico68 = "45";
                this.LigaFrenoDot3 = "84";
                this.Flushing = "47";

                this.Observaciones = "Observaciones";
                this.PrimeraVisitaSelected = DateTime.Today;
                this.PrimeraCompraSelected = DateTime.Today;
                this.SiguienteAccion = "Vender";
                this.SiguienteAccionSelected = DateTime.Today;
                this.VendedorEncargado = "Rafael Sanchez";
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        void Pestanas(int num) 
        {
            try
            {
                switch (num)
                {
                    case 1:
                        this.IsVisible1 = true;
                        this.IsVisible2 = false;
                        this.IsVisible3 = false;
                        this.IsVisible4 = false;
                        this.IsVisible5 = false;
                        break;
                    case 2:
                        this.IsVisible1 = false;
                        this.IsVisible2 = true;
                        this.IsVisible3 = false;
                        this.IsVisible4 = false;
                        this.IsVisible5 = false;
                        break;
                    case 3:
                        this.IsVisible1 = false;
                        this.IsVisible2 = false;
                        this.IsVisible3 = true;
                        this.IsVisible4 = false;
                        this.IsVisible5 = false;
                        break;
                    case 4:
                        this.IsVisible1 = false;
                        this.IsVisible2 = false;
                        this.IsVisible3 = false;
                        this.IsVisible4 = true;
                        this.IsVisible5 = false;
                        break;
                    case 5:
                        this.IsVisible1 = false;
                        this.IsVisible2 = false;
                        this.IsVisible3 = false;
                        this.IsVisible4 = false;
                        this.IsVisible5 = true;
                        break;

                    default:
                        this.IsVisible1 = true;
                        this.IsVisible2 = false;
                        this.IsVisible3 = false;
                        this.IsVisible4 = false;
                        this.IsVisible5 = false;
                        break;
                }
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

        async void ValidarEmail(int email) 
        {
            try
            {
                Utilitarios objUtilitarios = new Utilitarios();
                if (email == 1)
                {
                    if (string.IsNullOrEmpty(Email1))
                    {
                        this.Busy = false;
                        this.IsEnabledPage = true;
                        await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese un correo electrónico",
                        "Aceptar");

                        return;
                    }

                    if (!string.IsNullOrEmpty(Email1) && !objUtilitarios.IsValidEmail(Email1))
                    {
                        this.Busy = false;
                        this.IsEnabledPage = true;
                        await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Correo electrónico #1 no tiene formato valido.",
                        "Aceptar");

                        return;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(Email2))
                    {
                        this.Busy = false;
                        this.IsEnabledPage = true;
                        await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese un correo electrónico",
                        "Aceptar");

                        return;
                    }

                    if (!string.IsNullOrEmpty(Email2) && !objUtilitarios.IsValidEmail(Email2))
                    {
                        this.Busy = false;
                        this.IsEnabledPage = true;
                        await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Correo electrónico #2 no tiene formato valido.",
                        "Aceptar");

                        return;
                    }
                }

                // Enviar correo.
                EnviarEmail(email);
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

        async void EnviarEmail(int email) 
        {
            try
            {
                List<string> listaCorreos = new List<string>();
                if (email == 1)
                    listaCorreos.Add(this.Email1);
                else
                    listaCorreos.Add(this.Email2);

                var message = new EmailMessage
                {
                    Subject = "",
                    Body = "",
                    To= listaCorreos
                };
                await Email.ComposeAsync(message);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void LlamarNumero(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException)
            {
                // Number was null or white space.
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese un número telefónico",
                        "Aceptar");
                });
            }
            catch (FeatureNotSupportedException)
            {
                // Phone Dialer is not supported on this device.
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Acción no soportada en este dispositivo.",
                        "Aceptar");
                });
            }
            catch (Exception exc)
            {
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

        async void OpenMap()
        {
            try
            {
                if (this.Latitud == 0 && this.Longitud == 0)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert(
                            "Error",
                            "Debe obtener la ubicación",
                            "Aceptar");
                    });

                    return;
                }

                await Map.OpenAsync(Convert.ToDouble(this.Latitud), Convert.ToDouble(this.Longitud));
            }
            catch (Exception exc)
            {
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

