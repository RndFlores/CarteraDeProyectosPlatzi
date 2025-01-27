using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
namespace StringManipulation.Tests
{
    public class StringOperationsTest
    {
        [Fact(Skip = "Esta prueba no es valida en este momento, TICKET-001")]
        public void ConcatenateStrings()
        {
            //arrange
            var strOperations = new StringOperations();
            //act
            var result = strOperations.ConcatenateStrings("hello", "world");
            //assert
            Assert.NotNull(result);//verificar que no sea nulo.
            Assert.NotEmpty(result);//verificar que no sea vacío.
            Assert.Equal("hello world", result);//verificar si los resultados son iguales
        }

        [Fact]
        public void GetStringLength_Exception()
        {
            var strOperations = new StringOperations();
            Assert.ThrowsAny<ArgumentNullException>(
                () => //asignamos a un delegado
                strOperations.GetStringLength(null));
        }
        [Fact]
        public void GetStringLength() {
            var strOprations = new StringOperations();
            var result = strOprations.GetStringLength("Hola");

            Assert.Equal(4, result);
        }

        [Fact]
        public void RemoveWhitespace()
        {
            var strOperations = new StringOperations();
            var result = strOperations.RemoveWhitespace("Hello World!!");

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("HelloWorld!!", result);
        }


        [Fact]
        public void IsPalindrome_True()
        {
            var strOperations = new StringOperations();

            var result = strOperations.IsPalindrome("ala");

            Assert.True(result);
        }
        [Fact]
        public void IsPalindrome_False()
        {
            var strOperations = new StringOperations();

            var result = strOperations.IsPalindrome("hola");

            Assert.False(result);
        }

        [Fact]
        public void QuantintyInWords()
        {
            var strOperations = new StringOperations();
            var result = strOperations.QuantintyInWords("car", 7);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.StartsWith("siete", result);//empieze con un texto en particular
            Assert.EndsWith("cars", result);
            Assert.Contains("car", result);//que contenga la palabra car
            Assert.Equal("siete cars", result);
        }

        [Theory]
        [InlineData("v", 5)]//podremos hacer multiple comprobaciones
        [InlineData("x", 10)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {
            var strOperations = new StringOperations();
            var result = strOperations.FromRomanToNumber(romanNumber);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountOccurrences()
        {
            //var strOperations = new StringOperations();
            ////esta prueba usa logger y es dependeiente pero como no lo pasamos salta error
            //var result = strOperations.CountOccurrences("Hello Platzi Team", 'l');
            //Assert.Equal(2, result);


            /*
            ======== SOLUCION ========
            */
            var mockLogger = new Mock<ILogger<StringOperations>>();//simulamos este tipo
            var strOperations = new StringOperations(mockLogger.Object);

            var result = strOperations.CountOccurrences("Hello Platzi Team", 'l');
            Assert.Equal(3, result);
        }

        [Fact]
        public void ReadFile()
        {
            var strOperations = new StringOperations();
            var MoqReadFile= new Mock<IFileReaderConector>();
            //para simular que está leyendo un txt
            //MoqReadFile.Setup(p => p.ReadString("file.txt")).Returns("Reading file");

            //SI QUEREMOS QUE CUALQUIER NOMBRE DE ARCHIVO RETORNE LO QUE QUEREMOS
            MoqReadFile.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading file");

            //el nombre del archivo no importa
            var result = strOperations.ReadFile(MoqReadFile.Object, "file.txt");
            //ahora no importa que nombre le pondremos a file.txt que ahora retorna siempre lo de arriba.
            Assert.Equal("Reading file", result);
        }
    }
}
