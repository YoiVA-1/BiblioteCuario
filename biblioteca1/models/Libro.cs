
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
        public bool LibroDisponible { get; set; } = true;

        public Libro()
        {
        }

        
        public Libro(string libroTitulo, string libroAutor, int libroAño, string libroCategoria)
        {
            contador++;
            LibroId = contador;
            LibroTitulo = libroTitulo;
            LibroAutor = libroAutor;
            LibroAño = libroAño;
            LibroCategoria = libroCategoria;
            LibroDisponible = true;
        }

        public string ResumenCorto()
        {
            string estadoTexto = LibroDisponible ? "Disponible" : "Prestado";
            return $"ID: {LibroId}, Título: {LibroTitulo}, Autor: {LibroAutor}, Estado: {estadoTexto}";
        }
        public string DetalleCompleto()
        {
            string estadoTexto = LibroDisponible ? "Si" : "No";
            return $"=====================\nDetalle del Libro\n=====================\n-ID: {LibroId}\n-Título: {LibroTitulo}\n-Autor: {LibroAutor}\n-Año: {LibroAño}\n-Categoría: {LibroCategoria}\n-Disponible: {estadoTexto}\n=====================";
        }

        public override string ToString()
        {
            return ResumenCorto();
        }
    }
}