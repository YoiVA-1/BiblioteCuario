using System;
using System.Collections.Generic;
using System.Linq;
using biblioteca1.models;

namespace biblioteca1.services
{
    public class LibroService
    {
        private readonly List<Libro> libros = new List<Libro>();

        // --- Operaciones básicas ---
        public void AgregarLibro(Libro libro)
        {
            if (libro == null) throw new ArgumentNullException(nameof(libro));
            libros.Add(libro);
        }

        public bool EliminarLibro(int libroId)
        {
            Libro? libro = libros.FirstOrDefault(l => l.LibroId == libroId);
            if (libro == null) return false;
            return libros.Remove(libro);
        }

        // Lógica simulada: marcar como no disponible si no se desea borrar físicamente
        public bool MarcarNoDisponible(int libroId)
        {
            Libro? libro = libros.FirstOrDefault(l => l.LibroId == libroId);
            if (libro == null) return false;
            libro.LibroDisponible = false;
            return true;
        }

        public List<Libro> ObtenerTodos()
        {
            return new List<Libro>(libros);
        }

        // --- Búsquedas ---
        public Libro? BuscarPorId(int libroId)
        {
            return libros.FirstOrDefault(l => l.LibroId == libroId);
        }

        // Cubre "ISBN" buscando por ID numérico o coincidencia exacta/parcial si se pasa texto
        public List<Libro> BuscarPorIsbn(string isbnOCodigo)
        {
            if (string.IsNullOrWhiteSpace(isbnOCodigo)) return new List<Libro>();
            string criterio = isbnOCodigo.Trim();

            if (int.TryParse(criterio, out int idBuscado))
            {
                return libros.Where(l => l.LibroId == idBuscado).ToList();
            }

            return libros
                .Where(l => l.LibroId.ToString().Equals(criterio, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Libro> BuscarPorTitulo(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo)) return new List<Libro>();
            return libros
                .Where(l => l.LibroTitulo.Contains(titulo.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Libro> BuscarPorAutor(string autor)
        {
            if (string.IsNullOrWhiteSpace(autor)) return new List<Libro>();
            return libros
                .Where(l => l.LibroAutor.Contains(autor.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // --- Ordenación ---
        public List<Libro> OrdenarPorTitulo()
        {
            return libros
                .OrderBy(l => l.LibroTitulo, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        public List<Libro> OrdenarPorAnio()
        {
            return libros
                .OrderBy(l => l.LibroAño)
                .ThenBy(l => l.LibroTitulo)
                .ToList();
        }

        // --- KPIs / Estadísticas ---
        public int ObtenerTotalLibros()
        {
            return libros.Count;
        }

        public int ObtenerLibrosDisponibles()
        {
            return libros.Count(l => l.LibroDisponible);
        }

        public int ObtenerLibrosPrestados()
        {
            return libros.Count(l => !l.LibroDisponible);
        }

        public string ObtenerResumenKpis()
        {
            int total = ObtenerTotalLibros();
            int disponibles = ObtenerLibrosDisponibles();
            int prestados = ObtenerLibrosPrestados();
            return $"KPIs Libros -> Total: {total} | Disponibles: {disponibles} | Prestados: {prestados}";
        }
    }
}