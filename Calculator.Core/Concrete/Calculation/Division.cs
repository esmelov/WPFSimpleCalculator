using Calculator.Core.Interfaces;

namespace Calculator.Core.Concrete.Calculation
{
    internal class Division : ICalculation
    {
        public decimal Calculate(decimal a, decimal b)
        {
            return a / b;
        }
    }
}
