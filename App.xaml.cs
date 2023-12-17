using Microsoft.Maui.Controls;

namespace AirsoftCore_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}