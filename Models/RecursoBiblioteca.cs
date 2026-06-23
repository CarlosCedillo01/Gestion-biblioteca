namespace GestionBiblioteca.Models;

public abstract class RecursoBiblioteca
{
    private string _titulo = string.Empty;
    private int _anioPublicacion;

    protected RecursoBiblioteca(int id, string titulo, int anioPublicacion)
    {
        Id = id;
        Titulo = titulo;
        AnioPublicacion = anioPublicacion;
    }

    public int Id { get; private set; }

    public string Titulo
    {
        get => _titulo;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El titulo no puede estar vacio.");
            }

            _titulo = value.Trim();
        }
    }

    public int AnioPublicacion
    {
        get => _anioPublicacion;
        set
        {
            if (value < 1400 || value > DateTime.Now.Year + 1)
            {
                throw new ArgumentException("El año de publicacion no es valido.");
            }

            _anioPublicacion = value;
        }
    }

    public abstract TipoRecurso Tipo { get; }

    public abstract string ObtenerDescripcion();

    public void ActualizarBase(string titulo, int anioPublicacion)
    {
        Titulo = titulo;
        AnioPublicacion = anioPublicacion;
    }
}
