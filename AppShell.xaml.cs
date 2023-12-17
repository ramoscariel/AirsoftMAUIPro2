using Microsoft.Maui.Controls;
using AirsoftCore_App.Views;
using System.Linq;
using System.Threading.Tasks;

namespace AirsoftCore_App
{
    public partial class AppShell : Shell
    {
        public static bool IsUserLoggedIn { get; set; }

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(Views.MainPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(Views.LoginPage));
            Routing.RegisterRoute(nameof(RegistroPage), typeof(Views.RegistroPage));
            Routing.RegisterRoute(nameof(ProductosPage), typeof(Views.ProductosPage));
            Routing.RegisterRoute(nameof(PerfilPage), typeof(Views.PerfilPage));

            IsUserLoggedIn = false;
            MessagingCenter.Subscribe<Views.LoginPage>(this, "UserLoggedIn", (sender) =>
            {
                IsUserLoggedIn = true;
                ActualizarVisibilidadPestañas();
            });
        }

        private void ActualizarVisibilidadPestañas()
        {
            var productosTab = Shell.Current?.Items.FirstOrDefault(item => item.Route == nameof(ProductosPage));
            if (productosTab is ShellItem shellItemProductos)
            {
                foreach (var tab in shellItemProductos.Items)
                {
                    tab.FlyoutItemIsVisible = IsUserLoggedIn;
                }
            }

            var perfilTab = Shell.Current?.Items.FirstOrDefault(item => item.Route == nameof(PerfilPage));
            if (perfilTab is ShellItem shellItemPerfil)
            {
                foreach (var tab in shellItemPerfil.Items)
                {
                    tab.FlyoutItemIsVisible = IsUserLoggedIn;
                }
            }
        }

        protected override async void OnNavigating(ShellNavigatingEventArgs args)
        {
            if (args.Target.Location.OriginalString.Contains(nameof(PerfilPage)) && !IsUserLoggedIn)
            {
                args.Cancel();
                await MostrarMensajeIniciarSesion();
            }

            base.OnNavigating(args);
        }

        private async Task MostrarMensajeIniciarSesion()
        {
            await Shell.Current.DisplayAlert("Acceso Denegado", "Debes iniciar sesión para acceder a esta página", "OK");
        }
    }
}
