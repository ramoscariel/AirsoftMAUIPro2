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
            string contraseña = entryContraseña.Text;

            if (await authService.IniciarSesionAsync(usuario, contraseña))
            {
                await DisplayAlert("Inicio de Sesión", "Inicio de sesión exitoso", "OK");

                MessagingCenter.Send<LoginPage>(this, "UserLoggedIn");

                await Navigation.PushAsync(new ProductosPage());
            }
            else
            {
                await DisplayAlert("Inicio de Sesión", "Credenciales inválidas", "OK");
            }
        }

        private async void OnBotonRegistrarseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroPage());
        }

        private async void OnEntryContraseñaTextChanged(object sender, TextChangedEventArgs e)
        {
            entryContraseña.Text = new String('*', e.NewTextValue.Length);
        }
    }
}
