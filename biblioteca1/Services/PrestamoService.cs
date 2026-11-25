using System;
using System.Collections.Generic;
using System.Linq;
using biblioteca1.models;

namespace biblioteca1.services
{
    public class PrestamoService
    {
        private readonly List<Prestamo> prestamos = new List<Prestamo>();

        // --- Operaciones básicas ---
        public void AgregarPrestamo(Prestamo prestamo)
        {
            if (prestamo == null) throw new ArgumentNullException(nameof(prestamo));
            prestamo.EstaVencido();
            prestamos.Add(prestamo);
        }

        public bool EliminarPrestamo(int idPrestamo)
        {
            Prestamo? prestamo = prestamos.FirstOrDefault(p => p.prestamoID == idPrestamo);
            if (prestamo == null) return false;

            if (prestamo.LibroID != null)
            {
                prestamo.LibroID.LibroDisponible = true;
            }

            return prestamos.Remove(prestamo);
        }

        public bool RegistrarDevolucion(int idPrestamo, DateTime? fechaDevolucion = null)
        {
            Prestamo? prestamo = prestamos.FirstOrDefault(p => p.prestamoID == idPrestamo);
            if (prestamo == null) return false;

            prestamo.FechaDevolucion = fechaDevolucion ?? DateTime.Now;
            prestamo.Estado = EstadoPrestamo.Devuelto;
            prestamo.PrestamoActivo = false;

            if (prestamo.LibroID != null)
            {
                prestamo.LibroID.LibroDisponible = true;
            }

            return true;
        }

        public List<Prestamo> ObtenerTodos()
        {
            foreach (var p in prestamos) p.EstaVencido();
            return new List<Prestamo>(prestamos);
        }

        // --- Búsquedas ---
        public Prestamo? BuscarPorId(int idPrestamo)
        {
            Prestamo? prestamo = prestamos.FirstOrDefault(p => p.prestamoID == idPrestamo);
            prestamo?.EstaVencido();
            return prestamo;
        }

        public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
        {
            foreach (var p in prestamos) p.EstaVencido();
            return prestamos.Where(p => p.Estado == estado).ToList();
        }

        // --- Ordenación ---
        public List<Prestamo> OrdenarPorFechaLimite()
        {
            return prestamos
                .OrderBy(p => p.FechaVencimiento)
                .ToList();
        }

        // --- KPIs / Estadísticas ---
        public int ObtenerTotalPrestamos()
        {
            return prestamos.Count;
        }

        public int ObtenerPrestamosActivos()
        {
            foreach (var p in prestamos) p.EstaVencido();
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Activo);
        }

        public int ObtenerPrestamosVencidos()
        {
            foreach (var p in prestamos) p.EstaVencido();
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Vencido);
        }

        public int ObtenerPrestamosDevueltos()
        {
            foreach (var p in prestamos) p.EstaVencido();
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Devuelto);
        }

        public double ObtenerPromedioDiasPrestamo()
        {
            if (prestamos.Count == 0) return 0.0;
            return prestamos.Average(p => Math.Max(0, p.DiasTranscurridos()));
        }

        public string ObtenerResumenKpis()
        {
            int total = ObtenerTotalPrestamos();
            int activos = ObtenerPrestamosActivos();
            int vencidos = ObtenerPrestamosVencidos();
            int devueltos = ObtenerPrestamosDevueltos();
            double promedioDias = ObtenerPromedioDiasPrestamo();

            return $"KPIs Préstamos -> Total: {total} | Activos: {activos} | Vencidos: {vencidos} | Devueltos: {devueltos} | Promedio días: {promedioDias:F1}";
        }
    }
}