using CalcLib;

namespace CalcLibTest
{
    public class CalcTest
    {
        [Fact]
        public void UnitTest_A()
        {
            Assert.Equal(9, Calc.Compute("(4+5)"));
        }

        [Theory]
        [InlineData("(45+5*2)", 55)]
        [InlineData("(45+5*2/2)", 50)]
        [InlineData("(10*(34+2))", 360)]
        [InlineData("(10+(34+2))+(5*2)-1", 55)]
        public void UnitTest_B(string rawMathExpression, double expectedValue)
        {
            Assert.Equal(expectedValue, Calc.Compute(rawMathExpression));
        }

        [Theory]
        [InlineData("(45 + 5  *2)", 55)]
        [InlineData("(45+5*2  /2)", 50)]
        public void UnitTest_C(string rawMathExpression, double expectedValue)
        {
            Assert.Equal(expectedValue, Calc.Compute(rawMathExpression));
        }

        [Theory]
        [InlineData("(45+5*2")]
        [InlineData("(45+5*i2")]
        [InlineData("(45+-5*2")]
        [InlineData("(45+ (66-8")]
        [InlineData("")]
        public void UnitTest_D(string rawMathExpression)
        {
            Assert.Throws<ArgumentException>(() => Calc.Compute(rawMathExpression));
        }

        [Theory]
        [InlineData(null)]
        public void UnitTest_E(string rawMathExpression)
        {
            Assert.Throws<NullReferenceException>(() => Calc.Compute(rawMathExpression));
        }
    }
}