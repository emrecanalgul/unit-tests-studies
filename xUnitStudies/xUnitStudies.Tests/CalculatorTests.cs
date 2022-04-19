using Moq;
using System;
using Xunit;
using xUnitStudies.APP;
using xUnitStudies.APP.Calculator;

namespace xUnitStudies.Tests
{
    public class CalculatorTests
    {
        private Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator(new CalculatorService());
        }

        [Fact]
        public void AddTest()
        {
            //Arrange
            int a = 5;
            int b = 6;

            //Act
            var total = _calculator.Add(a, b);

            //Assert
            Assert.Equal(11, total);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(5, 4, 9)]
        [InlineData(15, 87, 102)]
        public void AddTestParameter(int a, int b, int excepted)
        {

            //Act
            var total = _calculator.Add(a, b);

            //Assert
            Assert.Equal(excepted, total);
        }
      
    }
}