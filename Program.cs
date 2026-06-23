using GestionBiblioteca.Services;
using GestionBiblioteca.Utilities;

namespace GestionBiblioteca;

internal static class Program
{
    private static void Main()
    {
        Console.Title = "Gestion de Biblioteca";

        var repositorio = new BibliotecaRepository();
        var servicio = new BibliotecaService(repositorio);
        servicio.CargarDatos();

        bool salir = false;
        while (!salir)
        {
            LimpiarPantalla();
            MostrarEncabezado();
            MostrarMenu();

            try
            {
                int opcion = InputHelper.LeerEntero("Selecciona una opcion: ", 1, 6);
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        servicio.AgregarRecurso();
                        break;
                    case 2:
                        servicio.MostrarRecursos();
                        break;
                    case 3:
                        servicio.ActualizarRecurso();
                        break;
                    case 4:
                        servicio.EliminarRecurso();
                        break;
                    case 5:
                        servicio.BuscarRecursoPorId();
                        break;
                    case 6:
                        salir = true;
                        continue;
                }

                Console.WriteLine();
                Console.WriteLine("Presiona Enter para continuar...");
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Entrada invalida: {ex.Message}");
                Esperar();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Dato no valido: {ex.Message}");
                Esperar();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Operacion no permitida: {ex.Message}");
                Esperar();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"No se pudo leer o guardar la informacion: {ex.Message}");
                Esperar();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrio un error inesperado: {ex.Message}");
                Esperar();
            }
        }

        Console.WriteLine();
        Console.WriteLine("Gracias por usar Gestion de Biblioteca.");
    }

    private static void MostrarEncabezado()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("      SISTEMA DE GESTION BIBLIOTECA     ");
        Console.WriteLine("========================================");
        Console.WriteLine();
    }

    private static void LimpiarPantalla()
    {
        if (!Console.IsOutputRedirected && !Console.IsErrorRedirected)
        {
            Console.Clear();
        }
    }

    private static void MostrarMenu()
    {
        Console.WriteLine("1. Agregar recurso");
        Console.WriteLine("2. Listar recursos");
        Console.WriteLine("3. Actualizar recurso");
        Console.WriteLine("4. Eliminar recurso");
        Console.WriteLine("5. Buscar recurso por ID");
        Console.WriteLine("6. Salir");
        Console.WriteLine();
    }

    private static void Esperar()
    {
        Console.WriteLine();
        Console.WriteLine("Presiona Enter para continuar...");
        Console.ReadLine();
    }
}
