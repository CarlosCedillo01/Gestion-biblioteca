using GestionBiblioteca.Models;

namespace GestionBiblioteca.Services;

public interface IBibliotecaRepository
{
    List<RecursoRegistro> Cargar();

    void Guardar(IEnumerable<RecursoRegistro> registros);
}
