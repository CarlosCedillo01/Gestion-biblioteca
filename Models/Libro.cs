namespace GestionBiblioteca.Models;

public sealed class Libro : RecursoBiblioteca
{
    private string _autor = string.Empty;
    private string _editorial = string.Empty;

    public Libro(int id, string titulo, int anioPublicacion, string autor, string editorial, int paginas)
        : base(id, titulo, anioPublicacion)
    {
        Autor = autor;
        Editorial = editorial;
        Paginas = paginas;
    }

    public string Autor
    {
        get => _autor;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El autor no puede estar vacio.");
            }

            _autor = value.Trim();
        }
    }

    public string Editorial
    {
        get => _editorial;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("La editorial no puede estar vacia.");
            }

            _editorial = value.Trim();
        }
    }

    public int Paginas { get; set; }

    public override TipoRecurso Tipo => TipoRecurso.Libro;

    public override string ObtenerDescripcion()
    {
        return $"Libro | Id: {Id} | Titulo: {Titulo} | Autor: {Autor} | Editorial: {Editorial} | Año: {AnioPublicacion} | Paginas: {Paginas}";
    }

    public void ActualizarLibro(string titulo, int anioPublicacion, string autor, string editorial, int paginas)
    {
        ActualizarBase(titulo, anioPublicacion);
        Autor = autor;
        Editorial = editorial;
        Paginas = paginas;
    }
}
