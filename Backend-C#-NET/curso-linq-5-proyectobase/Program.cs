using curso_linq;

//LINK OFICIAL DE LINQ MICROSOFT
//https://learn.microsoft.com/es-mx/dotnet/csharp/linq/
LinqQueries queries = new LinqQueries();

void ImprimirValores(IEnumerable<Book> listaDeLibros)
{
    Console.WriteLine("{0,-65} {1,9} {2,11}\n", "Titulo","N.Paginas","F. Publicacion");
    foreach(var item in listaDeLibros)
    {
        Console.WriteLine("{0,-65} {1,9} {2,11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirPorGrupos(IEnumerable<IGrouping<int, Book>>listaBooksAgrupados)
{
    foreach(var grupo in listaBooksAgrupados)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
        }
    }
}
void printDictionary(ILookup<char, Book> listBooks, char letter)
{
    char letterUpper = Char.ToUpper(letter);
    if (listBooks[letterUpper].Count() == 0)
    {
        Console.WriteLine($"No hay libros que inicien con la letra '{letterUpper}'");
    }
    else
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Título", "Nro. Páginas", "Fecha de Publicación");
        foreach (var book in listBooks[letterUpper])
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
        }
    }
}

//IMPRIMIR TODA LA COLLECCION
//ImprimirValores(queries.TodaLaColleccion());

//Imprimir libros despues del 2000
//ImprimirValores(queries.LibrosDespues2000());

//Imprimir libros con más de 250 páginas y que titulo contenga "In Action"
//ImprimirValores(queries.LibrosMas250PaginasTituloInAction());

//todos los libros tienen estatus
//Console.WriteLine($"Todos los libros tienen estatuso? - {queries.TodosLosLibrosTienenStatus()}");

//Si algún libro fue publicado en 2005
//Console.WriteLine($"Algún libro fue publicado en 2005? - {queries.AlgunLibroPublicadoEn2005()}");

//todos los libros que tengan python
//ImprimirValores(queries.LibrosDePython());

//libros de java ordenados por nombre
//ImprimirValores(queries.LibrosDeJavaOrdenadosPorNombreAscendente());

//los tres primeros libros de java publicados recientemente
//ImprimirValores(queries.TresPrimerosLibrosJavaOrdenadosPorFecha());

//tercer y cuarto libro con más de 400 paginas
//ImprimirValores(queries.TercerYCuartoLibroConMasDe400Paginas());

//tres primeros libros filtrados con select 
//ImprimirValores(queries.TresPrimerosLibrosDeLaCollecionFiltradosPorSelect());

//Imprimir la cantidad de libros que tengan entre 200 y 500 paginas
//Console.WriteLine($"Cantidad de libros que tengan entre 200 y 500 paginas: {queries.CantidadDeLibrosEntre200y500Paginas()}");

//Imprimir el libro más viejo
//Console.WriteLine($"El libro más viejo de la coleccion es del año : {queries.LibroMasViejo()}");

//Imprimir la mayor cantidad de páginas
//Console.WriteLine($"El mayor numero de paginas es : {queries.NumeroPaginasMayorDeLibros()}");

//Imprimir libros con menor numero de páginas usando MinBy
//var LibroMenorPag = queries.LibroConMenorNumeorDePaginasMinBy();
//Console.WriteLine($"{LibroMenorPag.Title} - {LibroMenorPag.PageCount}");

//Libros con la fecha más reciente
//var LibroMasReciente = queries.LibroConFechaMasReciente();
//Console.WriteLine($"{LibroMasReciente.Title} - {LibroMasReciente.PublishedDate}");

//Suma de paginas de libro entre 0 y 500
//Console.WriteLine($"Suma total de páginas entre 0 y 500: {queries.SumaDeTodasLasPaginasLibrosEntre0Y500()}");

//TitulosDeLibrosDespuesDel2015Concatenados
//Console.WriteLine(queries.TitulosDeLibrosDespuesDel2015Concatenados());

//Promedio de caracteres del titulo de los libros
//Console.WriteLine($"Promedio de caracteres del titulo de los libros: {queries.PromedidoCaracteresTitulo()}");


//Imprimir Libros en grupo despues del 2000 agrupados por año
//ImprimirPorGrupos(queries.LibrosDespuesDel2000GroupByAño());

//Imprimir Diccionario de libros agrupados por primera letra del titulo
//printDictionary(queries.DiccionarioDeLibrosPorLetra(),'S');


//LIBROS FILTRADOS CON LA CLAUSULA JOIN

ImprimirValores(queries.LibrosDespuesDel2005ConMasDe500Paginas());