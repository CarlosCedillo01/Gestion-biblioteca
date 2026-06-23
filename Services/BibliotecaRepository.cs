using System.Text.Json;
using GestionBiblioteca.Models;

namespace GestionBiblioteca.Services;

public sealed class BibliotecaRepository : IBibliotecaRepository
{
    private static readonly JsonSerializerOptions OpcionesJson = new()
    {
        WriteIndented = true
    };

    private readonly string _rutaArchivo;

    public BibliotecaRepository()
    {
        string carpetaDatos = Path.Combine(AppContext.BaseDirectory, "Datos");
        Directory.CreateDirectory(carpetaDatos);
        _rutaArchivo = Path.Combine(carpetaDatos, "biblioteca.json");
    }

    public List<RecursoRegistro> Cargar()
    {
        if (!File.Exists(_rutaArchivo))
        {
            return [];
        }

        string contenido = File.ReadAllText(_rutaArchivo);
        if (string.IsNullOrWhiteSpace(contenido))
        {
            return [];
        }

        return JsonSerializer.Deserialize<List<RecursoRegistro>>(contenido, OpcionesJson) ?? [];
    }

    public void Guardar(IEnumerable<RecursoRegistro> registros)
    {
        string contenido = JsonSerializer.Serialize(registros, OpcionesJson);
        File.WriteAllText(_rutaArchivo, contenido);
    }
}
