## Objetivo:

- Crear una simulación de registros de una escuela

## Pasos:

1. Hago uso del **namespaces CoreEscuela** para poder organizar y hacer una separacion entre las clases y otros tipos.
2. Creación de los enum **TiposEscuela** y **TIposJornada**.
3. Creando la clase **Alumno**, **Asignatura** con los atributos _UniqueID y Nombre_ cada uno.
4. Creando la clase **Evaluaciones** con los atributos _UniqueId, Nombre, Alumno, Asignatura y Nota_.
5. Creando clase **Curso** con atributos _Nombre, UniqueId, TiposJornada, List<Asignatura> Asignaturas, List<Alumno> Alumnos y List<Evaluaciones> Evaluaciones_
6. Creando clase **Escuela** con atributos _Nombre, UniqueId, AnhioCreacion, Pais, Ciudad, TiposEscuela y List<Curso> Cursos_
7. Creando la Clase **EscuelaEngine** con atributo _Escuela_ y metodo **_Inicializar(),CargarCursos()_**

## Correr:
En la carpeta raíz
dotnet run
solo consola.
