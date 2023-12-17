using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using AirsoftCore_App.Services;

namespace AirsoftCore_App.Views
{
    public partial class LoginPage : ContentPage
    {
        private AuthService authService = new AuthService();

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnBotonIniciarSesionClicked(object sender, EventArgs e)
        {
            string usuario = entryUsuario.Text;
            string contrase�a = entryContrase�a.Text;

            if (await authService.IniciarSesionAsync(usuario, contrase�a))
            {
                await DisplayAlert("Inicio de Sesi�n", "Inicio de sesi�n exitoso", "OK");

                MessagingCenter.Send<LoginPage>(this, "UserLoggedIn");

                await Navigation.PushAsync(new ProductosPage());
            }
            else
            {
                await DisplayAlert("Inicio de Sesi�n", "Credenciales inv�lidas", "OK");
            }
        }

        private async void OnBotonRegistrarseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroPage());
        }

        private async void OnEntryContrase�aTextChanged(object sender, TextChangedEventArgs e)
        {
            entryContrase�a.Text = new String('*', e.NewTextValue.Length);
        }
    }
}
