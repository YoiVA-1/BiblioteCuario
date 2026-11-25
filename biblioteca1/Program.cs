using System;
using System.Collections.Generic;
using System.Globalization;
using biblioteca1.models;
using biblioteca1.services;

namespace biblioteca1
{
    class Program
    {
        private static readonly LibroService libroService = new LibroService();
        private static readonly UsuarioService usuarioService = new UsuarioService();
        private static readonly PrestamoService prestamoService = new PrestamoService();

        static void Main(string[] args)
        {
            CargarDatosPrueba();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== BIBLIOTECA ===\n1. Libros\n2. Usuarios\n3. Préstamos\n4. Búsquedas, ordenaciones, KPIs y Array vs List\n5. Guardar / Cargar\n6. Salir");
                switch (Console.ReadLine())
                {
                    case "1": MenuLibros(); break;
                    case "2": MenuUsuarios(); break;
                    case "3": MenuPrestamos(); break;
                    case "4": ReportesKpisYComparacion(); break;
                    case "5": Console.WriteLine("Pendiente de persistencia."); Console.ReadKey(); break;
                    case "6": Console.Write("¿Salir? (S/N): "); if ((Console.ReadLine() ?? "").Equals("S", StringComparison.OrdinalIgnoreCase)) return; break;
                }
            }
        }

        static void MenuLibros()
        {
            Console.Clear();
            Console.WriteLine("--- LIBROS ---\n1. Registrar\n2. Listar Libros\n3. Buscar por autor\n4. Eliminar por ID\n5. Volver");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.Write("Título: "); string t = Console.ReadLine() ?? "";
                    Console.Write("Autor: "); string a = Console.ReadLine() ?? "";
                    Console.Write("Año: "); int.TryParse(Console.ReadLine(), out int anio);
                    Console.Write("Categoría: "); string cat = Console.ReadLine() ?? "";
                    libroService.AgregarLibro(new Libro(t, a, anio, cat));
                    Console.WriteLine("Libro agregado.");
                    break;
                case "2":
                    Console.Clear();
                    Console.Write(" 1.Todos\n 2.Disponibles\n 3.Prestados\n ");
                    string op = Console.ReadLine() ?? "1";
                    foreach (var l in libroService.ObtenerTodos())
                        if (op == "1" || (op == "2" && l.LibroDisponible) || (op == "3" && !l.LibroDisponible))
                            Console.WriteLine(l.ResumenCorto());
                    break;
                case "3":
                    Console.Clear();
                    Console.Write("Autor: ");
                    foreach (var l in libroService.BuscarPorAutor(Console.ReadLine() ?? ""))
                        Console.WriteLine(l.ResumenCorto());
                    break;
                case "4":
                    Console.Clear();
                    Console.Write("ID libro: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                        Console.WriteLine(libroService.EliminarLibro(id) ? "Eliminado." : "No encontrado.");
                    break;
            }
            Console.ReadKey();
        }

