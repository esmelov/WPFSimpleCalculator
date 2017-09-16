using Calculator.Core.Interfaces;
using System;

namespace Calculator.Core.Concrete.Calculation
{
    internal class Addition : ICalculation
    {
        public Decimal Calculate(Decimal a, Decimal b)
        {
            return a + b;
        }
    }
}
