using Moq;
using System;
using Xunit;
using xUnitStudies.APP.Calculator;

namespace xUnitStudies.Tests
{
    public class CalculatorMockTests
    {
        private Calculator _calculatorMock;
        private Mock<ICalculatorService> _calculatorServiceMock;

        public CalculatorMockTests()
        {
            _calculatorServiceMock = new Mock<ICalculatorService>();
            _calculatorMock = new Calculator(_calculatorServiceMock.Object);
        }


        [Theory]
        [InlineData(1, 2, 3)]
        public void MockExampleAddTest(int a, int b, int excepted)
        {
            _calculatorServiceMock.Setup(x => x.Add(a, b)).Returns(excepted);

            //Act
            var total = _calculatorMock.Add(a, b);

            //Assert
            Assert.Equal(excepted, total);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        public void MockExampleVerifyAddTest(int a, int b, int excepted)
        {
            _calculatorServiceMock.Setup(x => x.Add(a, b)).Returns(excepted);

            //Act
            var total = _calculatorMock.Add(a, b);

            //Assert
            Assert.Equal(excepted, total);

            _calculatorServiceMock.Verify(x => x.Add(a, b), Times.Once());
        }

        [Fact]
        public void MockExampleThrowErrorTest()
        {
            int a = 10;
            int b = 0;

            _calculatorServiceMock.Setup(x => x.Divide(a, b)).Throws(new Exception("DivideByZero"));

            Assert.Throws<Exception>(() => _calculatorMock.Divide(a, b));
        }
    }
}
