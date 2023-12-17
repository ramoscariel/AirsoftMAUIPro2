using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Threading.Tasks;
using AirsoftCore_App.Models;
using AirsoftCore_App.Services;

namespace AirsoftCore_App.Views
{
    public partial class PerfilPage : ContentPage
    {
        private AuthService authService = new AuthService();

        public PerfilPage()
        {
            InitializeComponent();
        }

        private async void OnGuardarCambiosClicked(object sender, EventArgs e)
        {
            string nuevoUsuario = entryNuevoUsuario.Text;
            string nuevaContraseña = entryNuevaContraseña.Text;

            if (string.IsNullOrWhiteSpace(nuevoUsuario) || string.IsNullOrWhiteSpace(nuevaContraseña))
            {
                await DisplayAlert("Perfil", "El usuario y la contraseña no pueden estar vacíos", "OK");
                return;
            }

            await DisplayAlert("Perfil", "Cambios guardados correctamente", "OK");

            await authService.ActualizarDatosPerfilAsync(nuevoUsuario, nuevaContraseña);
        }

        private async void OnSubirFotoClicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                if (photo != null)
                {
                    var photoStream = await photo.OpenReadAsync();
                    var photoBytes = new byte[photoStream.Length];
                    await photoStream.ReadAsync(photoBytes, 0, photoBytes.Length);

                    await authService.SubirFotoAsync(entryNuevoUsuario.Text, photoBytes);

                    await DisplayAlert("Perfil", "Foto subida correctamente", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al subir la foto: {ex.Message}", "OK");
            }
        }

        private async void OnCerrarSesionClicked(object sender, EventArgs e)
        {
            bool confirmacion = await DisplayAlert("Cerrar Sesión", "¿Estás seguro de cerrar sesión?", "Sí", "No");

            if (confirmacion)
            {
                authService.CerrarSesion();

                MessagingCenter.Send<PerfilPage>(this, "UserLoggedOut");

                await Navigation.PopToRootAsync();
            }
        }
    }
}
