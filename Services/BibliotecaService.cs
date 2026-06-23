using GestionBiblioteca.Models;
using GestionBiblioteca.Utilities;

namespace GestionBiblioteca.Services;

public sealed class BibliotecaService
{
    private readonly IBibliotecaRepository _repositorio;
    private readonly List<RecursoBiblioteca> _recursos = [];

    public BibliotecaService(IBibliotecaRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public void CargarDatos()
    {
        _recursos.Clear();

        foreach (RecursoRegistro registro in _repositorio.Cargar())
        {
            _recursos.Add(ConvertirAEntidad(registro));
        }
    }

    public void AgregarRecurso()
    {
        Console.WriteLine("Tipo de recurso");
        Console.WriteLine("1. Libro");
        Console.WriteLine("2. Revista");
        Console.WriteLine();

        int tipo = InputHelper.LeerEntero("Elige el tipo: ", 1, 2);
        int id = GenerarId();
        string titulo = InputHelper.LeerTexto("Titulo: ");
        int anio = InputHelper.LeerEntero("Año de publicacion: ", 1400, DateTime.Now.Year + 1);

        if (tipo == (int)TipoRecurso.Libro)
        {
            string autor = InputHelper.LeerTexto("Autor: ");
            string editorial = InputHelper.LeerTexto("Editorial: ");
            int paginas = InputHelper.LeerEntero("Numero de paginas: ", 1, 5000);

            _recursos.Add(new Libro(id, titulo, anio, autor, editorial, paginas));
            GuardarCambios();
            Console.WriteLine();
            Console.WriteLine("Libro agregado correctamente.");
            return;
        }

        int numeroEdicion = InputHelper.LeerEntero("Numero de edicion: ", 1, 10000);
        string frecuencia = InputHelper.LeerTexto("Frecuencia (semanal, mensual, etc.): ");

        _recursos.Add(new Revista(id, titulo, anio, numeroEdicion, frecuencia));
        GuardarCambios();
        Console.WriteLine();
        Console.WriteLine("Revista agregada correctamente.");
    }

    public void MostrarRecursos()
    {
        Console.WriteLine("Listado de recursos");
        Console.WriteLine("-------------------");

        if (_recursos.Count == 0)
        {
            Console.WriteLine("No hay recursos registrados.");
            return;
        }

        foreach (RecursoBiblioteca recurso in _recursos.OrderBy(r => r.Id))
        {
            Console.WriteLine(recurso.ObtenerDescripcion());
        }
    }

    public void BuscarRecursoPorId()
    {
        if (_recursos.Count == 0)
        {
            Console.WriteLine("No hay recursos registrados.");
            return;
        }

        int id = InputHelper.LeerEntero("Ingresa el ID a buscar: ", 1, int.MaxValue);
        RecursoBiblioteca? recurso = _recursos.FirstOrDefault(r => r.Id == id);

        if (recurso is null)
        {
            Console.WriteLine("No se encontro un recurso con ese ID.");
            return;
        }

        Console.WriteLine(recurso.ObtenerDescripcion());
    }

    public void ActualizarRecurso()
    {
        if (_recursos.Count == 0)
        {
            Console.WriteLine("No hay recursos para actualizar.");
            return;
        }

        int id = InputHelper.LeerEntero("Ingresa el ID a actualizar: ", 1, int.MaxValue);
        RecursoBiblioteca? recurso = _recursos.FirstOrDefault(r => r.Id == id);

        if (recurso is null)
        {
            Console.WriteLine("No se encontro el recurso.");
            return;
        }

        string titulo = InputHelper.LeerTexto("Nuevo titulo: ");
        int anio = InputHelper.LeerEntero("Nuevo anio de publicacion: ", 1400, DateTime.Now.Year + 1);

        if (recurso is Libro libro)
        {
            string autor = InputHelper.LeerTexto("Nuevo autor: ");
            string editorial = InputHelper.LeerTexto("Nueva editorial: ");
            int paginas = InputHelper.LeerEntero("Nuevas paginas: ", 1, 5000);

            libro.ActualizarLibro(titulo, anio, autor, editorial, paginas);
        }
        else if (recurso is Revista revista)
        {
            int numeroEdicion = InputHelper.LeerEntero("Nueva edicion: ", 1, 10000);
            string frecuencia = InputHelper.LeerTexto("Nueva frecuencia: ");

            revista.ActualizarRevista(titulo, anio, numeroEdicion, frecuencia);
        }
        else
        {
            throw new InvalidOperationException("Tipo de recurso no soportado.");
        }

        GuardarCambios();
        Console.WriteLine("Recurso actualizado correctamente.");
    }

    public void EliminarRecurso()
    {
        if (_recursos.Count == 0)
        {
            Console.WriteLine("No hay recursos para eliminar.");
            return;
        }

        int id = InputHelper.LeerEntero("Ingresa el ID a eliminar: ", 1, int.MaxValue);
        RecursoBiblioteca? recurso = _recursos.FirstOrDefault(r => r.Id == id);

        if (recurso is null)
        {
            Console.WriteLine("No se encontro el recurso.");
            return;
        }

        _recursos.Remove(recurso);
        GuardarCambios();
        Console.WriteLine("Recurso eliminado correctamente.");
    }

    private int GenerarId()
    {
        return _recursos.Count == 0 ? 1 : _recursos.Max(r => r.Id) + 1;
    }

    private void GuardarCambios()
    {
        List<RecursoRegistro> registros = _recursos.Select(ConvertirARegistro).ToList();
        _repositorio.Guardar(registros);
    }

    private static RecursoBiblioteca ConvertirAEntidad(RecursoRegistro registro)
    {
        return registro.Tipo switch
        {
            TipoRecurso.Libro => new Libro(
                registro.Id,
                registro.Titulo,
                registro.AnioPublicacion,
                registro.Autor ?? string.Empty,
                registro.Editorial ?? string.Empty,
                registro.Paginas ?? 0),
            TipoRecurso.Revista => new Revista(
                registro.Id,
                registro.Titulo,
                registro.AnioPublicacion,
                registro.NumeroEdicion ?? 1,
                registro.Frecuencia ?? string.Empty),
            _ => throw new InvalidOperationException("El tipo de recurso guardado no es valido.")
        };
    }

    private static RecursoRegistro ConvertirARegistro(RecursoBiblioteca recurso)
    {
        return recurso switch
        {
            Libro libro => new RecursoRegistro
            {
                Id = libro.Id,
                Tipo = libro.Tipo,
                Titulo = libro.Titulo,
                AnioPublicacion = libro.AnioPublicacion,
                Autor = libro.Autor,
                Editorial = libro.Editorial,
                Paginas = libro.Paginas
            },
            Revista revista => new RecursoRegistro
            {
                Id = revista.Id,
                Tipo = revista.Tipo,
                Titulo = revista.Titulo,
                AnioPublicacion = revista.AnioPublicacion,
                NumeroEdicion = revista.NumeroEdicion,
                Frecuencia = revista.Frecuencia
            },
            _ => throw new InvalidOperationException("No se puede guardar este tipo de recurso.")
        };
    }
}