        static void MenuUsuarios()
        {
            Console.Clear();
            Console.WriteLine("--- USUARIOS ---\n1. Registrar\n2. Listar\n3. Buscar por nombre\n4. Eliminar por ID\n5. Volver");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Nombre: "); string n = Console.ReadLine() ?? "";
                    Console.Write("Apellido: "); string ap = Console.ReadLine() ?? "";
                    Console.Write("Email: "); string em = Console.ReadLine() ?? "";
                    Console.Write("Teléfono: "); string tel = Console.ReadLine() ?? "";
                    usuarioService.AgregarUsuario(new Usuario(n, ap, em, tel));
                    Console.WriteLine("Usuario agregado.");
                    break;
                case "2":
                    foreach (var u in usuarioService.ObtenerTodos()) Console.WriteLine(u.ResumenCorto());
                    break;
                case "3":
                    Console.Write("Nombre: ");
                    foreach (var u in usuarioService.BuscarPorNombre(Console.ReadLine() ?? "")) Console.WriteLine(u.ResumenCorto());
                    break;
                case "4":
                    Console.Write("ID usuario: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        bool tienePrestamo = prestamoService.ObtenerTodos().Exists(p => p.UsuarioID?.UsuarioId == id && p.Estado != EstadoPrestamo.Devuelto);
                        if (tienePrestamo) Console.WriteLine("[ERROR] Tiene préstamos activos.");
                        else Console.WriteLine(usuarioService.EliminarUsuario(id) ? "Eliminado." : "No encontrado.");
                    }
                    break;
            }
            Console.ReadKey();
        }

        static void MenuPrestamos()
        {
            Console.Clear();
            Console.WriteLine("--- PRÉSTAMOS ---\n1. Registrar\n2. Listar\n3. Devolver por ID\n4. Eliminar por ID\n5. Volver");
            switch (Console.ReadLine())
            {
                case "1":
                Console.Clear();
                    Console.Write("ID préstamo: "); int.TryParse(Console.ReadLine(), out int idP);
                    Console.Write("Nombre usuario: "); var u = usuarioService.BuscarPorNombre(Console.ReadLine() ?? "").Find(x => x.Activo);
                    Console.Write("Título libro: "); var l = libroService.BuscarPorTitulo(Console.ReadLine() ?? "").Find(x => x.LibroDisponible);
                    if (u != null && l != null)
                    {
                        prestamoService.AgregarPrestamo(new Prestamo(idP, u, l, DateTime.Now, DateTime.Now.AddDays(7)));
                        Console.WriteLine("Préstamo registrado.");
                    }
                    else Console.WriteLine("Usuario no activo o libro no disponible.");
                    break;
                case "2":
                Console.Clear();
                    foreach (var p in prestamoService.ObtenerTodos()) Console.WriteLine(p.ResumenCorto());
                    break;
                case "3":
                Console.Clear();
                    Console.Write("ID préstamo: ");
                    if (int.TryParse(Console.ReadLine(), out int idDev))
                        Console.WriteLine(prestamoService.RegistrarDevolucion(idDev) ? "Devuelto." : "No encontrado.");
                    break;
                case "4":
                Console.Clear();
                    Console.Write("ID préstamo: ");
                    if (int.TryParse(Console.ReadLine(), out int idDel))
                        Console.WriteLine(prestamoService.EliminarPrestamo(idDel) ? "Eliminado." : "No encontrado.");
                    break;
            }
            Console.ReadKey();
        }

        static void ReportesKpisYComparacion()
        {
            Console.Clear();
            Console.WriteLine("--- ORDENACIONES ---");
            foreach (var l in libroService.OrdenarPorTitulo()) Console.WriteLine($"Libro: {l.LibroTitulo} ({l.LibroAño})");
            foreach (var u in usuarioService.OrdenarPorNombre()) Console.WriteLine($"Usuario: {u.UsuarioNombre} {u.UsuarioApellido}");
            foreach (var p in prestamoService.OrdenarPorFechaLimite()) Console.WriteLine($"Préstamo #{p.prestamoID} - Límite: {p.FechaVencimiento:dd/MM/yyyy}");

            Console.WriteLine("\n--- KPIS ---");
            Console.WriteLine(libroService.ObtenerResumenKpis());
            Console.WriteLine(usuarioService.ObtenerResumenKpis());
            Console.WriteLine(prestamoService.ObtenerResumenKpis());

            Console.WriteLine("\n--- ARRAY VS LIST<T> ---");
            string[] arr = { "1984", "Dune" }; // Tamaño fijo: no admite Add/Remove directo
            List<string> lista = new List<string> { "1984", "Dune" }; // Tamaño dinámico
            lista.Add("Fahrenheit 451");
            lista.Remove("1984");
            Console.WriteLine($"Array (fijo {arr.Length}): {string.Join(", ", arr)}");
            Console.WriteLine($"List<T> (dinámico {lista.Count}): {string.Join(", ", lista)}");
            Console.WriteLine("Diferencia: Array tiene tamaño fijo; List<T> crece/encoge dinámicamente y tiene Add/Remove.");
            Console.ReadKey();
        }

        static void CargarDatosPrueba()
        {
            var u1 = new Usuario("Juan", "Pérez", "juan@mail.com", "301456345");
            var u2 = new Usuario("María", "Gómez", "maria@mail.com", "310321545") { Activo = false };
            usuarioService.AgregarUsuario(u1);
            usuarioService.AgregarUsuario(u2);

            var l1 = new Libro("Cien Años de Soledad", "Gabriel García Márquez", 1967, "Novela");
            var l2 = new Libro("1984", "George Orwell", 1949, "Distopía");
            libroService.AgregarLibro(l1);
            libroService.AgregarLibro(l2);

            prestamoService.AgregarPrestamo(new Prestamo(1, u1, l1, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-2)));
        }
    }
}