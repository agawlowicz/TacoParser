using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.035985,-84.683302,Taco Bell Acworth...", -84.683302)]
        [InlineData("34.087508,-84.575512,Taco Bell Acworth...", -84.575512)]
        [InlineData("34.376395,-84.913185,Taco Bell Adairsvill...", -84.913185)]
        [InlineData("33.22997,-86.805275,Taco Bell Alabaste...", -86.805275)]
        [InlineData("31.570771,-84.10353,Taco Bell Albany...", -84.10353)]
        public void ShouldParseLongitude(string line, double expected)
        {
            //Arrange
            var challenger = new TacoParser();

            //Act
            var actual = challenger.Parse(line).Location.Longitude;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.035985,-84.683302,Taco Bell Acworth...", 34.035985)]
        [InlineData("34.087508,-84.575512,Taco Bell Acworth...", 34.087508)]
        [InlineData("34.376395,-84.913185,Taco Bell Adairsvill...", 34.376395)]
        [InlineData("33.22997,-86.805275,Taco Bell Alabaste...", 33.22997)]
        [InlineData("31.570771,-84.10353,Taco Bell Albany...", 31.570771)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var challenger = new TacoParser();

            //Act
            var actual = challenger.Parse(line).Location.Latitude;

            //Assert
            Assert.Equal(expected, actual);

        }

    }
}
