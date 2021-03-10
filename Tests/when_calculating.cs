using Console;
using Moq;
using Xunit;

namespace Tests
{
    public class when_calculating
    {
        private ICalculator _calculator;

        private void SetUpMocking()
        {
            var calculatorMoq = new Mock<ICalculator>();

            calculatorMoq
                .Setup(c => c.Calculate(It.IsAny<string>()))
                .Returns(0);

            _calculator = calculatorMoq.Object;
        }
        
        [Fact]
        public void it_should_calculate()
        {
            var calculator = new Calculator();
            var expression = "2+2";
            var result = calculator.Calculate(expression);
            
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("some expression", 0)]
        public void it_should_calculate_with_params(string expression, int expected)
        {
            var calculator = new Calculator();
            var actual = calculator.Calculate(expression);
            
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void mocking_should_work()
        {
            SetUpMocking();
            
            var actual = _calculator.Calculate("rand");
            
            Assert.Equal(0, actual);
        }
    }
}