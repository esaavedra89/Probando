using Probe.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Probe.Vistas.Modulos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaCliente : ContentPage
    {
        public ListaCliente()
        {
            InitializeComponent();
            Surveys.ItemSelected += Surveys_ItemSelected;
        }

        async void Surveys_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                // Obtenemos el objeto seleccionado.
                Empresa objEmpresa = e.SelectedItem as Empresa;

                // Si la lista de paquetes es igual a nulo, se instancia para evitar error.
                //if (objeto.Paquete == null)
                //{
                //    objeto.Paquete = new List<Paquete>();
                //}

                // Navegamos hasta Despacho.
                await Application.Current.MainPage.Navigation.PushAsync(new FormularioPrincipal(objEmpresa));
            }
        }
    }
}