using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Probe.Vistas.Modulos
{
    public class HomeViewModel
    {
        public Command NavegarRegistroCommand
        {
            get
            {
                return new Command(() =>
                {
                    NavegarRegistro();
                });
            }
        }

        

        public Command NavegarListaCommand
        {
            get
            {
                return new Command(() =>
                {
                    NavegarLista();
                });
            }
        }

        async void NavegarRegistro()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new FormularioPrincipal(), false);
            }
            catch (Exception exc)
            {
                // Number was null or white space.
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ha ocurrido un error: " + exc.Message,
                        "Aceptar");
                });
            }
        }

        async void NavegarLista()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ListaCliente(), false);
            }
            catch (Exception exc)
            {
                // Number was null or white space.
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ha ocurrido un error: " + exc.Message,
                        "Aceptar");
                });
            }
        }
    }
}
