using Microsoft.Maui.Controls;

namespace AirsoftCore_App.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void IniciarSesion_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void Registrarse_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//RegistroPage");
        }
    }
}
