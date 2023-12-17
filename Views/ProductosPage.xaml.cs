using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using AirsoftCore_App.Models;
using System.Linq;

namespace AirsoftCore_App.Views
{
    public partial class ProductosPage : ContentPage
    {
        public ProductosPage()
        {
            InitializeComponent();

            Productos = new ObservableCollection<Producto>
            {
                new Producto { Nombre = "Casco Airsoft", PrecioEnDolares = 49.99m, PrecioEnCreditos = 100,
                    Categoria = "Protecci�n", Descripcion = "Casco de alta calidad para airsoft.", UrlImagen = "casco.jpg" },
                new Producto { Nombre = "R�plica de Rifle", PrecioEnDolares = 199.99m, PrecioEnCreditos = 300,
                    Categoria = "Armas", Descripcion = "R�plica de rifle de asalto para airsoft.", UrlImagen = "rifle.jpg" },
            };

            productosCollectionView.ItemsSource = Productos;
        }

        public ObservableCollection<Producto> Productos { get; set; }

        private void OnDetallesButtonClick(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string nombreProducto)
            {
                Navigation.PushAsync(new DetallesProductoPage { nombreProducto = nombreProducto });
            }
        }

        private void OnProductoSeleccionado(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Producto selectedProducto)
            {
                Console.WriteLine($"Producto seleccionado: {selectedProducto.Nombre}");
                Console.WriteLine($"Precio: {selectedProducto.PrecioEnDolares:C}");
                Console.WriteLine($"Categor�a: {selectedProducto.Categoria}");


                DisplayAlert("Detalles del Producto", $"Nombre: {selectedProducto.Nombre}\nPrecio: {selectedProducto.PrecioEnDolares:C}\nCategor�a: {selectedProducto.Categoria}", "OK");
            }

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
