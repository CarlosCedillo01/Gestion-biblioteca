namespace GestionBiblioteca.Models;

public sealed class RecursoRegistro
{
    public int Id { get; set; }

    public TipoRecurso Tipo { get; set; }

    public string Titulo { get; set; } = string.Empty;

    public int AnioPublicacion { get; set; }

    public string? Autor { get; set; }

    public string? Editorial { get; set; }

    public int? Paginas { get; set; }

    public int? NumeroEdicion { get; set; }

    public string? Frecuencia { get; set; }
}
