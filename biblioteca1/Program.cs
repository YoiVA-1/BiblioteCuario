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
    }
}
