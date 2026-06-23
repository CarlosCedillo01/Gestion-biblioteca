# GestionBiblioteca

Aplicacion de consola en C# para administrar recursos de una biblioteca.

## Incluye

- Herencia con `RecursoBiblioteca`, `Libro` y `Revista`
- Encapsulamiento mediante atributos privados y propiedades
- Interfaz de repositorio para persistencia
- CRUD completo: agregar, listar, actualizar, eliminar y buscar
- Guardado en archivo JSON
- Manejo de excepciones con bloques diferenciados

## Como ejecutar

1. Abrir la carpeta en tu editor de codigo.
2. Ejecutar:

```bash
dotnet run
```

## Datos

Los registros se guardan en `bin/Debug/net10.0/Datos/biblioteca.json` cuando se ejecuta la app.
