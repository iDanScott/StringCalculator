using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_1_Returns1()
        {
            StringCalculator calc = GetNewCalculator();
            int result = calc.Add("1");
            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_12_Returns3()
        {
            StringCalculator calc = GetNewCalculator();
            int result = calc.Add("1,2");
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_12Newline_Returns3()
        {
            StringCalculator calc = GetNewCalculator();
            int result = calc.Add("1\n2");
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_1To10_Returns55()
        {
            StringCalculator calc = GetNewCalculator();
            int result = calc.Add("1,2,3,4,5,6,7,8,9,10");
            Assert.Equal(55, result);
        }

        [Fact]
        public void Add_Nothing_Returns0()
        {
            StringCalculator calc = GetNewCalculator();
            int result = calc.Add("");
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_12NewDelimiter_Returns3()
        {
            StringCalculator calc = GetNewCalculator();
            int result = calc.Add("//;\n1;2");
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_Negative1Negative2_ThrowsException()
        {
            StringCalculator calc = GetNewCalculator();
            FormatException fEx = Assert.Throws<FormatException>(() => calc.Add("-1,-2"));
            Assert.Equal("negatives not allowed: -1, -2", fEx.Message);
        }

        [Fact]
        public void Add_2_1001_Returns2_1001Ignored()
        {
            StringCalculator calc = GetNewCalculator();
            int result = calc.Add("2,1001");
            Assert.Equal(2, result);
        }

        [Fact]
        public void Add_AnyLengthDelimiter_123_Returns6()
        {
            StringCalculator calc = GetNewCalculator();
            int result = calc.Add("//***\n1***2***3");
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_123_MultipleDelimiter_Returns6()
        {
            StringCalculator calc = GetNewCalculator();
            int result = calc.Add("//[*][%]\n1*2%3");
            Assert.Equal(6, result);
        }

        public StringCalculator GetNewCalculator()
        {
            StringCalculator calculator = new StringCalculator();
            calculator.Initialise();
            return calculator;
        }
    }
}
