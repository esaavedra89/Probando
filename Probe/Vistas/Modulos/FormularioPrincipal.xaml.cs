using Probe.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Probe.Vistas.Modulos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioPrincipal : ContentPage
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
            this.BindingContext = new FormularioPrincipalViewModel();
        }

        public FormularioPrincipal(Empresa objEmpresa)
        {
            InitializeComponent();
            this.BindingContext = new FormularioPrincipalViewModel(objEmpresa);
        }
    }
}