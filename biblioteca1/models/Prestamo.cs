
namespace biblioteca1.models
{
    public class Prestamo
    {
        private static int ContadorPrestamo = 100;
        public int prestamoID { get; set; } = 0;
        public Usuario UsuarioID { get; set; } = new Usuario();
        public Libro LibroID { get; set; } = new Libro();
        public string UsuarioNombre { get; set; } = string.Empty;
        public string LibroTitulo { get; set; } = string.Empty;
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime? FechaDevolucion { get; set; } = null;
        public EstadoPrestamo Estado { get; set; } = EstadoPrestamo.Activo;

        public bool PrestamoActivo { get; set; } = true;

        public Prestamo()
        {
        }

        public Prestamo(int prestamoID, Usuario usuarioID, Libro libroID, DateTime fechaPrestamo, DateTime fechaVencimiento)
        {
            ContadorPrestamo++;
            this.prestamoID = prestamoID;
            UsuarioID = usuarioID;
            LibroID = libroID;
            UsuarioNombre = usuarioID.UsuarioNombre;
            LibroTitulo = libroID.LibroTitulo;
            FechaPrestamo = fechaPrestamo;
            FechaVencimiento = fechaVencimiento;
            FechaDevolucion = null;
            Estado = EstadoPrestamo.Activo;
            PrestamoActivo = true;
            LibroID.LibroDisponible = false; // Marcar el libro como no disponible al crear un préstamo
        }

    }
}