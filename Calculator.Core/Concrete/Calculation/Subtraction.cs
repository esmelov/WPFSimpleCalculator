using Calculator.Core.Interfaces;
using System;

namespace Calculator.Core.Concrete.Calculation
{
    internal class Subtraction : ICalculation
    {
        public Decimal Calculate(Decimal a, Decimal b)
        {
            return a - b;
        }
    }
}
