using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace curso_linq
{
    public class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();
        public LinqQueries() {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json,//Deserializar el json
                    new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });//darle el formato adecuado para CamelCase
            }
        }

        //Traer toda la collecion
        public IEnumerable<Book> TodaLaColleccion()
        {
            return librosCollection;
        }

        public IEnumerable<Book> LibrosDespues2000()
        {
            //extension method
            //return librosCollection.Where(p=>p.PublishedDate.Year>=2000);

            //query expresion
            return from l in librosCollection where l.PublishedDate.Year >= 2000 orderby l.PublishedDate select l;
        }

        public IEnumerable<Book> LibrosMas250PaginasTituloInAction()
        {
            //extension method
            //return librosCollection.Where(p => p.PageCount >= 250 && p.Title.Contains("in Action"));

            //query expresion
            return from l in librosCollection where l.PageCount >= 250 && l.Title.Contains("in Action") orderby l.PublishedDate select l;
        }

        public bool TodosLosLibrosTienenStatus()
        {
            return librosCollection.All(p => p.Status != string.Empty);
        }
        public bool AlgunLibroPublicadoEn2005()
        {
            return librosCollection.Any(p => p.PublishedDate.Year == 2005);
        }

        public IEnumerable<Book> LibrosDePython()
        {
            //extension method
            //return librosCollection.Where(p => p.Categories.Contains("Python")).OrderBy(p=>p.PublishedDate);

            //query expresion
            return from l in librosCollection where l.Categories.Contains("Python") orderby l.PublishedDate select l;
        }

        public IEnumerable<Book> LibrosDeJavaOrdenadosPorNombreAscendente()
        {
            //extension method
            //return librosCollection.Where(p=>p.Categories.Contains("Java")).OrderBy(p=>p.Title);

            //query expresion
            return from l in librosCollection where l.Categories.Contains("Java") orderby l.Title select l;
        }

        public IEnumerable<Book> TresPrimerosLibrosJavaOrdenadosPorFecha()
        {
            //extension method
            return librosCollection.Where(p => p.Categories.Contains("Java")).OrderByDescending(p => p.PublishedDate).Take(3);
        }

        public IEnumerable<Book> TercerYCuartoLibroConMasDe400Paginas()
        {
            //return librosCollection.Where(p => p.PageCount >= 400)
            //    .Take(4)//tome los primeros 4
            //    .Skip(2); // omita los primeros 2

            return (from l in librosCollection where l.PageCount >= 400 select l).Take(4).Skip(2);
        }

        public IEnumerable<Book> TresPrimerosLibrosDeLaCollecionFiltradosPorSelect()
        {
            return librosCollection.Take(3).Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
        }
        public int CantidadDeLibrosEntre200y500Paginas()
        {
            //return librosCollection.Where(p => p.PageCount >= 200 && p.PageCount <= 500).Count();
            //return librosCollection.Count(p => p.PageCount >= 200 && p.PageCount <= 500);
            return (from l in librosCollection where l.PageCount >= 200 && l.PageCount <= 500 select l).Count();
        }
        public DateTime LibroMasViejo()
        {
            return librosCollection.Min(p => p.PublishedDate);
        }
        public int NumeroPaginasMayorDeLibros()
        {
            return librosCollection.Max(p => p.PageCount);
        }

        public Book LibroConMenorNumeorDePaginasMinBy()
        {
            //expresion method
            //return librosCollection.Where(p=>p.PageCount>0).MinBy(p=>p.PageCount);

            //query expresion
            return (from l in librosCollection where l.PageCount > 0 select l).MinBy(l => l.PageCount);
        }

        public Book LibroConFechaMasReciente()
        {
            return librosCollection.MaxBy(l => l.PublishedDate);
        }

        public int SumaDeTodasLasPaginasLibrosEntre0Y500()
        {
            //return librosCollection.Where(l=> l.PageCount>=0 && l.PageCount<= 500).Sum(l=>l.PageCount);

            return (from l in librosCollection where l.PageCount >= 0 && l.PageCount <= 500 select l).Sum(l => l.PageCount);
        }

        public string TitulosDeLibrosDespuesDel2015Concatenados()
        {
            return librosCollection.Where(l => l.PublishedDate.Year > 2015)
                .Aggregate("", (TitulosLibros, next) => // string TitulosLibros = "";
                {
                    if (TitulosLibros != string.Empty) {
                        TitulosLibros += " - " + next.Title;
                    }
                    else
                    {
                        TitulosLibros += next.Title;
                    }
                    return TitulosLibros;
                });
        }

        public double PromedidoCaracteresTitulo()
        {
            return librosCollection.Average(l => l.Title.Length);
        }

        public IEnumerable<IGrouping<int,Book>> LibrosDespuesDel2000GroupByAño()
        {
            return librosCollection.Where(l => l.PublishedDate.Year > 2000).GroupBy(l => l.PublishedDate.Year);

        }
        public ILookup<char , Book > DiccionarioDeLibrosPorLetra()
        {
            return librosCollection.ToLookup(l => l.Title[0] // obtener la primera letra de los titlos
            , l=>l);//obtener toda la informaicon del libro
        }

        public IEnumerable<Book> LibrosDespuesDel2005ConMasDe500Paginas()
        {
            var librosDespuesDel2005 = librosCollection.Where(l => l.PublishedDate.Year > 2005);
            var librosConMasDe500Paginas = librosCollection.Where(l => l.PageCount > 500);

            return librosDespuesDel2005.Join(librosConMasDe500Paginas
                ,l=>l.Title //ID del conjunto 1
                ,l2=>l2.Title //ID del conjunto 2
                ,(l,l2)=>l); //como ambas colecciones son iguales da igual que retornamos
            //en este caso retornamos los datos de la primera coleccion
        }
    }
}
