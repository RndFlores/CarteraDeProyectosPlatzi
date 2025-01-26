using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringManipulation.Tests
{
    public class StringOperationsTest
    {
        [Fact]
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
            var strOprations= new StringOperations();
            var result = strOprations.GetStringLength("Hola");

            Assert.Equal(4, result);
        }

        [Fact]
        public void RemoveWhitespace()
        {
            var strOperations = new StringOperations();
            var result =strOperations.RemoveWhitespace("Hello World!!");
        
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

            Assert.NotNull (result);
            Assert.NotEmpty(result);
            Assert.StartsWith("siete", result);//empieze con un texto en particular
            Assert.EndsWith("cars", result);
            Assert.Contains("car", result);//que contenga la palabra car
            Assert.Equal("siete cars", result);
        }
    }
}
