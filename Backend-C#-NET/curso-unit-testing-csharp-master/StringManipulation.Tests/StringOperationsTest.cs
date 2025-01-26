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
    }
}
