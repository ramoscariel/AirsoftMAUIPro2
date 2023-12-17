using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using AirsoftCore_App.Models;

namespace AirsoftCore_App.Views
{
    public partial class DetallesProductoPage : ContentPage
    {
        public string nombreProducto { get; set; }

        public DetallesProductoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Producto producto = ObtenerProductoPorNombre(nombreProducto);
            producto.IsSelected = true;
            BindingContext = producto;
        }

        private Producto ObtenerProductoPorNombre(string nombreProducto)
        {
            ObservableCollection<Producto> listaProductos = ObtenerListaDeProductos();
            return listaProductos.FirstOrDefault(p => p.Nombre == nombreProducto);
        }

        private ObservableCollection<Producto> ObtenerListaDeProductos()
        {
            return new ObservableCollection<Producto>
            {
                new Producto { Nombre = "Casco Airsoft", PrecioEnDolares = 49.99m, PrecioEnCreditos = 100,
                    Categoria = "Protección", Descripcion = "Casco de alta calidad para airsoft.", UrlImagen = "casco.jpg" },
                new Producto { Nombre = "Réplica de Rifle", PrecioEnDolares = 199.99m, PrecioEnCreditos = 300,
                    Categoria = "Armas", Descripcion = "Réplica de rifle de asalto para airsoft.", UrlImagen = "rifle.jpg" },
            };
        }
    }
}
