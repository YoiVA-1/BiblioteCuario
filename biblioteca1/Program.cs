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

        static string usuarioID = "";
        static string usuarioNombre = "";
        static string correo = "";
        static bool usuarioActivo = true;
        static bool usuarioTienePrestamo = false; // Variable para simular si el usuario tiene préstamos activos temporalmente
        static string prestamoID = "";
        static string fechaPrestamo = "";
        static string fechaLimite = "";
        static string fechaDevolucion = "";
        static string estado = "";

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
                    case "2":
                        ShowUserMenu();
                        break;
                    case "3":
                        ShowLoansMenu();
                        break;
                    case "4":
                        ShowSearchReportsMenu();
                        break;
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
            Console.WriteLine("Menú de Libros\nSeleccione una opción:\n1. Registrar libro\n2. Listar libros\n3. Ver detalle de libro\n4. Buscar libro por autor\n5. Actualizar libro\n6. Eliminar libro\n7. Volver al menú principal");
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

        //--- Menú de Actualización ---//
        static void UpdateBookMenu()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Menú de Actualización de Libros\nSeleccione una opción:\n1. Actualizar libro por título\n2. Actualizar libro por autor\n3. Actualizar año y categoría\n4. Volver al menú de libros");
            Console.WriteLine("================================");
            string updateOption = Console.ReadLine() ?? "0";
            switch (updateOption)
            {
                case "1":
                    EditBookTitle();
                    break;
                case "2":
                    EditBookAuthor();
                    break;
                case "3":
                    EditBookYearCategory();
                    break;
                case "4":
                    ShowBookMenu();
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }
        }

        static void EditBookTitle()
        {
            Console.Clear();
            Console.WriteLine("Actualizar Libro por Título\nIngrese el título actual del libro:");
            string oldTitle = Console.ReadLine() ?? "";
            if (oldTitle.Equals(libroTitulo, StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Ingrese el nuevo título: ");
                libroTitulo = Console.ReadLine() ?? "";
                Console.WriteLine($"Título actualizado a '{libroTitulo}'.");
            }
            else
            {
                Console.WriteLine("No se encontró el libro.");
            }
            Console.ReadKey();
        }

        static void EditBookAuthor()
        {
            Console.Clear();
            Console.WriteLine("Actualizar Libro por Autor\nIngrese el título del libro:");
            string title = Console.ReadLine() ?? "";
            if (title.Equals(libroTitulo, StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Ingrese el nuevo autor: ");
                libroAutor = Console.ReadLine() ?? "";
                Console.WriteLine($"Autor actualizado a '{libroAutor}'.");
            }
            else
            {
                Console.WriteLine("No se encontró el libro.");
            }
            Console.ReadKey();
        }

        static void EditBookYearCategory()
        {
            Console.Clear();
            Console.WriteLine("Actualizar Año y Categoría\nIngrese el título del libro:");
            string title = Console.ReadLine() ?? "";
            if (title.Equals(libroTitulo, StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Ingrese el nuevo año: ");
                libroAño = Console.ReadLine() ?? "";
                Console.Write("Ingrese la nueva categoría: ");
                libroCategoria = Console.ReadLine() ?? "";
                Console.WriteLine("Datos actualizados correctamente.");
            }
            else
            {
                Console.WriteLine("No se encontró el libro.");
            }
            Console.ReadKey();
        }
//--- Menú de Usuarios ---//
        static void ShowUserMenu()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Menú de Usuarios\nSeleccione una opción:\n1. Registrar usuario\n2. Listar usuarios\n3. Ver detalle de usuario\n4. Actualizar usuario\n5. Eliminar usuario\n6. Volver al menú principal");
            Console.WriteLine("================================");
            string userOption = Console.ReadLine() ?? "0";
            switch (userOption)
            {
                case "1":
                    RegisterUser();
                    break;
                case "2":
                    ListUsers();
                    break;
                case "3":
                    ViewUserDetail();
                    break;
                case "4":
                    UpdateUserMenu();
                    break;
                case "5":
                    DeleteUser();
                    break;
                case "6":
                    ShowMainMenu();
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
        //--- Registro de Usuarios ---//
        static void RegisterUser()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Registro de Usuario\nIngrese los datos del usuario:");
            Console.WriteLine("================================");
            Console.Write("Nombre: ");
            usuarioNombre = Console.ReadLine() ?? "";
            Console.Write("Correo electrónico: ");
            correo = Console.ReadLine() ?? "";
            Console.Write("ID de usuario: ");
            usuarioID = Console.ReadLine() ?? "";
            usuarioActivo = true;

            Console.WriteLine($"Usuario '{usuarioNombre}' registrado exitosamente.");
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        //--- Listado de Usuarios ---//
        static void ListUsers()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Listado de Usuarios");
            Console.WriteLine("================================");
            if (string.IsNullOrEmpty(usuarioNombre))
            {
                Console.WriteLine("No hay usuarios registrados.");
            }
            else
            {
                Console.WriteLine($"ID: {usuarioID} | Nombre: {usuarioNombre}, Correo: {correo}");
            }
            Console.ReadKey();
        }
        //--- Ver Detalle de Usuario ---//
        static void ViewUserDetail()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Detalle de Usuario\nIngrese el ID del usuario:");
            Console.WriteLine("================================");
            string id = Console.ReadLine() ?? "";
            if (id.Equals(usuarioID, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Nombre: {usuarioNombre}\nCorreo: {correo}\nID: {usuarioID}");
            }
            else
            {
                Console.WriteLine($"No se encontró un usuario con el ID '{id}'.");
            }
            Console.ReadKey();
        }
        //--- Actualizar Usuario ---//
        static void UpdateUserMenu()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Menú de Actualización de Usuarios\nSeleccione una opción:\n1. Actualizar nombre\n2. Actualizar correo\n3. Volver al menú de usuarios");
            Console.WriteLine("================================");
            string updateOption = Console.ReadLine() ?? "0";
            switch (updateOption)
            {
                case "1":
                    EditUserName();
                    break;
                case "2":
                    EditUserContact();
                    break;
                case "3":
                    ToggleUserActiveStatus();
                break;
                case "4":
                    DeleteUser();
                    break;
                case "5":
                    ShowUserMenu();
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
        //--- Editar Nombre de Usuario ---//
        static void EditUserName()
        {
            Console.Clear();
            Console.WriteLine("Actualizar Nombre de Usuario\nIngrese el ID del usuario:");
            string id = Console.ReadLine() ?? "";
            if (id.Equals(usuarioID, StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Ingrese el nuevo nombre: ");
                usuarioNombre = Console.ReadLine() ?? "";
                Console.WriteLine($"Nombre actualizado a '{usuarioNombre}'.");
            }
            else
            {
                Console.WriteLine("No se encontró el usuario.");
            }
            Console.ReadKey();
        }

        //--- Editar Contacto de Usuario ---//
        static void EditUserContact()
        {
            Console.Clear();
            Console.WriteLine("Actualizar Correo de Usuario\nIngrese el ID del usuario:");
            string id = Console.ReadLine() ?? "";
            if (id.Equals(usuarioID, StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Ingrese el nuevo correo: ");
                correo = Console.ReadLine() ?? "";
                Console.WriteLine($"Correo actualizado a '{correo}'.");
            }
            else
            {
                Console.WriteLine("No se encontró el usuario.");
            }
            Console.ReadKey();
        }
        //--- activar / Desactivar Usuario ---//
        static void ToggleUserActiveStatus()
        {
            Console.Clear();
            Console.WriteLine("Activar / Desactivar Usuario\nIngrese el ID del usuario:");
            string id = Console.ReadLine() ?? "";
            if (id.Equals(usuarioID, StringComparison.OrdinalIgnoreCase))
            {
                usuarioActivo = !usuarioActivo;
                string status = usuarioActivo ? "activo" : "inactivo";
                Console.WriteLine($"El usuario ahora está {status}.");
            }
            else
            {
                Console.WriteLine("No se encontró el usuario.");
            }
            Console.ReadKey();
        }
//--- Eliminar Usuario ---//
        static void DeleteUser()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Eliminar Usuario\nIngrese el ID del usuario a eliminar:");
            Console.WriteLine("================================");
            string id = Console.ReadLine() ?? "";

            if (id.Equals(usuarioID, StringComparison.OrdinalIgnoreCase))
            {
                // Validación condicional: Evita eliminar si tiene préstamos activos
                if (usuarioTienePrestamo)
                {
                    Console.WriteLine("\n[ERROR] No se puede eliminar al usuario porque tiene préstamos activos.");
                }
                else
                {
                    usuarioID = "";
                    usuarioNombre = "";
                    correo = "";
                    usuarioActivo = false;
                    Console.WriteLine("\nUsuario eliminado exitosamente.");
                }
            }
            else
            {
                Console.WriteLine($"\nNo se encontró un usuario con el ID '{id}'.");
            }
            
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        //--- Menú de Préstamos ---//
        static void ShowLoansMenu()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Menú de Préstamos\nSeleccione una opción:\n1. Registrar préstamo\n2. Listar préstamos\n3. Ver detalle de préstamo\n4. Registrar devolucion\n5. Eliminar préstamo\n6. Volver al menú principal");
            Console.WriteLine("================================");
            string loanOption = Console.ReadLine() ?? "0";
            switch (loanOption)
            {
                case "1":
                    CreateLoan();
                    break;
                case "2":
                    ListLoansMenu();
                    break;
                case "3":
                    ViewLoanDetail();
                    break;
                case "4":
                    RegisterReturn();
                    break;
                case "5":
                    DeleteLoan();
                    break;
                case "6":
                    ShowMainMenu();
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
        //--- Registro de Préstamos ---//
        static void CreateLoan()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Registro de Préstamo\nIngrese los datos del préstamo:");
            Console.WriteLine("================================");
            Console.Write("Ingrese el nombre del usuario que quiere hacer el préstamo: ");
            string opcionUsuarioPrestamo= Console.ReadLine() ?? "";
            if (opcionUsuarioPrestamo == usuarioNombre && usuarioActivo)
                {
                    Console.Write("Ingrese el título del libro a prestar: ");
                    string opcionLibroPrestamo = Console.ReadLine() ?? "";
                if(opcionLibroPrestamo == libroTitulo && libroDisponible)
                {
                    Console.Write("Ingrese el ID del préstamo: ");
                    prestamoID = Console.ReadLine() ?? "";
                    Console.Write("Ingrese la fecha de préstamo (dd/MM/yyyy): ");
                    fechaPrestamo = Console.ReadLine() ?? "";
                    Console.Write("Ingrese la fecha límite de devolución (dd/MM/yyyy): ");
                    fechaLimite = Console.ReadLine() ?? "";
                    estado = "Activo";
                    libroDisponible = false; // Simula que el libro ya no está disponible
                    usuarioTienePrestamo = true; // Simula que el usuario ahora tiene un préstamo activo
                    Console.WriteLine($"Préstamo '{prestamoID}' registrado exitosamente.");
                }
                else
                {
                    Console.WriteLine("El libro no está disponible para préstamo o no existe.");
                }
            }
        }
        //--- Listado de Préstamos ---//
        static void ListLoansMenu()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Listado de Préstamos\nSeleccione una opción:\n1. Listar todos los préstamos\n2. Listar préstamos activos\n3. Listar préstamos devueltos\n4. Volver al menú de préstamos");
            Console.WriteLine("================================");
            string listOption = Console.ReadLine() ?? "0";
            switch (listOption)
            {
                case "1":
                    ListAllLoans();
                    break;
                case "2":
                    ListLoansActive();
                    break;
                case "3":
                    ListLoansClosed();
                    break;
                case "4":
                    ShowLoansMenu();
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
        //--- listar todo los prestamos por ---//
        static void ListAllLoans()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Listado de Todos los Préstamos");
            Console.WriteLine("================================");
            if (string.IsNullOrEmpty(prestamoID))
            {
                Console.WriteLine("No hay préstamos registrados.");
            }
            else
            {
                Console.WriteLine($"ID: {prestamoID} | Fecha de préstamo: {fechaPrestamo}, Fecha límite: {fechaLimite}, Estado: {estado}");
            }
            Console.ReadKey();
        }
        //--- listar prestamos activos ---//
        static void ListLoansActive()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Listado de Préstamos Activos");
            Console.WriteLine("================================");
            if (string.IsNullOrEmpty(prestamoID) || estado != "Activo")
            {
                Console.WriteLine("No hay préstamos activos.");
            }
            else
            {
                Console.WriteLine($"ID: {prestamoID} | Fecha de préstamo: {fechaPrestamo}, Fecha límite: {fechaLimite}, Estado: {estado}");
            }
            Console.ReadKey();
        }

        //--- listar prestamos devueltos ---//
        static void ListLoansClosed()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Listado de Préstamos Devueltos");
            Console.WriteLine("================================");
            if (string.IsNullOrEmpty(prestamoID) || estado != "Devuelto")
            {
                Console.WriteLine("No hay préstamos devueltos.");
            }
            else
            {
                Console.WriteLine($"ID: {prestamoID} | Fecha de préstamo: {fechaPrestamo}, Fecha límite: {fechaLimite}, Fecha de devolución: {fechaDevolucion}, Estado: {estado}");
            }
            Console.ReadKey();
        }
        //--- Ver Detalle de Préstamo (ID) ---//
        static void ViewLoanDetail()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Detalle de Préstamo\nIngrese el ID del préstamo:");
            Console.WriteLine("================================");
            string id = Console.ReadLine() ?? "";
            if (id.Equals(prestamoID, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"ID: {prestamoID}\nFecha de préstamo: {fechaPrestamo}\nFecha límite: {fechaLimite}\nFecha de devolución: {fechaDevolucion}\nEstado: {estado}");
            }
            else
            {
                Console.WriteLine($"No se encontró un préstamo con el ID '{id}'.");
            }
            Console.ReadKey();
        }
        //--- Registrar Devolución ---//
        static void RegisterReturn()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Registrar Devolución\nIngrese el ID del préstamo:");
            Console.WriteLine("================================");
            string id = Console.ReadLine() ?? "";
            if (id.Equals(prestamoID, StringComparison.OrdinalIgnoreCase))
            {
                if (estado == "Activo")
                {
                    Console.Write("Ingrese la fecha de devolución (dd/MM/yyyy): ");
                    fechaDevolucion = Console.ReadLine() ?? "";
                    estado = "Devuelto";
                    usuarioTienePrestamo = false; // Simula que el usuario ya no tiene un préstamo activo
                    Console.WriteLine($"Préstamo '{prestamoID}' marcado como devuelto.");
                }
                else
                {
                    Console.WriteLine("El préstamo ya ha sido devuelto.");
                }
            }
            else
            {
                Console.WriteLine($"No se encontró un préstamo con el ID '{id}'.");
            }
            Console.ReadKey();
        }
        //--- Eliminar Préstamo ---//
        static void DeleteLoan()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Eliminar Préstamo\nIngrese el ID del préstamo a eliminar:");
            Console.WriteLine("================================");
            string id = Console.ReadLine() ?? "";

            if (id.Equals(prestamoID, StringComparison.OrdinalIgnoreCase))
            {
                prestamoID = "";
                libroDisponible = true; // Simula que el libro ahora está disponible
                fechaPrestamo = "";
                fechaLimite = "";
                fechaDevolucion = "";
                estado = "";
                usuarioTienePrestamo = false; // Simula que el usuario ya no tiene un préstamo activo
                Console.WriteLine("Préstamo eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine($"No se encontró un préstamo con el ID '{id}'.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        //--- Menú de Búsquedas y Reportes ---//
        static void ShowSearchReportsMenu()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Menú de Búsquedas y Reportes\nSeleccione una opción:\n1. Buscar libro\n2. Buscar usuario\n3. menu de reportes\n5. Volver al menú principal");
            Console.WriteLine("================================");
            string searchOption = Console.ReadLine() ?? "0";
            switch (searchOption)
            {
                case "1":
                    SearchBook();
                    break;
                case "2":
                    SearchUser();
                    break;
                case "3":
                    ReportsMenu();
                    break;
                case "4":
                    ShowMainMenu();
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }
}