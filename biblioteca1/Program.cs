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
    }
}