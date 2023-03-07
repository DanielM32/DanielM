using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace CalculatorTest
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act
            var result = calculator.Add("");

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_SingleNumber_ReturnsNumber()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act
            var result = calculator.Add("1");

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Add_TwoNumbersCommaDelimited_ReturnsSum()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act
            var result = calculator.Add("1,2");

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_TwoNumbersNewlineDelimited_ReturnsSum()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act
            var result = calculator.Add("1\n2");

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_ThreeNumbersDelimited_ReturnsSum()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act
            var result = calculator.Add("1\n2,3");

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_NegativeNumber_ThrowsArgumentException()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => calculator.Add("-1"));
        }

        [TestMethod]
        public void Add_NumberGreaterThan1000_IgnoresNumber()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act
            var result = calculator.Add("2,1001");

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Add_SingleCharDelimiterDefined_ReturnsSum()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act
            var result = calculator.Add("//;\n1;2;3");

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_MultiCharDelimiterDefined_ReturnsSum()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act
            var result = calculator.Add("//[***]\n1***2***3");

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_ManyDelimitersDefined_ReturnsSum()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act
            var result = calculator.Add("//[*][%]\n1*2%3");

            // Assert
            Assert.AreEqual(6, result);
        }
    }
}