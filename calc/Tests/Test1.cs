using calc;
using Microsoft.CodeCoverage.Core.Reports.Cobertura;
using NUnit.Framework;

namespace Tests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void AddWithFloatingPointAndRounding()
        {
            List<double> numbers = new List<double> { 0.1, 0.2, 0.3 };
            double result = Calculate.Add(numbers);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0.6, result, 2);
        }

        [TestMethod]
        public void SubtractWithNegativeResult()
        {
            List<double> numbers = new List<double> { 5,10};
            double result = Calculate.Subtract(numbers);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(-5, result, 2);
        }

        [TestMethod]
        public void DivideByZero()
        {
            List<double> numbers = new List<double> { 5, 0 };
            double result = Calculate.Divide(numbers);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(double.NaN, result);
        }

        [TestMethod]
        public void PowerWithNegativeNumber()
        {
            List<double> numbers = new List<double> { 2, -2 };
            double result = Calculate.Power(numbers);
            NUnit.Framework.Assert.That(result, Is.InRange(0.24, 0.26));
                
        }

        
    }
}
