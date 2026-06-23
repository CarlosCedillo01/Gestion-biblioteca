namespace GestionBiblioteca.Utilities;

public static class InputHelper
{
    public static string LeerTexto(string mensaje)
    {
        Console.Write(mensaje);
        string? valor = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(valor))
        {
            throw new ArgumentException("El valor no puede estar vacio.");
        }

        return valor.Trim();
    }

    public static int LeerEntero(string mensaje, int minimo, int maximo)
    {
        Console.Write(mensaje);
        string? entrada = Console.ReadLine();

        if (!int.TryParse(entrada, out int valor))
        {
            throw new FormatException("Debes escribir un numero entero.");
        }

        if (valor < minimo || valor > maximo)
        {
            throw new ArgumentOutOfRangeException(nameof(valor), $"El valor debe estar entre {minimo} y {maximo}.");
        }

        return valor;
    }
}
