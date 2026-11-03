using System;

namespace biblioteca1
{
    class Program
    {
        // Variables estáticas individuales
        static string libroID = "";
        static string libroTitulo = "";
        static string libroAutor = "";
        static string libroAño = "";
        static string libroCategoria = "";
        static bool libroDisponible = true;

        static void Main(string[] args)
        {
            ShowMainMenu();
        }

        static void ShowMainMenu()
        {
            string seleccion = "0";
            do
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("Bienvenido a la Biblioteca\nSeleccione una opción:\n1. Libro\n2. Usuarios\n3. Préstamos\n4. Búsquedas y reportes\n5. Guardar / Cargar datos\n6. Salir");
                Console.WriteLine("================================");
                
                seleccion = Console.ReadLine() ?? "0";
                switch (seleccion)
                {
                    case "1":
                        ShowBookMenu();
                        break;
                    //case "2":
                        //ShowUserMenu();
                        //break;
                    //case "3":
                        //ShowLoansMenu();
                        //break;
                    //case "4":
                        //ShowSearchReportsMenu();
                        //break;
                    //case "5":
                        //ShowPersistenceMenu();
                        //break;
                    case "6":
                        Console.WriteLine("Saliendo del programa...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            } while (seleccion != "6");
        }

        //--- Menú de Libros ---//
        static void ShowBookMenu()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Menú de Libros\nSeleccione una opción:\n1. Registrar libro\n2. Listar libros\n3. Ver detalle de libro\n4. Actualizar libro\n5. Eliminar libro\n6. Volver al menú principal");
            Console.WriteLine("================================");
            string bookOption = Console.ReadLine() ?? "0";
            switch (bookOption)
            {
                case "1":
                    RegisterBook();
                    break;
                case "2":
                    ListBooksMenu();
                    break;
                case "3":
                    ViewBookDetail();
                    break;
                case "4":
                    UpdateBookMenu();
                    break;
                case "5":
                    DeleteBook();
                    break;
                case "6":
                    ShowMainMenu();
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }
        }

        //--- Registro de Libros ---//
        static void RegisterBook()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Registro de Libro\nIngrese los datos del libro:");
            Console.WriteLine("================================");
            Console.Write("Título: ");
            libroTitulo = Console.ReadLine() ?? "";
            Console.Write("Autor: ");
            libroAutor = Console.ReadLine() ?? "";
            Console.Write("Año de publicación: ");
            libroAño = Console.ReadLine() ?? "";
            Console.Write("Género / Categoría: ");
            libroCategoria = Console.ReadLine() ?? "";
            Console.Write("ID / ISBN: ");
            libroID = Console.ReadLine() ?? "";
            libroDisponible = true;

            Console.WriteLine($"Libro '{libroTitulo}' registrado exitosamente.");
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        //--- Menú de Listado de Libros ---//
        static void ListBooksMenu()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Menú de Listado de Libros\nSeleccione una opción:\n1. Listar todos los libros\n2. Listar libros disponibles\n3. Listar libros prestados\n4. Volver al menú de libros");
            Console.WriteLine("================================");
            string listOption = Console.ReadLine() ?? "0";
            switch (listOption)
            {
                case "1":
                    ListAllBooks();
                    break;
                case "2":
                    ListBooksAvailable();
                    break;
                case "3":
                    ListBooksBorrowed();
                    break;
                case "4":
                    ShowBookMenu();
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }
        }

        static void ListAllBooks()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Listado de Todos los Libros");
            Console.WriteLine("================================");
            if (string.IsNullOrEmpty(libroTitulo))
            {
                Console.WriteLine("No hay libros registrados.");
            }
            else
            {
                Console.WriteLine($"ID: {libroID} | Título: {libroTitulo}, Autor: {libroAutor}, Año: {libroAño}, Categoría: {libroCategoria}");
            }
            Console.ReadKey();
        }

        static void ListBooksAvailable()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Listado de Libros Disponibles");
            Console.WriteLine("================================");
            if (string.IsNullOrEmpty(libroTitulo) || !libroDisponible)
            {
                Console.WriteLine("No hay libros disponibles.");
            }
            else
            {
                Console.WriteLine($"ID: {libroID} | Título: {libroTitulo}, Autor: {libroAutor}, Año: {libroAño}, Categoría: {libroCategoria}");
            }
            Console.ReadKey();
        }

        static void ListBooksBorrowed()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Listado de Libros Prestados");
            Console.WriteLine("================================");
            if (string.IsNullOrEmpty(libroTitulo) || libroDisponible)
            {
                Console.WriteLine("No hay libros prestados.");
            }
            else
            {
                Console.WriteLine($"ID: {libroID} | Título: {libroTitulo}, Autor: {libroAutor}, Año: {libroAño}, Categoría: {libroCategoria}");
            }
            Console.ReadKey();
        }

        //--- Ver Detalle de Libro ---//
        static void ViewBookDetail()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Detalle de Libro\nIngrese el título del libro:");
            Console.WriteLine("================================");
            string title = Console.ReadLine() ?? "";
            if (title.Equals(libroTitulo, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Título: {libroTitulo}\nAutor: {libroAutor}\nAño: {libroAño}\nCategoría: {libroCategoria}");
            }
            else
            {
                Console.WriteLine($"No se encontró un libro con el título '{title}'.");
            }
            Console.ReadKey();
        }

        //--- Eliminar Libro ---//
        static void DeleteBook()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Eliminar Libro\nIngrese el título del libro a eliminar:");
            Console.WriteLine("================================");
            string title = Console.ReadLine() ?? "";
            if (title.Equals(libroTitulo, StringComparison.OrdinalIgnoreCase))
            {
                libroTitulo = "";
                libroAutor = "";
                libroAño = "";
                libroCategoria = "";
                libroID = "";
                Console.WriteLine($"Libro eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine($"No se encontró un libro con el título '{title}'.");
            }
            Console.ReadKey();
        }

    }
}