using Calculator.Core.Concrete.Calculation;
using Calculator.Core.Enum;
using Calculator.Core.Interfaces;
using System;

namespace Calculator.Core.Factory
{
    internal static class CalculationFactory
    {
        public static ICalculation Create(Operations OperationType)
        {
            switch (OperationType)
            {
                case Operations.Adition:
                    return new Addition();
                case Operations.Subtraction:
                    return new Subtraction();
                case Operations.Division:
                    return new Division();
                case Operations.Multiplication:
                    return new Multiplication();
                default:
                    throw new NotSupportedException("Данное действие не поддерживается!");
            }
        }
    }
}
