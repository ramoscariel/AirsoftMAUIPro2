namespace AirsoftCore_App.Models
{
    public class Producto
    {
        public string Nombre { get; set; }
        public decimal PrecioEnDolares { get; set; }
        public int PrecioEnCreditos { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public bool IsSelected { get; set; }
    }
}
