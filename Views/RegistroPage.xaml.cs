using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using AirsoftCore_App.Services;

namespace AirsoftCore_App.Views
{
    public partial class RegistroPage : ContentPage
    {
        private AuthService authService = new AuthService();

        public RegistroPage()
        {
            InitializeComponent();
        }

        private async void OnBotonRegistrarClicked(object sender, EventArgs e)
        {
            string nuevoUsuario = entryNuevoUsuario.Text;
            string nuevaContrase�a = entryNuevaContrase�a.Text;

            string errorMensaje = ObtenerMensajeErrorRegistro(nuevoUsuario, nuevaContrase�a);

            if (string.IsNullOrEmpty(errorMensaje))
            {
                if (await authService.RegistrarUsuarioAsync(nuevoUsuario, nuevaContrase�a))
                {
                    await DisplayAlert("Registro", "Registro exitoso", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Registro", "El usuario ya existe, elige otro nombre de usuario", "OK");
                }
            }
            else
            {
                await DisplayAlert("Registro", errorMensaje, "OK");
            }
        }

        private string ObtenerMensajeErrorRegistro(string nuevoUsuario, string nuevaContrase�a)
        {
            if (string.IsNullOrEmpty(nuevoUsuario) || string.IsNullOrEmpty(nuevaContrase�a))
            {
                return "El usuario y la contrase�a son obligatorios";
            }

            if (nuevoUsuario.ToLower() == "admin")
            {
                return "El usuario ya existe, elige otro nombre de usuario";
            }

            if (nuevaContrase�a.Length < 8)
            {
                return "La contrase�a debe tener al menos 8 caracteres";
            }

            return string.Empty;
        }

        private void OnEntryNuevaContrase�aTextChanged(object sender, TextChangedEventArgs e)
        {
            entryNuevaContrase�a.Text = new string('*', e.NewTextValue.Length);
        }

        private async void OnBotonRegresarClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
