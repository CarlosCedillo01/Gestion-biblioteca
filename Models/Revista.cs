namespace GestionBiblioteca.Models;

public sealed class Revista : RecursoBiblioteca
{
    private string _frecuencia = string.Empty;

    public Revista(int id, string titulo, int anioPublicacion, int numeroEdicion, string frecuencia)
        : base(id, titulo, anioPublicacion)
    {
        NumeroEdicion = numeroEdicion;
        Frecuencia = frecuencia;
    }

    public int NumeroEdicion { get; set; }

    public string Frecuencia
    {
        get => _frecuencia;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("La frecuencia no puede estar vacia.");
            }

            _frecuencia = value.Trim();
        }
    }

    public override TipoRecurso Tipo => TipoRecurso.Revista;

    public override string ObtenerDescripcion()
    {
        return $"Revista | Id: {Id} | Titulo: {Titulo} | Edicion: {NumeroEdicion} | Frecuencia: {Frecuencia} | Año: {AnioPublicacion}";
    }

    public void ActualizarRevista(string titulo, int anioPublicacion, int numeroEdicion, string frecuencia)
    {
        ActualizarBase(titulo, anioPublicacion);
        NumeroEdicion = numeroEdicion;
        Frecuencia = frecuencia;
    }
}
