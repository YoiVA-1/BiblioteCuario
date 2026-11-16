
namespace biblioteca1.models
{
    public class Libro
    {
        private static int contador = 100;
        public int LibroId { get; set; } = 0;
        public string LibroTitulo { get; set; } = string.Empty;
        public string LibroAutor { get; set; } = string.Empty;
        public int LibroAño { get; set; } = 0;
        public string LibroCategoria { get; set; } = string.Empty;
        public string LibroDisponible { get; set; } = string.Empty;

        public Libro()
        {

        }
        
        public Libro(string libroTitulo, string libroAutor, int libroAño, string libroCategoria, string libroDisponible)
        {
            contador++;
            LibroId = contador;
            LibroTitulo = libroTitulo;
            LibroAutor = libroAutor;
            LibroAño = libroAño;
            LibroCategoria = libroCategoria;
            LibroDisponible = libroDisponible;
        }

        public string ResumenCorto()
        {
            return $"ID: {LibroId}, Título: {LibroTitulo}, Autor: {LibroAutor}";
        }
        public string DetalleCompleto()
        {
            return $"=====================\nDetalle del Libro\n=====================\n-ID: {LibroId}\n-Título: {LibroTitulo}\n-Autor: {LibroAutor}\n-Año: {LibroAño}\n-Categoría: {LibroCategoria}\n-Disponible: {LibroDisponible}\n=====================";
        }

    }
}