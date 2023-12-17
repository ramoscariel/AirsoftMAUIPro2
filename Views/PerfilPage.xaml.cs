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
            string nuevaContrase�a = entryNuevaContrase�a.Text;

            if (string.IsNullOrWhiteSpace(nuevoUsuario) || string.IsNullOrWhiteSpace(nuevaContrase�a))
            {
                await DisplayAlert("Perfil", "El usuario y la contrase�a no pueden estar vac�os", "OK");
                return;
            }

            await DisplayAlert("Perfil", "Cambios guardados correctamente", "OK");

            await authService.ActualizarDatosPerfilAsync(nuevoUsuario, nuevaContrase�a);
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
            bool confirmacion = await DisplayAlert("Cerrar Sesi�n", "�Est�s seguro de cerrar sesi�n?", "S�", "No");

            if (confirmacion)
            {
                authService.CerrarSesion();

                MessagingCenter.Send<PerfilPage>(this, "UserLoggedOut");

                await Navigation.PopToRootAsync();
            }
        }
    }
}
