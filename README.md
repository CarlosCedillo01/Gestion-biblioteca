# GestionBiblioteca

Aplicación de consola desarrollada en C# para administrar recursos de una biblioteca mediante un menú interactivo.  
El proyecto cumple con los requisitos de programación orientada a objetos, herencia, encapsulamiento, interfaz, CRUD y persistencia de datos.

## Objetivo del proyecto

Desarrollar una aplicación que permita registrar, consultar, actualizar y eliminar recursos de biblioteca, aplicando:

- Estructuras de datos
- Lógica de control
- Herencia
- Encapsulamiento
- Interfaz
- Persistencia en archivo JSON
- Manejo de excepciones

## Funcionalidades principales

El sistema permite:

- Agregar recursos nuevos
- Listar todos los recursos registrados
- Buscar un recurso por ID
- Actualizar recursos existentes
- Eliminar recursos
- Guardar automáticamente la información en un archivo JSON

## Tipo de recursos manejados

El programa trabaja con dos tipos de recursos:

- `Libro`
- `Revista`

Ambos heredan de una clase base común, lo que permite reutilizar propiedades y comportamiento compartido.

## Estructura de programación orientada a objetos

### Clase base
`RecursoBiblioteca`

Contiene los datos comunes de cualquier recurso:

- `Id`
- `Titulo`
- `AnioPublicacion`

También define un método abstracto para obtener la descripción del recurso.

### Clases heredadas

#### `Libro`
Representa un libro y agrega información específica como:

- `Autor`
- `Editorial`
- `Paginas`

#### `Revista`
Representa una revista y agrega información específica como:

- `NumeroEdicion`
- `Frecuencia`

### Interfaz
`IBibliotecaRepository`

Define las operaciones que debe cumplir el repositorio encargado de guardar y cargar la información.

Esto ayuda a separar la lógica del negocio de la lógica de persistencia.

## Persistencia de datos

El proyecto guarda la información en un archivo JSON para que los datos no se pierdan al cerrar el programa.

### Archivo generado
La información se almacena automáticamente en:

- `bin/Debug/net10.0/Datos/biblioteca.json`

Cada vez que se agrega, actualiza o elimina un recurso, el archivo se actualiza.

## Manejo de excepciones

El programa incluye manejo de errores para evitar que se cierre de forma inesperada.

Se controlan, entre otros, estos casos:

- Entrada de texto donde se espera un número
- Campos vacíos
- Valores fuera de rango
- Operaciones no válidas
- Errores de lectura o escritura de archivos

Esto hace que el programa sea más estable y fácil de usar.

## Menú principal

Al ejecutar la aplicación, se muestra un menú con estas opciones:

1. Agregar recurso
2. Listar recursos
3. Actualizar recurso
4. Eliminar recurso
5. Buscar recurso por ID
6. Salir

## Validaciones del sistema

El programa valida que:

- El título no esté vacío
- El año de publicación sea válido
- Los campos obligatorios tengan contenido
- Los valores numéricos sean correctos
- El ID exista antes de actualizar o eliminar

## Estructura del proyecto

- `Program.cs`: punto de entrada de la aplicación
- `Models/`: contiene las clases del modelo
- `Services/`: contiene la lógica de negocio y persistencia
- `Utilities/`: contiene funciones auxiliares para lectura de datos

## Requisitos para ejecutar

- Tener instalado .NET 10
- Abrir el proyecto en un editor compatible con C#
- Ejecutar el programa desde la terminal o desde el archivo de inicio si está incluido

## Cómo ejecutar

Desde la carpeta del proyecto, usa:

```bash
dotnet run