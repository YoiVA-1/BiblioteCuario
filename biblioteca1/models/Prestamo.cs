
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

        public bool EstaVencido()
        {
            if (Estado == EstadoPrestamo.Activo && DateTime.Now > FechaVencimiento)
            {
                Estado = EstadoPrestamo.Vencido;
                return true;
            }
            return Estado == EstadoPrestamo.Vencido;
        }

        public int DiasTranscurridos()
        {
            DateTime FechaFinal = FechaDevolucion ?? DateTime.Now;
            TimeSpan diferencia = FechaFinal - FechaPrestamo;
            return (int)diferencia.TotalDays;
        }

        public string ResumenCorto()
        {
            EstaVencido();
            return $"ID: {prestamoID}, Usuario: {UsuarioNombre}, Libro: {LibroTitulo}, Estado: {Estado}";
        }

        public string DetalleCompleto()
        {
            EstaVencido();
            string fechaDevolucionTexto = FechaDevolucion.HasValue ? FechaDevolucion.Value.ToString("dd/MM/yyyy") : "No devuelto";
            return $"=====================\nDetalle del Préstamo\n=====================\n-ID: {prestamoID}\n-Usuario: {UsuarioNombre}\n-Libro: {LibroTitulo}\n-Fecha de Préstamo: {FechaPrestamo:dd/MM/yyyy}\n-Fecha de Vencimiento: {FechaVencimiento:dd/MM/yyyy}\n-Fecha de Devolución: {fechaDevolucionTexto}\n-Estado: {Estado}\n=====================";
        }

        public override string ToString()
        {
            return ResumenCorto();
        }
    }
}